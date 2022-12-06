namespace CarApiAiskinimas.Models.Dto
{
    public class FilterCarRequest
    {
        public string? Mark { get; set; }
        public string? Model { get; set; }
        
        /// <summary>
        /// Autotomobilio pavaru dezes tipas. Galimos reiksmes Manual ir Automatic
        /// </summary>
        public string? GearBox { get; set; }
        /// <summary>
        /// Automobilio kuro tipas. Galimos reiksmes Petrol, Diesel ir Electric
        /// </summary>
        public string? Fuel { get; set; }
    }
}
