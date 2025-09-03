using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Talabat.Repository.Data.Config
{
    internal class ProductCategoryConfigurations : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(C => C.Name)
                .IsRequired();
        }
    }
}


