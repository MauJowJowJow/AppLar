using AppLar.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLar.Core.Data
{
    public interface IMedicamentoDAO
    {
        Task CreateDatabaseAsync();
        Task<List<Medicamento>> GetMedicamentoAsync();
        Task Save(Medicamento medicamento);
        Task SaveAll(IEnumerable<Medicamento> medicamentos);

    }
}
