namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDHs = new HashSet<ChiTietDH>();
        }

        [Key]
        public int soDH { get; set; }

        public int id_KH { get; set; }

        public DateTime ngayLap { get; set; }

        public DateTime? ngayGiaoHang { get; set; }

        [Column(TypeName = "money")]
        public decimal? tongTien { get; set; }

        public int tinhTrang { get; set; }

        [StringLength(150)]
        public string tenNVGiaoHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDH> ChiTietDHs { get; set; }

        public virtual User_KH User_KH { get; set; }
    }
}
