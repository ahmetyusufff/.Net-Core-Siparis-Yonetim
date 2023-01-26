using ENOCA_CHALLENGE.Models;

namespace ENOCA_CHALLENGE.Repositories
{
    public interface IUrunRepository
    {
        IEnumerable<Urun> TumUrunleriGetir();
        Urun IdyeGoreUrunGetir(int id);
        void UrunEkle(Urun urun);
        void UrunGuncelle(Urun urun);
        void UrunSil(int id);
        void DegisiklikleriKaydet();
    }
}
