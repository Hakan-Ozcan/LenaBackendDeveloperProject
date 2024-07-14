using BusinessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace LenaBackendDeveloperProject.Controllers
{
    public class FormSubmissionController : Controller
    {
        private readonly FormService _formService;
        private readonly FormSubmissionService _formSubmissionService;

        public FormSubmissionController(FormService formService, FormSubmissionService formSubmissionService)
        {
            _formService = formService;
            _formSubmissionService = formSubmissionService;
        }

        [HttpGet]
        public async Task<IActionResult> Submit(int formId)
        {
            var form = await _formService.GetFormByIdAsync(formId);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(FormSubmission formSubmission)
        {
            if (ModelState.IsValid)
            {
                await _formSubmissionService.SubmitFormAsync(formSubmission);
                return RedirectToAction("Index", "Form");
            }
            return View(formSubmission);
        }
    }
}
