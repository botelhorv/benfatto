using BenFatto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BenFatto.Data.Mapping
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.SourceIP)
                .IsRequired()
                .HasColumnName("SourceIP");

            builder.Property(c => c.Channel)
               .IsRequired()
               .HasColumnName("Channel");

            builder.Property(c => c.Created)
               .IsRequired()
               .HasColumnName("Created");

            builder.Property(c => c.Method)
               .IsRequired()
               .HasColumnName("Method");

            builder.Property(c => c.Url)
                .IsRequired()
                .HasColumnName("Url");

            builder.Property(c => c.HttpVersion)
                .IsRequired()
                .HasColumnName("HttpVersion");

            builder.Property(c => c.HttpCode)
                .IsRequired()
                .HasColumnName("HttpCode");

            builder.Property(c => c.UrlDestination)
                .IsRequired()
                .HasColumnName("UrlDestination");

            builder.Property(c => c.Port)
                .IsRequired()
                .HasColumnName("Port");

            builder.Property(c => c.BrowserAgent)
                .IsRequired()
                .HasColumnName("BrowserAgent");

        }
    }
}
