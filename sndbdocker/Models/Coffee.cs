using System.ComponentModel.DataAnnotations;

namespace sndbdocker.Models
{
    public class Coffee
    {
        [Key]
        public int Id { get; set; }
        public string? Roaster { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
    }
}
