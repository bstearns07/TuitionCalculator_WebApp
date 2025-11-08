using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuitionCalculator_WebApp.Models;
using TuitionCalculator_WebApp.Models.DataLayer;

namespace TuitionCalculator_WebApp.Controllers
{
    public class ResultsController : Controller
    {
        //define a database context instance that can used throughout the controller
        private CollegeCostContext context {  get; set; }

        //define a constructor that initializes its private database context via dependency injection
        public ResultsController(CollegeCostContext ctx) => context = ctx;

        //action method that returns the List view for displaying the results of a budget
        public IActionResult List(CollegeCost model)
        {
            return View(model);
        }

        //action method that loads a record from the database for viewing
        public IActionResult Load(int id)
        {
            var budget = context.CollegeCost.FirstOrDefault(b => b.CollegeCostId == id);
            return View("List", budget);
        }

        //action method for returning a view that displays all records in the database
        public IActionResult Database()
        {
            var budgets = context.CollegeCost.OrderBy(b => b.CollegeCostId).ToList();
            return View(budgets);
        }

        //action method that accepts a cost model, saves it to the database, and returns that model back to the posting view
        public IActionResult Save(CollegeCost model)
        {
            if (model.CollegeCostId == 0)
            {
                context.CollegeCost.Add(model);
                context.SaveChanges();
                TempData["message"] = "Budget was successfully saved to the database";
                return View("List",model);
            }
            else
            {
                context.CollegeCost.Update(model);
                context.SaveChanges();
                TempData["message"] = $"Budget ID number {model.CollegeCostId} was successfully updated";
                var budgets = context.CollegeCost.OrderBy(b => b.CollegeCostId).ToList();
                return View("Database",budgets);
            }
        }

        //action method to edit a budget stored in the database
        public IActionResult Edit(int id)
        {
            //pull the record from the database to be edited using the route's id number
            var budget = context.CollegeCost.FirstOrDefault(b => b.CollegeCostId == id);
            return View(budget);
        }

        //action method that gets the Confirm Deletion page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var budget = context.CollegeCost.FirstOrDefault(b => b.CollegeCostId == id);
            return View(budget);
        }

        //action method that deletes a budget from the database and returns to the database screen
        [HttpPost]
        public IActionResult Delete(CollegeCost budget)
        {
            context.CollegeCost.Remove(budget);
            context.SaveChanges();
            TempData["message"] = $"Budget ID number '{budget.CollegeCostId}' was successfully deleted";
            var budgets = context.CollegeCost.OrderBy(b => b.CollegeCostId).ToList();
            return View("Database", budgets);
        }

    }
}
