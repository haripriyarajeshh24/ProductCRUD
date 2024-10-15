using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductCRUD.DAL;
using ProductCRUD.Models;

namespace ProductCRUD.Controllers
{
    public class ProductController : Controller
    {
        Product_DAL product_DAL = new Product_DAL();
        // GET: Product
        public ActionResult Index()
        {
            var productlist = product_DAL.GetProducts();
            return View(productlist);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = product_DAL.GetProductByID(id).FirstOrDefault();
            try
            {
                if (product == null)
                {
                    TempData["InfoMessage"] = "Product not available with id " + id.ToString();
                    return RedirectToAction("Index");

                }
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            bool IsInserted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    IsInserted = product_DAL.InsertProduct(product);

                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Product details saved successfully...!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save the product deatils.";
                    }
                    
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
           
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = product_DAL.GetProductByID(id).FirstOrDefault();
            if (product == null)
            {
                TempData["InfoMessage"] = "Product not available with given ID" + id.ToString();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                bool IsUpdated = product_DAL.UpdateProduct(product);
                if (IsUpdated)
                {
                    TempData["SuccessMessage"] = "Product details updated successfully...!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Product unable to edit...!";
                }
            }
            return RedirectToAction("Index"); try
            {

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = product_DAL.GetProductByID(id).FirstOrDefault();
            try
            {
                if (product == null)
                {
                    TempData["InfoMessage"] = "Product not available";
                    RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            string result = product_DAL.DeleteProduct(id);
            try
            {
                if (result.Contains("deleted"))
                {
                    TempData["SuccessMessage"] = "Product deleted successfully...!";
                }

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
