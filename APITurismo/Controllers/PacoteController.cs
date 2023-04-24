using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace APITurismo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacoteController : ControllerBase
    {
        private readonly PacoteService _pacoteService;

        public PacoteController()
        {
            _pacoteService = new PacoteService();
        }

        [HttpPost(Name = "Insert Pacote")]
        public ActionResult Insert(Pacote pacote)
        {
            if (_pacoteService.Insert(pacote))
                return StatusCode(201);
            else
                return BadRequest();
        }

        [HttpGet(Name = "Get Pacotes")]
        public List<Pacote> GetAll()
        {
            return _pacoteService.GetAll();
        }

        [HttpPatch(Name = "Update Pacote")]
        public void UpdatePacote(Pacote pacote)
        {
            _pacoteService.UpdatePacote(pacote);
        }

        [HttpDelete(Name = "Delete Pacote")]
        public void Delete(int id)
        {
            _pacoteService.Delete(id);
        }
    }
}
