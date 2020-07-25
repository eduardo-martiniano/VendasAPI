using Microsoft.EntityFrameworkCore;
using ProdutosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}