using RentAPI.Interfaces;

using RentAPI.Data;
using RentAPI.Models;
namespace RentAPI.Services
{
    public class FindRentService : IFindRent
    {
        private readonly RentAPIContext _context;

        public FindRentService(RentAPIContext context)
        {
            _context = context;
        }
       

        public BikeModel FindRent(int id)
        {
            var bikeModel =  _context.BikeModel.Find(id);
            return bikeModel;
        }
    }
}
