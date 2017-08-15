using Inshapardaz.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inshapardaz.Data
{
    public interface IDictionaryDatabase
    {
        DbSet<Meaning> Meaning { get; set; }
        DbSet<Translation> Translation { get; set; }
        DbSet<Word> Word { get; set; }
        DbSet<WordDetail> WordDetail { get; set; }
        DbSet<WordRelation> WordRelation { get; set; }

        int SaveChanges();

    }
}