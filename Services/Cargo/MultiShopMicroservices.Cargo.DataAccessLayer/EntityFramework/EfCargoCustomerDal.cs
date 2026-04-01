using MultiShopMicroservices.Cargo.DataAccessLayer.Abstract;
using MultiShopMicroservices.Cargo.DataAccessLayer.Concrete;
using MultiShopMicroservices.Cargo.DataAccessLayer.Repositories;
using MultiShopMicroservices.Cargo.EntityLayer.Concrete;

namespace MultiShopMicroservices.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargoContext;
        public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
        {
            _cargoContext = cargoContext;
        }

        public CargoCustomer GetCargoCustomerById(string id)
        {
            var values = _cargoContext.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
            return values;
        }
    }
}
