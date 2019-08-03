namespace GPromice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CartStatu
    {
        [Key]
        public int CartStatusID { get; set; }

        [StringLength(500)]
        public string CartStatus { get; set; }
    }
}
