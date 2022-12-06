namespace CarApiAiskinimas.Models.Dto
{
    public class PutCarRequest
    {
        /// <summary>
        /// Autogeneracinis id is duomenu bazes
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Automobilio gamintojo pavadinimas
        /// </summary>
        public string Mark { get; set; }
        public string Model { get; set; }
        /// <summary>
        /// Automobilio pagaminimo metai formatu yyyy-MM-dd
        /// </summary>
        public string Year { get; set; }
        public string PlateNumber { get; set; }
        /// <summary>
        /// Autotomobilio pavaru dezes tipas. Galimos reiksmes Manual ir Automatic
        /// </summary>
        public string GearBox { get; set; }
        /// <summary>
        /// Automobilio kuro tipas. Galimos reiksmes Petrol, Diesel ir Electric
        /// </summary>
        public string Fuel { get; set; }
    }
}
