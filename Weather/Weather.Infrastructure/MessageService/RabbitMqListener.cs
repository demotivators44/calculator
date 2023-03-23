using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;
using Weather.Application.Common.Interfaces;
using Weather.Application.WeatherForecasts.Commands.CreateWeatherForecast;
using Weather.Infrastructure.Persistence;

public class RabbitMqListener : BackgroundService
{
	private IConnection _connection;
	private IModel _channel;
	private readonly IMediator _mediator;
	private readonly IServiceProvider _serviceProvider;

	public RabbitMqListener(IMediator mediator, IServiceProvider serviceProvider)
	{
		// Не забудьте вынести значения "localhost" и "MyQueue"
		// в файл конфигурации
		var factory = new ConnectionFactory { HostName = "localhost" };
		_connection = factory.CreateConnection();
		_channel = _connection.CreateModel();
		_channel.QueueDeclare(queue: "MyQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

		this._mediator = mediator;
		_serviceProvider = serviceProvider;
	}

	protected override Task ExecuteAsync(CancellationToken stoppingToken)
	{
		stoppingToken.ThrowIfCancellationRequested();

		var consumer = new EventingBasicConsumer(_channel);
		consumer.Received += (ch, ea) =>
		{
			var content = Encoding.UTF8.GetString(ea.Body.ToArray());

			// Каким-то образом обрабатываем полученное сообщение
			_mediator.Send(new CreateWeatherCommand { Date = DateTime.Now.AddDays(50), Summary = content, TemperatureC = 1 });

			using (IServiceScope scope = _serviceProvider.CreateScope())
			{
				IApplicationDbContext scopedProcessingService =
					scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

				scopedProcessingService.WeatherForecasts.Add()
			}

			Debug.WriteLine($"Message received: {content}");

			_channel.BasicAck(ea.DeliveryTag, false);
		};

		_channel.BasicConsume("MyQueue", false, consumer);

		return Task.CompletedTask;
	}

	public override void Dispose()
	{
		_channel.Close();
		_connection.Close();
		base.Dispose();
	}
}
