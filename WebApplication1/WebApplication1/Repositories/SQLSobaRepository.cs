using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SQLSobaRepository : ISobeRepository
    {
        public void AzurirajSobu(int id, Soba soba)
        {
            HotelContext sobaContext = new HotelContext();
            var postoji = sobaContext.Sobe.FirstOrDefault(x => x.id == id);
            if (postoji == null)
            {
                throw new Exception("Soba ne postoji!");
            }
            postoji.naziv = soba.naziv;
            postoji.cena = soba.cena;
            postoji.idHotela = soba.idHotela;
            sobaContext.SaveChanges();

        }

        public void DodajSobu(int idHotel, Soba nova)
        {
            HotelContext sobaContext = new HotelContext();
            var soba = sobaContext.Sobe.FirstOrDefault(x => x.id == nova.id);
            if (soba != null)
            {
                throw new Exception("Soba postoji!");
            }
            sobaContext.Sobe.Add(nova);
            sobaContext.SaveChanges();
        }

        public void ObrisiSobu(int id)
        {
            HotelContext sobaContext = new HotelContext();
            var soba = sobaContext.Sobe.FirstOrDefault(x => x.id == id);
            if (soba == null)
            {
                throw new Exception("Soba ne postoji!");
            }
            sobaContext.Sobe.Remove(soba);
            sobaContext.SaveChanges();
        }

        public List<Soba> VratiSobeNazivId(int idHotela, string desc)
        {
            HotelContext sobaContext = new HotelContext();
            List<Soba> lista = new List<Soba>();
            foreach (var soba in sobaContext.Sobe)
            {
                if (soba.idHotela == idHotela && soba.naziv.Contains(desc))
                {
                    lista.Add(soba);
                }
            }
            return lista;
        }

        public Soba VratiSobu(int id)
        {
            HotelContext sobaContext = new HotelContext();
            var soba = sobaContext.Sobe.FirstOrDefault(x => x.id == id);
            if (soba == null)
            {
                throw new Exception("Soba ne postoji!");
            }
            return soba;
        }

        public List<Soba> VratiSve()
        {
            HotelContext sobaContext = new HotelContext();
            return sobaContext.Sobe.ToList();
        }

        public List<Soba> VratiSveSobeHotela(int idHotela)
        {
            HotelContext sobaContext = new HotelContext();
            List<Soba> lista = new List<Soba>();
            foreach (var soba in sobaContext.Sobe)
            {
                if (soba.idHotela == idHotela)
                {
                    lista.Add(soba);
                }
            }
            return lista;

        }
    }
}
