using eval.Web.ApiConfig;
using eval.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

namespace eval.Web.Controllers
{
    [Authorize]
    public class MatchController : Controller
    {
        public MatchController()
        {
            ApiHelper.InitializeClient();
        }
        public async Task<IActionResult> Index()
        {
            var response = await ApiHelper.ApiClient.GetAsync("username?username=" + User.Identity.Name);
            var result = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<MatchViewModel> match = JsonSerializer.Deserialize<List<MatchViewModel>>(result, options);
            return View(match);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateMatch(CreateMatchViewModel model)
        {
            model.UserName = User.Identity.Name;
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await ApiHelper.ApiClient.PostAsync("", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return Ok(responseString);
        }
    }
}
