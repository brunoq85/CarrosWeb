using CarrosWeb.API.Services;
using CarrosWeb.Core.Entities;
using CarrosWeb.Core.Interfaces;
using CarrosWeb.Infra.Data.Context;
using Dapper;

namespace CarrosWeb.Infra.Data.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private readonly AppDbContext _context;
        private readonly LoggerService _logger;

        public CarroRepository(AppDbContext context, LoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Add(Carro carro)
        {
            var sql = "INSERT INTO Carros (Marca, Modelo, Ano, Cor, Placa) VALUES (@Marca, @Modelo, @Ano, @Cor, @Placa)";
            _logger.Log(sql);

            using (var connection = _context.GetConnection())
            {
                await connection.ExecuteAsync(sql, carro);
            }
        }

        public async Task Delete(int id)
        {
            var sql = "DELETE FROM Carros WHERE Id = @Id";
            _logger.Log(sql);

            using (var connection = _context.GetConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Carro>> GetAll()
        {
            var sql = "SELECT * FROM Carros";
            _logger.Log(sql);

            using (var connection = _context.GetConnection())
            {
                return await connection.QueryAsync<Carro>(sql);
            }
        }

        public async Task<Carro> GetById(int id)
        {
            var sql = "SELECT * FROM Carros WHERE Id = @Id";
            _logger.Log(sql);

            using (var connection = _context.GetConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Carro>(sql, new { Id = id });
            }
        }

        public async Task Update(Carro carro)
        {
            var sql = "UPDATE Carros SET Marca = @Marca, Modelo = @Modelo, Ano = @Ano, Cor = @Cor, Placa = @Placa WHERE Id = @Id";
            _logger.Log(sql);

            using (var connection = _context.GetConnection())
            {
                await connection.ExecuteAsync(sql, carro);
            }
        }
    }
}
