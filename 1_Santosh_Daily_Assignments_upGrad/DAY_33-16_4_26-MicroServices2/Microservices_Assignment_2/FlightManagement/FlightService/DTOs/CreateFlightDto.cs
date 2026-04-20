namespace FlightService.DTOs
{
    public class CreateFlightDto
    {
        public string? FlightNumber { get; set; }
        public string? Source { get; set; }
        public string? Destination { get; set; }
    }
}
