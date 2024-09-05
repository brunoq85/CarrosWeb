using CarrosWeb.API.Services;
using CarrosWeb.Core.Entities;
using CarrosWeb.Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarrosWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LoggerService _logger;

        public CarrosController(IUnitOfWork unitOfWork, LoggerService logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Carro>> Get()
        {
            _logger.Log("Iniciando busca de todos os carros.");
            var carros = await _unitOfWork.carrosRepository.GetAll();
            _logger.Log("Busca de todos os carros concluída.");
            return carros;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetById(int id)
        {
            _logger.Log($"Iniciando busca do carro com ID: {id}.");
            var carro = await _unitOfWork.carrosRepository.GetById(id);
            if (carro == null)
            {
                _logger.Log($"Carro com ID: {id} não encontrado.");
                return NotFound();
            }
            _logger.Log($"Busca do carro com ID: {id} concluída.");
            return carro;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Carro carro)
        {
            _logger.Log("Iniciando adição de um novo carro.");
            await _unitOfWork.carrosRepository.Add(carro);
            await _unitOfWork.CompleteAsync();
            _logger.Log("Novo carro adicionado com sucesso.");
            return CreatedAtAction(nameof(GetById), new { id = carro.Id }, carro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Carro carro)
        {
            _logger.Log($"Iniciando atualização do carro com ID: {id}.");
            var carroExistente = await _unitOfWork.carrosRepository.GetById(id);
            if (carroExistente == null)
            {
                _logger.Log($"Carro com ID: {id} não encontrado para atualização.");
                return NotFound();
            }

            carro.Id = id;
            await _unitOfWork.carrosRepository.Update(carro);
            await _unitOfWork.CompleteAsync();
            _logger.Log($"Carro com ID: {id} atualizado com sucesso.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.Log($"Iniciando remoção do carro com ID: {id}.");
            var carroExistente = await _unitOfWork.carrosRepository.GetById(id);
            if (carroExistente == null)
            {
                _logger.Log($"Carro com ID: {id} não encontrado para exclusão.");
                return NotFound();
            }

            await _unitOfWork.carrosRepository.Delete(id);
            await _unitOfWork.CompleteAsync();
            _logger.Log($"Carro com ID: {id} excluído com sucesso.");
            return NoContent();
        }
    }
}
