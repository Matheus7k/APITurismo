using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace APITurismo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController()
        {
            _enderecoService = new EnderecoService();
        }

        [HttpPost(Name = "Insert Endereco")]
        public ActionResult Insert(Endereco endereco)
        {
            if(_enderecoService.Insert(endereco))
                return StatusCode(201);
            else
                return BadRequest();
        }

        [HttpGet(Name = "GetAll Endereco")]
        public List<Endereco> GetAll()
        {
            return _enderecoService.GetAll();
        }

        [HttpPatch(Name = "Update Endereco")]
        public void UpdateEndereco(Endereco endereco)
        {
            _enderecoService.UpdateEndereco(endereco);
        }
    }
}
