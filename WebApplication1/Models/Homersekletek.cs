using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Homersekletek
    {
        [Key]
        public int HofokId { get; set; }
        public int Hofok { get; set; }

    }
}
