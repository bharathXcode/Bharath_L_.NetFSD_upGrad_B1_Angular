using AutoMapper;
using FlightService.DTOs;
using FlightService.Model;

namespace FlightService.Profiles
{
    public class FlightProfile:Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, ReadFlightDto>();
            CreateMap<CreateFlightDto, Flight>();
            CreateMap<UpdateFlightDto, Flight>();
            CreateMap<ReadFlightDto, Flight>();

        }
    }
}
