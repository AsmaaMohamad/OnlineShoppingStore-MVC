namespace GPromice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SlideImage")]
    public partial class SlideImage
    {
        [Key]
        public int SlideId { get; set; }

        [StringLength(500)]
        public string SlideTitle { get; set; }

        [Column("SlideImage")]
        public string SlideImage1 { get; set; }
    }
}
