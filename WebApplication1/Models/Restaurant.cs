using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Api
{
    public class Restaurant
    {   
        /// <summary>
        /// Nome dos restaurantes abertos
        /// </summary>
        public string Name { get; set; }

        public Restaurant(string name)
        {
            this.Name = name;
        }
    }
}
