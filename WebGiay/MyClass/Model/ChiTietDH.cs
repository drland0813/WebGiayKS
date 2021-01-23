namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDH")]
    public partial class ChiTietDH
    {
        [Key]
        public int STT { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int soDH { get; set; }

        public int maGiay { get; set; }

        public double size { get; set; }

        public int soLuongMua { get; set; }

        public virtual ChiTietGiay ChiTietGiay { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}
