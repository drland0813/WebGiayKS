namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiGiay")]
    public partial class LoaiGiay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiGiay()
        {
            Giays = new HashSet<Giay>();
        }

        [Key]
        public int maLoai { get; set; }

        [Required]
        [StringLength(100)]
        public string tenLoai { get; set; }

        [Required]
        [StringLength(150)]
        public string xuatXu { get; set; }

        [Required]
        [StringLength(100)]
        public string slug { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giay> Giays { get; set; }
    }
}
