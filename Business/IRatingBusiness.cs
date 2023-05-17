using Entities;

namespace Business
{
    public interface IRatingBusiness
    {
        public Task<Rating> addRating(Rating ratingToAdd);
    }
}