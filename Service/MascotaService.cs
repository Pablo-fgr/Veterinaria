using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;
using Veterinaria.DB;

namespace Veterinaria.Service
{
    public class MascotaService
    {
        private readonly VeterinariaDBContext _context;

        public MascotaService(VeterinariaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Mascota>> GetAllMascotas()
        {
            return await _context.Mascotas
                .Include(m => m.Owner)
                .ToListAsync();
        }

        public async Task<Mascota?> GetMascotaById(int id)
        {
            return await _context.Mascotas
                .Include(m => m.Owner)
                .FirstOrDefaultAsync(m => m.IdMascota == id);
        }

        public async Task<bool> SaveMascota(Mascota mascota)
        {
            try
            {
                if (mascota.IdMascota == 0)
                {
                    // Es una mascota nueva
                    await _context.Mascotas.AddAsync(mascota);
                }
                else
                {
                    // Es una edición
                    _context.Mascotas.Update(mascota);
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

        public async Task<List<Mascota>> GetMascotasByOwnerId(int idDueño)
        {
            return await _context.Mascotas
                .Where(m => m.IdOwner == idDueño)
                .ToListAsync();
        }
    }
}
