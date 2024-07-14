using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Form
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; } // User entity ile ilişkilendirilecek.
        public User CreatedByUser { get; set; } // Navigation property

        public ICollection<FormField> Fields { get; set; }
        public ICollection<FormSubmission> Submissions { get; set; }
    }
}
