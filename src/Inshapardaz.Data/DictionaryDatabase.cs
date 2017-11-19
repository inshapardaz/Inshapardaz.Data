using Inshapardaz.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inshapardaz.Data
{
    public class DictionaryDatabase : DbContext, IDictionaryDatabase
    {
        public DictionaryDatabase(DbContextOptions<DictionaryDatabase> context)
            :base(context)
        {
        }

        public virtual DbSet<Dictionary> Dictionary { get; set; }
        public virtual DbSet<Meaning> Meaning { get; set; }
        public virtual DbSet<Translation> Translation { get; set; }
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<WordRelation> WordRelation { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.ToTable("Dictionary");
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.UserId).HasMaxLength(50);
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.ToTable("Word");

                entity.HasOne(d => d.Dictionary)
                      .WithMany(p => p.Word)
                      .HasForeignKey(d => d.DictionaryId)
                      .HasConstraintName("FK_Word_Dictionary")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Meaning>(entity =>
            {
                entity.ToTable("Meaning");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.Meaning)
                    .HasForeignKey(d => d.WordId)
                    .HasConstraintName("FK_Meaning_Word")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Translation>(entity =>
            {
                entity.ToTable("Translation");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.Translation)
                    .HasForeignKey(d => d.WordId)
                    .HasConstraintName("FK_Translation_WordDetail")
                    .OnDelete(DeleteBehavior.Cascade);
            });
            

            modelBuilder.Entity<WordRelation>(entity =>
            {
                entity.ToTable("WordRelation");

                entity.HasOne(d => d.RelatedWord)
                    .WithMany(p => p.WordRelationRelatedWord)
                    .HasForeignKey(d => d.RelatedWordId)
                    .HasConstraintName("FK_WordRelation_RelatedWord")
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.SourceWord)
                    .WithMany(p => p.WordRelationSourceWord)
                    .HasForeignKey(d => d.SourceWordId)
                    .HasConstraintName("FK_WordRelation_SourceWord")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}