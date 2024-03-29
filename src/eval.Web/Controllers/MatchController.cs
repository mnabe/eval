﻿using eval.Web.ApiConfig;
using eval.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using eval.Domain;

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
            var result = await response.Content.ReadAsAsync<List<Match>>();
            return View(result);
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
            await response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
            //return Ok(responseString);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await ApiHelper.ApiClient.GetAsync("?id=" + id);
            var result = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Match match = JsonSerializer.Deserialize<Match>(result, options);
            return View(match);
        }

        public async Task<IActionResult> EditMatch(EditMatchViewModel model)
        {
            model.UserName = User.Identity.Name;
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await ApiHelper.ApiClient.PutAsync("", content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await ApiHelper.ApiClient.GetAsync("?id=" + id);
            var result = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Match match = JsonSerializer.Deserialize<Match>(result, options);
            return View(match);
        }

        public async Task<IActionResult> DeleteMatch(int id)
        {
            await ApiHelper.ApiClient.DeleteAsync("?id=" + id);
            return RedirectToAction("Index");
        }
    }
}
