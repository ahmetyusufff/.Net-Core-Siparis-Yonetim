using ENOCA_CHALLENGE.Data;
using ENOCA_CHALLENGE.Models;

namespace ENOCA_CHALLENGE.Repositories
{
    public class SiparisRepository : ISiparisRepository
    {
        private readonly SiparisYonetimContext _context;

        public SiparisRepository(SiparisYonetimContext context)
        {
            _context = context;
        }

        public IEnumerable<Siparis> TumSiparisleriGetir()
        {
            return _context.Siparisler.ToList();
        }

        public Siparis IdyeGoreSiparisGetir(int id)
        {
            return _context.Siparisler.Find(id);
        }

        public void SiparisEkle(Siparis siparis)
        {
            _context.Siparisler.Add(siparis);
        }

        public void SiparisGuncelle(Siparis siparis)
        {
            _context.Siparisler.Update(siparis);
        }

        public void SiparisSil(int id)
        {
            var siparis = _context.Siparisler.Find(id);
            _context.Siparisler.Remove(siparis);
        }

        public void DegisiklikleriKaydet()
        {
            _context.SaveChanges();
        }
    }
}
