namespace RabbitMqBase.Model
{
    public class RabbitMqConnectionInfo
    {
        public string Hostname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public int ConsumerCount { get; set; }
    }
}
