using SketchWebService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SketchWebService.Interface
{
    public interface ISketchRepository
    {
        Task<Artist> GetLoggedArtist(string username);
        Task<ICollection<Artist>> GetArtists();
    }
}
