namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giay")]
    public partial class Giay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Giay()
        {
            ChiTietGiays = new HashSet<ChiTietGiay>();
            KhuyenMais = new HashSet<KhuyenMai>();
        }

        [Key]
        public int maGiay { get; set; }

        public int trangThai { get; set; }
        public int maLoai { get; set; }

        [Required]
        [StringLength(150)]
        public string tenGiay { get; set; }

        [Required]
        [StringLength(100)]
        public string slug { get; set; }

        [Column(TypeName = "money")]
        public decimal giaBan { get; set; }

        [Column(TypeName = "money")]
        public decimal giaNhap { get; set; }

        public DateTime ngayTao { get; set; }

        [StringLength(100)]
        public string image { get; set; }

        [Column(TypeName = "text")]
        public string chiTiet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGiay> ChiTietGiays { get; set; }

        public virtual LoaiGiay LoaiGiay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhuyenMai> KhuyenMais { get; set; }
    }
}
