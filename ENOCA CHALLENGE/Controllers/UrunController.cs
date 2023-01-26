using ENOCA_CHALLENGE.Models;
using ENOCA_CHALLENGE.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ENOCA_CHALLENGE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrunController : ControllerBase
    {
        private readonly IUrunRepository _urunRepository;

        public UrunController(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Urun>> GetAll()
        {
            return Ok(_urunRepository.TumUrunleriGetir());
        }

        [HttpGet("{id}")]
        public ActionResult<Urun> GetById(int id)
        {
            var urun = _urunRepository.IdyeGoreUrunGetir(id);
            if (urun == null)
                return NotFound();

            return Ok(urun);
        }
        [HttpPost]
        public ActionResult<Urun> Create([FromBody] Urun urun)
        {
            _urunRepository.UrunEkle(urun);
            _urunRepository.DegisiklikleriKaydet();
            return CreatedAtAction(nameof(GetById), new { id = urun.Id }, urun);
        }
    }

}
