using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Data
{
    public class DBInitializer
    {
        public static void Initialize(CrudContext context)
        {
            context.Database.EnsureCreated();

            if(context.People.Any())
            {
                return;
            }
            var people = new Person[]
            {
                new Person { NameFirst = "John", NameLast = "Johnson",
                    Email = "john@johnson.com", Age = 32,
                    Subscribed = true },
                new Person { NameFirst = "Bob", NameLast = "Bobson",
                    Email = "bob@bobson.com", Age = 26,
                    Subscribed = false }, 
                new Person { NameFirst = "Sally", NameLast = "Stevens",
                    Email = "sally@stevens.com", Age = 22,
                    Subscribed = false}
            };

            foreach(Person p in people)
            {
                context.People.Add(p);
            }
            context.SaveChanges();
        }
    }
}
