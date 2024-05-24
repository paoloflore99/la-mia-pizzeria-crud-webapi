
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace la_mia_pizzeria_static.data;

public class PizzeCintest : IdentityDbContext<IdentityUser>
{
    public DbSet<Pizze> Pizze { get; set; }

    public DbSet<Categoria> Categoria { get; set; }

    public DbSet<Ingredienti> Ingredientis { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Pizze;" +
        "Integrated Security=True;TrustServerCertificate=True");
    }

}



