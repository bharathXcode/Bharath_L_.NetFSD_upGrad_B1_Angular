using AutoMapper;
using BookingService.DTOs;
using BookingService.Model;

namespace BookingService.Services
{
    public class BookingService:IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper= mapper;
        }

        public async Task CreateBookingAsync(CreateBookingDto dto)
        {
            var booking = _mapper.Map<Booking>(dto);
            await _repository.CreateAsync(booking);
        }

        public async Task<List<ReadBookingDto>> GetAllBookingsAsync()
        {
            var booking=await _repository.GetAllAsync();
            var bookingDto=_mapper.Map<List<ReadBookingDto>>(booking);
            return bookingDto;
        }

        public async Task<ReadBookingDto> GetBookingByIdAsync(int id)
        {
            var booking = await _repository.GetByIdAsync(id);
            return _mapper.Map<ReadBookingDto>(booking);
        }
    }
}
