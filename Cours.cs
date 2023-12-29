namespace FluentAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Cours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cours()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Level { get; set; }
        public virtual Cover Cover {  get; set; } 
        public float FullPrice { get; set; }
        public int AuthorID { set; get; }
        public virtual Author Author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
