using Newtonsoft.Json;
using SmApp.Funcoes;
using StationMonitor.Entidades;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static SmApp.Funcoes.Hardware;

namespace SmApp
{
    public partial class Form1 : Form
    {
        ConcurrentQueue<Evento> eventos;
        private LocalConfig config;
        DirectoryInfo dirAppDAta;
        private bool running = false;
        private FileInfo fileCache = new FileInfo(LocalConfig.pathConfig + "\\station.cache");
        int intervalo = 5000;
        int intervaloHardware = 43200000; //12 horas

        public Form1()
        {
            InitializeComponent();
            eventos = new ConcurrentQueue<Evento>();

            dirAppDAta = new DirectoryInfo(LocalConfig.pathConfig);
            try
            {
                if (!dirAppDAta.Exists)
                    dirAppDAta.Create();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao criar diretório em appdata: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadLocalConfig();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        #region LocalConfig
        private void LoadLocalConfig()
        {
            if (File.Exists(LocalConfig.pathFileConfig))
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                string json = File.ReadAllText(LocalConfig.pathFileConfig);

                //Newtonsoft.Json.Serialization.
                config = JsonConvert.DeserializeObject<LocalConfig>(json);

                textBoxNomeComputador.Text = config.Nome;
                textBoxNomeComputador.ReadOnly = true;
                textBoxToken.Text = config.Token;
                textBoxToken.ReadOnly = true;

                running = true;
                backgroundWorkerLeitura.RunWorkerAsync();

                timerHardware.Enabled = true;
            }
            else
            {
                textBoxNomeComputador.ReadOnly = false;
                textBoxNomeComputador.Text = System.Environment.MachineName;
                running = false;
                this.WindowState = FormWindowState.Normal;
                this.Show();
            }
        }
        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Guid g;
            if (!String.IsNullOrEmpty(textBoxNomeComputador.Text) && Guid.TryParse(textBoxToken.Text, out g))
            {
                if (config == null)
                {
                    config = new LocalConfig();
                }

                config.Nome = textBoxNomeComputador.Text;
                config.Token = textBoxToken.Text;
                textBoxNomeComputador.ReadOnly = true;
                textBoxToken.ReadOnly = true;
                string json = JsonConvert.SerializeObject(config);

                File.WriteAllText(LocalConfig.pathFileConfig, json);

                running = true;

                if (!backgroundWorkerLeitura.IsBusy)
                    backgroundWorkerLeitura.RunWorkerAsync();

                timerHardware.Enabled = true;

                this.WindowState = FormWindowState.Minimized;
                this.Hide();

            }
            else
            {
                MessageBox.Show("Dados informados inválidos", "Gravar Configurações", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxToken.Focus();
            }
        }
        private void linkLabelCriar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(LocalConfig.Url + "Estacoes/Create");
        }
        #endregion
        #region LoadCache
        private void LoadCache()
        {
            if (fileCache.Exists)
            {
                try
                {
                    string json = File.ReadAllText(fileCache.FullName);
                    ConcurrentQueue<Evento> tmp = JsonConvert.DeserializeObject<ConcurrentQueue<Evento>>(json);
                    if (tmp != null)
                        eventos = tmp;
                }
                catch (Exception ex)
                {
                    Evento ev = new Evento() { Date = DateTime.Now, StationId = config.Id, OSUserName = Environment.UserName, Title = ex.Message, Type = StationInterface.Enum.TiposEventos.Erro, Process = String.Empty };
                    eventos.Enqueue(ev);
                }
            }
        }
        #endregion
        #region Leitura
        private void backgroundWorkerLeitura_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadCache();

            {
                Evento ev = new Evento() { Date = DateTime.Now, StationId = config.Id, OSUserName = Environment.UserName, Title = "Iniciou a Leitura", Type = StationInterface.Enum.TiposEventos.TurnOn, Process = "_self", X = 0, Y = 0 };
                eventos.Enqueue(ev);
            }

