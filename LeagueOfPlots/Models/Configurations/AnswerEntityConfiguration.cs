using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueOfPlots.Models.Configurations
{
    public class AnswerEntityConfiguration : IEntityTypeConfiguration<AnswerModel>
    {
        public void Configure(EntityTypeBuilder<AnswerModel> builder)
        {
            builder.ToTable("Answer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ASR_ID").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Content).HasColumnName("ASR_CONTENT").IsRequired();
        }
    }
}
