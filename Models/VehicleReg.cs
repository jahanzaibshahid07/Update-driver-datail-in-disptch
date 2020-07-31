using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despatch.Models
{
    public class VehicleReg
    {
        public ObjectId _id { get; set; }
        public string veh_type { get; set; }
        public string drv_name { get; set; }
        public string owner_name { get; set; }
        public string office_id { get; set; }
        public string steet1a { get; set; }
        public string steet1b { get; set; }
        public string steet2 { get; set; }
        public string town { get; set; }
        public string county { get; set; }
        public string postcode { get; set; }
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
        public string radio { get; set; }
        public string radio_model { get; set; }
        public string radio_serial_num { get; set; }
        public bool is_active { get; set; }
        public bool is_hide { get; set; }
        public bool shared { get; set; }
        public double insertion_time { get; set; }
    }
}