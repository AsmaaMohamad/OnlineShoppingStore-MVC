namespace GPromice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberRole")]
    public partial class MemberRole
    {
        public int MemberRoleId { get; set; }

        public int? MemId { get; set; }

        public int? RoleId { get; set; }

        public virtual Member Member { get; set; }

        public virtual Role Role { get; set; }
    }
}
