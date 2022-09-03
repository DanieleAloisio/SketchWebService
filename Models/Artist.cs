using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SketchWebService.Models
{
    public class Artist
    {
        [Key]
        public int IdArtist { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Style { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Photo { get; set; }
        
        public virtual User User { get; set; }
        public virtual ICollection<Sketch> Sketchs { get; set; }

    }
}
