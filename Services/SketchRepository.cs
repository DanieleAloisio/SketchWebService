using Microsoft.EntityFrameworkCore;
using SketchWebService.Interface;
using SketchWebService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SketchWebService.Services
{
    public class SketchRepository : ISketchRepository
    {
        private readonly SketchArtDbContext _context;

        public SketchRepository(SketchArtDbContext context)
        {
            _context = context;
        }

        public async Task<Artist> GetLoggedArtist(string usernameLogin)
        {
            return await _context.Artists
                                 .Include(x => x.User)
                                 .FirstOrDefaultAsync(x => x.User.Username == usernameLogin);

        }

        public async Task<ICollection<Artist>> GetArtists()
        {
            return await _context.Artists
                                 .Include(x => x.Sketchs)
                                 .ToListAsync();
        }
    }
}
