
using RentAPI.Interfaces;

using RentAPI.Data;
using RentAPI.Models;
namespace RentAPI.Services
{
    public class DeleteService : IDelete
    {
        private readonly RentAPIContext _context;
        public DeleteService(RentAPIContext context)
        {
            _context=context; ;
        }
        public void Delete(BikeModel bikeModel)
        {
            _context.BikeModel.Remove(bikeModel);
        }
    }
}
