using CarrosWeb.Core.Entities;

namespace CarrosWeb.Core.Interfaces
{
    public interface ICarroRepository
    {
        Task<IEnumerable<Carro>> GetAll();
        Task<Carro> GetById(int id);
        Task Add(Carro carro);
        Task Update(Carro carro);
        Task Delete(int id);
    }
}
