using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IHotelRepository
    {
        public void AddHotel(Hotel hotel);
        public List<Hotel> GetHotels();
        public Hotel GetHotelById(int id);
        public void UpdateHotel(int id, Hotel hotel);
        public void DeleteHotel(int id);
        public List<Hotel> HotelByDesc(string desc);
    }
}
