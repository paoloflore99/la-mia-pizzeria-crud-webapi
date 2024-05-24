using la_mia_pizzeria_static.data;

namespace la_mia_pizzeria_static.Models
{
    public class ListaPizze
    {
        public List<Pizze> PizzeList { get; set; }

        public ListaPizze()
        {
            PizzeList = new List<Pizze>();

        }
    }
}
