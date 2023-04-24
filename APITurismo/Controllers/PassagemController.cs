
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace APITurismo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagemController : ControllerBase
    {
        private PassagemService _passagemService;

        public PassagemController()
        {
            _passagemService = new PassagemService();
        }

        [HttpPost(Name = "Inset Passagem")]
        public ActionResult Insert(Passagem passagem)
        {
            if(_passagemService.Insert(passagem))
                return StatusCode(201);
            else
                return BadRequest();
        }

        [HttpGet(Name = "Get Passagens")]
        public List<Passagem> GetAll()
        {
            return _passagemService.GetAll();
        }

        [HttpPatch(Name = "Update Passagem")]
        public void UpdatePassagem(Passagem passagem)
        {
            _passagemService.UpdatePassagem(passagem);
        }
    }
}
