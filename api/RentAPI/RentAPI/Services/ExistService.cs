using RentAPI.Data;
using RentAPI.Interfaces;

namespace RentAPI.Services
{
    public class ExistService : IExist
    {
        private readonly RentAPIContext _context;
        public ExistService(RentAPIContext context)
        {
            _context = context; ;
        }
        public bool BikeModelExists(int id)
        {
            return _context.BikeModel.Any(e => e.Id == id);
        }
    }
}
