using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentAPI.Data;
using RentAPI.Interfaces;
using RentAPI.Models;

namespace RentAPI.Services
{
    public class EntryService : IEntry
    {
        private readonly RentAPIContext _context;
        public EntryService(RentAPIContext context)
        {
            _context = context; ;
        }
        public EntityEntry<BikeModel> Entry(BikeModel bikeModel)
        {
            return _context.Entry(bikeModel);
        }
    }
}
