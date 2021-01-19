namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_NV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_NV()
        {
            BaiViets = new HashSet<BaiViet>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_NV { get; set; }

        public int id_LoaiNV { get; set; }

        public DateTime ngayBDLam { get; set; }

        public double heSoLuong { get; set; }

        public DateTime ngaySinh { get; set; }

        [Required]
        [StringLength(20)]
        public string soCMND { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }

        public virtual LoaiNV LoaiNV { get; set; }
    }
}
