using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SQLHotelRepository : IHotelRepository
    {
        public void AddHotel(Hotel hotel)
        {
            HotelContext hotelContext = new HotelContext();
            var postoji = hotelContext.Hoteli.FirstOrDefault(x=>x.id==hotel.id);
            if (postoji != null)
            {
                throw new Exception("Hotel vec postoji!");
            }
            hotelContext.Hoteli.Add(hotel);
            hotelContext.SaveChanges();
        }

        public void DeleteHotel(int id)
        {
            HotelContext hotelContext = new HotelContext();
            var hotel = hotelContext.Hoteli.FirstOrDefault(y => y.id == id);
            if (hotel == null)
            {
                throw new Exception("Hotel ne postoji!");
            }
            hotelContext.Hoteli.Remove(hotel);
            hotelContext.SaveChanges();
        }

        public Hotel GetHotelById(int id)
        {
            HotelContext hotelContext = new HotelContext();
            var hotel = hotelContext.Hoteli.FirstOrDefault(x => x.id == id);
            if (hotel == null)
            {
                throw new Exception("Hotel ne postoji!");
            }
            return hotel;
        }

        public List<Hotel> GetHotels()
        {
            HotelContext hotelContext = new HotelContext();
            return hotelContext.Hoteli.ToList();
        }

        public List<Hotel> HotelByDesc(string desc)
        {
            HotelContext hotelContext = new HotelContext();
            List<Hotel> lista = new List<Hotel>();
            foreach(var hotel in hotelContext.Hoteli)
            {
                if (hotel.naziv.Contains(desc))
                {
                    lista.Add(hotel);
                }
            }
            return lista;
        }

        public void UpdateHotel(int id, Hotel hotel)
        {
            HotelContext hotelContext = new HotelContext();
            var postoji = hotelContext.Hoteli.FirstOrDefault(hotel => hotel.id == id);
            if (postoji == null)
            {
                throw new Exception("Hotel ne postoji!");
            }
            postoji.naziv = hotel.naziv;
            postoji.adresa = hotel.adresa;
            postoji.opis = hotel.opis;
            postoji.zvezdice = hotel.zvezdice;
            hotelContext.SaveChanges();
        }
    }
}
