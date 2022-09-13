using System;
using System.ComponentModel.DataAnnotations;

namespace WAD_NguyenCaoHieu.Models
{
    public class Product
    {
        [Key] public int ProductId { get; set; }

        [Required]
        [StringLength(32,MinimumLength = 3,ErrorMessage = "Product name length must be between 3 and 32 characters")]
        public string Name { get; set; }

        [Required]  
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Price must be numeric data")]
        public long Price { get; set; }

        [Required]
        [Range(1,100,ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        
        //navigation properties
        public virtual Category categories { get; set; }
         

    }
}