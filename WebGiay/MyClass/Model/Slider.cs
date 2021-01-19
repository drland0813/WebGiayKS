namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public partial class Slider
    {
        [Key]
        public int maSlide { get; set; }

        [Required]
        [StringLength(70)]
        public string viTri { get; set; }

        public int trangThai { get; set; }

        [Required]
        [StringLength(70)]
        public string image { get; set; }
    }
}
