﻿using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        public Invoice()
        {
            InvoiceDetailses = new HashSet<InvoiceDetails>();
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int Status { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetailses { get; set; }
    }
}
