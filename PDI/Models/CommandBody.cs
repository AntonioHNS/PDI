
using System.Security.Cryptography;
using System;
using System.Reflection;

namespace PDI.Models
{
    public class CommandBody
    {
        public string? Id { get; set; }
        public string? To { get; set; }
        public string? Method { get; set; }
        public string? Uri { get; set; }
        public string? Type { get; set; }
        public Resource? Resource { get; set; }

        public CommandBody() { }

        public CommandBody(string _to, String _method, string _uri)
        {
            Id= Guid.NewGuid().ToString();
            To = _to;
            Method = _method;
            Uri = _uri;
        }

        public CommandBody(string _id, string _to, String _method, string _uri, string _type, Resource _resource)
        {
            Id = Guid.NewGuid().ToString();
            To = _to;
            Method = _method;
            Uri = _uri;
            Type = _type;
            Resource = _resource;
        }
    }
}



/*{
    "id": "{{$guid}}",
    "to": "postmaster@desk.msging.net",
    "method": "set",
    "uri": "/attendance-queues",
    "type": "application/vnd.iris.desk.attendancequeue+json",
    "resource": {
        "name": "Queue name",
        "isActive": true
    }
}*/