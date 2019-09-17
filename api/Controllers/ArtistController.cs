
using System;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Services;

namespace api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _ArtistService;
        
        public ArtistController(IArtistService artistSvc){
            _ArtistService = artistSvc;
        }

        [HttpGet]
        public IActionResult GetAll(){
            try
            {
                var items = _ArtistService.GetAll();
                return Ok(items);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id){
            try
            {
                var item = _ArtistService.GetById(id);
                return Ok(item);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("{id}")]
        [Route("")]
        public IActionResult Store([FromBody]Artist param, int id)
        {
            try
            {
                if (id > 0 )
                {
                    param.ID = id;
                }
                _ArtistService.Store(param);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}