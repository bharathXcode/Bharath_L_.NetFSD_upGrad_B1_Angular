using AutoMapper;
using BookingService.DTOs;
using BookingService.Model;

namespace BookingService.Profiles
{
    public class BookingProofile:Profile
    {
        public BookingProofile()
        {
            CreateMap<Booking, ReadBookingDto>();
            CreateMap<CreateBookingDto, Booking>();
            CreateMap<ReadBookingDto, Booking>();
        }
    }
}
