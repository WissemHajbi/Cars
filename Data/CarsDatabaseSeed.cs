using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data;

public class CarsDatabasSeed
{
    public static void Seed(IApplicationBuilder builder)
    {
        using (var service = builder.ApplicationServices.CreateScope())
        {
            var context = service.ServiceProvider.GetService<CarsDbContext>();
            context.Database.EnsureCreated();

            // Brands
            if (!context.Brands.Any())
            {
                context.Brands.AddRange(new List<Brand>()
                {
                    new Brand()
                    {
                        PictureUrl = @"\images\Brands\Mercedes.png",
                        Name = "Mercedes",
                        Origin = "German",
                    },
                    new Brand()
                    {
                        PictureUrl = @"\images\Brands\Porsche.png",
                        Name = "Porsche",
                        Origin = "German",
                    },
                    new Brand()
                    {
                        PictureUrl = @"\images\Brands\Bentley.png",
                        Name = "Bentley",
                        Origin = "England",
                    },
                    new Brand()
                    {
                        PictureUrl = @"\images\Brands\Bmw.png",
                        Name = "Bmw",
                        Origin = "German",
                    }
                });
                context.SaveChanges();
            }

            // Cars
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(new List<Car>()
                {
                    new Car()
                    {
                        PictureUrl = @"\images\Cars\mercedes_c-class.png",
                        Name = "C-class",
                        Bio = "The 2023 Mercedes-Benz C-Class has been completely redesigned, and the result is a true European driving experience with many features that echo those of the formidable Mercedes S-Class.",
                        BrandId = context.Brands.First(x => x.Name == "Mercedes").Id,
                        brand = context.Brands.First(x => x.Name == "Mercedes"),
                    },
                    new Car()
                    {
                        PictureUrl =  @"\images\Cars\mercedes_amg-gt.png",
                        Name = "AMG GT",
                        Bio = "The Mercedes-Benz AMG GT is a 5-seater vehicle that comes in 4 trim levels. The most popular style is the AMG GT 63 4-Door Coupe,",
                        BrandId = context.Brands.First(x => x.Name == "Mercedes").Id,
                        brand = context.Brands.First(x => x.Name == "Mercedes"),
                    },
                    new Car()
                    {
                        PictureUrl =  @"\images\Cars\porsche_718_cayman.png",
                        Name = "718 CAYMAN",
                        Bio = "Like its cabriolet counterpart, the 718 Boxster, the 718 Cayman coup?? is all about pure driving fun mixed with practicality.",
                        BrandId = context.Brands.First(x => x.Name == "Porsche").Id,
                        brand = context.Brands.First(x => x.Name == "Porsche"),
                    },
                    new Car()
                    {
                        PictureUrl =  @"\images\Cars\bentley_Continental_GT.png",
                        Name = "Continental GT",
                        Bio = "But as is the trend with BMW M, the M2 needed time to mature, to develop and to grow ever more extreme. The broad recipe was very similar to the 1M but with more budget and more muscle. The CS is the logical extreme: carbon bodywork, an M4 engine at full muscle (444PS, 331kW).",
                        BrandId = context.Brands.First(x => x.Name == "Bmw").Id,
                        brand = context.Brands.First(x => x.Name == "Bmw"),
                    },
                    new Car()
                    {
                        PictureUrl =  @"\images\Cars\bentley_Continental GT.png",
                        Name = "Continental GT",
                        Bio = "Choose a Continental GT with either a V8 or W12 engine and you are guaranteed no less than 542 hp, with the W12 option offering a staggering 650 hp. Besides this, you will ride in one of the world's most amazing grand tourers and the cr??me of its class.",
                        BrandId = context.Brands.First(x => x.Name == "Bentley").Id,
                        brand = context.Brands.First(x => x.Name == "Bentley"),
                    }
                });
                context.SaveChanges();
            }

            // Sales
            if (!context.Sales.Any())
            {
                context.Sales.AddRange(new List<Sale>()
                {
                    new Sale()
                    {
                        Name = "C-class",
                        Description = "The Mercedes-Benz AMG GT is a 5-seater vehicle that comes in 4 trim levels.",
                        Price = 117.156,
                        Distance = 0f,
                        ImageUrl = context.Cars.First(x => x.Name == "C-class").PictureUrl,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(+60),
                        Categories = CarsCategories.SportsCar,
                        CarId = 0,
                        car = context.Cars.First(x => x.Name == "C-class"),
                        capacity = 12
                    },
                    new Sale()
                    {
                        Name = "AMG GT",
                        Description = "The Mercedes-Benz AMG GT is a 5-seater vehicle that comes in 4 trim levels.",
                        Price = 250.14,
                        Distance = 115.140f,
                        ImageUrl = context.Cars.First(x => x.Name == "AMG GT").PictureUrl,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(+60),
                        Categories = CarsCategories.Truck,
                        CarId = 1,
                        car = context.Cars.First(x => x.Name == "AMG GT"),
                        capacity = 12
                    },
                    new Sale()
                    {
                        Name = "718 CAYMAN",
                        Description = "The Mercedes-Benz AMG GT is a 5-seater vehicle that comes in 4 trim levels.",
                        Price = 490.99,
                        Distance = 0f,
                        ImageUrl = context.Cars.First(x => x.Name == "718 CAYMAN").PictureUrl,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(+60),
                        Categories = CarsCategories.Truck,
                        CarId = 2,
                        car = context.Cars.First(x => x.Name == "718 CAYMAN"),
                        capacity = 12
                    }
                });
                context.SaveChanges();
            }


        }
    }

    public static void UnSeed(IApplicationBuilder builder)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<CarsDbContext>();
            context.Database.EnsureCreated();

            foreach (var item in context.Brands)
            {
                context.Brands.Remove(item);
            }
            foreach (var item in context.Cars)
            {
                context.Cars.Remove(item);
            }
            foreach (var item in context.Sales)
            {
                context.Sales.Remove(item);
            }

            context.SaveChanges();
        }
    }

}