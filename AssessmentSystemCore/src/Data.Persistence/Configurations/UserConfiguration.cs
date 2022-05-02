using AssessmentSystemCore.Data.Persistence.Common;
using AssessmentSystemCore.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Data.Persistence.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("User");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email");
        }

        //To configure composite key
        //public override void ConfigureKey(EntityTypeBuilder<User> builder)
        //{
        //    //
        //}
    }
}
