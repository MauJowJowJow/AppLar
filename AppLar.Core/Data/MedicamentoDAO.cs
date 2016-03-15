using System;
using AppLar.Core.Model;
using SQLite.Net.Async;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AppLar.Core.Data
{
    class MedicamentoDAO
        : IMedicamentoDAO
    {
        private static readonly AsyncLock Mutex = new AsyncLock();
        private readonly SQLiteAsyncConnection _connection;

        public MedicamentoDAO()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            CreateDatabaseAsync();
        }

        public async Task CreateDatabaseAsync()
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                await _connection.CreateTableAsync<Medicamento>().ConfigureAwait(false);
            }
        }

        public async Task<List<Medicamento>> GetMedicamentoAsync()
        {
            List<Medicamento> medicamentos = new List<Medicamento>();
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                medicamentos = await _connection.Table<Medicamento>().ToListAsync().ConfigureAwait(false);
            }

            return medicamentos;
        }

        public async Task Save(Medicamento medicamento)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                var existingMeds = await _connection.Table<Medicamento>()
                        .Where(x => x.id == medicamento.id)
                        .FirstOrDefaultAsync();

                if (existingMeds == null)
                {
                    await _connection.InsertAsync(medicamento).ConfigureAwait(false);
                }
                else {
                    medicamento.id = existingMeds.id;
                    await _connection.UpdateAsync(medicamento).ConfigureAwait(false);
                }
            }
        }

        public async Task SaveAll(IEnumerable<Medicamento> medicamentos)
        {
            foreach (var medicamento in medicamentos)
            {
                await Save(medicamento);
            }
        }
    }
}
