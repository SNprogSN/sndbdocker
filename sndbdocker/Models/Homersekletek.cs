using System.ComponentModel.DataAnnotations;

namespace sndbdocker.Models
{
    public class Homersekletek
    {
        [Key]
        public int HomersekletId { get; set; }
        public decimal? Hofok { get; set; }
        public decimal? Paratartalom { get; set; }
        public DateTime? MeresDatuma { get; set; }
        public string? HomeroNeve { get; set; }
    }
}
