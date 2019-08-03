using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPromice.VM.Cart
{
    public class CartVm
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get { return Quantity * Price; }}
        public string ProductImage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}