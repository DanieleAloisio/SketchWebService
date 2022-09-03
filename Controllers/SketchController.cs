using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SketchWebService.ErrorModel;
using SketchWebService.Interface;
using SketchWebService.Models;
using SketchWebService.Services;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace SketchWebService.Controllers
{
    [ApiController]
    [Route("Api/Sketchs")]
    public class SketchController : ControllerBase
    {
        private readonly ISketchRepository _sketchRepository;
        public SketchController(ISketchRepository sketchRepository)
        {
            _sketchRepository = sketchRepository; //ok
        }

        [HttpGet("loggedUser/{username}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Artist))]
        [Authorize(Roles = "Admin, User")]

        public async Task<ActionResult<Artist>> GetLoggedArtist(string username)
        {
            var artist = await this._sketchRepository.GetLoggedArtist(username);

            if (artist == null)
            {
                return NotFound(
                    new ErrMsg("Si è verificato un errore nel recupero dati.",
                    this.HttpContext.Response.StatusCode));
            }

            return Ok(artist);
        }

        [HttpGet("artists")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Artist>))]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            var artists = await this._sketchRepository.GetArtists();

            if (artists == null || artists.Count == 0)
            {
                return NotFound(
                    new ErrMsg("Si è verificato un errore nel recupero dati.",
                    this.HttpContext.Response.StatusCode));
            }

            return Ok(artists);
        }


    }
}
