
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JobFinder.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Data.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder
                .HasKey(j => j.Id);

            builder
                .Property(j => j.Id)
                .UseIdentityColumn();
                
            builder
                .Property(j => j.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(j => j.Organization)
                .WithMany(o => o.OrganizationJobs)
                .HasForeignKey(j => j.OrganizationId);

            builder
                .HasMany(u => u.SavedUsers)
                .WithMany(j => j.SavedJobs);

            builder
                .ToTable("Jobs");
        }
    }
}