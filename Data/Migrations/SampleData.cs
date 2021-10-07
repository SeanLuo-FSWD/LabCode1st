using System;
using System.Linq;
using System.Collections.Generic;
using LabCode1st.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using LabCode1st.Data;

namespace Code1st.Data
{
    public class SampleData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (context.Provinces.Any())
                {
                    return;
                }

                var Provinces = GetProvinces().ToArray();
                context.Provinces.AddRange(Provinces);
                context.SaveChanges();

                var Cities = GetCities(context).ToArray();
                context.Cities.AddRange(Cities);
                context.SaveChanges();
            }
        }

        public static List<Province> GetProvinces()
        {
            List<Province> Provinces = new List<Province>() {
            new Province() {
                ProvinceCode="BC",
                ProvinceName="British Columbia",
            },
            new Province() {
                ProvinceCode="ON",
                ProvinceName="Ontario",
            },
            new Province() {
                ProvinceCode="QC",
                ProvinceName="Quebec",
            },
        };

            return Provinces;
        }

        public static List<City> GetCities(ApplicationDbContext context)
        {
            List<City> Cities = new List<City>() {
            new City {
                CityName = "Vancouver",
                Population = 2000000,
                ProvinceCode = "BC",
            },
            new City {
                CityName = "Victoria",
                Population = 500000,
                ProvinceCode = "BC",
            },
            new City {
                CityName = "Kamloops",
                Population = 50000,
                ProvinceCode = "BC",
            },
            new City {
                CityName = "Toronto",
                Population = 6000000,
                ProvinceCode = "ON",
            },
            new City {
                CityName = "Hamilton",
                Population = 30000,
                ProvinceCode = "ON",
            },
            new City {
                CityName = "Ottawa",
                Population = 1000000,
                ProvinceCode = "ON",
            },
            new City {
                CityName = "Montreal",
                Population = 4000000,
                ProvinceCode = "QC",
            },
            new City {
                CityName = "Quebec City",
                Population = 50000,
                ProvinceCode = "QC",
            },
            new City {
                CityName = "Gatineau",
                Population = 30000,
                ProvinceCode = "QC",
            },
        };

            return Cities;
        }
    }
}
