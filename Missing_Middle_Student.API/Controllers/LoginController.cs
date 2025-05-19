using Microsoft.AspNetCore.Mvc;
using Missing_Middle_Student.Model;
namespace Missing_Middle_Student.API.Controllers
{

    public class LoginController : Controller
        {
            // GET: Login - Show the Login Form
            public ActionResult Index()
            {
                return View();
            }

            // POST: Login - Handle login logic
            [HttpPost]
            public ActionResult Index(LoginModel model)
            {
                if (ModelState.IsValid)
                {
                    // Simulated database credentials for the sake of the example
                    string storedEmail = "student1@tut4life.ac.za";
                    string storedPassword = "Test@123"; // Ideally, this would be a hashed password

                    if (model.Email == storedEmail && model.Password == storedPassword)
                    {
                        if (IsValidPassword(model.Password))
                        {
                            // Redirect to another page (e.g., Dashboard)
                            return RedirectToAction("Dashboard", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Password does not meet the security requirements.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid email or password.");
                    }
                }

                return View(model);
            }

            // Validate password length, letter, and special character
            private bool IsValidPassword(string password)
            {
                if (password.Length >= 8)
                {
                    var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[a-zA-Z])(?=.*[\W_]).{8,}$");
                    return regex.IsMatch(password);
                }
                return false;
            }
        }
    }



