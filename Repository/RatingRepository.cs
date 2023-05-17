using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public class RatingRepository:IRatingRepository
    {
        Store214089435Context _Store214089435;

        public RatingRepository(Store214089435Context Store214089435)
        {
            this._Store214089435 = Store214089435;
        }
        public async Task<Rating> addRating(Rating ratingToAdd)
        {
            await _Store214089435.Rating.AddAsync(ratingToAdd);
            await _Store214089435.SaveChangesAsync();
            return ratingToAdd;
        }


    }
}
