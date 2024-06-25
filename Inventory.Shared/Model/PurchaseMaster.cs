using BZ.Shared.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Shared.Model
{
    [Table("PurchaseMaster", Schema = "dbo")]
    public class PurchaseMaster
    {
        [Key]
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<PurchaseDetails> purchaseDetails { get; set; } = default!;
    }
}
