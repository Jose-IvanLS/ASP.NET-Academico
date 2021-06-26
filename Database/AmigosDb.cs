using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ATVitor.Models;

namespace ATVitor.Database {
    public class AmigosDb : DbContext {

        public AmigosDb(DbContextOptions options) : base(options) {
        
        
        }

        public DbSet<Amigo> Amigos { get; set; }
        
    }
}
