using System.ComponentModel.DataAnnotations;

namespace Task_ToDo_API_DAL.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string? UserName { get; set; }

        public string? UserId { get; set; }

    }
}
