using ENOCA_CHALLENGE.Models;

namespace ENOCA_CHALLENGE.Repositories
{
    public interface ISiparisRepository
    {
        IEnumerable<Siparis> TumSiparisleriGetir();
        Siparis IdyeGoreSiparisGetir(int id);
        void SiparisEkle(Siparis siparis);
        void SiparisGuncelle(Siparis siparis);
        void SiparisSil(int id);
        void DegisiklikleriKaydet();
    }
}
