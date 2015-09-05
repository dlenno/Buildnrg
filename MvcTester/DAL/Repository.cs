using SensorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorApi.DAL
{
    public class Repository : IRepository
    {
        SensorDBEntities db = new SensorDBEntities();

        public void InsertReading(Reading rd)
        {
            //Building b = new Building { BuildingId = Guid.NewGuid(), Location = "here", Name = "house" };
            //db.Buildings.Add(b);
            //db.SaveChanges();

            //Pi p = new Pi { Building = b, BuildingId = b.BuildingId, Name = "P1", PiId = Guid.NewGuid() };
            //db.Pis.Add(p);
            //db.SaveChanges();

            //rd.Building = b;
            //rd.BuildingId = b.BuildingId;
            //rd.PiId = p.PiId;
            

            db.Readings.Add(rd);
            db.SaveChanges();
        }

        public List<Reading> GetReadings()
        {
            var gg = db.Readings.OrderByDescending(a => a.Time).ToList();
            var tf = db.Readings.ToList().Where(a => a.Time > DateTime.Today.AddDays(-1)).ToList();
            return tf;
        }
    }
}