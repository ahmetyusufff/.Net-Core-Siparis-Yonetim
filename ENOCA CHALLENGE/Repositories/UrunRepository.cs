using ENOCA_CHALLENGE.Data;
using ENOCA_CHALLENGE.Models;

namespace ENOCA_CHALLENGE.Repositories
{
    public class UrunRepository : IUrunRepository
    {
        private readonly SiparisYonetimContext _context;

        public UrunRepository(SiparisYonetimContext context)
        {
            _context = context;
        }

        public IEnumerable<Urun> TumUrunleriGetir()
        {
            return _context.Urunler.ToList();
        }

        public Urun IdyeGoreUrunGetir(int id)
        {
            return _context.Urunler.Find(id);
        }

        public void UrunEkle(Urun urun)
        {
            _context.Urunler.Add(urun);
        }

        public void UrunGuncelle(Urun urun)
        {
            _context.Urunler.Update(urun);
        }

        public void UrunSil(int id)
        {
            Urun? urun = _context.Urunler.Find(id);
            _context.Urunler.Remove(urun);
        }

        public void DegisiklikleriKaydet()
        {
            _context.SaveChanges();
        }
    }
}
