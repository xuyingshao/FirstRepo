namespace MyLogIn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Password")]
    public partial class Password
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        [Column("Password")]
        [StringLength(10)]
        public string Password1 { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool IsActive { get; set; }

        public virtual User User { get; set; }
    }
}
