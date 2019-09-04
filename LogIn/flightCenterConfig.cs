using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public static class flightCenterConfig
    {
        public const string CONNECTION_STRING = @"Data Source=.;Initial Catalog=FlightsAirline_project;Integrated Security=True";
        public const string ADMIN_NAME = "Admin";
        public const string ADMIN_PASSWORD = "9999";
        public const int SleepingTime = 24 * 60 * 60 * 1000;
    }
}

