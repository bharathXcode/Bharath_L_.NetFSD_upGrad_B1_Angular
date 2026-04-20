using AutoMapper;
using PassengerService.DTOs;
using PassengerService.Model;

namespace PassengerService.Profiles
{
    public class PassengerProfile:Profile
    {
        public PassengerProfile()
        {
            CreateMap<Passenger, ReadPassengerDto>();
            CreateMap<CreatePassengerDto, Passenger>();
            CreateMap<Passenger, ReadPassengerDto>();
        }
    }
}
