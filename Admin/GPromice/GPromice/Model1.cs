//namespace GPromice
//{
//    using System;
//    using System.Data.Entity;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Linq;

//    public partial class Model1 : DbContext
//    {
//        public Model1()
//            : base("name=DefaultConnection")
//        {
//        }

//          protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<CartStatu>()
//                .Property(e => e.CartStatus)
//                .IsUnicode(false);

//            modelBuilder.Entity<Category>()
//                .Property(e => e.CatName)
//                .IsUnicode(false);

//            modelBuilder.Entity<Category>()
//                .HasMany(e => e.Products)
//                .WithOptional(e => e.Category)
//                .HasForeignKey(e => e.CategoryID);

//            modelBuilder.Entity<Member>()
//                .Property(e => e.FirstName)
//                .IsUnicode(false);

//            modelBuilder.Entity<Member>()
//                .Property(e => e.lastName)
//                .IsUnicode(false);

//            modelBuilder.Entity<Member>()
//                .Property(e => e.EmailId)
//                .IsUnicode(false);

//            modelBuilder.Entity<Member>()
//                .Property(e => e.Password)
//                .IsUnicode(false);

//            modelBuilder.Entity<Member>()
//                .Property(e => e.ConfirmPassword)
//                .IsFixedLength();

//            modelBuilder.Entity<Member>()
//                .HasMany(e => e.MemberRoles)
//                .WithOptional(e => e.Member)
//                .HasForeignKey(e => e.MemId);

//            modelBuilder.Entity<Member>()
//                .HasMany(e => e.shippingDetails)
//                .WithOptional(e => e.Member)
//                .HasForeignKey(e => e.MemId);

//            modelBuilder.Entity<Product>()
//                .Property(e => e.ProductName)
//                .IsUnicode(false);

//            modelBuilder.Entity<Product>()
//                .Property(e => e.ProductImage)
//                .IsUnicode(false);

//            modelBuilder.Entity<Product>()
//                .Property(e => e.Price)
//                .HasPrecision(18, 0);

//            modelBuilder.Entity<Role>()
//                .Property(e => e.RoleName)
//                .IsUnicode(false);

//            modelBuilder.Entity<shippingDetail>()
//                .Property(e => e.Address)
//                .IsUnicode(false);

//            modelBuilder.Entity<shippingDetail>()
//                .Property(e => e.city)
//                .IsUnicode(false);

//            modelBuilder.Entity<shippingDetail>()
//                .Property(e => e.state)
//                .IsUnicode(false);

//            modelBuilder.Entity<shippingDetail>()
//                .Property(e => e.Country)
//                .IsUnicode(false);

//            modelBuilder.Entity<shippingDetail>()
//                .Property(e => e.ZipCode)
//                .IsUnicode(false);

//            modelBuilder.Entity<shippingDetail>()
//                .Property(e => e.AmountPaid)
//                .HasPrecision(18, 0);

//            modelBuilder.Entity<shippingDetail>()
//                .Property(e => e.PaymentType)
//                .IsUnicode(false);

//            modelBuilder.Entity<SlideImage>()
//                .Property(e => e.SlideTitle)
//                .IsUnicode(false);

//            modelBuilder.Entity<SlideImage>()
//                .Property(e => e.SlideImage1)
//                .IsUnicode(false);
//        }
//    }
//}
