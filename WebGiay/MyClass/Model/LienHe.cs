namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        [Key]
        public int maLH { get; set; }

        [Required]
        [StringLength(10)]
        public string sdt { get; set; }

        [Required]
        [StringLength(100)]
        public string diachi { get; set; }

        [Required]
        [MaxLength(70)]
        public byte[] email { get; set; }

        [Required]
        [StringLength(70)]
        public string hoten { get; set; }

        [Column(TypeName = "text")]
        public string noidung { get; set; }
    }
}
