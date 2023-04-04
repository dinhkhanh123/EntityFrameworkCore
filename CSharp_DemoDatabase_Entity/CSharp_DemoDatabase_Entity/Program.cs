using System;
using System.Linq;
using System.Threading.Tasks;
using CSharp_DemoDatabase_Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp_DemoDatabase_Entity
{
     class Program
    {
         static void CreateDatabase()
        {
            using var dbcontext = new ProductDbContext();
            
                String dbname = dbcontext.Database.GetDbConnection().Database;// mydata

                var rs =  dbcontext.Database.EnsureCreated();

            if (rs)
            {
                Console.WriteLine($"Tao db {dbname} thanh cong");
            }
            else
            {
                Console.WriteLine($"Tao db {dbname} that bai");
            }  
            
        }
        static void DropDatabase()
        {
            using var dbcontext = new ProductDbContext();

            String dbname = dbcontext.Database.GetDbConnection().Database;// mydata

            var rs = dbcontext.Database.EnsureDeleted();

            if (rs)
            {
                Console.WriteLine($"Xoa db {dbname} thanh cong");
            }
            else
            {
                Console.WriteLine($"Xoa db {dbname} that bai");
            }

        }

        static void InsertProduct()
        {
          using var dbcontext = new ProductDbContext();

            /* them 1 du lieu **/
            //var p1 = new Product()
            //{
            //    Name = "San pham 1",
            //    Provider = "Cong ty A",
            //};

            //dbcontext.Add(p1);

            /* them mot mang nhieu du lieu **/

            var products = new object[]
            {
                new Product(){Name = "San pham 3",Provider = "CTY A"},
                new Product(){Name = "San pham 4",Provider = "CTY B"},
                new Product(){Name = "San pham 5",Provider = "CTY C"},
            };

            dbcontext.AddRange(products);

            int row = dbcontext.SaveChanges();
            Console.WriteLine($"Da chen {row} du lieu");
        }

        static void ReadProduct()
        {
            using var dbcontext = new ProductDbContext();

            var products = dbcontext.Products.ToList();
            products.ForEach(p => p.PrintInfo());

            //Linq

            //var qr = from product in dbcontext.Products
            //         where product.ProductId >= 2
            //         select product;


            //var qr = from product in dbcontext.Products
            //         where product.Provider.Contains("CTY")
            //         orderby product.ProductId descending //giam dan
            //         select product;

            //qr.ToList().ForEach(p => p.PrintInfo());


            //Product product = (from p in dbcontext.Products
            //                  where p.Name == "San pham 2"
            //                  select p).FirstOrDefault();
            //if(product != null)
            //    product.PrintInfo();    
        }
        static void Main(string[] args)
        {
            /* Tao co so du lieu **/
            //  CreateDatabase();

            /* Xoa co so du lieu **/
            // DropDatabase(); 

            /* Insert,update,delete **/
            // InsertProduct();

            ReadProduct();


        }
    }
}
