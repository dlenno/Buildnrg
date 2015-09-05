using SensorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApi.DAL
{
    public interface IRepository
    {
        void InsertReading(Reading rd);
        List<Reading> GetReadings();
    }
}
