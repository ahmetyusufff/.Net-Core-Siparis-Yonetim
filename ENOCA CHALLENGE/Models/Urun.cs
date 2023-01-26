using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceStack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENOCA_CHALLENGE.Models
{
    [PrimaryKey(nameof(Id))]
    public class Urun
    {
        public int Id { get; set; }
        public int FirmaId { get; set; }
        public string Ad { get; set; }
        public int Stok { get; set; }
        public decimal Fiyat { get; set; }

        internal List<Siparis>? Siparisler { get; set; }

        internal virtual Firma Firma { get; set; }
    }
}
