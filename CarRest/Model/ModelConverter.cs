

using WebApiCar.Model;

namespace CarRest.Model
{
    public static class ModelConverter
    {
        public static Car CarConvert(CarDTO dto)
        {
            Car c = new Car()
            {
                Model = dto.model,
                Vendor = dto.vendor,
                Price = dto.price
            };
            return c;
        }
    }
}
