using System.Collections.Generic;

namespace Inshapardaz.Data.Entities
{
    public class Word
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string TitleWithMovements { get; set; }
        public string Description { get; set; }
        public string Pronunciation { get; set; }
        public GrammaticalTypes Attributes { get; set; }
        public Languages Language { get; set; }
        public int DictionaryId { get; set; }

        public virtual ICollection<Meaning> Meaning { get; set; }
        public virtual ICollection<Translation> Translation { get; set; }
        public virtual ICollection<WordRelation> WordRelationRelatedWord { get; set; } = new HashSet<WordRelation>();
        public virtual ICollection<WordRelation> WordRelationSourceWord { get; set; } = new HashSet<WordRelation>();
        public virtual Dictionary Dictionary { get; set; }
    }
}