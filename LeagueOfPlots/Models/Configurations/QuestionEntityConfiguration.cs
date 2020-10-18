using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueOfPlots.Models.Configurations
{
    public class QuestionEntityConfiguration : IEntityTypeConfiguration<QuestionModel>
    {
        public void Configure(EntityTypeBuilder<QuestionModel> builder)
        {
            builder.ToTable("Question");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("QST_ID").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Content).HasColumnName("QST_CONTENT").IsRequired();
            builder.Property(x => x.AnswerId).HasColumnName("ASR_ID");
            builder.HasOne(x => x.Answer).WithOne(x => x.Question);
        }
}
}
