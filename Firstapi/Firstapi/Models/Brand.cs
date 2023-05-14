using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firstapi.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Column("Brand Name")]
        public string? Name { get; set; }
        [Column("Brand Description")]
        public string? Description { get; set; }
        [Column("Brand Price")]
        [Precision(18, 2)] // specify precision and scale here
        public decimal? Price { get; set; }
        [Column("Brand Unit")]
        public string? Unit { get; set; }
    }
}