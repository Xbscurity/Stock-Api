using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(20, ErrorMessage = "Company cannot be over 20 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.01, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Industry cannot be over 15 characters")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000000)]
        public long MarketCap { get; set; }
    }
}