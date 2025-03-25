using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trilha_net_azure.Data;
using trilha_net_azure.Models;
using trilha_net_azure.Models.DbHrContext;

namespace trilha_net_azure.Controllers
{
    public class PortalController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PortalController(ApplicationDbContext db)
        {
            _db = db; 
        }

        public IActionResult AuxHome()
        {

            return RedirectToAction("Index", new Login { Email = "test@email.com", Password = "hrmasteriscool" });
        }

        public async Task<IActionResult> Index(Login model)
        {
            if(ModelState.IsValid)
            {
                if (model.Email == "test@email.com" && model.Password == "hrmasteriscool")
                {
                    List<Employee> listEmployee = new List<Employee>();

                    try
                    {
                        var queryEmployee = await _db.Employee.ToListAsync();
                        if (queryEmployee.Count > 0) listEmployee = queryEmployee;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }   
                    return View(listEmployee);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logs()
        {
            List<Log> model = new List<Log>();
            try
            {
                var queryLogs = await _db.Log.ToListAsync();
                if (queryLogs.Count > 0) model = queryLogs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(model);
        }

        public async Task<IActionResult> CreateEmployee()
        {
            

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var queryExisting = await _db.Employee.FirstOrDefaultAsync(e => e.Email == model.Email);

                    if(queryExisting != null)
                    {
                        TempData["ErrorMessage"] = "The email was already taken.";
                        return View();
                    }

                    var result = await _db.Employee.AddAsync(model);
                    _db.SaveChanges();
                    CreateLog("Create", $"Employee {model.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return RedirectToAction("Index", new Login { Email = "test@email.com", Password = "hrmasteriscool"});
        }

        public async Task<IActionResult> EditEmployee(int Id)
        {
            Employee model = new Employee();
            try
            {
                var queryEmployee = await _db.Employee.FirstOrDefaultAsync(e => e.Id == Id);

                if (queryEmployee == null)
                {
                    TempData["ErrorMessage"] = "The employee was not found.";
                    return View();
                }

                model = queryEmployee;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var queryExisting = await _db.Employee.AsNoTracking().FirstOrDefaultAsync(e => e.Id == model.Id);

                    if (queryExisting == null)
                    {
                        TempData["ErrorMessage"] = "Something went wrong.";
                        return View(model);
                    }

                    var result = _db.Employee.Update(model);
                    _db.SaveChanges();

                    CreateLog("Update", $"Employee {model.Name}");
                    TempData["SuccessMessage"] = $"The user {model.Name} was successfully updated.";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return RedirectToAction("Index", new Login { Email = "test@email.com", Password = "hrmasteriscool" });
        }

        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            Employee model = new Employee();
            try
            {
                var queryEmployee = await _db.Employee.FirstOrDefaultAsync(e => e.Id == Id);

                if (queryEmployee == null)
                {
                    TempData["ErrorMessage"] = "The employee was not found.";
                    return View();
                }

                model = queryEmployee;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(Employee model)
        {
            try
            {
                var queryExisting = await _db.Employee.AsNoTracking().FirstOrDefaultAsync(e => e.Id == model.Id);
                if(queryExisting != null)
                {
                    Employee employee = queryExisting;
                    var result = _db.Employee.Remove(employee);
                    _db.SaveChanges();
                }
                CreateLog("Delete", $"Employee {model.Name}");
                TempData["SuccessMessage"] = $"The user {model.Name} was successfully updated.";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return RedirectToAction("Index", new Login { Email = "test@email.com", Password = "hrmasteriscool" });
        }

        public async Task<IActionResult> EmployeeDetail(int id)
        {
            Employee model = new Employee();
            var queryEmployee = await _db.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (queryEmployee != null) model = queryEmployee;

            return View(model);
        }

        public void CreateLog(string action, string propName)
        {
            Log newLog = new Log()
            {
                Action = action,
                MyProperty = propName,
                Timestamp = DateTime.Now
            };
            _db.Log.Add(newLog);
            _db.SaveChanges();
        }

    }
}
