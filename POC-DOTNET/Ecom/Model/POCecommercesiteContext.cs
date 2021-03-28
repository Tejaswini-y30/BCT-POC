using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ecom.Model
{
    public partial class POCecommercesiteContext : DbContext
    {
        public POCecommercesiteContext()
        {
        }

        public POCecommercesiteContext(DbContextOptions<POCecommercesiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<TblCart> TblCarts { get; set; }
        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblSeller> TblSellers { get; set; }
        public virtual DbSet<TblShippingDetail> TblShippingDetails { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Server=.\\;Database=POCecommercesite;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.TokenId)
                    .HasName("PK__RefreshT__658FEE8A972B3F04");

                entity.ToTable("RefreshToken");

                entity.Property(e => e.TokenId)
                    .ValueGeneratedNever()
                    .HasColumnName("TokenID");

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RefreshTo__UserI__7FEAFD3E");
            });

            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.ProductId })
                    .HasName("PK__tblCart__9AFC1BF9220CC557");

                entity.ToTable("tblCart");

                entity.Property(e => e.CartId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CartID");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ProductID");

                entity.Property(e => e.DateAdded)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Purchased)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('NO')");

                entity.Property(e => e.QuantityWished)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("Quantity_wished");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblCarts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCart__Product__3864608B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblCarts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCart__UserID__395884C4");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__tblCateg__19093A2B990AD7CA");

                entity.ToTable("tblCategory");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CatergoryName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SellerId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SellerID");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.TblCategories)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCatego__Selle__2739D489");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tblProdu__B40CC6ED47ED7AA1");

                entity.ToTable("tblProduct");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ProductID");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CategoryID");

                entity.Property(e => e.Cost).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductColor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDescription).HasColumnType("text");

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductSize)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.SellerId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SellerID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__tblProduc__Categ__2CF2ADDF");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblProduc__Selle__2BFE89A6");
            });

            modelBuilder.Entity<TblSeller>(entity =>
            {
                entity.HasKey(e => e.SellerId)
                    .HasName("PK__tblSelle__7FE3DBA183B959A4");

                entity.ToTable("tblSeller");

                entity.Property(e => e.SellerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SellerID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.SellerEmail)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SellerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SellerPassword)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblShippingDetail>(entity =>
            {
                entity.HasKey(e => e.ShippingDetailId)
                    .HasName("PK__tblShipp__FBB368714293290A");

                entity.ToTable("tblShippingDetails");

                entity.Property(e => e.ShippingDetailId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ShippingDetailID");

                entity.Property(e => e.AmountPaid).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ProductID");

                entity.Property(e => e.Uaddress)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("UAddress");

                entity.Property(e => e.Ucity)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("UCity");

                entity.Property(e => e.Ucountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UCountry");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.Ustate)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("UState");

                entity.Property(e => e.UzipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UZipCode");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblShippingDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__tblShippi__Produ__339FAB6E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblShippingDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblShippi__UserI__32AB8735");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tblUser__1788CCACC1B4D501");

                entity.ToTable("tblUser");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
