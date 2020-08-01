using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROBE_SYSTEM.Models;

namespace PROBE_SYSTEM.Controllers
{
    public class VewInvoiceInquiryModelsController : Controller
    {
        private readonly OneWorldDbContext _context;

        public VewInvoiceInquiryModelsController(OneWorldDbContext context)
        {
            _context = context;
        }

        // GET: VewInvoiceInquiryModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.vewInvoiceInquiry.Where(x=>x.PONo == "2000058091").ToListAsync());
        }

        // GET: VewInvoiceInquiryModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vewInvoiceInquiryModel = await _context.vewInvoiceInquiry
                .FirstOrDefaultAsync(m => m.PONo == id);
            if (vewInvoiceInquiryModel == null)
            {
                return NotFound();
            }

            return View(vewInvoiceInquiryModel);
        }

        // GET: VewInvoiceInquiryModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VewInvoiceInquiryModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PONo,LineNo,InvoiceNo,PRNo,ItemCode,ItemCategory,Item,Specification,Unit,UnitName,ReceivingQTY,ReceivingUnitPrice,ReceivingAmount,PODate,ReceivingDate,Remarks,MakerName,SpecialNote,SupplierCode,SupplierName,ChargeSectionCode,ChargeSectionName,Currency,BuyerCode,BuyerName,AccountNo,AccountSubNo,AccountName,SuspenseAccountNo,LicenseNo,DecisionFormNo,ORGReceivingUnitPrice,ORGReceivingAmount,DataMakingDate,DeliveryPlaceCode,DeliveryPlaceName,DeliverySectionCode,DeliverySectionName,ReceivingEntryDate,OpeDate,ReceivingDate_1")] VewInvoiceInquiryModel vewInvoiceInquiryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vewInvoiceInquiryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vewInvoiceInquiryModel);
        }

        // GET: VewInvoiceInquiryModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vewInvoiceInquiryModel = await _context.vewInvoiceInquiry.FindAsync(id);
            if (vewInvoiceInquiryModel == null)
            {
                return NotFound();
            }
            return View(vewInvoiceInquiryModel);
        }

        // POST: VewInvoiceInquiryModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PONo,LineNo,InvoiceNo,PRNo,ItemCode,ItemCategory,Item,Specification,Unit,UnitName,ReceivingQTY,ReceivingUnitPrice,ReceivingAmount,PODate,ReceivingDate,Remarks,MakerName,SpecialNote,SupplierCode,SupplierName,ChargeSectionCode,ChargeSectionName,Currency,BuyerCode,BuyerName,AccountNo,AccountSubNo,AccountName,SuspenseAccountNo,LicenseNo,DecisionFormNo,ORGReceivingUnitPrice,ORGReceivingAmount,DataMakingDate,DeliveryPlaceCode,DeliveryPlaceName,DeliverySectionCode,DeliverySectionName,ReceivingEntryDate,OpeDate,ReceivingDate_1")] VewInvoiceInquiryModel vewInvoiceInquiryModel)
        {
            if (id != vewInvoiceInquiryModel.PONo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vewInvoiceInquiryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VewInvoiceInquiryModelExists(vewInvoiceInquiryModel.PONo))
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
            return View(vewInvoiceInquiryModel);
        }

        // GET: VewInvoiceInquiryModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vewInvoiceInquiryModel = await _context.vewInvoiceInquiry
                .FirstOrDefaultAsync(m => m.PONo == id);
            if (vewInvoiceInquiryModel == null)
            {
                return NotFound();
            }

            return View(vewInvoiceInquiryModel);
        }

        // POST: VewInvoiceInquiryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vewInvoiceInquiryModel = await _context.vewInvoiceInquiry.FindAsync(id);
            _context.vewInvoiceInquiry.Remove(vewInvoiceInquiryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VewInvoiceInquiryModelExists(string id)
        {
            return _context.vewInvoiceInquiry.Any(e => e.PONo == id);
        }
    }
}
