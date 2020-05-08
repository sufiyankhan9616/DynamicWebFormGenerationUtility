using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DynamicWebFormGenerationUtility.Common
{
    public class ListConversion
    {
        public static DataTable ToDataTable<T>(IList<T> data)// T is any generic type
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static string GetCurrentPageName(string Path)
        {

         return   "ExportedFile";
        }
        public static void ExporttoExcel(DataTable table, String Filename)
        {
            Filename = GetCurrentPageName(Filename) + ".xls";
            Filename = Filename.Replace(" ", string.Empty);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Filename);

            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            //sets font
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            //am getting my grid's column headers
            int columnscount = table.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {      //write in new column
                HttpContext.Current.Response.Write("<Td>");
                //Get column headers  and make it as bold in excel columns
                HttpContext.Current.Response.Write("<B>");
                HttpContext.Current.Response.Write(table.Columns[j].ColumnName.ToString());
                HttpContext.Current.Response.Write("</B>");
                HttpContext.Current.Response.Write("</Td>");
            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in table.Rows)
            {//write in new row
                HttpContext.Current.Response.Write("<TR>");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
                    HttpContext.Current.Response.Write("</Td>");
                }

                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            HttpContext.Current.Response.Write("</font>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public static void ExporttoExcel(DataTable table)
        {
            // get current page name 
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            var sRet = oInfo.Name;
            string FileName = "ExportedFile"; // get MENU name, as per define in menu table
            FileName = FileName.Replace(" ", string.Empty);
            //
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            //sets font
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            //am getting my grid's column headers
            int columnscount = table.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {      //write in new column
                HttpContext.Current.Response.Write("<Td>");
                //Get column headers  and make it as bold in excel columns
                HttpContext.Current.Response.Write("<B>");
                HttpContext.Current.Response.Write(table.Columns[j].ColumnName.ToString());
                HttpContext.Current.Response.Write("</B>");
                HttpContext.Current.Response.Write("</Td>");
            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in table.Rows)
            {//write in new row
                HttpContext.Current.Response.Write("<TR>");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
                    HttpContext.Current.Response.Write("</Td>");
                }

                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            HttpContext.Current.Response.Write("</font>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        public static void ExportToPDF(DataTable table, string FileName)
        {

            StringBuilder sb = new StringBuilder();
            //sets font
            sb.Append("<font style='font-size:10.0pt; font-family:Calibri;'>");
            sb.Append("<BR><BR><BR>");
            //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            sb.Append("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            //am getting my grid's column headers
            int columnscount = table.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {      //write in new column
                sb.Append("<Td>");
                //Get column headers  and make it as bold in excel columns
                sb.Append("<B>");
                sb.Append(table.Columns[j].ColumnName.ToString());
                sb.Append("</B>");
                sb.Append("</Td>");
            }
            sb.Append("</TR>");
            foreach (DataRow row in table.Rows)
            {//write in new row
                sb.Append("<TR>");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    sb.Append("<Td>");
                    sb.Append(row[i].ToString());
                    sb.Append("</Td>");
                }

                sb.Append("</TR>");
            }
            sb.Append("</Table>");
            sb.Append("</font>");


            StringReader sr = new StringReader(sb.ToString());

            Document pdfDoc = new Document(PageSize.A3.Rotate(), 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                htmlparser.Parse(sr);
                pdfDoc.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                HttpContext.Current.Response.Clear();
                // Gets or sets the HTTP MIME type of the output stream.
                HttpContext.Current.Response.ContentType = "application/pdf";
                // Adds an HTTP header to the output stream
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ".pdf");

                //Gets or sets a value indicating whether to buffer output and send it after
                // the complete response is finished processing.
                HttpContext.Current.Response.Buffer = true;
                // Sets the Cache-Control header to one of the values of System.Web.HttpCacheability.
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                // Writes a string of binary characters to the HTTP output stream. it write the generated bytes .
                HttpContext.Current.Response.BinaryWrite(bytes);
                // Sends all currently buffered output to the client, stops execution of the
                // page, and raises the System.Web.HttpApplication.EndRequest event.

                HttpContext.Current.Response.End();
                // Closes the socket connection to a client. it is a necessary step as you must close the response after doing work.its best approach.

            }
                       
        }
    }
}
