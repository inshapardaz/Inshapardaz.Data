using System;
using Inshapardaz.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inshapardaz.Data
{
    public interface IDictionaryDatabase : IDisposable
    {
        DbSet<Dictionary> Dictionary { get; set; }
        DbSet<Meaning> Meaning { get; set; }
        DbSet<Translation> Translation { get; set; }
        DbSet<Word> Word { get; set; }
        DbSet<WordRelation> WordRelation { get; set; }

        int SaveChanges();

    }
}