using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client_Core.Data;
using Client_Core.Models;
using Client_Core.BLL;

namespace Client_Core.Controllers
{
    public class Covid_DtoController : Controller
    {
        private readonly Client_CoreContext _context;

        public Covid_DtoController(Client_CoreContext context)
        {
            _context = context;
        }

        // GET: Covid_Dto
        public async Task<IActionResult> Index()
        {

            var data =await BLL.ApiHelper.GetAllData();
            IdHelper.Id = data.Max(x => x.Id) + 1;
            return View(data);
        }

        // GET: Covid_Dto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covid_Dto = await _context.Covid_Dto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (covid_Dto == null)
            {
                return NotFound();
            }

            return View(covid_Dto);
        }

        // GET: Covid_Dto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Covid_Dto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Province_State,Country_Region,Confirmed,Deaths,Recovered")] Covid_Dto covid_Dto)
        {
            if (ModelState.IsValid)
            {
                covid_Dto.Id = IdHelper.Id;
                var res=await ApiHelper.InsertCovidData(covid_Dto);
                if (res == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(covid_Dto);
        }

        // GET: Covid_Dto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res = await ApiHelper.GetById((int)id);
            if (res == null)
            {
                return NotFound();
            }
            return View(res);
        }

        // POST: Covid_Dto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Province_State,Country_Region,Confirmed,Deaths,Recovered")] Covid_Dto covid_Dto)
        {
            if (id != covid_Dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var res = await ApiHelper.Update(id, covid_Dto);
                    if (res == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Covid_DtoExists(covid_Dto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(covid_Dto);
        }

        // GET: Covid_Dto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res =await ApiHelper.GetById((int)id);
            if (res == null)
            {
                return NotFound();
            }

            return View(res);
        }

        // POST: Covid_Dto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           var res=await ApiHelper.DeleteCovid(id);
            
            return RedirectToAction("Index");
        }

        private bool Covid_DtoExists(int id)
        {
            return _context.Covid_Dto.Any(e => e.Id == id);
        }
    }
}
