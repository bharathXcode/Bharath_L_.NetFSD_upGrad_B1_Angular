namespace FlightAPI.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightCode { get; set; } = string.Empty;
        public int Seat { get; set; }
        public string FlightType { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
    }
}