using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENOCA_CHALLENGE.Models
{
    [PrimaryKey(nameof(Id))]
    public class Siparis
    {
        public int Id { get; set; }
        public int FirmaId { get; set; }
        public int UrunId { get; set; }
        public string SiparisVeren { get; set; }
        public DateTime SiparisTarihi { get; set; }
        internal virtual Urun Urun { get; set; }

        internal virtual Firma Firma { get; set; }
    }
}
