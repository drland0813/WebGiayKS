namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Link
    {
        [Key]
        [StringLength(100)]
        public string slug { get; set; }

        [Required]
        [StringLength(100)]
        public string table_name { get; set; }

        public int table_id { get; set; }
    }
}
