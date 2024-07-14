using DataAccessLayer;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class FormService
    {
        private readonly Context _context;

        public FormService(Context context)
        {
            _context = context;
        }

        public async Task<List<Form>> GetFormsAsync()
        {
            return await _context.Forms.Include(f => f.Fields).ToListAsync();
        }

        public async Task<Form> GetFormByIdAsync(int id)
        {
            return await _context.Forms
                .Include(f => f.Fields)
                .Include(f => f.Submissions)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task CreateFormAsync(Form form)
        {
            _context.Forms.Add(form);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFormAsync(Form form)
        {
            _context.Forms.Update(form);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFormAsync(int id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form != null)
            {
                _context.Forms.Remove(form);
                await _context.SaveChangesAsync();
            }
        }
    }
}
