using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despatch.Models
{
    public class VehicleAlloc
    {
        public ObjectId _id { get; set; }
        public string veh_type { get; set; }
        public string drv_name { get; set; }
        public string owner_name { get; set; }
        public string office_id { get; set; }
        public string veh_make { get; set; }
        public string veh_model { get; set; }
        public string body_style { get; set; }
        public string colour { get; set; }
        public string reg { get; set; }
        public double mot_exp { get; set; }
        public double ins_exp { get; set; }
        public double road_tax_exp { get; set; }
        public string plateid { get; set; }
        public double plateexp { get; set; }
        public bool is_active { get; set; }
        public bool is_inuse { get; set; }
        public bool is_hide { get; set; }
        public double insettion_time { get; set; }
        public bool shared { get; set; }
        public string deviceid { get; set; }
    }
}