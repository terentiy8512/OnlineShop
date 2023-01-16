using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Dtos
{
    public class OrdersDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
