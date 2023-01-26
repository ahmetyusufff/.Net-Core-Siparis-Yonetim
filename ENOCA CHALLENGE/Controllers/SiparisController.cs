using ENOCA_CHALLENGE.Models;
using ENOCA_CHALLENGE.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ENOCA_CHALLENGE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiparisController : ControllerBase
    {
        private readonly ISiparisRepository _siparisRepository;
        private readonly IFirmaRepository _firmaRepository;
        private readonly IUrunRepository _urunRepository;

        public SiparisController(ISiparisRepository siparisRepository, IFirmaRepository firmaRepository, IUrunRepository urunRepository)
        {
            _siparisRepository = siparisRepository;
            _firmaRepository = firmaRepository;
            _urunRepository = urunRepository;
        }

        [HttpPost]
        public ActionResult<string> Create([FromBody] Siparis siparis)
        {
            var firma = _firmaRepository.IdyeGoreFirmaGetir(siparis.FirmaId);
            if (firma == null)
                return BadRequest("Firma bulunamadı.");

            if (!firma.OnayDurumu)
                return BadRequest("Firma onaylı değil.");

            if (siparis.SiparisTarihi.TimeOfDay < firma.SiparisBaslangicSaati || siparis.SiparisTarihi.TimeOfDay > firma.SiparisBitisSaati)
                return BadRequest("Firma şu anda sipariş almıyor.");

            var urun = _urunRepository.IdyeGoreUrunGetir(siparis.UrunId);
            if (urun == null)
                return BadRequest("Ürün bulunamadı.");

            _siparisRepository.SiparisEkle(siparis);
            _siparisRepository.DegisiklikleriKaydet();
            return Ok("Sipariş oluşturuldu.");
        }
    }
}
