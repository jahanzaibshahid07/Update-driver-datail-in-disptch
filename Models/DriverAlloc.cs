using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despatch.Models
{
    public class DriverAlloc
    {
        public ObjectId _id { get; set; }
        public string drv_name { get; set; }
        public string office_id { get; set; }
        public string call_sign { get; set; }
        public string drvuid { get; set; }
        public string pin_num { get; set; }
        public double badg_exp { get; set; }
        public double lic_exp { get; set; }
        public double end_date { get; set; }
        public bool lockout_drv_chk { get; set; }
        public bool is_active { get; set; }
        public bool is_hide { get; set; }
        public bool is_engage { get; set; }
        public bool isvirtual { get; set; }
        public List<string> weekdays { get; set; }
        public string shift_timestart { get; set; }
        public string shift_timeend { get; set; }
        public double insertion_time { get; set; }
        public string DefaultVehicle { get; set; }
        public string deviceid { get; set; }
        public int priority { get; set; }
        public bool driverRevert { get; set; }
        public bool driverBid { get; set; }
        public bool ApplicationLogs { get; set; }
        public bool AllowBidGlobal { get; set; }
        public bool AllowBidRadius { get; set; }
        public string email { get; set; }
        public string agent_id { get; set; }
        public double comm_startdate { get; set; }
        public double comm_enddate { get; set; }
        public double comm_value { get; set; }
        public string comm_value_as { get; set; }
        public string comm_type { get; set; }
        public double var_comm_startdate { get; set; }
        public double var_comm_enddate { get; set; }
        public string var_comm_monthlychange { get; set; }
        public double var_comm_value { get; set; }
        public string var_comm_value_as { get; set; }
        public bool AllowFutureJob { get; set; }

    }
}