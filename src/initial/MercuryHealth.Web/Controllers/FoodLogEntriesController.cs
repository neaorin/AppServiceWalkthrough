#region Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MercuryHealth.Models;
using MercuryHealth.Web.Models;
using System.Diagnostics;

#endregion

namespace MercuryHealth.Web.Controllers
{

    public class FoodLogEntriesController : Controller
    {

        private IFoodLogEntryRepository repository;

        public FoodLogEntriesController(IFoodLogEntryRepository repo)
        {
            this.repository = repo;
        }

        public FoodLogEntriesController() : this(new FoodLogEntrySqlRepository())
        {

        }

        // GET: FoodLogEntries
        public ActionResult Index()
        {
            return View(repository.GetAll().ToList());
        }

        // GET: FoodLogEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodLogEntry foodLogEntry = repository.Get(id);
            if (foodLogEntry == null)
            {
                return HttpNotFound();
            }
            return View(foodLogEntry);
        }

        // GET: FoodLogEntries/Create
        public ActionResult Create()
        {

            var query = new FoodLogEntry
            {
                Quantity = 1,
                Description = "Apple",
                //MealTime = DateTime.UtcNow,
                MealTime = Convert.ToDateTime("8/25/2105"),
                Calories = 116,
                Tags = "fruit, snack",
                ProteinInGrams = Convert.ToDecimal("0.6"),
                FatInGrams = Convert.ToDecimal("0.4"),
                CarbohydratesInGrams = Convert.ToDecimal("38.8"),
                SodiumInGrams = Convert.ToDecimal("2.0")
            };

            return View(query);
        }

        // POST: FoodLogEntries/Create
        // 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantity,Description,MealTime,Tags,Calories,ProteinInGrams,FatInGrams,CarbohydratesInGrams,SodiumInGrams")] FoodLogEntry foodLogEntry)
        {
            if (ModelState.IsValid)
            {
                repository.Create(foodLogEntry);

                Trace.TraceInformation("Created Nutrition {0}", foodLogEntry.Description);

                // Application Insights - Track Events
                Utilities.TelemetryClientHelper.TrackEvent("Created Nutrition");

                return RedirectToAction("Index");
            }

            return View(foodLogEntry);

            //Comment
        }

        // GET: FoodLogEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodLogEntry foodLogEntry = repository.Get(id);
            if (foodLogEntry == null)
            {
                return HttpNotFound();
            }
            return View(foodLogEntry);
        }

        // POST: FoodLogEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantity,Description,MealTime,Tags,Calories,ProteinInGrams,FatInGrams,CarbohydratesInGrams,SodiumInGrams")] FoodLogEntry foodLogEntry)
        {
            if (ModelState.IsValid)
            {
                repository.Update(foodLogEntry);

                Trace.TraceInformation("Updated Nutrition {0}", foodLogEntry.Description);

                // Application Insights - Track Events
                Utilities.TelemetryClientHelper.TrackEvent("Updated Nutrition");

                return RedirectToAction("Index");
            }
            return View(foodLogEntry);
        }

        // GET: FoodLogEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodLogEntry foodLogEntry = repository.Get(id);
            if (foodLogEntry == null)
            {
                return HttpNotFound();
            }
            return View(foodLogEntry);
        }

        // POST: FoodLogEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);

            Trace.TraceInformation("Deleted Nutrition {0}", id.ToString());

            // Application Insights - Track Events
            Utilities.TelemetryClientHelper.TrackEvent("Deleted Nutrition");

            return RedirectToAction("Index");
        }
        
    }

}
