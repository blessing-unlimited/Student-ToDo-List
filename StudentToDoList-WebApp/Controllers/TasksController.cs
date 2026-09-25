using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using StudentToDoList_WebApp.Models;

namespace StudentToDoList_WebApp.Controllers
{
    public class TasksController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public TasksController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private HttpClient GetClient() => _httpClientFactory.CreateClient("ApiClient");

        public async Task<IActionResult> Index()
        {
            var tasks = await GetClient().GetFromJsonAsync<List<Tasks>>("api/tasks");
            return View(tasks ?? new List<Tasks>());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
                return NotFound();
            var tasks = await GetClient().GetFromJsonAsync<Tasks>($"api/tasks/{id}");
            return View(tasks);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tasks task)
        {
            if (!ModelState.IsValid)
                return View(task);

            var response = await GetClient().PostAsJsonAsync($"api/tasks", task);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Could not save task");
                return View(task);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var task = await GetClient().GetFromJsonAsync<Tasks>($"api/tasks/{id}");
            if (task is null)
                return NotFound();
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tasks task)
        {
            if (!ModelState.IsValid)
                return View(task);

            var response = await GetClient().PutAsJsonAsync($"api/tasks/{id}", task);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Could not update task");
                return View(task);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var task = await GetClient().GetFromJsonAsync<Tasks>($"api/tasks/{id}");
            if (task is null)
                return NotFound();
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await GetClient().DeleteAsync($"api/tasks/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
