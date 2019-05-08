using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DEMO5.Models
{
    public partial class IdataContext : DbContext
    {
        public IdataContext()
        {
        }

        public IdataContext(DbContextOptions<IdataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TItemSourceList> TItemSourceList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<TItemSourceList>(entity =>
            {
                entity.ToTable("t_item_source_list");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Addtime)
                    .HasColumnName("addtime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.CntPerPage).HasColumnName("cnt_per_page");

                entity.Property(e => e.FirstPage)
                    .HasColumnName("first_page")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FirstPagePlus)
                    .HasColumnName("first_page_plus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FirstPageRatio)
                    .HasColumnName("first_page_ratio")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GatherPages)
                    .HasColumnName("gather_pages")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.GatherUrl).HasColumnName("gather_url");

                entity.Property(e => e.InfoUrl)
                    .HasColumnName("info_url")
                    .IsUnicode(false);

                entity.Property(e => e.IsGatherAllPages)
                    .HasColumnName("is_gather_all_pages")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsGatherInfopages)
                    .HasColumnName("is_gather_infopages")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsGenericGatherUrl).HasColumnName("is_generic_gather_url");

                entity.Property(e => e.ListBegin).HasColumnName("list_begin");

                entity.Property(e => e.ListCharset)
                    .HasColumnName("list_charset")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('utf-8')");

                entity.Property(e => e.ListEnd).HasColumnName("list_end");

                entity.Property(e => e.ListIspost)
                    .HasColumnName("list_ispost")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ListP1)
                    .HasColumnName("list_p1")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.ListP2)
                    .HasColumnName("list_p2")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.ListPattern).HasColumnName("list_pattern");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpcId).HasColumnName("opc_id");

                entity.Property(e => e.ParamResidual)
                    .HasColumnName("param_residual")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.RequestHeaders).HasColumnName("request_headers");

                entity.Property(e => e.SourceName)
                    .HasColumnName("source_name")
                    .HasMaxLength(96);

                entity.Property(e => e.SourceUrl).HasColumnName("source_url");

                entity.Property(e => e.TotalPages)
                    .HasColumnName("total_pages")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Valid)
                    .HasColumnName("valid")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.WdId).HasColumnName("wd_id");
            });
        }
    }
}
