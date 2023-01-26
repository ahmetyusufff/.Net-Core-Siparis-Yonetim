using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceStack;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENOCA_CHALLENGE.Models
{
    public class Firma
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public bool OnayDurumu { get; set; }
        public TimeSpan SiparisBaslangicSaati { get; set; }
        public TimeSpan SiparisBitisSaati { get; set; }
        internal List<Urun>? Urunler { get; set; }
        internal List<Siparis>? Siparisler { get; set; }
    }

}
