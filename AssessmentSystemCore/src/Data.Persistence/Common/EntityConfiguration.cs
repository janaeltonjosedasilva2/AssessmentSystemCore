using AssessmentSystemCore.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Data.Persistence.Common
{
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureKey(builder);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(x => x.RegisteDate)
                .IsRequired()
                .HasColumnName("RegisteDate");

            builder.Property(x => x.LastUpdate)
                .IsRequired()
                .HasColumnName("LastUpdate");

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("IsActive");
        }

        public virtual void ConfigureKey(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
