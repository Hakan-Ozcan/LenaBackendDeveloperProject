using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class FormSubmission
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public Form Form { get; set; } // Navigation property
        public int UserId { get; set; }
        public User User { get; set; } // Navigation property
        public DateTime SubmittedAt { get; set; }
        public ICollection<FormSubmissionField> Fields { get; set; }
    }
}
