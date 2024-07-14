using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FormSubmissionService
    {
        private readonly Context _context;

        public FormSubmissionService(Context context)
        {
            _context = context;
        }

        public async Task SubmitFormAsync(FormSubmission formSubmission)
        {
            _context.FormSubmissions.Add(formSubmission);
            await _context.SaveChangesAsync();
        }
    }
}
