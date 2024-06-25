using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Shared.Model
{
    [Table("Item",Schema ="dbo")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
