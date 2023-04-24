using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace APITurismo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private CidadeService _cidadeService;

        public CidadeController()
        {
            _cidadeService = new CidadeService();
        }

        [HttpPost(Name = "Insert Cidade")]
        public ActionResult Insert(Cidade cidade)
        {
            if (_cidadeService.Insert(cidade))
                return StatusCode(201);
            else
                return BadRequest();
        }

        [HttpGet(Name = "GetAll Cidade")]
        public List<Cidade> GetAll()
        {
            return _cidadeService.GetAll();
        }

        [HttpPatch(Name = "Update Cidade")]
        public void UpdateCidade(Cidade cidade)
        {
            _cidadeService.UpdateCidade(cidade);
        }
    }
}
