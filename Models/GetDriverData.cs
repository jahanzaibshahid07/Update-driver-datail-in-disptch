using Despatch.App_Start;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despatch.Models
{
    public class GetDriverData
    {
        MongoContext dbcontext = new MongoContext();
        DriverReg dic_list = new DriverReg();
        public List<DriverReg> GetDriver()
        {
           
            var data = dbcontext.mongoDatabase.GetCollection<DriverReg>("DriverReg");
            var list = data.AsQueryable<DriverReg>().Where(x => x.office_id == "CYP").ToList();
            List<DriverReg> dri_list = (List<DriverReg>)list;
            return dri_list;
        }

        public DriverReg GetDriverWithCall_Sign(string call_sign)
        {
        
            var data1 = dbcontext.mongoDatabase.GetCollection<DriverReg>("DriverReg");
            DriverReg list1 = data1.AsQueryable<DriverReg>().Where(x => x.office_id == "CYP" && x.call_sign == call_sign).FirstOrDefault();
            return list1;
        }

        public List<VehicleReg> GetVehicle()
        {
            var vehdata = dbcontext.mongoDatabase.GetCollection<VehicleReg>("VehicleReg");
            var vehlist1 = vehdata.AsQueryable<VehicleReg>().Where(x => x.office_id == "CYP").ToList();
            List<VehicleReg> veh_type = (List<VehicleReg>)vehlist1;
            return veh_type;
        }

        public VehicleReg GetVehicleWithReg(string reg)
        {

            var data1 = dbcontext.mongoDatabase.GetCollection<VehicleReg>("VehicleReg");
            VehicleReg list1 = data1.AsQueryable<VehicleReg>().Where(x => x.office_id == "CYP" && x.reg == reg).FirstOrDefault();
            return list1;
        }
    }
}