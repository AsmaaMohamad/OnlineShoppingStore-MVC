using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPromice.Models
{
    public class ProductVM
    {

        public int ProductID { get; set; }

       // [StringLength(500)]
        public string ProductName { get; set; }
//        [ForeignKey("Category")]
        public int? CategoryID { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }



        public string ProductImage { get; set; }

       public HttpPostedFileBase imagefile { get; set; }



        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Category Category { get; set; }
    }
}