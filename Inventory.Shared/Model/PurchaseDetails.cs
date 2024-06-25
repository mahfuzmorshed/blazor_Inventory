using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Shared.Model
{
    [Table("PurchaseDetails", Schema = "dbo")]
    public class PurchaseDetails
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        [Required(ErrorMessage = "* Required")]
        public int ItemId { get; set; }
        [DefaultValue(1)]
        [Required(ErrorMessage = "* Required")]
        public int Quantity {  get; set; }
        [Required(ErrorMessage = "* Required")]
        public decimal Price {  get; set; }
    }
}
