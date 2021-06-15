using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDatabaseApp.Model.Objects
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MaxLength(75)]
        [Required]
        public string ProductName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
