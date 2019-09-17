using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var artist = new List<ArtistViewModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000");
                var resp = await client.GetAsync("/api/artist");
                if (resp.IsSuccessStatusCode)
                {
                    artist = await resp.Content.ReadAsAsync<List<ArtistViewModel>>();
                }
            }
            return View(artist);
        }

        [Route("Form/{id}")]
        [Route("Form")]
        public async Task<IActionResult> Form(int id)
        {
            var artist = new ArtistViewModel();
            if (id > 0){  
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5000");
                    var resp = await client.GetAsync("/api/artist/"+id.ToString());
                    if (resp.IsSuccessStatusCode)
                    {
                        artist = await resp.Content.ReadAsAsync<ArtistViewModel>();
                    }
                }
            } 
            return View(artist);
        }

        [HttpPost]
        [Route("Store")]
        public async Task<IActionResult> Store(ArtistViewModel artist)
        {
            using(var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(artist), Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("http://localhost:5000");
                var resp = await client.PostAsync("/api/artist", content);
                if (resp.IsSuccessStatusCode)
                {
                    return Redirect("/");
                }
            }
            return View();
        }
    }
}
