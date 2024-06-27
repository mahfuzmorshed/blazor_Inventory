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
    public class PurchaseDetailsViewModel
    {
        public int Id { get; set; }
        public string PurchaseMasterId { get; set; }
        [Required(ErrorMessage = "* Required")]
        public string ItemId { get; set; }
        [DefaultValue(1)]
        [Required(ErrorMessage = "* Required")]
        public string Quantity {  get; set; }
        [Required(ErrorMessage = "* Required")]
        public string Price {  get; set; }
    }
}
