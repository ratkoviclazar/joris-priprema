using Microsoft.Identity.Client;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ISobeRepository
    {
        public void DodajSobu(int idHotel, Soba nova);
        public List<Soba> VratiSve();
        public Soba VratiSobu(int id);
        public void AzurirajSobu(int id, Soba soba);
        public void ObrisiSobu(int id);
        public List<Soba> VratiSveSobeHotela(int idHotela);
        public List<Soba> VratiSobeNazivId(int idHotela, string desc);
    }
}
