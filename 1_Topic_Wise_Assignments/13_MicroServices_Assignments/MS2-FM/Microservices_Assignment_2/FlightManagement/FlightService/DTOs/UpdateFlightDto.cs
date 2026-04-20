namespace FlightService.DTOs
{
    public class UpdateFlightDto
    {
        public int Id { get; set; }
        public string? FlightNumber { get; set; }
        public string? Source { get; set; }
        public string? Destination { get; set; }
    }
}
