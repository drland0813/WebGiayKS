using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyClass.Model
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=ChuoiKN")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<ChiTietDH> ChiTietDHs { get; set; }
        public virtual DbSet<ChiTietGiay> ChiTietGiays { get; set; }
        public virtual DbSet<ChiTietQuyen> ChiTietQuyens { get; set; }
        public virtual DbSet<ChuDeBV> ChuDeBVs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Giay> Giays { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<LoaiGiay> LoaiGiays { get; set; }
        public virtual DbSet<LoaiNV> LoaiNVs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<User_KH> User_KH { get; set; }
        public virtual DbSet<User_NV> User_NV { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.sdt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.passwords)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasOptional(e => e.User_KH)
                .WithRequired(e => e.Account);

            modelBuilder.Entity<Account>()
                .HasOptional(e => e.User_NV)
                .WithRequired(e => e.Account);

            modelBuilder.Entity<BaiViet>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<BaiViet>()
                .Property(e => e.noiDung)
                .IsUnicode(false);

            modelBuilder.Entity<BaiViet>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<BaiViet>()
                .Property(e => e.tenCD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietGiay>()
                .HasMany(e => e.ChiTietDHs)
                .WithRequired(e => e.ChiTietGiay)
                .HasForeignKey(e => new { e.size, e.maGiay })
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<ChiTietQuyen>()
            //    .HasMany(e => e.Accounts)
            //    .WithRequired(e => e.ChiTietQuyen)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChuDeBV>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<ChuDeBV>()
                .HasMany(e => e.BaiViets)
                .WithRequired(e => e.ChuDeBV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.tongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDHs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Giay>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<Giay>()
                .Property(e => e.giaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Giay>()
                .Property(e => e.giaNhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Giay>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<Giay>()
                .Property(e => e.chiTiet)
                .IsUnicode(false);

            modelBuilder.Entity<Giay>()
                .HasMany(e => e.ChiTietGiays)
                .WithRequired(e => e.Giay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhuyenMai>()
                .HasMany(e => e.Giays)
                .WithMany(e => e.KhuyenMais)
                .Map(m => m.ToTable("ChiTietKhuyenMai").MapLeftKey("id_KM").MapRightKey("maGiay"));

            modelBuilder.Entity<LienHe>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.noidung)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.table_name)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiGiay>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiGiay>()
                .HasMany(e => e.Giays)
                .WithRequired(e => e.LoaiGiay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiNV>()
                .Property(e => e.LuongCB)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LoaiNV>()
                .Property(e => e.phuCap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LoaiNV>()
                .HasMany(e => e.User_NV)
                .WithRequired(e => e.LoaiNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<Size>()
                .HasMany(e => e.ChiTietGiays)
                .WithRequired(e => e.Size1)
                .HasForeignKey(e => e.size)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.viTri)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<User_KH>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.User_KH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_NV>()
                .Property(e => e.soCMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User_NV>()
                .HasMany(e => e.BaiViets)
                .WithRequired(e => e.User_NV)
                .WillCascadeOnDelete(false);
        }
    }
}
