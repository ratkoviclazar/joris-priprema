using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SobeController : ControllerBase
    {
        private static ISobeRepository sobeRepository;
        public SobeController(ISobeRepository repos)
        {
            sobeRepository = repos;
        }

        [HttpPost("dodaj-sobu/hotel-{id}")]
        public void DodajSobuHotel(int id, [FromBody] Soba nova)
        {
            sobeRepository.DodajSobu(id, nova);
        }

        [HttpGet("vrati-sobe")]
        public List<Soba> VratiSveSobeHotela( int idHotela)
        {
            return sobeRepository.VratiSveSobeHotela(idHotela);
        }

        [HttpGet("vrati-sobu/{id}")]
        public Soba VratiSobu(int id)
        {
            return sobeRepository.VratiSobu(id);
        }

        [HttpPut("azuriraj-sobu/{id}")]
        public void Azuziraj(int id,[FromBody] Soba nova)
        {
            sobeRepository.AzurirajSobu(id, nova);
        }

        [HttpDelete("obrisi-sobu/{id}")]
        public void ObrisiSobu(int id)
        {
            sobeRepository.ObrisiSobu(id);
        }

        [HttpGet("vrati-sobe-hotela")]
        public List<Soba> SobeHotela(int idHotela)
        {
            return sobeRepository.VratiSveSobeHotela(idHotela);
        }

        [HttpGet("sve-sobe")]
        public List<Soba> SveSobe()
        {
            return sobeRepository.VratiSve();
        }

        [HttpGet("sobe-tekst-hotel")]
        public List<Soba> SobeHotelTekst(int idHotela, string desc)
        {
            return sobeRepository.VratiSobeNazivId(idHotela, desc);
        }
    }
}
