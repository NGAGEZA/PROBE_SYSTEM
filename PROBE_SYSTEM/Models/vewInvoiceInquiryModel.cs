using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROBE_SYSTEM.Models
{
    public class VewInvoiceInquiryModel
    {
        [Key]
        public string PONo { get; set; }
        public decimal LineNo { get; set; }
        public string InvoiceNo  { get; set; }
        public string PRNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemCategory { get; set; }
        public string Item { get; set; }
        public string Specification { get; set; }
        public string Unit { get; set; }
        public string UnitName { get; set; }
        public string ReceivingQTY { get; set; }
        public string ReceivingUnitPrice { get; set; }
        public string ReceivingAmount { get; set; }
        public string PODate { get; set; }
        public string ReceivingDate { get; set; }
        public string Remarks { get; set; }
        public string MakerName { get; set; }
        public string SpecialNote { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string ChargeSectionCode { get; set; }
        public string ChargeSectionName { get; set; }
        public string Currency { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string AccountNo { get; set; }
        public string AccountSubNo { get; set; }
        public string AccountName { get; set; }
        public string SuspenseAccountNo { get; set; }
        public string LicenceNo { get; set; }
        public string DecisionFormNo { get; set; }
        public string ORGReceivingUnitPrice { get; set; }
        public string ORGReceivingAmount { get; set; }
        public string DataMakingDate { get; set; }
        public int DeliveryPlaceCode { get; set; }
        public string DeliveryPlaceName { get; set; }
        public string DeliverySectionCode { get; set; }
        public string DeliverySectionName { get; set; }
        public string ReceivingEntryDate { get; set; }
        public string OpeDate { get; set; }
        public DateTime ReceivingDate_1 { get; set; }
    }
}
