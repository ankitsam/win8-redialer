using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
namespace Win8Redialer
{
    class VersionHelper
    {
        private string MSIFilePath = Path.Combine(Environment.CurrentDirectory, "Win8-Redialer.zip");
        private string CmdFilePath = Path.Combine(Environment.CurrentDirectory, "Install.cmd");
        private string MsiUrl = String.Empty;

        public bool CheckForNewVersion()
        {
            try
            {
                MsiUrl = GetNewVersionUrl();
            }
            catch (Exception e)
            {
            }
            return MsiUrl.Length > 0;
        }

        public void DownloadNewVersion()
        {
            DownloadNewVersion(MsiUrl);
            CreateCmdFile();
            RunCmdFile();
            ExitApplication();
        }

        private string GetNewVersionUrl()
        {
            var currentVersion = Properties.Settings.Default.Properties["Version"].DefaultValue;
            var url = "http://www.ankitsharma.info/softwares/windows8-redialer/update.xml";
            var builder = new StringBuilder();
            using (var stringWriter = new StringWriter(builder))
            {
                using (var xmlReader = new XmlTextReader(url))
                {
                    var doc = XDocument.Load(xmlReader);
                    //get versions.
                    var versions = from v in doc.Descendants("version")
                                   select new
                                   {
                                       Name = v.Element("name").Value,
                                       Number = v.Element("number").Value,
                                       URL = v.Element("url").Value,
                                       Date = Convert.ToDateTime(v.Element("date").Value)
                                   };
                    var version = versions.ToList()[0];
                    //check if latest version newer than current version.
                    string[] v1 = version.Number.Split('.');
                    string[] v2 = currentVersion.ToString().Split('.');

                    if (int.Parse(v1[0]) > int.Parse(v2[0]))
                    {
                        return version.URL;
                    }
                    else if (int.Parse(v1[0]) == int.Parse(v2[0]) && int.Parse(v1[1]) > int.Parse(v2[1]))
                    {
                        return version.URL;
                    }
                    else if (int.Parse(v1[0]) == int.Parse(v2[0]) && int.Parse(v1[1]) == int.Parse(v2[1]) && int.Parse(v1[2]) > int.Parse(v2[2]))
                    {
                        return version.URL;
                    }
                }
            }
            return String.Empty;
        }

        private void DownloadNewVersion(string url)
        {
            //delete existing msi.
            if (File.Exists(MSIFilePath))
            {
                File.Delete(MSIFilePath);
            }
            //download new msi.
            using (var client = new WebClient())
            {
                client.DownloadFile(url, MSIFilePath);
            }
            ZipFile.ExtractToDirectory(MSIFilePath, Environment.CurrentDirectory);
        }

        private void CreateCmdFile()
        {
            //check if file exists.
            if (File.Exists(CmdFilePath))
                File.Delete(CmdFilePath);
            //create new file.
            var fi = new FileInfo(CmdFilePath);
            var fileStream = fi.Create();
            fileStream.Close();
            //write commands to file.
            using (TextWriter writer = new StreamWriter(CmdFilePath))
            {
                writer.WriteLine("Win8-Redialer.exe");
            }
        }

        private void RunCmdFile()
        {
            //run command file to reinstall app.
            var p = new Process();
            p.StartInfo = new ProcessStartInfo("cmd.exe", "/c Install.cmd");
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            //p.WaitForExit();
        }

        private void ExitApplication()
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
