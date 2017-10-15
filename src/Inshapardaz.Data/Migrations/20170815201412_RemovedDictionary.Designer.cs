﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Inshapardaz.Data;
using Inshapardaz.Data.Entities;

namespace Inshapardaz.Data.Migrations
{
    [DbContext(typeof(DictionaryDatabase))]
    [Migration("20170815201412_RemovedDictionary")]
    partial class RemovedDictionary
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Inshapardaz.Data.Entities.Meaning", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Context");

                    b.Property<string>("Example");

                    b.Property<string>("Value");

                    b.Property<long>("WordDetailId");

                    b.HasKey("Id");

                    b.HasIndex("WordDetailId");

                    b.ToTable("Meaning");
                });

            modelBuilder.Entity("Inshapardaz.Data.Entities.Translation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Language");

                    b.Property<string>("Value");

                    b.Property<long>("WordDetailId");

                    b.HasKey("Id");

                    b.HasIndex("WordDetailId");

                    b.ToTable("Translation");
                });

            modelBuilder.Entity("Inshapardaz.Data.Entities.Word", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DictionaryId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Pronunciation");

                    b.Property<string>("Title");

                    b.Property<string>("TitleWithMovements");

                    b.HasKey("Id");

                    b.ToTable("Word");
                });

            modelBuilder.Entity("Inshapardaz.Data.Entities.WordDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Attributes");

                    b.Property<int>("Language");

                    b.Property<long>("WordInstanceId");

                    b.HasKey("Id");

                    b.HasIndex("WordInstanceId");

                    b.ToTable("WordDetail");
                });

            modelBuilder.Entity("Inshapardaz.Data.Entities.WordRelation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("RelatedWordId");

                    b.Property<int>("RelationType");

                    b.Property<long>("SourceWordId");

                    b.HasKey("Id");

                    b.HasIndex("RelatedWordId");

                    b.HasIndex("SourceWordId");

                    b.ToTable("WordRelation");
                });

            modelBuilder.Entity("Inshapardaz.Data.Entities.Meaning", b =>
                {
                    b.HasOne("Inshapardaz.Data.Entities.WordDetail", "WordDetail")
                        .WithMany("Meaning")
                        .HasForeignKey("WordDetailId")
                        .HasConstraintName("FK_Meaning_WordDetail");
                });

            modelBuilder.Entity("Inshapardaz.Data.Entities.Translation", b =>
                {
                    b.HasOne("Inshapardaz.Data.Entities.WordDetail", "WordDetail")
                        .WithMany("Translation")
                        .HasForeignKey("WordDetailId")
                        .HasConstraintName("FK_Translation_WordDetail");
                });

            modelBuilder.Entity("Inshapardaz.Data.Entities.WordDetail", b =>
                {
                    b.HasOne("Inshapardaz.Data.Entities.Word", "WordInstance")
                        .WithMany("WordDetail")
                        .HasForeignKey("WordInstanceId")
                        .HasConstraintName("FK_WordDetail_Word");
                });

            modelBuilder.Entity("Inshapardaz.Data.Entities.WordRelation", b =>
                {
                    b.HasOne("Inshapardaz.Data.Entities.Word", "RelatedWord")
                        .WithMany("WordRelationRelatedWord")
                        .HasForeignKey("RelatedWordId")
                        .HasConstraintName("FK_WordRelation_RelatedWord");

                    b.HasOne("Inshapardaz.Data.Entities.Word", "SourceWord")
                        .WithMany("WordRelationSourceWord")
                        .HasForeignKey("SourceWordId")
                        .HasConstraintName("FK_WordRelation_SourceWord");
                });
        }
    }
}