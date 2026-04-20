using AutoMapper;
using PassengerService.DTOs;
using PassengerService.Model;
using PassengerService.Repositories;

namespace PassengerService.Services
{
    public class PassengerService:IPassengerService
    {
        private readonly IPassengerRepository _repository;
        private readonly IMapper _mapper;

        public PassengerService(IPassengerRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreatePassenger(CreatePassengerDto dto)
        {
            var passenger = _mapper.Map<Passenger>(dto);
            await _repository.Create(passenger);
        }

        public async Task<List<ReadPassengerDto>> GetAllPassenger()
        {
            var passengers=await _repository.GetAll();
            var passengerDto = _mapper.Map<List<ReadPassengerDto>>(passengers);
            return passengerDto;
        }
    }
}
