using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Xml.Linq;

namespace ComponentEdit2
{
    public class LibraryRead
    {
        public FileInfo[] fileCollection;

        private static Component _component;
        private Interface _interface;

        public LibraryRead()
        {
            _component = new Component();
            _interface = new Interface();
        }
        DirectoryInfo TheFolder;
        public void ReadFileCollection(String path)
        {
            if(Directory.Exists(path))
            {
                TheFolder = new DirectoryInfo(path);
                fileCollection = TheFolder.GetFiles();
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(path);
                    ReadFileCollection(path);
                }
                catch(Exception e)
                {
                    Console.WriteLine("{0} Second exception.", e.Message);
                }
                finally
                {
                    path = Directory.GetCurrentDirectory() + "/Library";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        ReadFileCollection(path);
                    }
                }
            }
        }

        public Image GetIcon(string lib, string file)
        {
            Image image;
            XElement xele = XElement.Load(file);
            XElement xele1 = xele.Element("backImage");
            string path2 = Directory.GetCurrentDirectory() + "\\Library\\" + lib + "\\Images";
            if (File.Exists(xele1.Value.Trim()))
            {
                string path1 = xele1.Value.Trim();
                string destPath = Path.Combine(path2, Path.GetFileName(path1));
                try
                {
                    //FileInfo fi1 = new FileInfo(path1);
                    if(Directory.Exists(path2))
                    {
                        File.Copy(path1, destPath);
                    }
                    else
                    {
                        Directory.CreateDirectory(path2);
                        File.Copy(path1, destPath);
                    }
                    xele.SetElementValue("backImage", destPath);
                    xele.Save(file);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    image = Image.FromFile(destPath);
                }
            }
            else
            {
                image = Image.FromFile(path2 + "\\未命名.png");
            }
            return image;
        }

        public static void ReadComponentXml(String file,Component component)
        {
            XElement xelement = XElement.Load(file);

            XElement name = xelement.Element("name");
            XElement width = xelement.Element("width");
            XElement height = xelement.Element("height");
            XElement backImage = xelement.Element("backImage");
            XElement backColor = xelement.Element("backColor");

            component.Name = name.Value.Trim();
            component.Width = Convert.ToInt32(width.Value.Trim());
            component.Height = Convert.ToInt32(height.Value.Trim());
            if (backColor.Value != "")
            {
                string[] strarr = backColor.Value.Split(',');
                int R = Convert.ToInt32(strarr[0]);
                int G = Convert.ToInt32(strarr[1]);
                int B = Convert.ToInt32(strarr[2]);
                component.Attdisp.backColor = Color.FromArgb(R, G, B);
            }
            if (backImage.Value != "" && File.Exists(backImage.Value.Trim()))
            {
                component.Attdisp.backImage = Image.FromFile(backImage.Value.Trim());
            }
            else
            {
                component.Attdisp.backImage = null;
            }
        }

        public static void ReadInterfaceXml(String file,Interface inf)
        {
            XElement xelement = XElement.Load(file);

            XElement name = xelement.Element("name");
            XElement width = xelement.Element("width");
            XElement height = xelement.Element("height");
            XElement backImage = xelement.Element("backImage");
            XElement backColor = xelement.Element("backColor");

            inf.Name = name.Value.Trim();
            inf.Width = Convert.ToInt32(width.Value.Trim());
            inf.Height = Convert.ToInt32(height.Value.Trim());
            if (backColor.Value != "")
            {
                string[] strarr = backColor.Value.Split(',');
                int R = Convert.ToInt32(strarr[0]);
                int G = Convert.ToInt32(strarr[1]);
                int B = Convert.ToInt32(strarr[2]);
                inf.Attdisp.backColor = Color.FromArgb(R, G, B);
            }
            if (backImage.Value != "" && File.Exists(backImage.Value.Trim()))
            {
                inf.Attdisp.backImage = Image.FromFile(backImage.Value.Trim());
            }
            else
            {
                inf.Attdisp.backImage = null;
            }
        }
    }
}
