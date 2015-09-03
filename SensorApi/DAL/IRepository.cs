using MvcTester.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTester.DAL
{
    public interface IRepository
    {
        void InsertReading(Reading rd);
        List<Reading> GetReadings();
    }
}
