using System;
using System.Threading.Tasks;

namespace Localiza.Frotas.Domain
{
    public interface IVeiculoDetran
    {
        Task AgendarVistoriaDetran(Guid veiculoId);
    }
}