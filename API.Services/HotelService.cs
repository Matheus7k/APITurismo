using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Repositories;
using API.Repositories.Interfaces;
using Models;

namespace API.Services
{
    public class HotelService
    {
        private IHotelRepository _hotelRepository;

        public HotelService()
        {
            _hotelRepository = new HotelRepository();
        }

        public bool Insert(Hotel hotel)
        {
            return _hotelRepository.Insert(hotel);
        }

        public List<Hotel> GetAll()
        {
            return _hotelRepository.GetAll();
        }
    }
}
