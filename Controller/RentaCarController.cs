using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RentaCarController : ControllerBase
{
    public static List<VehicleFeatures> Car = new List<VehicleFeatures>
    {
        new VehicleFeatures
        {
            CarId = 1,
            CarName = "Fiat Egea",
            CarAge = 2017,
            CarFeul = "Benzin",
            CarGear = "Manuel",
            CarCapacity=5,
            CarPrice = 900,
            CarKm = 120000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/fiat-egea-2017-5f525778affa4.png"
        },

        new VehicleFeatures
        {
            CarId = 2,
            CarName = "Peugeot 301",
            CarAge = 2018,
            CarFeul = "Dizel",
            CarGear = "Manuel",
            CarCapacity=5,
            CarPrice = 800,
            CarKm = 90000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/peugeot-301-2017-5f52572b5f881.png"
        },

        new VehicleFeatures
        {
            CarId = 3,
            CarName = "Volkswagen Passat",
            CarAge = 2017,
            CarFeul = "Dizel",
            CarGear = "Otomatik",
            CarCapacity=5,
            CarPrice = 1000,
            CarKm = 100000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/volkswagen-passat-2017-5f5257c4b0955.png"
        },
        new VehicleFeatures
        {
            CarId = 4,
            CarName = "Renault Symbol",
            CarAge = 2019,
            CarFeul = "Dizel",
            CarGear = "Manuel",
            CarCapacity=5,
            CarPrice = 800,
            CarKm = 85000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/renault-symbol-2017-5f5257eb52035.png"
        },

        new VehicleFeatures
        {
            CarId = 5,
            CarName = "Citroen C Elysee",
            CarAge = 2020,
            CarFeul = "Benzin",
            CarGear = "Manuel",
            CarCapacity=5,
            CarPrice = 900,
            CarKm = 95000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/citroen-c-elysee-2017-5f52578b31d25.png"
        },

        new VehicleFeatures
        {
            CarId = 6,
            CarName = "Renault Megane",
            CarAge = 2022,
            CarFeul = "Benzin",
            CarGear = "Otomatik",
            CarCapacity=5,
            CarPrice = 1200,
            CarKm = 55000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/renault-megane-2017-5f5257b06c77a.jpg"
        },

        new VehicleFeatures
        {
            CarId = 7,
            CarName = "Ford Tourneo Courier",
            CarAge = 2016,
            CarFeul = "Dizel",
            CarGear = "Manuel",
            CarCapacity=6,
            CarPrice = 850,
            CarKm = 140000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/ford-tourneo-courier-2017-5f525800ed9f4.png"
        },

        new VehicleFeatures
        {
            CarId = 8,
            CarName = "Fiat Doblo",
            CarAge = 2023,
            CarFeul = "Benzin",
            CarGear = "Manuel",
            CarCapacity=6,
            CarPrice = 1100,
            CarKm = 45000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/fiat-doblo-2017-5f525752c6acf.png"
        },

        new VehicleFeatures
        {
            CarId = 9,
            CarName = "Nissan Qashqai",
            CarAge = 2020,
            CarFeul = "Dizel",
            CarGear = "Otomatik",
            CarCapacity=5,
            CarPrice = 1200,
            CarKm = 64000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/nissan-qashqai-2017-5f5257d91eb66.png"
        },

        new VehicleFeatures
        {
            CarId = 10,
            CarName = "Dacia Duster",
            CarAge = 2024,
            CarFeul = "Benzin",
            CarGear = "Otomatik",
            CarCapacity=5,
            CarPrice = 1800,
            CarKm = 12000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/dacia-duster-2017-5f525764040fd.png"
        },

        new VehicleFeatures
        {
            CarId = 11,
            CarName = "Volkswagen Caravelle",
            CarAge = 2020,
            CarFeul = "Benzin",
            CarGear = "Manuel",
            CarCapacity=9,
            CarPrice = 1100,
            CarKm = 66000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/volkswagen-caravelle-2017-5f52573cdbcfe.png"
        },

        new VehicleFeatures
        {
            CarId = 12,
            CarName = "Mercedes Vito",
            CarAge = 2022,
            CarFeul = "Dizel",
            CarGear = "Otomatik",
            CarCapacity=8,
            CarPrice = 1300,
            CarKm = 55000,
            CarImage = "https://tema16.otokiralamascripti.net/images/cars/mercedes-vito-2017-5f52581c1bdcf.png"
        }

    };

    [HttpGet]
    public IActionResult GetAllCars()
    {
        return Ok(Car);
    }

    [HttpGet("{id}")]
    public IActionResult GetCarById(int id)
    {
        var car = Car.FirstOrDefault(x => x.CarId == id);
        if (car == null)
        {
            return NotFound(new { message = "Araç Bulunamadı" });
        }
        return Ok(car);
    }

    [HttpPost]
    public IActionResult AddCar([FromBody] VehicleFeatures newCar)
    {
        if (newCar == null || string.IsNullOrEmpty(newCar.CarName) || newCar.CarAge <= 0)
        {
            return BadRequest("Invalid car data");
        }

        newCar.CarId = Car.Max(c => c.CarId) + 1;

        Car.Add(newCar);
        return CreatedAtAction(nameof(GetCarById), new { id = newCar.CarId }, newCar);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteCar(int id)
    {
        var car = Car.FirstOrDefault(x => x.CarId == id);
        if (car == null)
        {
            return NotFound(new { message = "Araç bulunamadı" });
        }

        Car.Remove(car);
        return Ok(new { message = "Araç başarıyla silindi" });
    }

}
