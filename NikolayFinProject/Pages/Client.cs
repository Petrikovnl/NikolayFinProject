using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace NikolayFinProject.Pages
{
    public class Client
    {
        public ObjectId _id { get; set; }
        [Required]
        [MaxLength(5)]
        public string Name { get; set; }    
    }
}
