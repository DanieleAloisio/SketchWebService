using System.ComponentModel.DataAnnotations;


namespace SketchWebService.Models
{
    public class Sketch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdArtist { get; set; }

        [Required]
        public string SketchName { get; set; }
        [Required]
        public string Photo { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
