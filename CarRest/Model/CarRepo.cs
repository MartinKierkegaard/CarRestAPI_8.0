using WebApiCar.Model;

namespace CarRest.Model
{
    public class CarRepo
    {
        private readonly List<Car> carList;
        private int _nextId;
        public CarRepo()
        {
            carList = new List<Car>()
            {
                new Car(){Id = 1,Model="x3",Vendor="Tesla", Price=400000},
                new Car(){Id = 2,Model="x2",Vendor="Tesla", Price=600000},
                new Car(){Id = 3,Model="x1",Vendor="Tesla", Price=800000},
                new Car(){Id = 4,Model="x0",Vendor="Tesla", Price=1400000},
            };
            _nextId = 5;
        }
        public List<Car> GetAll()
        {
            try
            {
                if (carList.Count != 0)
                {
                    return carList;
                }
                else
                {
                    return new List<Car>();
                }
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException("No cars");
            }
        }
        public Car Add(Car car)
        {
            car.Id = GenerateId();
            carList.Add(car);
            return car;
        }
        public Car Remove(int id)
        {
            Car? a = carList.Find(x => x.Id == id);
            if (a != null)
                carList.Remove(a);

            return a;
        }
        public Car GetById(int id)
        {
            return carList.FirstOrDefault(x => x.Id == id);
        }
        public int GenerateId()
        {
            if (carList.Count == 0)
            {
                return _nextId = 1;
            }
            else
            {
                return carList.Max(x => x.Id + 1);
            }
        }
    }
}
