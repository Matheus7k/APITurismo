using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace APITurismo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private HotelService _hotelService;

        public HotelController()
        {
            _hotelService = new HotelService();
        }

        [HttpPost(Name = "Insert Hotel")]
        public ActionResult Insert(Hotel hotel)
        {
            if (_hotelService.Insert(hotel))
                return StatusCode(201);
            else
                return BadRequest();
        }

        [HttpGet(Name = "Get Hoteis")]
        public List<Hotel> GetAll()
        {
            return _hotelService.GetAll();
        }
    }
}
