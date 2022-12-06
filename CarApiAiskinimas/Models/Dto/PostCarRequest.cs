using System.ComponentModel.DataAnnotations;

namespace CarApiAiskinimas.Models.Dto
{
    public class PostCarRequest
    {
        /// <summary>
        /// Automobilio gamintojo pavadinimas
        /// </summary>
        [MaxLength(50, ErrorMessage = "Mark cannot be more then 50 simbols")]
        public string Mark { get; set; }
        [MaxLength(50, ErrorMessage = "Mark cannot be more then 50 simbols")]

        public string Model { get; set; }
        /// <summary>
        /// Automobilio pagaminimo metai formatu yyyy-MM-dd. Galimi metai nuo 1990 iki 2022
        /// </summary>
        [Range(typeof(DateTime), "1990-01-01", "2022-01-01", ErrorMessage = "date must be between 1990 - 2022")]
        public string Year { get; set; }
        [MaxLength(20, ErrorMessage = "Mark cannot be more then 20 simbols")]

        public string? PlateNumber { get; set; }
        /// <summary>
        /// Autotomobilio pavaru dezes tipas. Galimos reiksmes Manual ir Automatic
        /// </summary>
        [MaxLength(15, ErrorMessage = "Mark cannot be more then 50 simbols")]

        public string GearBox { get; set; }
        /// <summary>
        /// Automobilio kuro tipas. Galimos reiksmes Petrol, Diesel ir Electric
        /// </summary>
        [MaxLength(15, ErrorMessage = "Mark cannot be more then 50 simbols")]

        public string Fuel { get; set; }
    }
}
