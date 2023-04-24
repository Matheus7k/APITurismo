using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace API.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        bool Insert(Hotel hotel);
        List<Hotel> GetAll();
        int InsertHotel(Hotel hotel);
        Hotel GetHotelId(int id);
        void UpdateHotel(Hotel hotel);
    }
}
