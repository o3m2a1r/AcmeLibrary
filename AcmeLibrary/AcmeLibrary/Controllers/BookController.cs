using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcmeLibrary.Models;

namespace AcmeLibrary.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/

        public ActionResult Index()
        {
            var context = new AcmeLibraryDataEntities();
            var books = context.Books;
            return View(books);
        }

        //
        // GET: /Book/Details/5

        public ActionResult Details(int id)
        {
            var context = new AcmeLibraryDataEntities();
            var book = context.Books.First(b => b.Id == id);
            return View(book);
        }

        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            var context = new AcmeLibraryDataEntities();
            var book = new Book
            {
                Author = "(Author)",
                Title = "(Title)",
                //ISBN = "(ISBN)"
            };
            context.AddToBooks(book);
            TempData["context"] = context;
            TempData["book"] = book;
            return View(book);
        } 

        //
        // POST: /Book/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            return Edit(-1, collection);
        }
        
        //
        // GET: /Book/Edit/5
 
        public ActionResult Edit(int id)
        {
            var context = new AcmeLibraryDataEntities();
            var book = context.Books.First(b => b.Id == id);
            TempData["context"] = context;
            TempData["book"] = book;
            return View(book);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var context = TempData["context"] as AcmeLibraryDataEntities;
                var book = TempData["book"] as Book;
                if (context != null && book != null)
                {
                    UpdateModel(book, collection.ToValueProvider());
                    context.SaveChanges();
                    context.Dispose();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Book/Delete/5
 
        public ActionResult Delete(int id)
        {
            var context = new AcmeLibraryDataEntities();
            var book = context.Books.First(b => b.Id == id);
            TempData["context"] = context;
            TempData["book"] = book;
            return View(book);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var context = TempData["context"] as AcmeLibraryDataEntities;
                var book = TempData["book"] as Book;
                if (context != null && book != null)
                {
                    context.DeleteObject(book);
                    context.SaveChanges();
                    context.Dispose();
                }
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
