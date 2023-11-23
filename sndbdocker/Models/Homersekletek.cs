using System.ComponentModel.DataAnnotations;

namespace sndbdocker.Models
{
    public class Homersekletek
    {
        [Key]
        public int HofokId { get; set; }
        public int Hofok { get; set; }

    }
}
