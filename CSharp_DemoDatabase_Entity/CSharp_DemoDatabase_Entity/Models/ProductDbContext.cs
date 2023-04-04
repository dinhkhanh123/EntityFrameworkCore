using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CSharp_DemoDatabase_Entity.Models
{

    public class ProductDbContext : DbContext   
    {
            public DbSet<Product> Products { get; set; }

        private const string stringConnect = @"
                Server=DESKTOP-3EU7UMS\SQLEXPRESS;
                Database=mydata;
                User ID=sa;Password=12341234";

        // Phương thức OnConfiguring gọi mỗi khi một đối tượng DbContext được tạo
        // Nạp chồng nó để thiết lập các cấu hình, như thiết lập chuỗi kết nối
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(stringConnect);
        }


    }
}
