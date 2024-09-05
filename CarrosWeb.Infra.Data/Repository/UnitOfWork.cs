using CarrosWeb.Core.Interfaces;
using CarrosWeb.Infra.Data.Context;

namespace CarrosWeb.Infra.Data.Repository
{
    public interface IUnitOfWork
    {
        ICarroRepository carrosRepository { get; }
        Task CompleteAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICarroRepository carrosRepository { get; }


        public UnitOfWork(AppDbContext context, ICarroRepository carroRepository)
        {
            _context = context;
            this.carrosRepository = carroRepository;
        }

        public async Task CompleteAsync()
        {
            // Aqui pode-se fazer o commit ou qualquer outra operação necessária para finalizar a UnitOfWork
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
