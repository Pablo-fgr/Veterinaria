using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;
using Veterinaria.DB;

namespace Veterinaria.Service
{
    public class AtencionService
    {
        private readonly VeterinariaDBContext _context;

        public AtencionService(VeterinariaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Atencion>> GetAllAtenciones()
        {
            return await _context.Atenciones
                .Include(a => a.Mascota)
                .ThenInclude(m => m.Owner)
                .OrderByDescending(a => a.FechaAtencion)
                .ToListAsync();
        }

        public async Task<Atencion?> GetAtencionById(int id)
        {
            return await _context.Atenciones
                .Include(a => a.Mascota)
                .ThenInclude(m => m.Owner)
                .FirstOrDefaultAsync(a => a.IdAtencion == id);
        }

        public async Task<bool> SaveAtencion(Atencion atencion)
        {
            try
            {
                if (atencion.IdAtencion == 0)
                {
                    // Es una atención nueva
                    await _context.Atenciones.AddAsync(atencion);
                }
                else
                {
                    // Es una edición
                    _context.Atenciones.Update(atencion);
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

        public async Task<List<Atencion>> GetAtencionesByMascotaId(int idMascota)
        {
            return await _context.Atenciones
                .Where(a => a.IdMascota == idMascota)
                .OrderByDescending(a => a.FechaAtencion)
                .ToListAsync();
        }
    }
}
