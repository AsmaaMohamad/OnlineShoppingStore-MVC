namespace GPromice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int CartId { get; set; }

        public int? ProductId { get; set; }

        public int? MemberId { get; set; }

        public int? CartStatusId { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
