using AutoMapper;
using FlightService.DTOs;
using FlightService.Model;
using FlightService.Service;

namespace FlightService.Services
{
    public class FlightService:IFlightService
    {
        private readonly IFlightRepository _repository;
        private readonly IMapper _mapper;

        public FlightService(IFlightRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddFlightAsync(CreateFlightDto dto)
        {
            var flight = _mapper.Map<Flight>(dto);
            await _repository.CreateAsync(flight);
        }

        public async Task DeleteFlightAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ReadFlightDto>> GetAllFlightAsync()
        {
            var flights=await _repository.GetAllAsync();
            var flightDto = _mapper.Map<List<ReadFlightDto>>(flights);
            return flightDto;
        }

        public async Task<ReadFlightDto> GetFlightByIdAsync(int id)
        {
            var flight = await _repository.GetByIdAsync(id);
            return _mapper.Map<ReadFlightDto>(flight);
        }

        public async Task UpdateFlightAsync(int id,UpdateFlightDto dto)
        {
            var flight=_mapper.Map<Flight>(dto);
            flight.Id=id;
            await _repository.UpdateAsync(id,flight);
        }
    }
}
