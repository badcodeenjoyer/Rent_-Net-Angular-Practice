using Microsoft.AspNetCore.Mvc;
using RentAPI.Models;

namespace RentAPI.Interfaces
{
    public interface IList
    {
        public Task<ActionResult<IEnumerable<BikeModel>>> GetList();
    }
}
