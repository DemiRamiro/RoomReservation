using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomReservation.Services
{
    public class Greeter : IGreeter
    {
        private readonly IConfiguration _config;

        public Greeter(IConfiguration config)
        {
            _config = config;
        }

        public string GreetGuest()
        {
            return _config["Greetings"];
        }
    }
}
