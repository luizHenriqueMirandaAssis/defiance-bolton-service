using System;
using System.Collections.Generic;

namespace Defiance.Bolton.Domain.Entities
{
    public class EletronicTaxInvoice
    {
        public string AccessKey { get; set; }
        public DateTime DateIssued { get; set; }
        public string IssuerTaxId { get; set; }
        public string RecipientTaxId { get; set; }
        public decimal TotalAmount { get; private set; }

        public static EletronicTaxInvoice Build(string accessKey, DateTime dateIssued, string issuerTaxId, string recipientTaxId, decimal totalAmount)
        {
            return new EletronicTaxInvoice()
            {
                AccessKey = accessKey,
                DateIssued = dateIssued,
                IssuerTaxId = issuerTaxId,
                RecipientTaxId = recipientTaxId,
                TotalAmount = totalAmount
            };
        }

        public static List<EletronicTaxInvoice> ListEmpty() => new List<EletronicTaxInvoice>() { };
    }
}
