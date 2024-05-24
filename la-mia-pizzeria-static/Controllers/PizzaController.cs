using la_mia_pizzeria_static.data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Migrations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;
namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {


        public IActionResult Index()
        {
            using PizzeCintest db = new PizzeCintest();
            if (!db.Pizze.Any())
            {
                List<Pizze> PizzaDb = new List<Pizze>()
            {
                new Pizze("Margherita", "suggo, salame, ecc", "~/img/fotopizza.png", 5.90),
                new Pizze("Capricciosa", "suggo, salame, funghi, olive", "~/img/fotopizza.png", 7.50),
                new Pizze("Quattro Stagioni", "suggo, salame, prosciutto cotto, funghi, carciofi", "~/img/fotopizza.png", 8.20),
                new Pizze("Diavola", "suggo, salame piccante, peperoni", "~/img/fotopizza.png", 6.80),
                new Pizze("Quattro Formaggi", "suggo, mozzarella, gorgonzola, fontina, parmigiano", "~/img/fotopizza.png", 9.50),
                new Pizze("Napoli", "suggo, acciughe, olive nere, capperi", "~/img/fotopizza.png", 7.00),
                new Pizze("Vegetariana", "suggo, mozzarella, verdure miste", "~/img/fotopizza.png", 6.50),
                new Pizze("Tonno e Cipolla", "suggo, tonno, cipolla", "~/img/fotopizza.png", 7.20),
                new Pizze("Boscaiola", "suggo, salsiccia, funghi", "~/img/fotopizza.png", 8.00),
                new Pizze("Prosciutto e Funghi", "suggo, prosciutto cotto, funghi", "~/img/fotopizza.png", 7.00)
            };
                foreach (Pizze p in PizzaDb)
                {
                    db.Add(p);
                    db.SaveChanges();

                }
            }

            return View(PizzeManager.ListaPizee() );
        }

        public IActionResult  PerId(int ID)
        {
            return View(PizzeManager.GetPrendere(ID));
            // View.Model == OggettoPassato
        }



       // [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Create()
        {
            using (PizzeCintest db = new PizzeCintest())
            {
                PizzeCategorie model = new PizzeCategorie();
                List<Categoria> categorias = db.Categoria.ToList();
                List<Ingredienti> ingrediti = db.Ingredientis.ToList();
                List<SelectListItem> Listaingredienti = new List<SelectListItem>();
                foreach(Ingredienti ingredient in ingrediti)
                {
                    Listaingredienti.Add(new SelectListItem()
                    {
                        Text = ingredient.Name,
                        Value = ingredient.Id.ToString()
                    });;
                }
                model.Ingredientis = Listaingredienti;
                model.Categorias = categorias;
                model.Pizze =new Pizze();
                return View("Create", model);
            }
                
        }



        //[Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzeCategorie categoriepizze)
        {
            if (!ModelState.IsValid)
            {
                using (PizzeCintest db = new PizzeCintest())
                {
                    List<SelectListItem> Listaingredienti = new List<SelectListItem>();
                    List<Ingredienti> ingrediti = db.Ingredientis.ToList();
                    List<Categoria> categorias = db.Categoria.ToList();
                    foreach(Ingredienti ingrent in ingrediti)
                    {
                        Listaingredienti.Add(new SelectListItem()
                        {
                            Text = ingrent.Name,
                            Value = ingrent.Id.ToString()
                        });
                    }
                    categoriepizze.Categorias = categorias;
                    categoriepizze.Ingredientis = Listaingredienti;
                    return View(categoriepizze);
                }    
            }

            using (PizzeCintest db = new PizzeCintest())
            {
                Pizze CreazionePizze = new Pizze();
                //List<SelectListItem> Listaingredienti = new List<SelectListItem>();
                categoriepizze.Pizze.Ingredientis = new List<Ingredienti>();    
                if(categoriepizze.SelezionaInredienti != null )
                {
                    foreach (string SelezionaInredienti in categoriepizze.SelezionaInredienti)
                    {
                        Ingredienti ingredienti = db.Ingredientis.FirstOrDefault(i => i.Id.ToString() == SelezionaInredienti);
                        if(ingredienti != null)
                        {
                            categoriepizze.Pizze.Ingredientis.Add(ingredienti);
                        }
                    }
                }

                db.Add(categoriepizze.Pizze);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }



        [HttpGet]
        public IActionResult Edit(int Id)
        {
            using (PizzeCintest db = new PizzeCintest())
            {

                Pizze Edit = db.Pizze.Where(pizze => pizze.ID == Id).FirstOrDefault();
                if(Edit == null)
                {
                    return NotFound();
                }
                else
                {
                    List<Ingredienti> ingredienti = db.Ingredientis.ToList();
                    List<Categoria> categgiria = db.Categoria.ToList();
                    PizzeCategorie model = new PizzeCategorie();
                    model.Pizze = Edit;
                    model.Categorias = categgiria;
                    List<SelectListItem> Listaingredienti = new List<SelectListItem>();
                    foreach(Ingredienti ingrent in ingredienti)
                    {
                        Listaingredienti.Add(new SelectListItem()
                        {
                            Text = ingrent.Name,
                            Value = ingrent.Id.ToString()
                        });
                    }
                    model.Ingredientis = Listaingredienti;
                    return View(model);
                }
            } 
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, PizzeCategorie dati)
        {

            if(!ModelState.IsValid)
            {
                using (PizzeCintest db = new PizzeCintest())
                {
                    List<Ingredienti> ingredienti = db.Ingredientis.ToList();
                    List<Categoria> categgiria = db.Categoria.ToList();
                    PizzeCategorie model = new PizzeCategorie();
                    model.Categorias = categgiria;
                    List<SelectListItem> Listaingredienti = new List<SelectListItem>();
                    foreach (Ingredienti ingrent in ingredienti)
                    {
                        Listaingredienti.Add(new SelectListItem()
                        {
                            Text = ingrent.Name,
                            Value = ingrent.Id.ToString()
                        });
                    }
                    dati.Ingredientis = Listaingredienti;
                    dati.Categorias = categgiria;
                    return View("Edit", dati);
                }
                
            }

            using (PizzeCintest db = new PizzeCintest())
            {

                Pizze PizzeRdit = db.Pizze.Where(pizze => pizze.ID == Id).Include(p => p.Ingredientis).FirstOrDefault();
                PizzeRdit.Ingredientis.Clear();
                if (PizzeRdit != null)
                {
                    foreach(string selezionaIngrediente in dati.SelezionaInredienti)
                    {
                        int selezionaIngredienteId = int.Parse(selezionaIngrediente);
                        Ingredienti ingredienti = db.Ingredientis.
                            Where(x => x.Id == selezionaIngredienteId).FirstOrDefault();
                        PizzeRdit.Ingredientis.Add(ingredienti);
                    }

                    PizzeRdit.Nome = dati.Pizze.Nome;
                    PizzeRdit.Descrizione = dati.Pizze.Descrizione;
                    PizzeRdit.Prezzo = dati.Pizze.Prezzo;
                    PizzeRdit.UrlFoto = dati.Pizze.UrlFoto;
                    PizzeRdit.CategoriaId = dati.Pizze.CategoriaId;
                    db.SaveChanges();
                    return RedirectToAction("PerId", new { Id = PizzeRdit.ID });
                }
                else
                {
                    return NotFound();
                }
            }
        }


        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (PizzeCintest db = new PizzeCintest())
            {
                Pizze PizzeRdit = db.Pizze.Where(pizze => pizze.ID == id).FirstOrDefault();
                if (PizzeRdit != null)
                {
                    db.Pizze.Remove(PizzeRdit);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}