using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DEMO5.Models;

namespace DEMO5.Controllers
{
    public class TItemSourceListsController : Controller
    {
        private readonly IdataContext _context;

        public TItemSourceListsController(IdataContext context)
        {
            _context = context;
        }

        // GET: TItemSourceLists
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.TItemSourceList.ToListAsync());
        //}
        public async Task<IActionResult> Index(int? id, string searchSourceName, string isGatherUrlNull, string searchGatherURL,string sortOrder,int? pageNumber)
        {

            ViewData["CurrentSort"] = sortOrder;
   

            IQueryable<TItemSourceList> data = from m in _context.TItemSourceList
                                               select m;

            
            if (id > 0)
            {
                data = data.Where(s => s.Id == id);
            }
            if (!string.IsNullOrEmpty(searchSourceName))
            {
                data=data.Where(m=>m.SourceName.Contains(searchSourceName));
            }

            if (isGatherUrlNull == "未填写")
            {
                data = data.Where(m => m.GatherUrl == null);
            }
            else if (isGatherUrlNull == "已填写")
            {
                data = data.Where(m => m.GatherUrl != null);
            }

            if (!string.IsNullOrEmpty(searchGatherURL))
            {
                data = data.Where(m => m.GatherUrl.Contains(searchGatherURL));
            }

            //为界面下拉框，填充值，以便初始化ListsViewModel,将值显示在界面上
            List<string> listItem = new List<string>();
            listItem.Add("未填写");  listItem.Add("已填写"); listItem.Add("所有");




            var listviewmodel = new ListViewModel
            {    
                lists = await data.ToListAsync(),
                GatherUrls = new SelectList(listItem)
            };
            return  View(listviewmodel);
        }

        // GET: TItemSourceLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tItemSourceList = await _context.TItemSourceList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tItemSourceList == null)
            {
                return NotFound();
            }

            return View(tItemSourceList);
        }

        // GET: TItemSourceLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TItemSourceLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //"Valid,Id,OpcId,Class,WdId,SourceName,SourceUrl,GatherUrl,ListP1,ListP2,ParamResidual,FirstPage,GatherPages,TotalPages,IsGatherAllPages,ListPattern,ListCharset,InfoUrl,ListIspost,IsGatherInfopages,Addtime,CntPerPage,IsGenericGatherUrl,ListBegin,ListEnd,FirstPageRatio,FirstPagePlus,Userid"
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Valid,Id,OpcId,Class,WdId,SourceName,SourceUrl,GatherUrl,ListP1,ListP2,ParamResidual,FirstPage,GatherPages,TotalPages,IsGatherAllPages,ListPattern,ListCharset,InfoUrl,ListIspost,IsGatherInfopages,Addtime,CntPerPage,IsGenericGatherUrl,ListBegin,ListEnd,FirstPageRatio,FirstPagePlus,Userid,ModifyDate")] TItemSourceList tItemSourceList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tItemSourceList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tItemSourceList);
        }

        // GET: TItemSourceLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tItemSourceList = await _context.TItemSourceList.FindAsync(id);
            if (tItemSourceList == null)
            {
                return NotFound();
            }
            return View(tItemSourceList);
        }

        // POST: TItemSourceLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Valid,Id,OpcId,Class,WdId,SourceName,SourceUrl,GatherUrl,ListP1,ListP2,ParamResidual,FirstPage,GatherPages,TotalPages,IsGatherAllPages,ListPattern,ListCharset,InfoUrl,ListIspost,IsGatherInfopages,Addtime,CntPerPage,IsGenericGatherUrl,ListBegin,ListEnd,FirstPageRatio,FirstPagePlus,Userid,ModifyDate")] TItemSourceList tItemSourceList)
        {
            if (id != tItemSourceList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tItemSourceList.ModifyDate = DateTime.Now.ToLocalTime();
                    _context.Update(tItemSourceList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TItemSourceListExists(tItemSourceList.Id))
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
            return View(tItemSourceList);
        }

        // GET: TItemSourceLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tItemSourceList = await _context.TItemSourceList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tItemSourceList == null)
            {
                return NotFound();
            }

            return View(tItemSourceList);
        }

        // POST: TItemSourceLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tItemSourceList = await _context.TItemSourceList.FindAsync(id);
            _context.TItemSourceList.Remove(tItemSourceList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TItemSourceListExists(int id)
        {
            return _context.TItemSourceList.Any(e => e.Id == id);
        }

    }
}
