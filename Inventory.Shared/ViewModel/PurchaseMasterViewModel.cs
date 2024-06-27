﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Shared.Model
{
    public class PurchaseMasterViewModel
    {
        public int Id { get; set; }
        public string? InvoiceNo { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<PurchaseDetailsViewModel> purchaseDetailsViewModel { get; set; } = default!;
    }
}
