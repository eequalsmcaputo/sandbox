using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Persistence;
using Vidly.Models;
using Vidly.DTOs;

namespace Vidly.Controllers.API
{
    public class RentalsController : ApiController
    {
        private VidlyContext _context;

        public RentalsController()
        {
            _context = new VidlyContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == rentalDto.CustomerId);

            var movies = _context.Movies.Where(
                m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if(movie.NumberAvailable == 0)
                {
                    return BadRequest("One or more movies are not available.");
                }
                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
