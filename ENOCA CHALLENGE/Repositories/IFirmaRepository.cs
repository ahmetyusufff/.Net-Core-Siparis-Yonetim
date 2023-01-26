using ENOCA_CHALLENGE.Models;

namespace ENOCA_CHALLENGE.Repositories
{
    public interface IFirmaRepository
    {
        IEnumerable<Firma> TumFirmalariGetir();
        Firma IdyeGoreFirmaGetir(int id);
        void FirmaEkle(Firma firma);
        void FirmaGuncelle(Firma firma);
        void FirmaSil(int id);
        void DegisiklikleriKaydet();
    }
}
