using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despatch.Models
{
    public class DriverReg
    {
        public ObjectId _id { get; set; }
        public string drv_Name { get; set; }
        public string drvuid { get; set; }
        public string office_id { get; set; }
        public string call_sign { get; set; }
        public string pdaPin { get; set; }
        public string steet1a { get; set; }
        public string steet1b { get; set; }
        public string steet2 { get; set; }
        public string town { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
        public string home_tele_num { get; set; }
        public string mob_tele_num { get; set; }
        public string taxi_badg_num { get; set; }
        public double badg_exp { get; set; }
        public string drvlic_num { get; set; }
        public double lic_exp { get; set; }
        public double dob { get; set; }
        public double start_date { get; set; }
        public double end_date { get; set; }
        public string sex_chk { get; set; }

        //public string veh_type { get; set; }
        public string nat_ins_num { get; set; }
        public string last_statemnt_date { get; set; }
        public string laststatement_num { get; set; }
        public string balance { get; set; }
        public string prnt_cashstatement_chk { get; set; }
        public string pricrate { get; set; }
        public string statement_period { get; set; }
        public string statement_style { get; set; }
        public string schedule { get; set; }
        public bool lockout_drv_chk { get; set; }
        public string lowest_score { get; set; }
        public string highest_score { get; set; }
        public string longrote_score { get; set; }
        public double shift_timestart { get; set; }
        public double shift_timeend { get; set; }
        public bool is_active { get; set; }
        public bool is_hide { get; set; }
        public List<string> weekdays { get; set; }
        public double insertion_time { get; set; }
        public string DefaultVehicle { get; set; }
        public string dfid { get; set; }
        public int priority { get; set; }
        public bool driverRevert { get; set; }
        public bool driverBid { get; set; }
        public bool AllowBidGlobal { get; set; }
        public bool AllowFutureJob { get; set; }
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
        public string var_comm_value_type { get; set; }
        public double CommissionDown { get; set; }
       

        // "_id" : ObjectId("5d085379935045d9a4c54adb"),
        //"reg" : "SM12HXP",
        //"vcolour" : "SILVER",
        //"vmake" : "TOYOTA",
        //"vmodel" : "PRIUS T3 \n- Device: Android SM-G965F OS: 9 AppVersion: 10.2\nMobile Data: 3G\nKiosk: false\nactivity: In Vehicle \n@ETA: 1 minutes\nDevice unlocked\nBattery Power Save Mode: N/A",
        //"vtype" : "S",
        //"lng" : -0.2793335,
        //"lat" : 51.3800301,
        //"accuracy" : 6,
        //"isvirtual" : false,
        //"callsign" : "5",
        //"name" : "Mohammed Mohamud Ahmed",
        //"office_id" : "SUR",
        //"state" : "Accepted",
        //"lstate" : "ENG",
        //"loc" : {
        //    "type" : "Point",
        //    "coordinates" : [
        //        -0.2752352,
        //        51.3842636
        //    ]
        //},
        //"battery" : "64",
        //"clrtimestamp" : 1560846553,
        //"outcodetime" : 1560846664,
        //"timestamp" : 1560846749,
        //"jobid" : "5d088a69d4af0c2378ab5d3e",
        //"from" : "STATION CARS SURBITON LTD GLENBUCK ROAD",
        //"to" : "NORTH STREET, GUILDFORD GU1 4AW, UK",
        //"priority" : 0,
        //"outcode" : "tolworth",
        //"speed" : 0,
        //"telephone" : "07424916314"
    }

}