            int MouseLoops = 6, mouseLoop =0;
            uint lPID = 0;
            int lX = -999, lY = -999;
          


            while (running)
            {
                if (!backgroundWorkerEnvia.IsBusy)
                    backgroundWorkerEnvia.RunWorkerAsync();

                try
                {
                   

                    uint id;
                    IntPtr handle = WindowsAPI.GetForegroundWindow();
                    WindowsAPI.GetWindowThreadProcessId(handle, out id);
                    //leituras.Enqueue(new Leitura() { Id = id, Data = DateTime.Now });
                    Process p = Process.GetProcessById((int)id);
                    if (p != null)
                    {
                        bool flagMouse = false;
                        string title = WindowsAPI.GetActiveWindowTitle(handle);

                        Point point = new Point();

                        bool result = WindowsAPI.GetCursorPos(ref point);
                        if (result)
                        {
                            if (point.X == lX && point.Y == lY)
                            {
                                if (mouseLoop < MouseLoops)
                                {
                                    mouseLoop++;
                                }
                                else
                                {
                                    mouseLoop = 0;
                                    flagMouse = true;
                                }
                            }
                            else
                            {
                                mouseLoop = 0;
                                flagMouse = false;
                            }

                            if (point.X != lX || point.Y != lY || flagMouse || lPID != id)
                            {
                                lPID = id;
                                lX = point.X;
                                lY = point.Y;

                                TemperatureProbe temp = null;
                                try { temp = Funcoes.Hardware.GetTemperature(); } catch { }
                                Win32_OperatingSystem os = null;
                                try { os = Funcoes.Hardware.GetWin32_OperatingSystem(); } catch { }

                                Evento ev = new Evento() { Date = DateTime.Now, StationId = config.Id, OSUserName = Environment.UserName, Title = title, Type = (flagMouse ? StationInterface.Enum.TiposEventos.Ocioso : StationInterface.Enum.TiposEventos.Mouse), Process = p.ProcessName, X = point.X, Y = point.Y, CurrentTemperature = (temp==null ? null : temp.Current), WarningTemperature = (temp == null ? null : temp.Warning), FreeMemory = (os==null ? null : os.FreePhysicalMemory) };
                                eventos.Enqueue(ev);
                            }

                        }

                        //if (!String.IsNullOrEmpty(campoTagsProibidas.Text))
                        //{
                        //    Process papp = Process.GetCurrentProcess();
                        //    if (papp.Id != p.Id)
                        //    {
                        //        string[] tps = campoTagsProibidas.Text.Split(',');
                        //        foreach (string tp in tps)
                        //        {
                        //            if (p.ProcessName.ToLower().Trim().Contains(tp) || title.ToLower().Trim().Contains(tp))
                        //            {
                        //                p.Kill();
                        //                Log("Processo " + p.ProcessName + " com o título " + title + " foi finalizado pelo auxiliar de desempenho.");
                        //            }
                        //        }
                        //    }
                        //}

                        //tw.WriteLine(id + ";" + DateTime.Now + ";" + /*p.MainModule.ModuleName + ";" +*/ p.ProcessName+";"+ GetActiveWindowTitle(handle));
                    }
                }
                catch (Exception ex)
                {
                    Evento ev = new Evento() { Date = DateTime.Now, StationId = config.Id, OSUserName = Environment.UserName, Title = ex.Message, Type = StationInterface.Enum.TiposEventos.Erro, Process = String.Empty };
                    eventos.Enqueue(ev);
                }

                Thread.Sleep(intervalo);

            }
        }
        private void backgroundWorkerLeitura_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            {
                Evento ev = new Evento() { Date = DateTime.Now, StationId = config.Id, OSUserName = Environment.UserName, Title = "Finalizou a Leitura", Type = StationInterface.Enum.TiposEventos.TurnOff, Process = "_self", X = 0, Y = 0 };
                eventos.Enqueue(ev);
            }
        }
        #endregion
        #region Enviar
        private void backgroundWorkerEnvia_DoWork(object sender, DoWorkEventArgs e)
        {
            while (running || eventos.Count > 0)
            {
                if (eventos.Count >= 20)
                {
                    List<Evento> listaEnviar = new List<Evento>();

                    Evento obj;
                    while (eventos.Count > 0)
                    {
                        if (eventos.TryDequeue(out obj))
                        {
                            if (obj.StationId == config.Id)
                                listaEnviar.Add(obj);
                        }

                        if (listaEnviar.Count >= 100)
                            break;
                    }

                    try
                    {
                        string json = JsonConvert.SerializeObject(listaEnviar);
                        string response = Funcoes.FuncoesHttp.HttpRquest( Funcoes.HttpRequestMethods.POST,  LocalConfig.Url + "api/Events", json, config.Token);
                    }
                    catch (Exception ex)
                    {
                        Evento ev = new Evento() { Date = DateTime.Now, StationId = config.Id, OSUserName = Environment.UserName, Title = ex.Message, Type = StationInterface.Enum.TiposEventos.Erro, Process = String.Empty };
                        foreach (Evento o in listaEnviar)
                            eventos.Enqueue(o);

                        eventos.Enqueue(ev);
                    }
                }

                using (TextWriter tw = new StreamWriter(fileCache.FullName, false, Encoding.Default))
                {
                    tw.WriteLine(JsonConvert.SerializeObject(eventos));
                }

                if (!running)
                    eventos = new ConcurrentQueue<Evento>();

                Thread.Sleep(intervalo);
            }
        }

       
        #endregion
        #region Close
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (backgroundWorkerLeitura.IsBusy)
            {
                running = false;
                e.Cancel = true;
                timerClose.Enabled = true;
            }
            else
            {
                if (backgroundWorkerEnvia.IsBusy)
                {
                    running = false;
                    e.Cancel = true;
                    timerClose.Enabled = true;
                }
            }
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            timerClose.Enabled = false;
            this.Close();
        }
        #endregion
        #region NotifyIcon / Hide-Show
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
        }

        
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
             
            }
        }

        #endregion

        #region Hardaware
        private void timerHardware_Tick(object sender, EventArgs e)
        {
            timerHardware.Enabled = false;
            if (!backgroundWorkerHardware.IsBusy)
                backgroundWorkerHardware.RunWorkerAsync();
            else
                timerHardware.Enabled = true;

        }

        private void backgroundWorkerHardware_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                var os = Funcoes.Hardware.GetWin32_OperatingSystem();

                Estacao estacao = new Estacao();
                estacao.Id = config.Id;
                estacao.Name = config.Nome;
                estacao.Cpu = Funcoes.Hardware.GetProcessador();
                estacao.MotherBoard = Funcoes.Hardware.GetPlacaMae();
                estacao.Memory = Funcoes.Hardware.GetMemRam();
                estacao.Connections = Funcoes.Hardware.GetRedes(config.Id);
                estacao.Drivers = Funcoes.Hardware.GetDrives(config.Id);
                estacao.OS = os.Caption;
                estacao.OSArchitecture = os.OSArchitecture;
                estacao.OSDirectory = os.WindowsDirectory;
                estacao.LocalDateTime = os.LocalDateTime;
                estacao.LastBootUpTime = os.LastBootUpTime;
                estacao.InstallDate = os.InstallDate;
                


                string json = JsonConvert.SerializeObject(estacao);
                string response = Funcoes.FuncoesHttp.HttpRquest(Funcoes.HttpRequestMethods.POST, LocalConfig.Url + "Stations/Hardware", json, config.Token);

            }
            catch (Exception ex)
            {
                Evento ev = new Evento() { Date = DateTime.Now, StationId = config.Id, OSUserName = Environment.UserName, Title = ex.Message, Type = StationInterface.Enum.TiposEventos.Erro, Process = "_sendHardware" };
                eventos.Enqueue(ev);
            }


        }
        
        private void backgroundWorkerHardware_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timerHardware.Interval = intervaloHardware;
            timerHardware.Enabled = true;
        }
        #endregion

    }
}
