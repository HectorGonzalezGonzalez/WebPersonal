using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebPersonal.METODOS
{
    public class SaveFile
    {
        public void saveFile(HttpPostedFileBase ImgFile,int id,string tipo,string origen)
        {
            if (ImgFile != null)
            {
                var supportedTypes=new[] {""};
                string carpeta = "";
                if (origen=="tema")
                {
                    supportedTypes = new[] { "png", "jpg", "gif" };
                    carpeta = "IMG/TEMA";
                }
                else if(origen=="ejemplo")
                {
                    if (tipo == "IMG")
                    {
                        supportedTypes = new[] { "png", "jpg", "gif" };
                        carpeta = "IMG/EJEMPLO";
                    }
                    else
                    {
                        supportedTypes = new[] { "zip", "rar" };
                        carpeta = "FILE/EJEMPLO";
                    }
                }
               
                var fileExt = System.IO.Path.GetExtension(ImgFile.FileName).Substring(1).ToLower();

                if (supportedTypes.Contains(fileExt))
                {
                    string fileName = Path.GetFileName(ImgFile.FileName);
                    string path = HttpContext.Current.Server.MapPath("~/RECURSOS/"+carpeta+"/" + id + "/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    ImgFile.SaveAs(path + fileName);
                }
                else
                {
                    //mensaje el formato no es correcto
                }
            }
        }
    }
}