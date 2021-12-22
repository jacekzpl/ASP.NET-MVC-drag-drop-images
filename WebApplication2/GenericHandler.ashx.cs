using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class GenericHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string dirFullPath = "c:\\Img";
            string[] files;
            int numFiles;
            files = System.IO.Directory.GetFiles(dirFullPath);
            numFiles = files.Length;
            numFiles = numFiles + 1;
            string str_image = "";

            foreach (string s in context.Request.Files)
            {
                HttpPostedFile file = context.Request.Files[s];
                string fileName = file.FileName;
                string fileExtension = file.ContentType;

                if (!string.IsNullOrEmpty(fileName))
                {
                    fileExtension = Path.GetExtension(fileName);
                    str_image = "image_" + numFiles.ToString() + fileExtension;
                    string pathToSave = dirFullPath +"\\"+ str_image;
                    file.SaveAs(pathToSave);
                }
            }
            context.Response.Write(str_image);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}