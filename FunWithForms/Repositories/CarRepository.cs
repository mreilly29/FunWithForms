using FunWithForms.Models;
using FunWithForms.Repositoriesy;

namespace FunWithForms.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(AutoContext db) : base(db)
        {
        }
    }
}
