using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LabCode1st.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Display(Name = "City")]
        public string CityName { get; set; }
        public int Population { get; set; }

        [Display(Name = "Province")]
        public string ProvinceCode { get; set; }


        [ForeignKey("ProvinceCode")]
        [JsonIgnore]
        public Province Province { get; set; }

        public City()
        {
        }
    }
}
