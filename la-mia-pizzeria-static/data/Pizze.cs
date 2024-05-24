using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace la_mia_pizzeria_static.data
{
    [Table("Pizze")]
    public class Pizze
    {
        [Key]
        public int ID { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "metti nome pizza")]
        public string Nome { get; set; }

        [StringLength(100)]
        [Required (ErrorMessage = "metti la descrizione")]
        public string Descrizione { get; set; }

        [StringLength(1000)]
        [Required (ErrorMessage ="Metti url for ")]

        public string UrlFoto { get; set; }
        [Range(1,20000)]
        public double Prezzo { get; set; }
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public List<Ingredienti>? Ingredientis { get; set; }

        public Pizze() { }
        public Pizze( string nome, string descrizione, string urlfoto, double prezzo)
        {
          
            Nome = nome;
            Descrizione = descrizione;
            UrlFoto = urlfoto;
            Prezzo = prezzo;
        }

        public string DammiNomeCategoria()
        {
            if (Categoria != null) return Categoria.CateggoriePizze;
            else return "categoria non presente";
        }   
    }

}


