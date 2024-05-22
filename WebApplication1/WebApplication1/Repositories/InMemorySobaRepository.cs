using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class InMemorySobaRepository : ISobeRepository
    {
        private List<Soba> sobe = new List<Soba>();
        public void AzurirajSobu(int id, Soba soba)
        {
            var postoji = sobe.FirstOrDefault(x=>x.id==id);
            if (postoji == null)
            {
                throw new Exception("Ne postoji!");
            }
            postoji.cena = soba.cena;
            postoji.naziv = soba.naziv;
            postoji.idHotela = soba.idHotela;
        }

        public void DodajSobu(int idHotel, Soba nova)
        {
            var postoji = sobe.FirstOrDefault(x => x.id == nova.id);
            if (postoji != null)
            {
                throw new Exception("Soba postoji!");
            }
            if (nova.idHotela == idHotel)
            {
                sobe.Add(nova);
            }
            else
            {
                nova.idHotela = idHotel;
                sobe.Add(nova);
            }
        }

        public void ObrisiSobu(int id)
        {
            var postoji = sobe.FirstOrDefault(x => x.id == id);
            if (postoji == null)
            {
                throw new Exception("Soba ne postoji!");
            }
            sobe.Remove(postoji);
        }

        public List<Soba> VratiSobeNazivId(int idHotela, string desc)
        {
            List<Soba> lista = new List<Soba>();
            foreach(var soba in sobe)
            {
                if (idHotela == soba.idHotela && soba.naziv.Contains(desc))
                {
                    lista.Add(soba);
                }
            }
            return lista;
        }

        public Soba VratiSobu(int id)
        {
            var soba = sobe.FirstOrDefault(x => x.id == id);
            if(soba == null)
            {
                throw new Exception("Soba ne postoji!");
            }
            return soba;
        }

        public List<Soba> VratiSve()
        {
            return sobe;
        }

        public List<Soba> VratiSveSobeHotela(int idHotela)
        {
            List<Soba> lista = new List<Soba>();
            foreach(var soba in sobe)
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
