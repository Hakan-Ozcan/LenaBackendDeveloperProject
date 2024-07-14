using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class FormField
    {
        public int Id { get; set; }
        public int FormId { get; set; } // Hangi formun alanı olduğunu belirtmek için
        public Form Form { get; set; } // Navigation property
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool Required { get; set; }

        public ICollection<FormSubmissionField> FormSubmissionFields { get; set; }
    }
}
