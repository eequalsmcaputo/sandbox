using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Persistence
{
    public class VidlyContext : DbContext
    {
        public VidlyContext() : base("name=VidlyContext")
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MembershipType> MembershipTypes { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
    }
}