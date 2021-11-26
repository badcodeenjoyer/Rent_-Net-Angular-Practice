using RentAPI.Models;

namespace RentAPI.Interfaces
{
    public interface IFindRent
    {
        public  BikeModel FindRent(int id);
    }
}
