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
            var book = new Book
            {
                Author = "(Author)",
                Title = "(Title)",
                ISBN = "(ISBN)"
            };
            return View(book);
        } 

        //
        // POST: /Book/Create

        [HttpPost]
        public ActionResult Create(Book newBook)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    using (var context = new AcmeLibraryDataEntities())
                    {
                        context.AddToBooks(newBook);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    return View(newBook);
                }
            }
            return View(newBook);
        }
        
        //
        // GET: /Book/Edit/5
 
        public ActionResult Edit(int id)
        {
            using (var context = new AcmeLibraryDataEntities())
            {
                var book = context.Books.First(b => b.Id == id);
                context.Detach(book);
                return View(book);
            }
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        public ActionResult Edit(Book editedBook)
        {
            try
            {
                using (var context = new AcmeLibraryDataEntities())
                {
                    context.Books.Attach(editedBook);
                    context.Books.ApplyOriginalValues(new Book {Id = editedBook.Id });
                    context.SaveChanges();
                }
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(editedBook);
            }
        }

        //
        // GET: /Book/Delete/5
 
        public ActionResult Delete(int id)
        {
            return Edit(id);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost]
        public ActionResult Delete(Book bookToDelete)
        {
            try 
            {
                using (var context = new AcmeLibraryDataEntities())
                {
                    context.Books.Attach(bookToDelete);
                    context.Books.DeleteObject(bookToDelete);
                    context.SaveChanges();
                }
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(bookToDelete);
            }
        }
    }
}
