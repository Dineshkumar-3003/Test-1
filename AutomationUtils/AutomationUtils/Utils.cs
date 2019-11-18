using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;
using System.Diagnostics;
using Excel;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using ClosedXML.Excel;

namespace AutomationUtils
{
    public static class Utils
    {

        public static void SendMail(String Subject, String contentBody, string dateTimeInString)
        {
            MailMessage mail = new MailMessage();
            string[] toAddrs = ConfigurationManager.AppSettings["ToMail"].Split(';');
            foreach (string addr in toAddrs)
            {
                if (!string.IsNullOrEmpty(addr))
                {
                    mail.To.Add(addr);
                }
            }

            mail.From = new MailAddress(ConfigurationManager.AppSettings["FromMail"]);
            mail.Subject = ConfigurationManager.AppSettings["MailSubject"];
            mail.IsBodyHtml = true;
            mail.Body = ConfigurationManager.AppSettings["MailBody"];

            if (ConfigurationManager.AppSettings["EmailResultsWithAttachment"] == "Yes")
            {
                mail.Attachments.Add(new Attachment(ConfigurationManager.AppSettings["ReportsPath"] + "Execution_Report_" + dateTimeInString + ".html"));
               // mail.Attachments.Add(new Attachment(ConfigurationManager.AppSettings["ReportsPath"] + "PIRates_" + dateTimeInString + ".xlsx"));
            }
            else
            {
                mail.Body += "</br></br>Please <a href=" + ConfigurationManager.AppSettings["ReportsPath"] + "Execution_Report_" + dateTimeInString + ".html" + ">click here</a> to see the overview report.";
               // mail.Body += "</br></br>Please <a href=" + ConfigurationManager.AppSettings["ReportsPath"] + "PIRates_" + dateTimeInString + ".xlsx" + ">click here</a> to see the detailed report.";
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SmtpHost"];
            smtp.Port = Int32.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SmtpUserId"], ConfigurationManager.AppSettings["SmtpPassword"]);
            smtp.EnableSsl = ConfigurationManager.AppSettings["EnableSSL"] == "Y";
            smtp.Send(mail);
        }

        public static void CreateFileOrFolder(string subfolder)
        {
            string folderName = ConfigurationManager.AppSettings["ReportsPath"];
            string pathString = System.IO.Path.Combine(folderName, subfolder);
            System.IO.Directory.CreateDirectory(pathString);
        }

        // Export DataTable into an excel file with field names in the header line
        // - Save excel file without ever making it visible if filepath is given
        // - Don't save excel file, just make it visible if no filepath is given
        //public static void ExportToExcel(System.Data.DataTable tbl, string excelFilePath = null)
        //{
        //    try
        //    {
        //        XLWorkbook wb = new XLWorkbook();
        //        wb.Worksheets.Add(tbl, "PI Rates");
        //        wb.SaveAs(excelFilePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ExportToExcel: \n" + ex.Message);
        //    }
        //}

        public static DataTable ExcelToDataTable(string fileName, string strSheetname)
        {
            //open file and returns as Stream
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            //Createopenxmlreader via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx

            //Set the First Row as Column Name
            excelReader.IsFirstRowAsColumnNames = true;
            //Return as DataSet
            DataSet result = excelReader.AsDataSet();
            //Get all the Tables
            DataTableCollection table = result.Tables;
            //Store it in DataTable
            DataTable resultTable = table[strSheetname];

            //return
            return resultTable;
        }


        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
                //colData = null;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static List<Datacollection> dataCol = null;


        public static void PopulateInCollection(string fileName, string strSheetname)

        {

            dataCol = new List<Datacollection>();
            DataTable table = ExcelToDataTable(fileName, strSheetname);

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }

        }

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }


        public static string AppendTimeStamp(this string filename)
        {
            return string.Concat(
            Path.GetFileNameWithoutExtension(filename),
            DateTime.Now.ToString("yyyyMMddHHmmssfff"),
            Path.GetExtension(filename));
        }

        public static void Contentdelete(string path)
        {
            int noOfDaysToKeepReports = Int32.Parse(ConfigurationManager.AppSettings["NumberOfdaysToRetainResults"]);
            DateTime dateTime = DateTime.Now.AddDays(noOfDaysToKeepReports * -1);
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                if (file.CreationTime <= dateTime)
                {
                    file.Delete();
                }
            }

            foreach (DirectoryInfo file1 in di.GetDirectories())
            {
                file1.Delete(true);
            }
        }
    

        public static void InitiateDelete()
        {
            Contentdelete(ConfigurationManager.AppSettings["ReportsPath"]);
        }

        public static void DriverSetup()
        {
            foreach (var process in Process.GetProcessesByName("Credentials4"))
            { process.Kill(); }
            foreach (var process in Process.GetProcessesByName("Credentials5"))
            { process.Kill(); }
            foreach (var process in Process.GetProcessesByName("Credentials8"))
            { process.Kill(); }
            foreach (var process in Process.GetProcessesByName("Credentials9"))
            { process.Kill(); }
            foreach (var process in Process.GetProcessesByName("IEDriverServer"))
            { process.Kill(); }
        }

        public static void ScriptSetup()
        {
            foreach (var process in Process.GetProcessesByName("Credentials4"))
            { process.Kill(); }
            foreach (var process in Process.GetProcessesByName("Credentials5"))
            { process.Kill(); }
            foreach (var process in Process.GetProcessesByName("Credentials8"))
            { process.Kill(); }
            foreach (var process in Process.GetProcessesByName("Credentials9"))
            { process.Kill(); }
        }

        public static string gettext(this IWebElement element)
        {
            return element.GetAttribute("value");
        }
        public static string gettextfromDDL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }

        public static void entertext(this IWebElement element, string value)
        {
            element.SendKeys(value);

        }

        public static void clicks(this IWebElement element)
        {
            element.Click();
        }

        public static void selectdropdown(this IWebElement element, int value)
        {

            new SelectElement(element).SelectByIndex(value);
        }

        public static void selectdropdowntext(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        public static void selectdropdownvalue(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByValue(value);
        }

    }
}


