namespace LicenseCreator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblAppSub;

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblStepTitle;
        private System.Windows.Forms.Panel panelSep;

        private System.Windows.Forms.Panel panelStep0;
        private System.Windows.Forms.Label lblStep0Info;
        private System.Windows.Forms.Button btnSelectExe;
        private System.Windows.Forms.Label lblSelectedExe;

        private System.Windows.Forms.Panel panelStep1;
        private System.Windows.Forms.Label lblStep1Info;
        private System.Windows.Forms.NumericUpDown numKeyCount;
        private System.Windows.Forms.Label lblKeyCountUnit;

        private System.Windows.Forms.Panel panelStep2;
        private System.Windows.Forms.Label lblStep2Info;
        private System.Windows.Forms.Button btnOpenKeysTxt;

        private System.Windows.Forms.Panel panelStep3;
        private System.Windows.Forms.Label lblStep3Info;
        private System.Windows.Forms.NumericUpDown numLicenseDays;
        private System.Windows.Forms.Label lblDaysUnit;

        private System.Windows.Forms.Panel panelStep4;
        private System.Windows.Forms.Label lblStep4Info;
        private System.Windows.Forms.Button btnOpenCodeTxt;

        private System.Windows.Forms.Panel panelStep5;
        private System.Windows.Forms.Label lblStep5Info;
        private System.Windows.Forms.TextBox txtDeploymentId;
        private System.Windows.Forms.Label lblDeployHint;

        private System.Windows.Forms.Panel panelFinal;
        private System.Windows.Forms.Label lblFinalInfo;

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.SuspendLayout();

            
            var cBg = System.Drawing.Color.FromArgb(14, 14, 20);
            var cHeader = System.Drawing.Color.FromArgb(20, 20, 32);
            var cPanel = System.Drawing.Color.FromArgb(24, 24, 38);
            var cBorder = System.Drawing.Color.FromArgb(48, 48, 72);
            var cAccent = System.Drawing.Color.FromArgb(50, 130, 255);
            var cAccent2 = System.Drawing.Color.FromArgb(100, 190, 255);
            var cText = System.Drawing.Color.FromArgb(215, 215, 230);
            var cSub = System.Drawing.Color.FromArgb(120, 120, 155);
            var cInput = System.Drawing.Color.FromArgb(30, 30, 48);
            var cGreen = System.Drawing.Color.FromArgb(70, 200, 110);

            var fBig = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            var fBody = new System.Drawing.Font("Segoe UI", 9.5f);
            var fSmall = new System.Drawing.Font("Segoe UI", 8.5f);
            var fMono = new System.Drawing.Font("Consolas", 9f);

            
            this.Text = "License Creator - github.com/EyupTekce";
            this.ClientSize = new System.Drawing.Size(720, 570);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = cBg;
            this.ForeColor = cText;
            this.Font = fBody;

            
            panelHeader = new System.Windows.Forms.Panel();
            panelHeader.BackColor = cHeader;
            panelHeader.Size = new System.Drawing.Size(720, 74);
            panelHeader.Location = new System.Drawing.Point(0, 0);

            lblAppTitle = new System.Windows.Forms.Label();
            lblAppTitle.Text = "🔐  License Creator (Made by Eyüp Tekçe)";
            lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            lblAppTitle.ForeColor = cAccent2;
            lblAppTitle.AutoSize = true;
            lblAppTitle.Location = new System.Drawing.Point(22, 10);

            lblAppSub = new System.Windows.Forms.Label();
            lblAppSub.Text = "Google Sheets-based license key system setup wizard | github.com/EyupTekce";
            lblAppSub.Font = fSmall;
            lblAppSub.ForeColor = cSub;
            lblAppSub.AutoSize = true;
            lblAppSub.Location = new System.Drawing.Point(24, 46);

            panelHeader.Controls.Add(lblAppTitle);
            panelHeader.Controls.Add(lblAppSub);

           
            progressBar = new System.Windows.Forms.ProgressBar();
            progressBar.Size = new System.Drawing.Size(570, 6);
            progressBar.Location = new System.Drawing.Point(22, 84);
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            lblProgress = new System.Windows.Forms.Label();
            lblProgress.Text = "Step 1 / 6";
            lblProgress.Font = fSmall;
            lblProgress.ForeColor = cSub;
            lblProgress.AutoSize = true;
            lblProgress.Location = new System.Drawing.Point(606, 80);

            
            lblStepTitle = new System.Windows.Forms.Label();
            lblStepTitle.Text = "";
            lblStepTitle.Font = fBig;
            lblStepTitle.ForeColor = cAccent2;
            lblStepTitle.AutoSize = true;
            lblStepTitle.Location = new System.Drawing.Point(22, 100);

            panelSep = new System.Windows.Forms.Panel();
            panelSep.BackColor = cBorder;
            panelSep.Size = new System.Drawing.Size(676, 1);
            panelSep.Location = new System.Drawing.Point(22, 132);

            
            var cX = 22;
            var cY = 142;
            var cW = 676;
            var cH = 350;

            
            panelStep0 = new System.Windows.Forms.Panel();
            panelStep0.Location = new System.Drawing.Point(cX, cY);
            panelStep0.Size = new System.Drawing.Size(cW, cH);
            panelStep0.BackColor = System.Drawing.Color.Transparent;
            panelStep0.Visible = false;

            lblStep0Info = new System.Windows.Forms.Label();
            lblStep0Info.Font = fBody;
            lblStep0Info.ForeColor = cText;
            lblStep0Info.Size = new System.Drawing.Size(cW, 100);
            lblStep0Info.Location = new System.Drawing.Point(0, 0);

            btnSelectExe = new System.Windows.Forms.Button();
            btnSelectExe.Text = "📁   Select .exe File";
            btnSelectExe.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnSelectExe.BackColor = cAccent;
            btnSelectExe.ForeColor = System.Drawing.Color.White;
            btnSelectExe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSelectExe.FlatAppearance.BorderSize = 0;
            btnSelectExe.Size = new System.Drawing.Size(210, 42);
            btnSelectExe.Location = new System.Drawing.Point(0, 115);
            btnSelectExe.Click += new System.EventHandler(this.btnSelectExe_Click);

            lblSelectedExe = new System.Windows.Forms.Label();
            lblSelectedExe.Font = fMono;
            lblSelectedExe.ForeColor = cGreen;
            lblSelectedExe.Size = new System.Drawing.Size(cW, 36);
            lblSelectedExe.Location = new System.Drawing.Point(0, 170);

            panelStep0.Controls.Add(lblStep0Info);
            panelStep0.Controls.Add(btnSelectExe);
            panelStep0.Controls.Add(lblSelectedExe);

            
            panelStep1 = new System.Windows.Forms.Panel();
            panelStep1.Location = new System.Drawing.Point(cX, cY);
            panelStep1.Size = new System.Drawing.Size(cW, cH);
            panelStep1.BackColor = System.Drawing.Color.Transparent;
            panelStep1.Visible = false;

            lblStep1Info = new System.Windows.Forms.Label();
            lblStep1Info.Font = fBody;
            lblStep1Info.ForeColor = cText;
            lblStep1Info.Size = new System.Drawing.Size(cW, 90);
            lblStep1Info.Location = new System.Drawing.Point(0, 0);

            var lblKL = new System.Windows.Forms.Label();
            lblKL.Text = "Number of keys to generate:";
            lblKL.Font = new System.Drawing.Font("Segoe UI", 10f);
            lblKL.ForeColor = cSub;
            lblKL.AutoSize = true;
            lblKL.Location = new System.Drawing.Point(0, 105);

            numKeyCount = new System.Windows.Forms.NumericUpDown();
            numKeyCount.Minimum = 1;
            numKeyCount.Maximum = 50000;
            numKeyCount.Value = 10;
            numKeyCount.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
            numKeyCount.Size = new System.Drawing.Size(130, 34);
            numKeyCount.Location = new System.Drawing.Point(0, 130);
            numKeyCount.BackColor = cInput;
            numKeyCount.ForeColor = cAccent2;

            lblKeyCountUnit = new System.Windows.Forms.Label();
            lblKeyCountUnit.Text = "keys  ( XXXX-XXXX-XXXX format )";
            lblKeyCountUnit.Font = fBody;
            lblKeyCountUnit.ForeColor = cSub;
            lblKeyCountUnit.AutoSize = true;
            lblKeyCountUnit.Location = new System.Drawing.Point(145, 136);

            panelStep1.Controls.Add(lblStep1Info);
            panelStep1.Controls.Add(lblKL);
            panelStep1.Controls.Add(numKeyCount);
            panelStep1.Controls.Add(lblKeyCountUnit);

            
            panelStep2 = new System.Windows.Forms.Panel();
            panelStep2.Location = new System.Drawing.Point(cX, cY);
            panelStep2.Size = new System.Drawing.Size(cW, cH);
            panelStep2.BackColor = System.Drawing.Color.Transparent;
            panelStep2.Visible = false;

            lblStep2Info = new System.Windows.Forms.Label();
            lblStep2Info.Font = fBody;
            lblStep2Info.ForeColor = cText;
            lblStep2Info.Size = new System.Drawing.Size(cW, 290);
            lblStep2Info.Location = new System.Drawing.Point(0, 0);

            btnOpenKeysTxt = new System.Windows.Forms.Button();
            btnOpenKeysTxt.Text = "📄   Open keys.txt location";
            btnOpenKeysTxt.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            btnOpenKeysTxt.BackColor = System.Drawing.Color.FromArgb(38, 38, 58);
            btnOpenKeysTxt.ForeColor = cAccent2;
            btnOpenKeysTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOpenKeysTxt.FlatAppearance.BorderColor = cBorder;
            btnOpenKeysTxt.Size = new System.Drawing.Size(210, 34);
            btnOpenKeysTxt.Location = new System.Drawing.Point(0, 300);
            btnOpenKeysTxt.Click += new System.EventHandler(this.btnOpenKeysTxt_Click);

            panelStep2.Controls.Add(lblStep2Info);
            panelStep2.Controls.Add(btnOpenKeysTxt);

            
            panelStep3 = new System.Windows.Forms.Panel();
            panelStep3.Location = new System.Drawing.Point(cX, cY);
            panelStep3.Size = new System.Drawing.Size(cW, cH);
            panelStep3.BackColor = System.Drawing.Color.Transparent;
            panelStep3.Visible = false;

            lblStep3Info = new System.Windows.Forms.Label();
            lblStep3Info.Font = fBody;
            lblStep3Info.ForeColor = cText;
            lblStep3Info.Size = new System.Drawing.Size(cW, 220);
            lblStep3Info.Location = new System.Drawing.Point(0, 0);

            var lblDL = new System.Windows.Forms.Label();
            lblDL.Text = "License duration (days):";
            lblDL.Font = new System.Drawing.Font("Segoe UI", 10f);
            lblDL.ForeColor = cSub;
            lblDL.AutoSize = true;
            lblDL.Location = new System.Drawing.Point(0, 230);

            numLicenseDays = new System.Windows.Forms.NumericUpDown();
            numLicenseDays.Minimum = 1;
            numLicenseDays.Maximum = 3650;
            numLicenseDays.Value = 30;
            numLicenseDays.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
            numLicenseDays.Size = new System.Drawing.Size(130, 34);
            numLicenseDays.Location = new System.Drawing.Point(0, 255);
            numLicenseDays.BackColor = cInput;
            numLicenseDays.ForeColor = cAccent2;

            lblDaysUnit = new System.Windows.Forms.Label();
            lblDaysUnit.Text = "days  ( 30 = 1 month | 365 = 1 year | 9999 = lifetime )";
            lblDaysUnit.Font = fBody;
            lblDaysUnit.ForeColor = cSub;
            lblDaysUnit.AutoSize = true;
            lblDaysUnit.Location = new System.Drawing.Point(145, 261);

            panelStep3.Controls.Add(lblStep3Info);
            panelStep3.Controls.Add(lblDL);
            panelStep3.Controls.Add(numLicenseDays);
            panelStep3.Controls.Add(lblDaysUnit);

            
            panelStep4 = new System.Windows.Forms.Panel();
            panelStep4.Location = new System.Drawing.Point(cX, cY);
            panelStep4.Size = new System.Drawing.Size(cW, cH);
            panelStep4.BackColor = System.Drawing.Color.Transparent;
            panelStep4.Visible = false;

            lblStep4Info = new System.Windows.Forms.Label();
            lblStep4Info.Font = fBody;
            lblStep4Info.ForeColor = cText;
            lblStep4Info.Size = new System.Drawing.Size(cW, 295);
            lblStep4Info.Location = new System.Drawing.Point(0, 0);

            btnOpenCodeTxt = new System.Windows.Forms.Button();
            btnOpenCodeTxt.Text = "📝   Open kod.txt";
            btnOpenCodeTxt.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            btnOpenCodeTxt.BackColor = System.Drawing.Color.FromArgb(38, 38, 58);
            btnOpenCodeTxt.ForeColor = cAccent2;
            btnOpenCodeTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOpenCodeTxt.FlatAppearance.BorderColor = cBorder;
            btnOpenCodeTxt.Size = new System.Drawing.Size(210, 34);
            btnOpenCodeTxt.Location = new System.Drawing.Point(0, 305);
            btnOpenCodeTxt.Click += new System.EventHandler(this.btnOpenCodeTxt_Click);

            panelStep4.Controls.Add(lblStep4Info);
            panelStep4.Controls.Add(btnOpenCodeTxt);

            
            panelStep5 = new System.Windows.Forms.Panel();
            panelStep5.Location = new System.Drawing.Point(cX, cY);
            panelStep5.Size = new System.Drawing.Size(cW, cH);
            panelStep5.BackColor = System.Drawing.Color.Transparent;
            panelStep5.Visible = false;

            lblStep5Info = new System.Windows.Forms.Label();
            lblStep5Info.Font = fBody;
            lblStep5Info.ForeColor = cText;
            lblStep5Info.Size = new System.Drawing.Size(cW, 140);
            lblStep5Info.Location = new System.Drawing.Point(0, 0);

            lblDeployHint = new System.Windows.Forms.Label();
            lblDeployHint.Text = "Deployment ID:";
            lblDeployHint.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            lblDeployHint.ForeColor = cSub;
            lblDeployHint.AutoSize = true;
            lblDeployHint.Location = new System.Drawing.Point(0, 150);

            txtDeploymentId = new System.Windows.Forms.TextBox();
            txtDeploymentId.Font = fMono;
            txtDeploymentId.Size = new System.Drawing.Size(cW, 28);
            txtDeploymentId.Location = new System.Drawing.Point(0, 175);
            txtDeploymentId.BackColor = cInput;
            txtDeploymentId.ForeColor = cGreen;
            txtDeploymentId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDeploymentId.TextChanged += new System.EventHandler(this.txtDeploymentId_TextChanged);

            var lblDN = new System.Windows.Forms.Label();
            lblDN.Text = "⚠  Ensure there are no extra spaces at the beginning or end of the ID.";
            lblDN.Font = fSmall;
            lblDN.ForeColor = System.Drawing.Color.FromArgb(255, 175, 55);
            lblDN.AutoSize = true;
            lblDN.Location = new System.Drawing.Point(0, 212);

            panelStep5.Controls.Add(lblStep5Info);
            panelStep5.Controls.Add(lblDeployHint);
            panelStep5.Controls.Add(txtDeploymentId);
            panelStep5.Controls.Add(lblDN);

           
            panelFinal = new System.Windows.Forms.Panel();
            panelFinal.Location = new System.Drawing.Point(cX, cY);
            panelFinal.Size = new System.Drawing.Size(cW, cH);
            panelFinal.BackColor = System.Drawing.Color.Transparent;
            panelFinal.Visible = false;

            lblFinalInfo = new System.Windows.Forms.Label();
            lblFinalInfo.Font = fBody;
            lblFinalInfo.ForeColor = cText;
            lblFinalInfo.Size = new System.Drawing.Size(cW, cH - 10);
            lblFinalInfo.Location = new System.Drawing.Point(0, 0);

            panelFinal.Controls.Add(lblFinalInfo);

            
            panelBottom = new System.Windows.Forms.Panel();
            panelBottom.BackColor = cHeader;
            panelBottom.Size = new System.Drawing.Size(720, 58);
            panelBottom.Location = new System.Drawing.Point(0, 512);

            btnBack = new System.Windows.Forms.Button();
            btnBack.Text = "◀   Back";
            btnBack.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            btnBack.BackColor = System.Drawing.Color.FromArgb(42, 42, 62);
            btnBack.ForeColor = cText;
            btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBack.FlatAppearance.BorderColor = cBorder;
            btnBack.Size = new System.Drawing.Size(115, 38);
            btnBack.Location = new System.Drawing.Point(18, 10);
            btnBack.Enabled = false;
            btnBack.Click += new System.EventHandler(this.btnBack_Click);

            btnNext = new System.Windows.Forms.Button();
            btnNext.Text = "Next   ▶";
            btnNext.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            btnNext.BackColor = cAccent;
            btnNext.ForeColor = System.Drawing.Color.White;
            btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.Size = new System.Drawing.Size(135, 38);
            btnNext.Location = new System.Drawing.Point(567, 10);
            btnNext.Enabled = false;
            btnNext.Click += new System.EventHandler(this.btnNext_Click);

            panelBottom.Controls.Add(btnBack);
            panelBottom.Controls.Add(btnNext);

            
            this.Controls.Add(panelHeader);
            this.Controls.Add(progressBar);
            this.Controls.Add(lblProgress);
            this.Controls.Add(lblStepTitle);
            this.Controls.Add(panelSep);
            this.Controls.Add(panelStep0);
            this.Controls.Add(panelStep1);
            this.Controls.Add(panelStep2);
            this.Controls.Add(panelStep3);
            this.Controls.Add(panelStep4);
            this.Controls.Add(panelStep5);
            this.Controls.Add(panelFinal);
            this.Controls.Add(panelBottom);

            this.ResumeLayout(false);
        }
    }
}
