using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyChanged;
using AppLar.Core.Model;
//using AppLar.Core.Service;
using AppLar.Core.Data;
using AppLar.Core.Model;

namespace AppLar.Core.ViewModel
{
    [ImplementPropertyChanged]
    class MedicamentoViewModel
    {
        readonly MedicamentoDAO _db;

        public MedicamentoViewModel()
        {
            _db = new MedicamentoDAO();
        }

        public List<Medicamento> Medicamentos { get; set; }

        public async Task GetMedicamentos()
        {
            await GetLocalMedicamentos();
            await GetRemoteMedicamentos();
            //await GetLocalMedicamentos();
        }

        private async Task GetLocalMedicamentos()
        {
            var medicamentos = await _db.GetMedicamentoAsync();
            this.Medicamentos = medicamentos.OrderBy(x => x.nome).ToList();

            this.Medicamentos.Add(new Medicamento(1, "Medicamento 1"));
            this.Medicamentos.Add(new Medicamento(2, "Medicamento 2"));
        }

        private async Task GetRemoteMedicamentos()
        {
            /*var remoteClient = new TekConfClient();
            var conferences = await remoteClient.GetConferences().ConfigureAwait(false);
            await _db.SaveAll(conferences).ConfigureAwait(false);*/
        }
    }
}
