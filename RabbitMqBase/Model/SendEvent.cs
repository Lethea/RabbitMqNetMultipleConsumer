using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace RabbitMqBase.Model
{
    public class SendEvent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} CreateDate :{CreateDate}";
        }
    }
}
