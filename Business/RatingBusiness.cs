using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Business
{
    public class RatingBusiness:IRatingBusiness
    {
        IRatingRepository _ratingRepository;

        public RatingBusiness(IRatingRepository ratingRepository)
        {
            this._ratingRepository = ratingRepository;
        }
        public async Task<Rating> addRating(Rating ratingToAdd)
        {
            return await _ratingRepository.addRating(ratingToAdd);
        }

    }
}
