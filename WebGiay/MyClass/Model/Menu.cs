namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        public int id_menu { get; set; }

        [Required]
        [StringLength(100)]
        public string slug { get; set; }

        [Required]
        [StringLength(70)]
        public string ten_menu { get; set; }
    }
}
