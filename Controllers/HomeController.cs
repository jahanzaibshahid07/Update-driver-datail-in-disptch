using Despatch.App_Start;
using Despatch.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Despatch.Controllers
{
    public class HomeController : Controller
    {
        MongoContext dbcontext = new MongoContext();


        DriverReg dic_list;
        VehicleReg veh_list;
        GetDriverData gdd = new GetDriverData();
        ImageDownload id = new ImageDownload();


        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            //string image = download();
            ViewModel mymodel = new ViewModel();
            mymodel.Driver = gdd.GetDriver();
            mymodel.Vehicle = gdd.GetVehicle();
            return View(mymodel);
        }

        [HttpPost]
        public ActionResult Index(string idd)
        {
            try
            {
   
                //var bitmap = GetDriverImage(idd); // The method that returns Bitmap
                //var bitmapBytes = ImageToByteArray(bitmap);

                ////Convert byte arry to base64string   
                //string imreBase64Data = Convert.ToBase64String(bitmapBytes);
                //string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                ////Passing image data in viewbag to view  
                //ViewBag.ImageData = imgDataURL;

                ViewModel vm = new ViewModel();
                dic_list = gdd.GetDriverWithCall_Sign(idd);
                return Json(new { success = true, obj = dic_list, JsonRequestBehavior.AllowGet });
            }
            catch (Exception)
            {

                return Json(new { success = false, JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPost]
        public ActionResult EditDriver(DriverReg obj1)
        {

            try
            {
                dic_list = gdd.GetDriverWithCall_Sign(obj1.call_sign);

                dic_list.priority = obj1.priority;
                dic_list.DefaultVehicle = obj1.DefaultVehicle;

                if (dic_list.DefaultVehicle == null)
                {
                    dic_list.DefaultVehicle = "";
                }

                dic_list.is_active = obj1.is_active;
                dic_list.AllowBidRadius = obj1.AllowBidRadius;
                dic_list.driverRevert = obj1.driverRevert;
                dic_list.driverBid = obj1.driverBid;
                dic_list.AllowBidGlobal = obj1.AllowBidGlobal;
                dic_list.AllowFutureJob = obj1.AllowFutureJob;
                dic_list.lockout_drv_chk = obj1.lockout_drv_chk;
                dic_list.steet1a = obj1.steet1a;

                if (dic_list.steet1a == null)
                {
                    dic_list.steet1a = "";
                }

                dic_list.steet1b = obj1.steet1b;
                if (dic_list.steet1b == null)
                {
                    dic_list.steet1b = "";
                }
                dic_list.steet2 = obj1.steet2;
                if (dic_list.steet2 == null)
                {
                    dic_list.steet2 = "";
                }
                dic_list.town = obj1.town;
                if (dic_list.town == null)
                {
                    dic_list.town = "";
                }
                dic_list.country = obj1.country;
                if (dic_list.country == null)
                {
                    dic_list.country = "";
                }
                dic_list.postcode = obj1.postcode;
                if (dic_list.postcode == null)
                {
                    dic_list.postcode = "";
                }
                dic_list.home_tele_num = obj1.home_tele_num;
                if (dic_list.home_tele_num == null)
                {
                    dic_list.home_tele_num = "";
                }
                dic_list.taxi_badg_num = obj1.taxi_badg_num;
                if (dic_list.taxi_badg_num == null)
                {
                    dic_list.taxi_badg_num = "";
                }
                dic_list.badg_exp = obj1.badg_exp;
                dic_list.lic_exp = obj1.lic_exp;
                dic_list.dob = obj1.dob;
                dic_list.start_date = obj1.start_date;
                dic_list.end_date = obj1.end_date;
                dic_list.sex_chk = obj1.sex_chk;
                dic_list.email = obj1.email;
                if (dic_list.email == null)
                {
                    dic_list.email = "";
                }
                dic_list.weekdays = obj1.weekdays;
                dic_list.shift_timestart = obj1.shift_timestart;
                dic_list.shift_timeend = obj1.shift_timeend;


                var data = dbcontext.mongoDatabase.GetCollection<DriverReg>("DriverReg");
                var filter = Builders<DriverReg>.Filter.Where(x => x.call_sign == dic_list.call_sign);
                var update = Builders<DriverReg>.Update
                    .Set(x => x.priority, dic_list.priority)
                    .Set(x => x.DefaultVehicle, dic_list.DefaultVehicle)
                    .Set(x => x.is_active, dic_list.is_active)
                    .Set(x => x.AllowBidRadius, dic_list.AllowBidRadius)
                    .Set(x => x.driverRevert, dic_list.driverRevert)
                    .Set(x => x.driverBid, dic_list.driverBid)
                    .Set(x => x.AllowBidGlobal, dic_list.AllowBidGlobal)
                    .Set(x => x.AllowFutureJob, dic_list.AllowFutureJob)
                    .Set(x => x.lockout_drv_chk, dic_list.lockout_drv_chk)
                    .Set(x => x.steet1a, dic_list.steet1a)
                    .Set(x => x.steet1b, dic_list.steet1b)
                    .Set(x => x.steet2, dic_list.steet2)
                    .Set(x => x.town, dic_list.town)
                    .Set(x => x.country, dic_list.country)
                    .Set(x => x.postcode, dic_list.postcode)
                    .Set(x => x.home_tele_num, dic_list.home_tele_num)
                    .Set(x => x.taxi_badg_num, dic_list.taxi_badg_num)
                    .Set(x => x.badg_exp, dic_list.badg_exp)
                    .Set(x => x.lic_exp, dic_list.lic_exp)
                    .Set(x => x.dob, dic_list.dob)
                    .Set(x => x.start_date, dic_list.start_date)
                    .Set(x => x.end_date, dic_list.end_date)
                    .Set(x => x.sex_chk, dic_list.sex_chk)
                    .Set(x => x.email, dic_list.email)
                    .Set(x => x.weekdays, dic_list.weekdays)
                    .Set(x => x.shift_timestart, dic_list.shift_timestart)
                    .Set(x => x.shift_timeend, dic_list.shift_timeend);
                var result = data.UpdateOneAsync(filter, update).Result;



                var data1 = dbcontext.mongoDatabase.GetCollection<DriverAlloc>("DriverAlloc");
                var filter1 = Builders<DriverAlloc>.Filter.Where(x => x.call_sign == dic_list.call_sign);
                var update1 = Builders<DriverAlloc>.Update
                    .Set(x => x.priority, dic_list.priority)
                    .Set(x => x.DefaultVehicle, dic_list.DefaultVehicle)
                    .Set(x => x.is_active, dic_list.is_active)
                    .Set(x => x.AllowBidRadius, dic_list.AllowBidRadius)
                    .Set(x => x.driverRevert, dic_list.driverRevert)
                    .Set(x => x.driverBid, dic_list.driverBid)
                    .Set(x => x.AllowBidGlobal, dic_list.AllowBidGlobal)
                    .Set(x => x.AllowFutureJob, dic_list.AllowFutureJob)
                    .Set(x => x.lockout_drv_chk, dic_list.lockout_drv_chk)
                    .Set(x => x.badg_exp, dic_list.badg_exp)
                    .Set(x => x.lic_exp, dic_list.lic_exp)
                    .Set(x => x.end_date, dic_list.end_date)
                    .Set(x => x.email, dic_list.email)
                    .Set(x => x.weekdays, dic_list.weekdays)
                    .Set(x => x.shift_timestart, datetime(dic_list.shift_timestart))
                    .Set(x => x.shift_timeend, datetime(dic_list.shift_timeend));
                var result1 = data1.UpdateOneAsync(filter1, update1).Result;

                if (result != null || result1 != null)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

            }
            return View();
        }

        [HttpGet]
        public ActionResult UploadDriverImage()
        {
           
            return View();
        }

        [HttpPost]
        public JsonResult UploadDriverImage(HttpPostedFileBase data, string callsign)//, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4, HttpPostedFileBase file5, HttpPostedFileBase file6, HttpPostedFileBase file7, HttpPostedFileBase file9, HttpPostedFileBase file10)
        {
           

            string username = "picbuzybeezuk", password = "Haris_1290";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic1 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages1"];
                var pic2 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages2"];
                var pic3 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages3"];
                var pic4 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages4"];
                var pic5 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages5"];
                var pic6 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages6"];
                var pic7 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages7"];
                var pic8 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages8"];
                var pic9 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages9"];
                var pic10 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages10"];

                //officemameid = Session["officename"].ToString();
                string ftpfullpath = "ftp://pic.buzybeezuk.com/public_html/" + "CYP" + "/" + callsign + "/";

                try
                {
                    var request2 = (FtpWebRequest)WebRequest.Create(ftpfullpath);
                    request2.Credentials = new NetworkCredential(username, password);
                    request2.Method = WebRequestMethods.Ftp.ListDirectory;
                    try
                    {
                        FtpWebResponse response = (FtpWebResponse)request2.GetResponse();
                        response.Close();
                    }
                    catch (WebException ex)
                    {
                        FtpWebResponse response = (FtpWebResponse)ex.Response;
                        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                        {
                            response.Close();
                            var request22 = (FtpWebRequest)WebRequest.Create(ftpfullpath);
                            request22.Credentials = new NetworkCredential(username, password);
                            request22.Method = WebRequestMethods.Ftp.ListDirectory;

                            FtpWebResponse response22 = (FtpWebResponse)request22.GetResponse();
                            response22.Close();
                        }
                    }
                }
                catch (WebException)
                {

                    FtpWebRequest request1 = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpfullpath));
                    request1.Credentials = new NetworkCredential(username, password);
                    request1.Method = WebRequestMethods.Ftp.MakeDirectory;

                    FtpWebResponse response2 = (FtpWebResponse)request1.GetResponse();
                    Stream ftpStream1 = response2.GetResponseStream();
                    ftpStream1.Close();
                    response2.Close();
                }

                if (pic1 != null)
                {
                    //bool uploadcheck = db.FTP_ImgSave(pic1, ftpfullpath, username, password);

                    var uploadfilename = "DriverSnapshot.png";
                    Stream streamObj = pic1.InputStream;
                    byte[] buffer = new byte[pic1.ContentLength];
                    streamObj.Read(buffer, 0, buffer.Length);
                    streamObj.Close();
                    streamObj = null;
                    string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                    var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                    requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                    requestObj.Credentials = new NetworkCredential(username, password);
                    Stream requestStream = requestObj.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Flush();
                    requestStream.Close();
                    requestObj = null;
                }

                try
                {
                    if (pic2 != null)
                    {
                        string[] str1 = pic2.ContentType.Split('/');
                        var uploadfilename = "DrivingLicenceCardBack." + str1[1];
                        Stream streamObj = pic2.InputStream;
                        byte[] buffer = new byte[pic2.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic3 != null)
                    {
                        string[] str1 = pic3.ContentType.Split('/');
                        var uploadfilename = "DrivingLicenceCardFront." + str1[1];
                        Stream streamObj = pic1.InputStream;
                        byte[] buffer = new byte[pic3.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic4 != null)
                    {

                        string[] str1 = pic4.ContentType.Split('/');
                        var uploadfilename = "DrivingLicenceCounterpart." + str1[1];
                        Stream streamObj = pic4.InputStream;
                        byte[] buffer = new byte[pic4.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic5 != null)
                    {

                        string[] str1 = pic5.ContentType.Split('/');
                        var uploadfilename = "PCODriverLicence." + str1[1];
                        Stream streamObj = pic5.InputStream;
                        byte[] buffer = new byte[pic5.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic6 != null)
                    {
                        string[] str1 = pic6.ContentType.Split('/');
                        var uploadfilename = "InsuranceCertificate." + str1[1];
                        Stream streamObj = pic6.InputStream;
                        byte[] buffer = new byte[pic6.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic7 != null)
                    {
                        string[] str1 = pic7.ContentType.Split('/');
                        var uploadfilename = "VehicleLogBook." + str1[1];
                        Stream streamObj = pic7.InputStream;
                        byte[] buffer = new byte[pic7.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic8 != null)
                    {
                        string[] str1 = pic8.ContentType.Split('/');
                        var uploadfilename = "VehiclePCO." + str1[1];
                        Stream streamObj = pic8.InputStream;
                        byte[] buffer = new byte[pic8.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic9 != null)
                    {
                        string[] str1 = pic9.ContentType.Split('/');
                        var uploadfilename = "NationalInsurance." + str1[1];
                        Stream streamObj = pic9.InputStream;
                        byte[] buffer = new byte[pic9.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic10 != null)
                    {
                        string[] str1 = pic10.ContentType.Split('/');
                        var uploadfilename = "MOT." + str1[1];
                        Stream streamObj = pic10.InputStream;
                        byte[] buffer = new byte[pic10.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                }
                catch (Exception)
                {
                    return Json(new { success = false, message = "Please Again Choose The Files !" });
                }

            }
            return Json(new { success = true, message = "Your 50 % Data Submitted !" });
        }
        [HttpPost]
        public JsonResult DownloadDriverImage(DriverReg obj1)
        {
            try
            {
                id.dwnload_attachmnt_btn_Click(obj1.call_sign,"Driver");
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Pictures can not download" });
            }

            return Json(new { success = true, message = "Pictures Downloaded successfully" });

        }

        [HttpGet]
        public ActionResult EditVehicle()
        {
            ViewModel mymodel = new ViewModel();
            mymodel.Vehicle = gdd.GetVehicle();
            return View(mymodel);
        }

        [HttpPost]
        public ActionResult EditVehicle(string idd)
        {
            try
            {
                veh_list = gdd.GetVehicleWithReg(idd);
                return Json(new { success = true, obj = veh_list, JsonRequestBehavior.AllowGet });
            }
            catch (Exception)
            {

                return Json(new { success = false, JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPost]
        public ActionResult UpdateVehicleData(VehicleReg obj1)
        {
            try
            {
                veh_list = gdd.GetVehicleWithReg(obj1.reg);
                if (obj1.drv_name == null)
                {
                    obj1.drv_name = "";
                }
                if (obj1.steet1a == null)
                {
                    obj1.steet1a = "";
                }
                if (obj1.steet1b == null)
                {
                    obj1.steet1b = "";
                }
                if (obj1.town == null)
                {
                    obj1.town = "";
                }
                if (obj1.postcode == null)
                {
                    obj1.postcode = "";
                }
                if (obj1.veh_make == null)
                {
                    obj1.veh_make = "";
                }
                if (obj1.veh_model == null)
                {
                    obj1.veh_model = "";
                }
                if (obj1.body_style == null)
                {
                    obj1.body_style = "";
                }
                if (obj1.colour == null)
                {
                    obj1.colour = "";
                }

                veh_list.drv_name = obj1.drv_name;
                veh_list.is_active = obj1.is_active;
                veh_list.is_hide = obj1.is_hide;
                veh_list.shared = obj1.shared;
                veh_list.owner_name = obj1.owner_name;
                veh_list.postcode = obj1.postcode;
                veh_list.steet1a = obj1.steet1a;
                veh_list.steet1b = obj1.steet1b;
                veh_list.steet2 = obj1.steet2;
                veh_list.town = obj1.town;
                veh_list.county = obj1.county;
                veh_list.veh_make = obj1.veh_make;
                veh_list.veh_model = obj1.veh_model;
                veh_list.body_style = obj1.body_style;
                veh_list.colour = obj1.colour;
                veh_list.road_tax_exp = obj1.road_tax_exp;
                veh_list.plateexp = obj1.plateexp;
                veh_list.mot_exp = obj1.mot_exp;
                veh_list.ins_exp = obj1.ins_exp;

                var data = dbcontext.mongoDatabase.GetCollection<VehicleReg>("VehicleReg");
                var filter = Builders<VehicleReg>.Filter.Where(x => x.reg == veh_list.reg);
                var update = Builders<VehicleReg>.Update
                    .Set(x => x.drv_name, veh_list.drv_name)
                    .Set(x => x.is_active, veh_list.is_active)
                    .Set(x => x.is_hide, veh_list.is_hide)
                    .Set(x => x.shared, veh_list.shared)
                    .Set(x => x.owner_name, veh_list.owner_name)
                    .Set(x => x.postcode, veh_list.postcode)
                    .Set(x => x.steet1a, veh_list.steet1a)
                    .Set(x => x.steet1b, veh_list.steet1b)
                    .Set(x => x.steet2, veh_list.steet2)
                    .Set(x => x.town, veh_list.town)
                    .Set(x => x.county, veh_list.county)
                    .Set(x => x.veh_make, veh_list.veh_make)
                    .Set(x => x.veh_model, veh_list.veh_model)
                    .Set(x => x.body_style, veh_list.body_style)
                    .Set(x => x.colour, veh_list.colour)
                    .Set(x => x.road_tax_exp, veh_list.road_tax_exp)
                    .Set(x => x.plateexp, veh_list.plateexp)
                    .Set(x => x.mot_exp, veh_list.mot_exp)
                    .Set(x => x.ins_exp, veh_list.ins_exp);
                var result = data.UpdateOneAsync(filter, update).Result;


                var data1 = dbcontext.mongoDatabase.GetCollection<VehicleAlloc>("VehicleAlloc");
                var filter1 = Builders<VehicleAlloc>.Filter.Where(x => x.reg == veh_list.reg);
                var update1 = Builders<VehicleAlloc>.Update
                    .Set(x => x.drv_name, veh_list.drv_name)
                    .Set(x => x.is_active, veh_list.is_active)
                    .Set(x => x.is_hide, veh_list.is_hide)
                    .Set(x => x.shared, veh_list.shared)
                    .Set(x => x.veh_make, veh_list.veh_make)
                    .Set(x => x.veh_model, veh_list.veh_model)
                    .Set(x => x.body_style, veh_list.body_style)
                    .Set(x => x.colour, veh_list.colour)
                    .Set(x => x.road_tax_exp, veh_list.road_tax_exp)
                    .Set(x => x.plateexp, veh_list.plateexp)
                    .Set(x => x.mot_exp, veh_list.mot_exp)
                    .Set(x => x.ins_exp, veh_list.ins_exp);
                var result1 = data1.UpdateOneAsync(filter1, update1).Result;

                if (result != null || result1 != null)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

            }
            return View();
        }

        [HttpPost]
        public JsonResult UploadVehicleImage(HttpPostedFileBase data, string reg)//, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4, HttpPostedFileBase file5, HttpPostedFileBase file6, HttpPostedFileBase file7, HttpPostedFileBase file9, HttpPostedFileBase file10)
        {

            string username = "picbuzybeezuk", password = "Haris_1290";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic1 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages1"];
                var pic2 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages2"];
                var pic3 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages3"];
                var pic4 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages4"];
                var pic5 = System.Web.HttpContext.Current.Request.Files["HelpSectionImages5"];

              
                string ftpfullpath = "ftp://pic.buzybeezuk.com/public_html/" + "CYP" + "/" + reg + "/";

                try
                {
                    var request2 = (FtpWebRequest)WebRequest.Create(ftpfullpath);
                    request2.Credentials = new NetworkCredential(username, password);
                    request2.Method = WebRequestMethods.Ftp.ListDirectory;
                    try
                    {
                        FtpWebResponse response = (FtpWebResponse)request2.GetResponse();
                        response.Close();
                    }
                    catch (WebException ex)
                    {
                        FtpWebResponse response = (FtpWebResponse)ex.Response;
                        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                        {
                            response.Close();
                            var request22 = (FtpWebRequest)WebRequest.Create(ftpfullpath);
                            request22.Credentials = new NetworkCredential(username, password);
                            request22.Method = WebRequestMethods.Ftp.ListDirectory;

                            FtpWebResponse response22 = (FtpWebResponse)request22.GetResponse();
                            response22.Close();
                        }
                    }
                }
                catch (WebException)
                {

                    FtpWebRequest request1 = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpfullpath));
                    request1.Credentials = new NetworkCredential(username, password);
                    request1.Method = WebRequestMethods.Ftp.MakeDirectory;

                    FtpWebResponse response2 = (FtpWebResponse)request1.GetResponse();
                    Stream ftpStream1 = response2.GetResponseStream();
                    ftpStream1.Close();
                    response2.Close();
                }

                try
                {
                    if (pic1 != null)
                    {
                        //bool uploadcheck = db.FTP_ImgSave(pic1, ftpfullpath, username, password);

                        var uploadfilename = "VehicleSnapshot.png";
                        Stream streamObj = pic1.InputStream;
                        byte[] buffer = new byte[pic1.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic2 != null)
                    {
                        string[] str1 = pic2.ContentType.Split('/');
                        var uploadfilename = "InsuranceCertificate." + str1[1];
                        Stream streamObj = pic2.InputStream;
                        byte[] buffer = new byte[pic2.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic3 != null)
                    {
                        string[] str1 = pic3.ContentType.Split('/');
                        var uploadfilename = "VehicleLogbook." + str1[1];
                        Stream streamObj = pic1.InputStream;
                        byte[] buffer = new byte[pic3.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic4 != null)
                    {

                        string[] str1 = pic4.ContentType.Split('/');
                        var uploadfilename = "VehiclePCO." + str1[1];
                        Stream streamObj = pic4.InputStream;
                        byte[] buffer = new byte[pic4.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                    if (pic5 != null)
                    {

                        string[] str1 = pic5.ContentType.Split('/');
                        var uploadfilename = "MOT." + str1[1];
                        Stream streamObj = pic5.InputStream;
                        byte[] buffer = new byte[pic5.ContentLength];
                        streamObj.Read(buffer, 0, buffer.Length);
                        streamObj.Close();
                        streamObj = null;
                        string ftpurl = String.Format("{0}/{1}", ftpfullpath, uploadfilename);
                        var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                        requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                        requestObj.Credentials = new NetworkCredential(username, password);
                        Stream requestStream = requestObj.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestObj = null;
                    }
                }
                catch (Exception)
                {
                    return Json(new { success = false, message = "Please Again Choose The Files !" });
                }

            }
            return Json(new { success = true, message = "Your 50 % Data Submitted !" });
        }
       
        [HttpPost]
        public JsonResult DownloadVehicleImage(VehicleReg obj)
        {
            try
            {
                
                id.dwnload_attachmnt_btn_Click(obj.reg,"Vehicle");

            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Pictures can not download" });
            }

            return Json(new { success = true, message = "Pictures Downloaded successfully" });

        }
  
        string ftpfullpath = "ftp://pic.buzybeezuk.com/public_html/";
        string username = "picbuzybeezuk", password = "Haris_1290";

        public Image GetDriverImage(string callsign)
        {

            Image result = null;

            try
            {
                FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath + callsign + "/DriverSnapshot.png");
                req.Credentials = new NetworkCredential(username, password);
                req.Method = WebRequestMethods.Ftp.DownloadFile;
            
                if (req != null)
                {
                    using (var response = req.GetResponse())
                        if (response != null)
                        {
                            var stream = response.GetResponseStream();

                            result = Bitmap.FromStream(stream);

                            response.Close();
                        }
                }


            }
            catch (WebException)
            {

                try
                {
                    FtpWebRequest req2 = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath + callsign + "/DriverSnapshot.png");
                    req2.Credentials = new NetworkCredential(username, password);
                    req2.Method = WebRequestMethods.Ftp.DownloadFile;
             
                    ServicePointManager.DefaultConnectionLimit = 2;
                    if (req2 != null)
                    {
                        using (var response2 = req2.GetResponse())
                            if (response2 != null)
                            {
                                var stream = response2.GetResponseStream();
                                result = Bitmap.FromStream(stream);
                                response2.Close();
                            }
                    }

                }
                catch (Exception)
                {
                    return null;
                }

            }
            return result;
        }

        public string datetime(double anydate)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (long)(Convert.ToDouble(anydate) * TimeSpan.TicksPerSecond);
            string DateTime = new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc).ToString("HH:mm:ss");
            return DateTime;
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

    }
}