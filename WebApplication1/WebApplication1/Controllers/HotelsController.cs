using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private static IHotelRepository _hotelRepository;
        public HotelsController(IHotelRepository repos) {
            _hotelRepository = repos;
        }
        [HttpPost("dodaj-hotel")]
        public void DodajHotel([FromBody] Hotel novi)
        {
            _hotelRepository.AddHotel(novi);
        }

        [HttpGet("vrati-sve")]
        public List<Hotel> VratiHotele()
        {
            return _hotelRepository.GetHotels();
        }

        [HttpGet("vrati-hotel/{id}")]
        public Hotel VratiHotel(int id)
        {
            return _hotelRepository.GetHotelById(id);
        }

        [HttpPut("azuriraj-hotel/{id}")]
        public void Azuriraj(int id, [FromBody] Hotel hotel)
        {
            _hotelRepository.UpdateHotel(id, hotel);
        }

        [HttpDelete("obrisi-hotel/{id}")]
        public void Obrisi(int id)
        {
            _hotelRepository.DeleteHotel(id);
        }

        [HttpGet("vrati-sve-desc")]
        public List<Hotel> VratiDesc(string desc)
        {
            return _hotelRepository.HotelByDesc(desc);
        }
    }
}
