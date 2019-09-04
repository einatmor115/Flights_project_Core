using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project.Facade
{
    public class CleaningDataFacade 
    {       
        public void CleanData()
        {
            Flights_project.DAOClean DAOCleaning = new DAOClean();
            DAOCleaning.CleanFlithsAndTickets();
        }
    }
}
