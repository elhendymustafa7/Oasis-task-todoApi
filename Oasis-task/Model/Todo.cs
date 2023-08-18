using Oasis_task.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oasis_task.Model
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Completed is required")]
        [Column(TypeName = "bit")]
        public bool Completed { get; set; }
        // Foreign key   
        public virtual int UserId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual User User { get; set; }
    }
}
