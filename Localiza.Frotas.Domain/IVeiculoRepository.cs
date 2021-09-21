using System;
using System.Collections.Generic;

namespace Localiza.Frotas.Domain
{
    interface IVeiculoRepository
    {
        Veiculo GetById(Guid id);
        IEnumerable<Veiculo> GetAll();
        void Add(Veiculo veiculo);
        void Delete(Veiculo veiculo);
        void Update(Veiculo veiculo);


    }
}

namespace Localiza.Frotas.Domain
{
    public class IVeiculoRepository
    {
    }
}