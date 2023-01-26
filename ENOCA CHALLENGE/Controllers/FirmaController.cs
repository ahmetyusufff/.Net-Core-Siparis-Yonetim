using ENOCA_CHALLENGE.Models;
using ENOCA_CHALLENGE.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ENOCA_CHALLENGE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirmaController : ControllerBase
    {
        private readonly IFirmaRepository _firmaRepository;

        public FirmaController(IFirmaRepository firmaRepository)
        {
            _firmaRepository = firmaRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Firma>> GetAll()
        {
            return Ok(_firmaRepository.TumFirmalariGetir());
        }

        [HttpGet("{id}")]
        public ActionResult<Firma> GetById(int id)
        {
            var firma = _firmaRepository.IdyeGoreFirmaGetir(id);
            if (firma == null)
                return NotFound();

            return Ok(firma);
        }

        [HttpPost]
        public ActionResult<Firma> Create([FromBody] Firma firma)
        {
            _firmaRepository.FirmaEkle(firma);
            _firmaRepository.DegisiklikleriKaydet();
            return CreatedAtAction(nameof(GetById), new { id = firma.Id }, firma);
        }

        [HttpPut("{id}")]
        public ActionResult<Firma> Update(int id, [FromBody] Firma firma)
        {
            var existingFirma = _firmaRepository.IdyeGoreFirmaGetir(id);
            if (existingFirma == null)
                return NotFound();

            existingFirma.SiparisBaslangicSaati = firma.SiparisBaslangicSaati;
            existingFirma.SiparisBitisSaati = firma.SiparisBitisSaati;
            existingFirma.OnayDurumu = firma.OnayDurumu;
            _firmaRepository.DegisiklikleriKaydet();
            return Ok(existingFirma);
        }
    }
}
