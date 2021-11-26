using System.ComponentModel.DataAnnotations;

namespace RentAPI.Models
{
    public class BikeModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public bool Rented { get; set; }

    }
}
