using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WAD_NguyenCaoHieu.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        
        [Required]
        public string CategoryName { get; set; }
        
        //navigation properties
        public virtual ICollection<Product> Products { get; set; }
    }
}