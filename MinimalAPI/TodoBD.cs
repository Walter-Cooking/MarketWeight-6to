using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPI
{
    public class TodoBD : DbContext
    {
    public TodoBD(DbContextOptions<TodoBD> options) : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Moneda> Monedas => Set<Moneda>();
    }
}