using BusinessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace LenaBackendDeveloperProject.Controllers
{
    public class FormController : Controller
    {
        private readonly FormService _formService;

        public FormController(FormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var forms = await _formService.GetFormsAsync();
            return View(forms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Form form)
        {
            if (ModelState.IsValid)
            {
                await _formService.CreateFormAsync(form);
                return RedirectToAction("Index");
            }
            return View(form);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var form = await _formService.GetFormByIdAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Form form)
        {
            if (ModelState.IsValid)
            {
                await _formService.UpdateFormAsync(form);
                return RedirectToAction("Index");
            }
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _formService.DeleteFormAsync(id);
            return RedirectToAction("Index");
        }
    }
}
