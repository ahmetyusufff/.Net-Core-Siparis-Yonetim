using ENOCA_CHALLENGE.Data;
using ENOCA_CHALLENGE.Models;
using Microsoft.EntityFrameworkCore;

namespace ENOCA_CHALLENGE.Repositories
{
    public class FirmaRepository : IFirmaRepository
    {
        private readonly SiparisYonetimContext _context;

        public FirmaRepository(SiparisYonetimContext context)
        {
            _context = context;
        }

        public IEnumerable<Firma> TumFirmalariGetir()
        {
            return _context.Firmalar.ToList();
        }

        public Firma IdyeGoreFirmaGetir(int id)
        {
            return _context.Firmalar.Find(id);
        }

        public void FirmaEkle(Firma firma)
        {
            _context.Firmalar.Add(firma);
        }

        public void FirmaGuncelle(Firma firma)
        {
            _context.Firmalar.Update(firma);
        }

        public void FirmaSil(int id)
        {
            var firma = _context.Firmalar.Find(id);
            _context.Firmalar.Remove(firma);
        }

        public void DegisiklikleriKaydet()
        {
            _context.SaveChanges();
        }
    }
}
