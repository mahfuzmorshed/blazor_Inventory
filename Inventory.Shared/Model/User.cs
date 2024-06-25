using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Inventory.Shared.Model
{
    [Table("User",Schema ="dbo")]
    public class User
    {
        [Key]
        public int Id {get; set;}
        public string FirstName {get; set;} = default!;
        public string LastName {get; set;} = default!;
        public string Username {get; set;} = default!;
        public string Password {get; set;} = default!;
        public string? Token {get; set;} = default!;
        public bool IsDeleting {get; set;} = default!;
        [JsonIgnore]
        public string? PasswordHash {get; set;}
    }
}