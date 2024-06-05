using EmployeeManagementSystem_Final.Data;
using Login_Register_Function.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmployeeManagementSystem_Final
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ApplicationDbContext _dbContext;
        public AccountController(ApplicationDbContext Context)
        {
            _dbContext = Context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                // Check if the email is already in use
                var existingUser = _dbContext.Account.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email is already registered.");
                }
                else
                {
                    _dbContext.Account.Add(user);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(user);

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User model)
        {if(ModelState.IsValid)
            {
             var user=   _dbContext.Account.FirstOrDefault(U=>U.Email == model.Email);
                if (user != null)
                {
                    // User exists, check if the password matches
                    if (user.Password == model.Password)
                    {
                        // Password matches, redirect to home page or any other action
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Password doesn't match, add error message to ModelState
                        ModelState.AddModelError("", "Invalid password.");
                    }
                }
                else
                {
                    // User does not exist, add error message to ModelState
                    ModelState.AddModelError("", "User does not exist.");
                }
            }
            return View(model);
        }
    }
}
