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

        private Component _component;
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

        public Image GetIcon(string file)
        {
            Image image;
            XElement xele = XElement.Load(file);
            XElement xele1 = xele.Element("backImage");
            if (File.Exists(xele1.Value.Trim()))
            {
                string path1 = xele1.Value.Trim();
                string path2 = Directory.GetCurrentDirectory() + "\\Library\\ComponentLibrary\\Images";
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
                image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Library\\ComponentLibrary\\Images\\未命名.png");
            }
            return image;
        }

        public Component ReadComponentXml(String file)
        {
            XElement xelement = XElement.Load(file);

            XElement name = xelement.Element("name");
            XElement width = xelement.Element("width");
            XElement height = xelement.Element("height");
            XElement backImage = xelement.Element("backImage");
            XElement backColor = xelement.Element("backColor");

            _component.Name = name.Value.Trim();
            _component.DesignProperty.Width = Convert.ToInt32(width.Value.Trim());
            _component.DesignProperty.Height = Convert.ToInt32(height.Value.Trim());
            if (backColor.Value != "")
            {
                string[] strarr = backColor.Value.Split(',');
                int R = Convert.ToInt32(strarr[0]);
                int G = Convert.ToInt32(strarr[1]);
                int B = Convert.ToInt32(strarr[2]);
                _component.DesignProperty.BackColor = Color.FromArgb(R, G, B);
            }
            if (backImage.Value != "" && File.Exists(backImage.Value.Trim()))
            {
                _component.DesignProperty.BackImage = Image.FromFile(backImage.Value.Trim());
            }
            else
            {
                _component.DesignProperty.BackImage = null;
            }
            //ComponentTemp.componentTemp = _component;
            return _component;
        }

        public void ReadInterfaceXml(String file)
        {

        }
    }

    public static class ComponentTemp
    {
        public static Component componentTemp;
    }

}
