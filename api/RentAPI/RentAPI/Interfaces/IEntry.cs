using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentAPI.Models;

namespace RentAPI.Interfaces
{
    public interface IEntry
    {
        public EntityEntry<BikeModel> Entry(BikeModel bikeModel);
    }
}
