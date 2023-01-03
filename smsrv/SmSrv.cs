using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;


namespace smsrv
{
    public partial class SmSrv : ServiceBase
    {
        string exe;
        string path;

       

        public SmSrv()
        {
            InitializeComponent();

            exe = Process.GetCurrentProcess().MainModule.FileName;
            path = Path.GetDirectoryName(exe);
        }


    



        protected override void OnStart(string[] args)
        {
            timerMinuto.Enabled = true;
        }

        protected override void OnStop()
        {
            timerMinuto.Enabled = false;
        }

        private void timerMinuto_Tick(object sender, EventArgs e)
        {
            timerMinuto.Enabled = false;
            //verifica atualizacao

            //verifica execucao
            string exeApp = "smapp.exe";

            Process[] ps =  System.Diagnostics.Process.GetProcessesByName(exeApp);
            
            if (ps.Length < 0)
            {
                Process.Start(path + "\\" + exeApp);
            }

            timerMinuto.Enabled = true;
        }



       
    }
}




//private string GetActiveWindowTitle(IntPtr handle)
//{
//    const int nChars = 256;
//    StringBuilder Buff = new StringBuilder(nChars);
//    //IntPtr handle = Program. GetForegroundWindow();

//    if (WindowsAPI.GetWindowText(handle, Buff, nChars) > 0)
//    {
//        return Buff.ToString();
//    }
//    return null;
//}