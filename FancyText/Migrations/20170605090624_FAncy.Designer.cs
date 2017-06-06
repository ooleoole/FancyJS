using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FancyText.Migrations
{
    [DbContext(typeof(FancyContext))]
    [Migration("20170605090624_FAncy")]
    partial class FAncy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FancyText.Model.FancyText", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Color");

                    b.Property<int>("FancyTextCompositionId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("FancyTextCompositionId");

                    b.ToTable("FancyTexts");
                });

            modelBuilder.Entity("FancyText.Model.FancyTextComposition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("FancyTextComposition");
                });

            modelBuilder.Entity("FancyText.Model.FancyText", b =>
                {
                    b.HasOne("FancyText.Model.FancyTextComposition", "FancyTextComposition")
                        .WithMany("FancyTexts")
                        .HasForeignKey("FancyTextCompositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
