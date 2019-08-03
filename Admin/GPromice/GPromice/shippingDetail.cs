namespace GPromice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class shippingDetail
    {
        [Key]
        public int shippingDetailsID { get; set; }

        public int? MemId { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(500)]
        public string city { get; set; }

        [StringLength(500)]
        public string state { get; set; }

        [StringLength(500)]
        public string Country { get; set; }

        [StringLength(50)]
        public string ZipCode { get; set; }

        public int? orderId { get; set; }

        public decimal? AmountPaid { get; set; }

        [StringLength(50)]
        public string PaymentType { get; set; }

        public virtual Member Member { get; set; }
    }
}
