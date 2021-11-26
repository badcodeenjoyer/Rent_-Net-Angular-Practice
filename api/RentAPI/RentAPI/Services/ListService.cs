using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAPI.Data;
using RentAPI.Interfaces;
using RentAPI.Models;

namespace RentAPI.Services
{
    public class ListService:IList
    {
        private readonly RentAPIContext _context;
        public ListService(RentAPIContext context)
        {
            _context = context; ;
        }

        public async Task<ActionResult<IEnumerable<BikeModel>>> GetList()
        {
            return await _context.BikeModel.ToListAsync();
        }
    }
}
