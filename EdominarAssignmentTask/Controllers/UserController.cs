using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace EdominarAssignmentTask.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepositiory _data;

        public UserController(IUserRepositiory data)
        {
            _data = data;
        }

        public async Task<IActionResult> Index()
        {

            var states = await _data.GetStates();
            var hobbies = await _data.GetHobbies();
            ViewBag.hobbies = hobbies;
            ViewBag.states = states;
            ViewBag.gender = new[] { "Male", "Female", "Other" };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _data.AddUser(user);
                return RedirectToAction("Show");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please fill out all the required fields");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Show()
        {

            var userInfo = await _data.GetUsers();
            return View(userInfo);
        }

        [HttpGet]
        public async Task<JsonResult> ShowById(int Id)
        {
            var userData = await _data.GetUserById(Id);
            return Json(userData);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _data.DeleteUser(Id);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var user = await _data.GetUserById(Id);
            var states = await _data.GetStates();
            var hobbies = await _data.GetHobbies();
            ViewBag.hobbies = hobbies;
            ViewBag.states = states;
            ViewBag.gender = new[] { "Male", "Female", "Other" };
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(User user)
        {
            if (ModelState.IsValid)
            {

                await _data.UpdateUser(user);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please fill out all the required fields");
            }

            return RedirectToAction("Show");
        }




    }
}
