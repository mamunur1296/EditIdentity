using System.ComponentModel.DataAnnotations;

namespace Test.Model
{
    public class Country
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? description { get; set; }
        [Required]
        public string? language { get; set; }
    }
}
