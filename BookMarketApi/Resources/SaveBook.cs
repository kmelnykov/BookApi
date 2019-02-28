using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookMarketApi.Resources
{
    public class SaveBook
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MaxLength(80)]
        public string Author { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}