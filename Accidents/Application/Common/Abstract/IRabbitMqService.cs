﻿namespace Application.Common.Abstract
{
	public interface IRabbitMqService
	{
		void SendMessage(object obj);
		void SendMessage(string message);
	}
}
