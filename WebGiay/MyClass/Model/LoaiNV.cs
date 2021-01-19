namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiNV")]
    public partial class LoaiNV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiNV()
        {
            User_NV = new HashSet<User_NV>();
        }

        [Key]
        public int id_LoaiNV { get; set; }

        [Required]
        [StringLength(100)]
        public string tenLoai { get; set; }

        [Column(TypeName = "money")]
        public decimal LuongCB { get; set; }

        [Column(TypeName = "money")]
        public decimal? phuCap { get; set; }

        [StringLength(100)]
        public string chucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_NV> User_NV { get; set; }
    }
}
