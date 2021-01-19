namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        public int id_account { get; set; }

        public int index_quyen { get; set; }

        [Required]
        [StringLength(150)]
        public string fullName { get; set; }

        public DateTime ngayTao { get; set; }

        [StringLength(25)]
        public string gioiTinh { get; set; }

        [Required]
        [StringLength(150)]
        public string diaChi { get; set; }

        [Required]
        [StringLength(12)]
        public string sdt { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(70)]
        public string passwords { get; set; }

        public virtual id_KM ChiTietQuyen { get; set; }

        public virtual User_KH User_KH { get; set; }

        public virtual User_NV User_NV { get; set; }
    }
}
