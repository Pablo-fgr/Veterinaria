using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;
using Veterinaria.DB;

namespace Veterinaria.Service
{
    public class DueñoService
    {
        private readonly VeterinariaDBContext _context;

        public DueñoService(VeterinariaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Dueño>> GetAllDueños()
        {
            return await _context.Dueños.ToListAsync();
        }

        public async Task<Dueño?> GetDueñoById(int id)
        {
            return await _context.Dueños.FindAsync(id);
        }

        public async Task<bool> SaveDueño(Dueño dueño)
        {
            try
            {
                if (dueño.IdDueño == 0)
                {
                    // Es un dueño nuevo
                    await _context.Dueños.AddAsync(dueño);
                }
                else
                {
                    // Es una edición
                    _context.Dueños.Update(dueño);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Aquí podrías loguear el error (ex.Message)
                return false;
            }
        }
    }
}