using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcFaceitAPI.Models;

namespace MvcFaceitAPI.Data
{
    public class MvcFaceitAPIContext : DbContext
    {
        public MvcFaceitAPIContext (DbContextOptions<MvcFaceitAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MvcFaceitAPI.Models.Movie> Movie { get; set; }
    }
}
