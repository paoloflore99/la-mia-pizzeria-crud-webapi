namespace la_mia_pizzeria_static.data
{
    public class Ingredienti
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pizze> PizzeList { get; set; }

        public Ingredienti() { }
    }
}
