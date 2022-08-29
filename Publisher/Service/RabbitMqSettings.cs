﻿namespace Publisher.Service
{
    public class RabbitMqSettings
    {
        public string HostName { get; set; } = null!;
        public string ExchangeName { get; set; } = null!;
        public string ExchangeType { get; set; } = null!;
    }
}
