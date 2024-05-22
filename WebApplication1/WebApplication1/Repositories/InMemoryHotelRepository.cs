using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class InMemoryHotelRepository : IHotelRepository
    {
        private List<Hotel> hoteli = new List<Hotel>();
        public void AddHotel(Hotel hotel)
        {
            var postoji = hoteli.FirstOrDefault(x => x.id == hotel.id);
            if (postoji != null)
            {
                throw new Exception("Dati hotel postoji!");
            }
            hoteli.Add(hotel);
        }

        public void DeleteHotel(int id)
        {
            var postoji = hoteli.FirstOrDefault(x => x.id == id);
            if (postoji == null)
            {
                throw new Exception("Dati hotel postoji!");
            }
            hoteli.Remove(postoji);
        }

        public Hotel GetHotelById(int id)
        {
            var hotel = hoteli.FirstOrDefault(x=>x.id == id);
            if (hotel == null)
            {
                throw new Exception("Dati hotel ne postoji!");
            }
            return hotel;
        }

        public List<Hotel> GetHotels()
        {
            return hoteli;
        }

        public List<Hotel> HotelByDesc(string desc)
        {
            List<Hotel> lista = new List<Hotel>();
            foreach (var hotel in hoteli)
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
            var postoji = hoteli.FirstOrDefault(x => x.id == id);
            if (postoji == null)
            {
                throw new Exception("Dati hotel ne postoji!");
            }
            postoji.naziv = hotel.naziv;
            postoji.adresa = hotel.adresa;
            postoji.opis = hotel.opis;
            postoji.zvezdice = hotel.zvezdice;
        }
    }
}
