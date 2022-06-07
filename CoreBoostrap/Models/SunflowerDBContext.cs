using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class SunflowerDBContext : DbContext
    {
        public SunflowerDBContext()
        {
        }

        public SunflowerDBContext(DbContextOptions<SunflowerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Advertise> Advertises { get; set; }
        public virtual DbSet<Advertisestatue> Advertisestatues { get; set; }
        public virtual DbSet<Appointmentdetial> Appointmentdetials { get; set; }
        public virtual DbSet<Artical> Articals { get; set; }
        public virtual DbSet<Articalcomment> Articalcomments { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Clinicdetial> Clinicdetials { get; set; }
        public virtual DbSet<Clinicroom> Clinicrooms { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Departmentcategory> Departmentcategories { get; set; }
        public virtual DbSet<Diagnosistime> Diagnosistimes { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Doctordepartment> Doctordepartments { get; set; }
        public virtual DbSet<Doctorposition> Doctorpositions { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Newscategory> Newscategories { get; set; }
        public virtual DbSet<Odstate> Odstates { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Park> Parks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productbrand> Productbrands { get; set; }
        public virtual DbSet<Productcategory> Productcategories { get; set; }
        public virtual DbSet<Ptype> Ptypes { get; set; }
        public virtual DbSet<Reportdescription> Reportdescriptions { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Statue> Statues { get; set; }
        public virtual DbSet<Tabletype> Tabletypes { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SunflowerDB;Integrated Security=True\n");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("ADMINISTRATOR");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.AdminAccount)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Advertise>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("PK_Advertise");

                entity.ToTable("ADVERTISE");

                entity.Property(e => e.AdContent).HasMaxLength(50);

                entity.Property(e => e.AdTitle).HasMaxLength(50);

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.HasOne(d => d.AdStatue)
                    .WithMany(p => p.Advertises)
                    .HasForeignKey(d => d.AdStatueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADVERTISE_ADVERTISESTATUE");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Advertises)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADVERTISE_ADMINISTRATOR");
            });

            modelBuilder.Entity<Advertisestatue>(entity =>
            {
                entity.HasKey(e => e.AdStatueId);

                entity.ToTable("ADVERTISESTATUE");

                entity.Property(e => e.AdStatueId).ValueGeneratedNever();

                entity.Property(e => e.AdStatue)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Appointmentdetial>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("APPOINTMENTDETIAL");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.CreateDatm).HasColumnType("datetime");

                entity.Property(e => e.MemId).HasColumnName("MemID");

                entity.Property(e => e.StatueId).HasColumnName("StatueID");

                entity.Property(e => e.TreatmentNote).HasMaxLength(50);

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Appointmentdetials)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPOINTMENTDETIAL_CLINICDETIAL");

                entity.HasOne(d => d.Mem)
                    .WithMany(p => p.Appointmentdetials)
                    .HasForeignKey(d => d.MemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPOINTMENTDETIAL_MEMBER");

                entity.HasOne(d => d.Statue)
                    .WithMany(p => p.Appointmentdetials)
                    .HasForeignKey(d => d.StatueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPOINTMENTDETIAL_STATUE");
            });

            modelBuilder.Entity<Artical>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.ToTable("ARTICAL");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.ArticleContent).IsRequired();

                entity.Property(e => e.ArticleImage).HasColumnType("image");

                entity.Property(e => e.ArticleTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DrId).HasColumnName("DrID");

                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.Articals)
                    .HasForeignKey(d => d.DrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ARTICAL_DOCTOR");
            });

            modelBuilder.Entity<Articalcomment>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("ARTICALCOMMENT");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DrId).HasColumnName("DrID");

                entity.Property(e => e.MemId).HasColumnName("MemID");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Articalcomments)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ARTICALCOMMENT_ARTICAL");

                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.Articalcomments)
                    .HasForeignKey(d => d.DrId)
                    .HasConstraintName("FK_ARTICALCOMMENT_DOCTOR");

                entity.HasOne(d => d.Mem)
                    .WithMany(p => p.Articalcomments)
                    .HasForeignKey(d => d.MemId)
                    .HasConstraintName("FK_ARTICALCOMMENT_MEMBER");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.Articalcomments)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_ARTICALCOMMENT_REPORTDESCRIPTION");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Clinicdetial>(entity =>
            {
                entity.HasKey(e => e.ClinicId);

                entity.ToTable("CLINICDETIAL");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.ClinicNote).HasMaxLength(50);

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.DiaTimeId).HasColumnName("DiaTimeID");

                entity.Property(e => e.DrId).HasColumnName("DrID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Clinicdetials)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLINICDETIAL_DEPARTMENT");

                entity.HasOne(d => d.DiaTime)
                    .WithMany(p => p.Clinicdetials)
                    .HasForeignKey(d => d.DiaTimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLINICDETIAL_DIAGNOSISTIME");

                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.Clinicdetials)
                    .HasForeignKey(d => d.DrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLINICDETIAL_DOCTOR");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Clinicdetials)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLINICDETIAL_CLINICROOM");
            });

            modelBuilder.Entity<Clinicroom>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.ToTable("CLINICROOM");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.DepCatId).HasColumnName("DepCatID");

                entity.Property(e => e.ParkId).HasColumnName("ParkID");

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.DepCat)
                    .WithMany(p => p.Clinicrooms)
                    .HasForeignKey(d => d.DepCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLINICROOM_DEPARTMENTCATEGORY");

                entity.HasOne(d => d.Park)
                    .WithMany(p => p.Clinicrooms)
                    .HasForeignKey(d => d.ParkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLINICROOM_PARK");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.DepCatId).HasColumnName("DepCatID");

                entity.Property(e => e.DepName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.DepCat)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.DepCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEPARTMENT_DEPARTMENTCATEGORY1");
            });

            modelBuilder.Entity<Departmentcategory>(entity =>
            {
                entity.HasKey(e => e.DepCatId);

                entity.ToTable("DEPARTMENTCATEGORY");

                entity.Property(e => e.DepCatId).HasColumnName("DepCatID");

                entity.Property(e => e.DepCatName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Diagnosistime>(entity =>
            {
                entity.HasKey(e => e.DiaTimeId);

                entity.ToTable("DIAGNOSISTIME");

                entity.Property(e => e.DiaTimeId).HasColumnName("DiaTimeID");

                entity.Property(e => e.DiaTime)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DrId);

                entity.ToTable("DOCTOR");

                entity.Property(e => e.DrId).HasColumnName("DrID");

                entity.Property(e => e.DrAccount).HasMaxLength(50);

                entity.Property(e => e.DrName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DrPassword).HasMaxLength(50);

                entity.Property(e => e.DrPhotoPath).HasMaxLength(200);

                entity.Property(e => e.PosId).HasColumnName("PosID");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.PosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCTOR_DOCTORPOSITION");
            });

            modelBuilder.Entity<Doctordepartment>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("DOCTORDEPARTMENT");

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.DrId).HasColumnName("DrID");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Doctordepartments)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCTORDEPARTMENT_DEPARTMENT");

                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.Doctordepartments)
                    .HasForeignKey(d => d.DrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCTORDEPARTMENT_DOCTOR");
            });

            modelBuilder.Entity<Doctorposition>(entity =>
            {
                entity.HasKey(e => e.PosId);

                entity.ToTable("DOCTORPOSITION");

                entity.Property(e => e.PosId).HasColumnName("PosID");

                entity.Property(e => e.PosName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("GENDER");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.Gender1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Gender");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemId);

                entity.ToTable("MEMBER");

                entity.Property(e => e.MemId).HasColumnName("MemID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.MemAddress).HasMaxLength(50);

                entity.Property(e => e.MemBrith).HasColumnType("date");

                entity.Property(e => e.MemEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MemIdentifyNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MemPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MemPhone).HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEMBER_CITY");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEMBER_GENDER");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("NEWS");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.NewsCategoryId).HasColumnName("NewsCategoryID");

                entity.Property(e => e.NewsContent).IsRequired();

                entity.Property(e => e.NewsTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NEWS_ADMINISTRATOR");

                entity.HasOne(d => d.NewsCategory)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.NewsCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NEWS_NEWSCATEGORY");
            });

            modelBuilder.Entity<Newscategory>(entity =>
            {
                entity.ToTable("NEWSCATEGORY");

                entity.Property(e => e.NewsCategoryId).HasColumnName("NewsCategoryID");

                entity.Property(e => e.NewsCategoryName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Odstate>(entity =>
            {
                entity.HasKey(e => e.OrderStateId)
                    .HasName("PK_OrderState");

                entity.ToTable("ODSTATE");

                entity.Property(e => e.OrderState)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDER");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.MemId).HasColumnName("MemID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.ShipAddress).HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_CITY");

                entity.HasOne(d => d.Mem)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_MEMBER");

                entity.HasOne(d => d.OrderState)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStateId)
                    .HasConstraintName("FK_ORDER_OrderState");

                entity.HasOne(d => d.PayType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PayTypeId)
                    .HasConstraintName("FK_ORDER_PAYTYPE");
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("ORDERDETAIL");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERDETAIL_ORDER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERDETAIL_PRODUCT");
            });

            modelBuilder.Entity<Park>(entity =>
            {
                entity.ToTable("PARK");

                entity.Property(e => e.ParkId).HasColumnName("ParkID");

                entity.Property(e => e.ParkName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ImagePath).HasMaxLength(200);

                entity.Property(e => e.ProductBrandId).HasColumnName("ProductBrandID");

                entity.Property(e => e.ProductCatId).HasColumnName("ProductCatID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShelfDate).HasColumnType("date");

                entity.HasOne(d => d.ProductBrand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductBrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_PRODUCTBRAND");

                entity.HasOne(d => d.ProductCat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_PRODUCTCATEGORY");
            });

            modelBuilder.Entity<Productbrand>(entity =>
            {
                entity.ToTable("PRODUCTBRAND");

                entity.Property(e => e.ProductBrandId).HasColumnName("ProductBrandID");

                entity.Property(e => e.ProductBrandName)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Productcategory>(entity =>
            {
                entity.HasKey(e => e.ProductCatId);

                entity.ToTable("PRODUCTCATEGORY");

                entity.Property(e => e.ProductCatId).HasColumnName("ProductCatID");

                entity.Property(e => e.ProductCatName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Ptype>(entity =>
            {
                entity.HasKey(e => e.PayTypeId)
                    .HasName("PK_PAYTYPE");

                entity.ToTable("PTYPE");

                entity.Property(e => e.PayType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Reportdescription>(entity =>
            {
                entity.HasKey(e => e.ReportId);

                entity.ToTable("REPORTDESCRIPTION");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.ReportDescription1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("ReportDescription");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("REVIEW");

                entity.Property(e => e.Comment).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DrId).HasColumnName("DrID");

                entity.Property(e => e.MemId).HasColumnName("MemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.DrId)
                    .HasConstraintName("FK_REVIEW_DOCTOR");

                entity.HasOne(d => d.Mem)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REVIEW_MEMBER");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_REVIEW_ORDER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_REVIEW_PRODUCT");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_REVIEW_REPORTDESCRIPTION");
            });

            modelBuilder.Entity<Statue>(entity =>
            {
                entity.ToTable("STATUE");

                entity.Property(e => e.StatueId).HasColumnName("StatueID");

                entity.Property(e => e.Statue1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Statue");
            });

            modelBuilder.Entity<Tabletype>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("TABLETYPE");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("WISHLIST");

                entity.Property(e => e.MemId).HasColumnName("MemID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Mem)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.MemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WISHLIST_MEMBER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WISHLIST_PRODUCT");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WISHLIST_TABLETYPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
