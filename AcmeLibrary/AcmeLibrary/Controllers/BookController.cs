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
            return View();
        } 

        //
        // POST: /Book/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
                    book.Author = collection["Author"];
                    book.Title = collection["Title"];
                    book.ISBN = collection["ISBN"];
                    DateTime published;
                    if (DateTime.TryParse(collection["published"], out published))
                    {
                        book.Published = published;
                    }
                    book.Publisher = collection["Publisher"];
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
            return View();
        }

        //
        // POST: /Book/Delete/5

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
    }
}
