using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Model;
using API;
using System.Diagnostics.Contracts;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Net;


namespace Presentation.Controllers
{

    public class RepoInfo : Controller
    {
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            List<Repository> Repo_list = new List<Repository>();
            client.BaseAddress = new Uri("https://localhost:7202/api/repoapi");
            var response = client.GetAsync("repoapi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var result = test.Content.ReadAsAsync<List<Repository>>();
                result.Wait();
                Repo_list = result.Result;
            }
            return View(Repo_list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Repository repo)
        {
            if (ModelState.IsValid)
            {
                client.BaseAddress = new Uri("https://localhost:7202/api/repoapi");
                var response = client.PostAsJsonAsync<Repository>("repoapi", repo);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    TempData["success"] = "Data added successfully";
                    return RedirectToAction("Index");

                }
                return View();

            }
            return View();
        }

       
        public IActionResult Edit(int id)
        {
            Repository rp = new Repository();
            client.BaseAddress = new Uri("https://localhost:7202/api/repoapi");
             var response = client.GetAsync("repoapi/"+id);

            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var result = test.Content.ReadAsAsync<Repository>();
                result.Wait();
                rp = result.Result;
            }
            return View(rp);
        }
        
        [HttpPost]
        public IActionResult Edit(Repository rp) 
        {
            client.BaseAddress = new Uri("https://localhost:7202/api/repoapi");
            var response = client.PutAsJsonAsync<Repository>("repoapi", rp);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode) 
            {
                TempData["success"] = "Data updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            Repository rp = new Repository();
            client.BaseAddress = new Uri("https://localhost:7202/api/repoapi");
            var response = client.GetAsync("repoapi/" + id);

            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var result = test.Content.ReadAsAsync<Repository>();
                result.Wait();
                rp = result.Result;
            }
            return View(rp);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int id) 
        {
            client.BaseAddress = new Uri("https://localhost:7202/api/repoapi");
            var response= client.DeleteAsync("repoapi?id="+id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode) 
            {
                TempData["success"] = "Deleted successfully";
                return RedirectToAction("Index");
            }
            return View(id);
        }
        public IActionResult Details(int id) 
        {
            Repository rp = new Repository();
            client.BaseAddress = new Uri("https://localhost:7202/api/repoapi");
            var response = client.GetAsync("repoapi/" + id);

            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var result = test.Content.ReadAsAsync<Repository>();
                result.Wait();
                rp = result.Result;
            }
            return View(rp);
        }
    }
}
