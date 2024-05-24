using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.data
{
    public class PizzeManager 
    {

        public static Pizze GetPrendere(int id, bool IncludiCategoria=true, bool IncludiIngredienti = true)
        {
            using PizzeCintest db = new PizzeCintest();
            //return db.Pizze.FirstOrDefault(x => x.ID == id);
            if (!IncludiCategoria && IncludiIngredienti)
            {
                return db.Pizze.FirstOrDefault(x => x.ID == id);
            }
            else
            {
                var query = db.Pizze.Where(x => x.ID == id);
                if (IncludiCategoria)
                {
                    query = query.Include(c => c.Categoria);
                }
                if (IncludiIngredienti)
                {
                    query = query.Include(p => p.Ingredientis);
                }
                return query.FirstOrDefault();
            }

        }
        


        
        public static List<Pizze> ListaPizee()
        {
            using PizzeCintest db = new PizzeCintest();
            return db.Pizze.ToList();
        }


    }


}
