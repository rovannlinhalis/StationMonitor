namespace SmApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBoxNomeComputador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxToken = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.backgroundWorkerLeitura = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerEnvia = new System.ComponentModel.BackgroundWorker();
            this.linkLabelCriar = new System.Windows.Forms.LinkLabel();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerHardware = new System.ComponentModel.BackgroundWorker();
            this.timerHardware = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Station Monitor";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // textBoxNomeComputador
            // 
            this.textBoxNomeComputador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNomeComputador.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.textBoxNomeComputador.Location = new System.Drawing.Point(12, 30);
            this.textBoxNomeComputador.Name = "textBoxNomeComputador";
            this.textBoxNomeComputador.ReadOnly = true;
            this.textBoxNomeComputador.Size = new System.Drawing.Size(311, 27);
            this.textBoxNomeComputador.TabIndex = 0;
            this.textBoxNomeComputador.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome do Computador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.label2.Location = new System.Drawing.Point(38, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Token de Acesso";
            // 
            // textBoxToken
            // 
            this.textBoxToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxToken.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.textBoxToken.Location = new System.Drawing.Point(12, 87);
            this.textBoxToken.Name = "textBoxToken";
            this.textBoxToken.Size = new System.Drawing.Size(311, 27);
            this.textBoxToken.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SmApp.Properties.Resources.kgpg;
            this.pictureBox2.Location = new System.Drawing.Point(13, 63);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SmApp.Properties.Resources.Computer_icon24;
            this.pictureBox1.Location = new System.Drawing.Point(12, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonGravar.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.buttonGravar.Image = global::SmApp.Properties.Resources.dialog_ok_apply;
            this.buttonGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGravar.Location = new System.Drawing.Point(17, 150);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Padding = new System.Windows.Forms.Padding(80, 0, 120, 0);
            this.buttonGravar.Size = new System.Drawing.Size(301, 67);
            this.buttonGravar.TabIndex = 4;
            this.buttonGravar.Text = "Ok";
            this.buttonGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // backgroundWorkerLeitura
            // 
            this.backgroundWorkerLeitura.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLeitura_DoWork);
            this.backgroundWorkerLeitura.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLeitura_RunWorkerCompleted);
            // 
            // backgroundWorkerEnvia
            // 
            this.backgroundWorkerEnvia.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerEnvia_DoWork);
            // 
            // linkLabelCriar
            // 
            this.linkLabelCriar.AutoSize = true;
            this.linkLabelCriar.Location = new System.Drawing.Point(202, 117);
            this.linkLabelCriar.Name = "linkLabelCriar";
            this.linkLabelCriar.Size = new System.Drawing.Size(121, 13);
            this.linkLabelCriar.TabIndex = 7;
            this.linkLabelCriar.TabStop = true;
            this.linkLabelCriar.Text = "Cadastrar nova Estação";
            this.linkLabelCriar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCriar_LinkClicked);
            // 
            // timerClose
            // 
            this.timerClose.Interval = 500;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // backgroundWorkerHardware
            // 
            this.backgroundWorkerHardware.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerHardware_DoWork);
            this.backgroundWorkerHardware.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerHardware_RunWorkerCompleted);
            // 
            // timerHardware
            // 
            this.timerHardware.Interval = 10000;
            this.timerHardware.Tick += new System.EventHandler(this.timerHardware_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 224);
            this.Controls.Add(this.linkLabelCriar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxToken);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNomeComputador);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(351, 239);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Station Monitor App";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox textBoxNomeComputador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxToken;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLeitura;
        private System.ComponentModel.BackgroundWorker backgroundWorkerEnvia;
        private System.Windows.Forms.LinkLabel linkLabelCriar;
        private System.Windows.Forms.Timer timerClose;
        private System.ComponentModel.BackgroundWorker backgroundWorkerHardware;
        private System.Windows.Forms.Timer timerHardware;
    }
}

