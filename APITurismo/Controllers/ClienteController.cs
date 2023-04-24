using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace APITurismo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteService _clicenteService;

        public ClienteController()
        {
            _clicenteService = new ClienteService();
        }

        [HttpPost(Name = "Insert Cliente")]
        public ActionResult Insert(Cliente cliente)
        {
            if (_clicenteService.Insert(cliente))
                return StatusCode(201);
            else
                return BadRequest();
        }

        [HttpGet(Name = "Get Clientes")]
        public List<Cliente> GetAll()
        {
            return _clicenteService.GetAll();
        }        

        [HttpPatch(Name = "Update Ciiente")]
        public void UpdateCliente(Cliente cliente)
        {
            _clicenteService.UpdateCliente(cliente);
        }
    }
}
