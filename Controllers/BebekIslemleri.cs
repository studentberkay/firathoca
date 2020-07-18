using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FiratHoca.Data;
using FiratHoca.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace FiratHoca.Controllers
{
    public class BebekIslemleri : Controller
    {
        private readonly FiratHocaContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        //Yapıcı method
        //dependency injection --> bağımlı enjeksiyon
        public BebekIslemleri(FiratHocaContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: BebekIslemleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bebekler.Include(x => x.Resimler).ToListAsync());
        }

        // GET: BebekIslemleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Bebek = await _context.Bebekler.Include(x => x.Resimler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Bebek == null)
            {
                return NotFound();
            }

            return View(Bebek);
        }

        // GET: BebekIslemleri/Create
        public IActionResult Create()
        {
            return View(); //form ---> Bebek
        }

        // POST: BebekIslemleri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Aciklama,Kilo,Dosyalar")] Bebek Bebek)
        {
            if (ModelState.IsValid)
            {
                var dosyaYolu = Path.Combine(_hostEnvironment.WebRootPath, "resimler");
                if (!Directory.Exists(dosyaYolu))
                {
                    Directory.CreateDirectory(dosyaYolu);
                }

                foreach (var item in Bebek.Dosyalar)
                {
                    // IFormFile   -->  FileStream   :upload
                    using (var dosyaAkisi = new FileStream(Path.Combine(dosyaYolu, item.FileName), FileMode.Create))
                    {
                        await item.CopyToAsync(dosyaAkisi);
                    }

                    Bebek.Resimler.Add(new Resim { DosyaAdi = item.FileName });
                }

                _context.Add(Bebek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Bebek);
        }

        // GET: BebekIslemleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Bebek = await _context.Bebekler.Include(x => x.Resimler).SingleOrDefaultAsync(x => x.Id == id);

            if (Bebek == null)
            {
                return NotFound();
            }
            return View(Bebek);
        }

        // POST: BebekIslemleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Aciklama,Kilo")] Bebek Bebek)
        {
            if (id != Bebek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Bebek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BebekExists(Bebek.Id))
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
            return View(Bebek);
        }

        // GET: BebekIslemleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Bebek = await _context.Bebekler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Bebek == null)
            {
                return NotFound();
            }

            return View(Bebek);
        }

        // POST: BebekIslemleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Bebek = await _context.Bebekler.FindAsync(id);
            _context.Bebekler.Remove(Bebek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ResimSil(int id)
        {
            var resim = await _context.Resimler.FindAsync(id);

            _context.Resimler.Remove(resim);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new {id=resim.BebekuId});
        }

        private bool BebekExists(int id)
        {
            return _context.Bebekler.Any(e => e.Id == id);
        }
    }
}
