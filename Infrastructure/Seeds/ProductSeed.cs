using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id= 1,
                    Name="Prdouct 1",
                    Price=500,
                    CategoryId=1,
                    CreatedDate=DateTime.Now,
                },
                 new Product
                 {
                     Id = 2,
                     Name = "Prdouct 2",
                     Price = 500,
                     CategoryId =1,
                     CreatedDate = DateTime.Now,
                 },
                  new Product
                  {
                      Id = 3,
                      Name = "Prdouct 3",
                      Price = 500,
                      CategoryId =1,
                      CreatedDate = DateTime.Now,
                  }
                );
        }
    }
}
