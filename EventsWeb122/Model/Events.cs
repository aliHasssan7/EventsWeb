using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsWeb122.Model
{
    public class Events : EntityBase
    {
        [Required]
        public string EventName { get; set; }
        public string Desription { get; set; }
        public string ImgeUrl { get; set; }
        
        public DateTime Date { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
