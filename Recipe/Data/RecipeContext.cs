using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Recipe.Model;

namespace Recipe.Data
{
    public class RecipeContext :DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) :base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Cook> cooks { get; set; }

    }
}
