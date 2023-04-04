using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CSharp_ManageCategoriesApp
{
    [Table("MyStockDB")]
        public class Category{
         public Category() { }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]  
        public string CategoryName { get; set; }    
       
        }
    public class MyStockDBContext : DbContext
    {
        public MyStockDBContext() { }

        public DbSet<Category> Categories { get; set; }

        // Chuỗi kết nối tới CSDL (MS SQL Server)
        private const string connectionString = @"
                Server=DESKTOP-3EU7UMS\SQLEXPRESS;
                Database=MyStockDB;
                UID=sa;PWD=12341234";
        // Phương thức OnConfiguring gọi mỗi khi một đối tượng DbContext được tạo
        // Nạp chồng nó để thiết lập các cấu hình, như thiết lập chuỗi kết nối
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuider.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Beverge"},
                    new Category { CategoryId = 2, CategoryName = "Shoes"},
                    new Category { CategoryId = 3, CategoryName = "Food"}
                );
        }

    }
}
