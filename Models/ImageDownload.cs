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

namespace Despatch.Models
{
    public class ImageDownload
    {

        public void dwnload_attachmnt_btn_Click(string regcallsign,string DriverOrVehicle)
        {
            try
            {
                string officename = "CYP";
                string officeurl = "ftp://pic.buzybeezuk.com/public_html/";
                string tb_CallSign = regcallsign;
                string path = "";
                try
                {
                    string userURL = officeurl + officename + "/" + tb_CallSign + "/";

                    if (DriverOrVehicle == "Vehicle")
                    {
                        path = @"C:\Vehicle\" + tb_CallSign + "/";
                    }
                    else if(DriverOrVehicle == "Driver")
                    {
                        path = @"C:\Driver\" + tb_CallSign + "/";
                    }
               

                    if (System.IO.File.Exists(path))
                    {

                        string[] files = GetFileList(userURL, path);

                        if (files.Length == 0)
                        {


                            return;
                        }
                        else

                            foreach (string file in files)
                            {
                                string temp = Download(file, userURL, tb_CallSign, DriverOrVehicle);
                                if (!temp.Contains("Successfull"))
                                {

                                }


                            }
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(path);


                        string[] files = GetFileList(userURL, path);
                        if (files == null)
                        {

                            return;
                        }
                        else
                            foreach (string file in files)
                            {
                                Download(file, userURL, tb_CallSign, DriverOrVehicle);
                            }
                    }



                }
                catch (Exception)
                {

                }
            }
            catch (Exception)
            {

            }
        }
        public string Download(string file, string user_url, string callsign, string DriverOrVehicle)
        {
            string result = "";
            string remote = "";
            try
            {

   
                if (DriverOrVehicle == "Vehicle")
                {
                    remote = @"C:\Vehicle\";
                }
                else if(DriverOrVehicle == "Driver")
                {
                    remote = @"C:\Driver\";
                }
                
               
                string uri = user_url + file;
                Uri serverUri = new Uri(uri);
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return "";
                }
                FtpWebRequest reqFTP;
                try
                {

                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(user_url + file));
                    reqFTP.Credentials = new NetworkCredential("picbuzybeezuk", "Haris_1290");
            
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                   
                    using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                    {
                        Stream responseStream = response.GetResponseStream();
                        FileStream writeStream = new FileStream(remote + "/" + callsign + "/" + file, FileMode.Create);
                        int Length = 2048;
                        Byte[] buffer = new Byte[Length];
                        int bytesRead = responseStream.Read(buffer, 0, Length);
                        while (bytesRead > 0)
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                            bytesRead = responseStream.Read(buffer, 0, Length);
                        }
                        writeStream.Close();
                        response.Close();
                        result = "Successfull";

                    }

                }
                catch (Exception)
                {

                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(user_url + file));
                    reqFTP.Credentials = new NetworkCredential("picbuzybeezuk", "Haris_1290");
                    reqFTP.KeepAlive = false;
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.Proxy = null;
                    reqFTP.UsePassive = false;
                    using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                    {
                        Stream responseStream = response.GetResponseStream();
                        FileStream writeStream = new FileStream(remote + "/" + callsign + "/" + file, FileMode.Create);
                        int Length = 2048;
                        Byte[] buffer = new Byte[Length];
                        int bytesRead = responseStream.Read(buffer, 0, Length);
                        while (bytesRead > 0)
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                            bytesRead = responseStream.Read(buffer, 0, Length);
                        }
                        writeStream.Close();
                        response.Close();
                        result = "Successfull";

                    }


                }
            }
            catch (WebException wEx)
            {
                result = wEx.Message + " Download Error";
            }
            return result;
        }
        public string[] GetFileList(string user_url, string path)
        {
            //userURL = officeURL + txtCallSign.Text + "/";
            //string path = @"C:\drv\" + Program.officeAbb + "/" + txtCallSign.Text;


            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                //reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(userURL));
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(user_url));
                //reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential("picbuzybeezuk", "Haris_1290");
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                // reqFTP.Proxy = null;
                //reqFTP.KeepAlive = false;
                //reqFTP.UsePassive = false;
                //reqFTP.Timeout = 3000;

                // ServicePointManager.DefaultConnectionLimit = 2;

                using (response = reqFTP.GetResponse())
                {
                    reader = new StreamReader(response.GetResponseStream());

                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        if (!line.StartsWith("."))
                        {
                            result.Append(line);
                            result.Append("\n");

                        }

                        line = reader.ReadLine();

                    }
                    StringBuilder re = result;

                    // to remove the trailing '\n'
                    result.Remove(result.ToString().LastIndexOf('\n'), 1);
                    response.Close();
                    return result.ToString().Split('\n');

                }

            }
            catch
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                downloadFiles = null;
                return downloadFiles;
            }
        }

    }
}