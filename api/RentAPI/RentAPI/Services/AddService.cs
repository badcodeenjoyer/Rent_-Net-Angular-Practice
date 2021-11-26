using RentAPI.Interfaces;

using RentAPI.Data;
using RentAPI.Models;
namespace RentAPI.Services
{
    public class AddService :IAdd
    {
        private readonly RentAPIContext _context;
        public AddService(RentAPIContext context)
        {
            _context = context; ;
        }

        public void Add(BikeModel bikeModel)
        {
            _context.BikeModel.Add(bikeModel);
        }
    }
}
