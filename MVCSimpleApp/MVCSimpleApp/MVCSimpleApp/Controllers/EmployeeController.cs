using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

using MVCSimpleApp.Models; // MUST ADD THIS TO COMPILE MODEL

namespace MVCSimpleApp.Controllers
{
    public class EmployeeController : Controller
    {
        //needed for database use
        private EmpDBContext db = new EmpDBContext();

        //database GET
        //GET : Employee

        //INDEX -------------------------------

        //[OutputCache(Duration = 60)] //Output Caching added to Index
        [OutputCache(CacheProfile = "Cache10Min")] //this is using output cache set in web.config

        public ActionResult Index()
        {

            var employees = from e in db.Employees
                            orderby e.ID
                            select e;
            return View(employees);
        }


        // GET: Employee
        
        //using static index definition     
        /*
        public ActionResult Index()
        {
            //return View();
            var employees = from e in GetEmployeeList() // SQLish?
                            orderby e.ID
                            select e;
            return View(employees);

        }
        */

        //using database model
        
        //---DETAILS-----------------------------------------------

        // GET: Employee/Details/5
        [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public ActionResult Details(int id)
        {
            var employee = db.Employees.SingleOrDefault(e => e.ID == id);
            return View(employee);
        }

        //------CREATE ACTIONS -------------------------------

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }



        
        /*added code below for MANUAL BINDING - getting posted values from HTML view and 
         assigning them one by one. SIMPLE AND SMALL DATA MODEL'S, not ideal
        */        


        /*COMMENTING OUT TO USE MODEL BINDING INSTEAD

        // POST: Employee/Create - updated this to actually Create an employee
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                /*added code below for MANUAL BINDING - getting posted values from HTML view and 
                assigning them one by one. SIMPLE AND SMALL DATA MODEL'S, not ideal
                
                */
                /*
                Employee emp = new Employee(); //employee built from collection

                emp.Name = collection["Name"];

                DateTime jdate;
                DateTime.TryParse(collection["DOB"], out jdate);
                emp.JoiningDate = jdate;

                string age = collection["Age"];
                emp.Age = Int32.Parse(age);

                empList.Add(emp);
               
                //--- end of new code

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */

        /*Create Using MODEL BINDING - HTML input field same as the property names of the Employee
        Model Lines 26 and 27 on Create.cshtml

        //include database model for database use

        */

        //POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            //using class model
            /*
            try
            {
                empList.Add(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            */

            //Using Database model
            try
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //------EDIT ACTIONS-------------------------------------------

        // GET Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = db.Employees.Single(m => m.ID == id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var employee = db.Employees.Single(m => m.ID == id);
                if (TryUpdateModel(employee))
                {
                    //to Do: database code
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }

        }

        /*Commenting out previous Edit Actions

        // GET: Employee/Edit/5

        //-------------ACTION UPDATED--------------------------------------------- 
        public ActionResult Edit(int id)
        {
            //return View(); removed in update
            List<Employee> empList = GetEmployeeList();
            var employee = empList.Single(m => m.ID == id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        //---------------ACTION UPDATED------------------------------------------
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var employee = empList.Single(m => m.ID == id); //need to learn this syntax
                if (TryUpdateModel(employee))
                {
                    return RedirectToAction("Index");
                }
                return View(employee);
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        */

        //---DELETE ACTIONS ---------------------------------------------------

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //-----------PUBLIC LISTS----------------------------------------

        /*comment out when using the Database Model 

        [NonAction]
        public List<Employee> GetEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    ID = 1,
                    Name = "Allan",
                    JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                    Age = 23
                },

                new Employee
                {
                    ID = 2,
                    Name = "Carson",
                    JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                    Age = 45
                },

                new Employee
                {
                    ID = 3,
                    Name = "Laura",
                    JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                    Age = 26
                },

                new Employee
                {
                    ID = 4,
                    Name = "Walter",
                    JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                    Age = 38
                },
            };
        }
        
        //public employee list (can be used in any function)
        public static List<Employee> empList = new List<Employee>
        {
            new Employee
            {
                 ID = 1,
                 Name = "Allan",
                 JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                 Age = 23
            },

            new Employee
                {
                    ID = 2,
                    Name = "Carson",
                    JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                    Age = 45
                },

            new Employee
                {
                    ID = 3,
                    Name = "Laura",
                    JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                    Age = 26
                },

            new Employee
                {
                    ID = 4,
                    Name = "Walter",
                    JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                    Age = 38
                },

        };

        public ActionResult Index()
        {
            var employees = from e in empList
                            orderby e.ID
                            select e;
            return View(employees);
                        
        }
        */
    }


}
