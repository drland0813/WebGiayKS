namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiViet")]
    public partial class BaiViet
    {
        [Key]
        public int maBV { get; set; }

        public int id_NV { get; set; }

        public int maCD { get; set; }

        [Required]
        [StringLength(100)]
        public string slug { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string noiDung { get; set; }

        public int trangThai { get; set; }

        public DateTime ngayTao { get; set; }

        public DateTime? ngayDang { get; set; }

        public virtual User_NV User_NV { get; set; }

        public virtual ChuDeBV ChuDeBV { get; set; }

        public string image { get; set; }

        public string tenCD { get; set; }


    }
}
