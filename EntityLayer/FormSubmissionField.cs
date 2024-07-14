using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class FormSubmissionField
    {
        public int Id { get; set; }
        public int FormSubmissionId { get; set; }
        public FormSubmission FormSubmission { get; set; } // Navigation property
        public int FormFieldId { get; set; }
        public FormField FormField { get; set; } // Navigation property
        public string Value { get; set; }
    }
}
