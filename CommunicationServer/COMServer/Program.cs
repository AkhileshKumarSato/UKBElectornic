using SatoLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMServer
{
    public static class GlobalVariable
    {
        public static SatoCustomFunction mStoCustomFunction = new SatoCustomFunction();
        public static string mSatoApps = "SatoApps";
        public static string mMainSqlConString = "";
        public static string mSatoDbServer = "";
        public static string mSatoDb = "";
        public static string mSatoDbUser = "";
        public static string mSatoDbPassword = "";
        public static string mSatoAppsLoginUser = "";
        public static string mUserType = "";
        public static SatoLogger AppLog;
        public static string UserName = "";
        public static string UserGroup = "";
        public static string mAccessUser = "";
    }
    static class Program
    {
        public static string PrinterName = "";
        public static string MachiningPrinterIP = "";
        public static string MachiningPrinterPort="";
        public static string FinalPackingPrinterIP = "";
        public static string FinalPackingPrinterPort = "";
      
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PopulateSystemSetting();
            GlobalVariable.mMainSqlConString = "Server=" + GlobalVariable.mSatoDbServer + "; Database=" + GlobalVariable.mSatoDb + ";Uid=" + GlobalVariable.mSatoDbUser + "; pwd=" + GlobalVariable.mSatoDbPassword + "; pooling=true";
            bool CreatedOn;
            var mutex = new System.Threading.Mutex(true, "SatoCOMServer", out CreatedOn);
            if (!CreatedOn)
            {
                MessageBox.Show("Comm Server already running", "SatoCOMServer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            { Application.Run(new frmServer()); }
        }
        public static void PopulateSystemSetting()
        {
            FileInfo _fi = new FileInfo(Application.StartupPath + "\\DBSettings.txt");
            if (!_fi.Exists) { MessageBox.Show("System File Not Found !!!!", GlobalVariable.mSatoApps, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); return; }
            StreamReader _sr = default(StreamReader);
            string strLine = null;
            try
            {
                if (_fi.Exists == true)
                {
                    _fi = null;
                    string[] _strArr = null;
                    _sr = new StreamReader(Application.StartupPath + "\\DBSettings.txt");
                    while (!_sr.EndOfStream)
                    {
                        strLine = _sr.ReadLine();
                        _strArr = strLine.Split('=');
                        switch (_strArr[0])
                        {

                            case "SQL_DB_SERVER":
                                GlobalVariable.mSatoDbServer = _strArr[1].ToString().Trim();
                                break;
                            case "SQL_DB":
                                GlobalVariable.mSatoDb = _strArr[1].ToString().Trim();
                                break;
                            case "SQL_DB_USER":
                                GlobalVariable.mSatoDbUser = _strArr[1].ToString().Trim();
                                break;
                            case "SQL_DB_PASSWORD":
                                GlobalVariable.mSatoDbPassword = _strArr[1].ToString().Trim();
                                break;

                        }
                    }
                    _sr.Close();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
