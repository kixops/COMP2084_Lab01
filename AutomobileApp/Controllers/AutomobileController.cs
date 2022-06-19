//using AutomobileApp.Models.Automobile;
using AutomobileApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileApp.Controllers
{
    public class AutomobileController : Controller
    {
        private readonly NewAutomobileContext _context;
        public AutomobileController(NewAutomobileContext context)
        {
            _context = context;
        }
        // GET: Automobile
        public ActionResult Index()
        {
            var automobiles = _context.AutoMobileCompany.ToList();
            return View(automobiles);
        }

        // GET: Automobile/Details/5
        public ActionResult AutomobileDetail(int id)
        {
            var automobile = _context.AutoMobileCompany.Find(id);

            if (automobile == null)
            {
                return NotFound();
            }
            return View(automobile);
            //return View();
        }

        // GET: Automobile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Automobile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Automobile/Edit/5
        public ActionResult AddEditAutomobile(int? id)
        {
            var automobile = _context.AutoMobileCompany.Find(id);
            ViewBag.IsEdit = id == null ? false : true;
            if (id == null)
            {
                ViewBag.PageName = "Add Automobile Company";
                return View();
            }
            if (automobile == null)
            {
                return NotFound();
            }

            ViewBag.PageName = "Update Automobile Company";
            return View(automobile);
            //return View();
        }

        // POST: Automobile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveData([Bind("CompanyId,Name,Foundation")] AutoMobileCompany automobileData)
        {
            bool isAlreadyExist = false;
            AutoMobileCompany autoMobileCompany = _context.AutoMobileCompany.Find(automobileData.CompanyId);

            if (autoMobileCompany != null)
            {
                isAlreadyExist = true;
            }
            else
            {
                autoMobileCompany = new AutoMobileCompany();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        autoMobileCompany.Name = automobileData.Name;
                        autoMobileCompany.Foundation = automobileData.Foundation;
                        autoMobileCompany.CreatedDateTime = DateTime.UtcNow;

                        if (isAlreadyExist)
                        {
                            _context.Update(autoMobileCompany);
                        }
                        else
                        {
                            _context.Add(autoMobileCompany);
                        }
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex.InnerException;
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(automobileData);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Automobile/Delete/5
        public ActionResult DeleteAutomobile(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var autoMobile = _context.AutoMobileCompany.FirstOrDefault(m => m.CompanyId == id);

            return View(autoMobile);
            //return View();
        }

        // POST: Automobile/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int companyId)
        {
            try
            {
                var autoMobile = _context.AutoMobileCompany.Find(companyId);
                _context.AutoMobileCompany.Remove(autoMobile);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CarList()
        {
            var cars = _context.Cars.Include(x => x.Company).ToList();

            return View("~/Views/Automobile/Car/CarList.cshtml", cars);
        }


        // GET: Car/Edit/5
        public ActionResult AddEditCar(int? id)
        {
            var autoMobileCompany = _context.AutoMobileCompany.ToList();
            ViewBag.Company = autoMobileCompany;
            var car = _context.Cars.Find(id);
            ViewBag.IsEdit = id == null ? false : true;
            if (id == null)
            {
                ViewBag.PageName = "Add New Car";
                return View("~/Views/Automobile/Car/AddEditCar.cshtml");
            }
            if (car == null)
            {
                return NotFound();
            }

            ViewBag.PageName = "Update Car";
            ViewBag.CompanyId = car.CompanyId;
            return View("~/Views/Automobile/Car/AddEditCar.cshtml", car);
            //return View();
        }

        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCarData(Cars carData)
        {
            bool isAlreadyExist = false;
            Cars car = _context.Cars.Find(carData.CarId);

            if (car != null)
            {
                isAlreadyExist = true;
            }
            else
            {
                car = new Cars();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        car.Name = carData.Name;
                        car.Model = carData.Model;
                        car.Foundation = carData.Foundation;
                        car.CreatedDateTime = DateTime.UtcNow;
                        car.CompanyId = carData.CompanyId;

                        if (isAlreadyExist)
                        {
                            _context.Update(car);
                        }
                        else
                        {
                            _context.Add(car);
                        }
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex.InnerException;
                    }
                    return RedirectToAction(nameof(CarList));
                }
                else
                {
                    return View("~/Views/Automobile/Car/CarList.cshtml", car);
                }
            }
            catch
            {
                return View("~/Views/Automobile/Car/CarList.cshtml");
            }
        }

        public ActionResult DeleteCarView(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var car = _context.Cars.Include(x => x.Company).FirstOrDefault(x => x.CarId == id);

            return View("~/Views/Automobile/Car/DeleteCar.cshtml", car);
            //return View();
        }

        // POST: Car/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCar(int carId)
        {
            try
            {
                var car = _context.Cars.Find(carId);
                _context.Cars.Remove(car);
                _context.SaveChanges();
                return RedirectToAction(nameof(CarList));
            }
            catch
            {
                return View("~/Views/Automobile/Car/CarList.cshtml");
            }
        }

        // GET: Car/Details/5
        public ActionResult CarDetail(int id)
        {
            var car = _context.Cars.Include(x=> x.Company).FirstOrDefault(x=> x.CarId == id);

            if (car == null)
            {
                return NotFound();
            }
            return View("~/Views/Automobile/Car/DetailCar.cshtml", car);
        }
    }
}
