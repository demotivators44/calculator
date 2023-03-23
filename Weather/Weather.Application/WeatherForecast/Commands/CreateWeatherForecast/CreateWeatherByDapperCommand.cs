using MediatR;

namespace Weather.Application.WeatherForecasts.Commands.CreateWeatherForecast
{
    public record CreateWeatherByDapperCommand : IRequest<int>
    {
        public DateTime Date { get; init; }
        public int TemperatureC { get; init; }
        public string? Summary { get; init; }
    }

    public class CreateWeatherByDapperHandler : IRequestHandler<CreateWeatherByDapperCommand, int>
    {
        private readonly IDapperRepository _dapperRepository;

        public CreateWeatherByDapperHandler(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<int> Handle(CreateWeatherByDapperCommand request, CancellationToken cancellationToken)
        {
            int id = await _dapperRepository.CreateWeather(request.Date.Date, request.TemperatureC, request.Summary);
            return id;
        }
    }
}