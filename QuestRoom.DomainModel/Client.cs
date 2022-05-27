using System.ComponentModel.DataAnnotations;

namespace QuestRoom.DomainModel
{
    public class Client : BaseEntity
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        [Phone]
        public string Email { get; set; }

        [Required]
        [MaxLength(128)]
        [Phone]
        public string PhoneNumbe { get; set; }
    }
}