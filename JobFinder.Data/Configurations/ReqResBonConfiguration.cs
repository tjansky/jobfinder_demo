using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Data.Configurations
{
    public class ReqResBonConfiguration : IEntityTypeConfiguration<ReqResBon>
    {
        public void Configure(EntityTypeBuilder<ReqResBon> builder)
        {
             builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
                
            builder
                .Property(m => m.Name)
                .IsRequired();

            builder
                .Property(m => m.Type)
                .IsRequired();

            builder
                .HasOne(r => r.Job)
                .WithMany(j => j.ReqResBons)
                .HasForeignKey(r => r.JobId);

            builder
                .ToTable("ReqResBons");
        }
    }
}