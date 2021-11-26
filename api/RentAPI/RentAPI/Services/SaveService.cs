using RentAPI.Interfaces;

using RentAPI.Data;
namespace RentAPI.Services
{
    public class SaveService : ISave
    {
        private readonly RentAPIContext _context;

        public SaveService(RentAPIContext context)
        {
            _context = context;
        }
        public async Task<int> Save()
        {
         return await _context.SaveChangesAsync();
          
        }
    }
}
