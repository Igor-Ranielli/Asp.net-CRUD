using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PIM_VIII_CRUD.Models;

namespace PIM_VIII_CRUD.Data
{
    public class PIM_VIII_CRUDContext : DbContext
    {
        public PIM_VIII_CRUDContext (DbContextOptions<PIM_VIII_CRUDContext> options)
            : base(options)
        {
        }

        public DbSet<PIM_VIII_CRUD.Models.Pessoa> Pessoa { get; set; } = default!;
    }
}
