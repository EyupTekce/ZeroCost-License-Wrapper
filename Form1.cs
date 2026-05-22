using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LicenseCreator
{
    public partial class Form1 : Form
    {
        
        private int currentStep = 0;
        private string selectedExePath = "";
        private int keyCount = 0;
        private int licenseDays = 0;
        private string deploymentId = "";
        private List<string> generatedKeys = new List<string>();
        private string savedTxtPath = "";
        private string savedCodePath = "";

        private readonly string[] stepTitles =
        {
            "Step 1 / 6  —  Select Application",
            "Step 2 / 6  —  Key Quantity",
            "Step 3 / 6  —  Google Sheets Setup",
            "Step 4 / 6  —  License Duration",
            "Step 5 / 6  —  Apps Script Setup",
            "Step 6 / 6  —  Deployment ID"
        };

        private System.Windows.Forms.Timer countdownTimer;
        private int countdownSeconds = 10;

        
        public Form1()
        {
            InitializeComponent();
            ShowStep(0);
        }

        
        private void ShowStep(int step)
        {
            currentStep = step;
            btnNext.Enabled = false;
            btnBack.Enabled = step > 0;

            panelStep0.Visible = false;
            panelStep1.Visible = false;
            panelStep2.Visible = false;
            panelStep3.Visible = false;
            panelStep4.Visible = false;
            panelStep5.Visible = false;
            panelFinal.Visible = false;

            UpdateProgress(step);

            switch (step)
            {
                case 0: ShowStep0(); break;
                case 1: ShowStep1(); break;
                case 2: ShowStep2(); break;
                case 3: ShowStep3(); break;
                case 4: ShowStep4(); break;
                case 5: ShowStep5(); break;
            }
        }

        
        private void ShowStep0()
        {
            lblStepTitle.Text = stepTitles[0];
            panelStep0.Visible = true;

            lblStep0Info.Text =
                "Select the .exe file you want to license.\r\n\r\n" +
                "This wizard will set up a Google Sheets-based license key system\r\n" +
                "for your software and generate a ready-to-use license validator exe.\r\n\r\n" +
                "Click the button below to start.";

            lblSelectedExe.Text = selectedExePath == ""
                ? "No file selected yet."
                : "✅   " + selectedExePath;

            btnNext.Enabled = selectedExePath != "";
        }

        
        private void ShowStep1()
        {
            lblStepTitle.Text = stepTitles[1];
            panelStep1.Visible = true;

            lblStep1Info.Text =
                "How many license keys do you want to generate?\r\n\r\n" +
                "Keys will be generated cryptographically in XXXX-XXXX-XXXX format.\r\n" +
                "No key will be duplicated.\r\n\r\n" +
                "Generated keys will be saved to Downloads\\keys.txt.";

            numKeyCount.Value = keyCount > 0 ? keyCount : 10;
            btnNext.Enabled = true;
        }

        
        private void ShowStep2()
        {
            lblStepTitle.Text = stepTitles[2];
            panelStep2.Visible = true;

            generatedKeys = GenerateKeys((int)numKeyCount.Value);
            keyCount = (int)numKeyCount.Value;
            savedTxtPath = SaveKeysTxt(generatedKeys);

            lblStep2Info.Text =
                "✅   " + keyCount + " keys generated → Downloads\\keys.txt\r\n\r\n" +
                "─────────────────────────────────────────────────────────────\r\n\r\n" +
                "Now, open Google Sheets and follow these steps:\r\n\r\n" +
                "1. Go to sheets.google.com.\r\n" +
                "   Click the + icon at the top left to create a new spreadsheet.\r\n\r\n" +
                "2. Type these headers in the first row in exact order:\r\n" +
                "   A1 → Key        B1 → Status      C1 → HWID\r\n" +
                "   D1 → Date       E1 → Duration\r\n\r\n" +
                "3. Open Downloads\\keys.txt.\r\n" +
                "   Copy all keys and paste them into cell A2.\r\n" +
                "   Each key will automatically align into its own row.\r\n\r\n" +
                "⏱   Next button will be active in 10 seconds...";

            btnNext.Enabled = false;
            StopCountdown();
            StartCountdown();
        }

        
        private void ShowStep3()
        {
            lblStepTitle.Text = stepTitles[3];
            panelStep3.Visible = true;

            lblStep3Info.Text =
                "Continue in your Sheet:\r\n\r\n" +
                "4. Type \"Active\" in cell B2.\r\n" +
                "   Select B2 and drag the small square at the bottom-right corner\r\n" +
                "   down to the last key row.\r\n" +
                "   The entire column B should be \"Active\".\r\n\r\n" +
                "5. Select the license duration (in days) below.\r\n" +
                "   Type the number in cell E2 and drag it down to the last row.\r\n\r\n" +
                "─────────────────────────────────────────────────────────────\r\n\r\n" +
                "After setting the days, click the Next button.";

            numLicenseDays.Value = licenseDays > 0 ? licenseDays : 30;
            btnNext.Enabled = true;
        }

        
        private void ShowStep4()
        {
            lblStepTitle.Text = stepTitles[4];
            panelStep4.Visible = true;
            licenseDays = (int)numLicenseDays.Value;
            savedCodePath = SaveCodeTxt();

            lblStep4Info.Text =
                "✅   Apps Script code saved → Downloads\\kod.txt\r\n\r\n" +
                "─────────────────────────────────────────────────────────────\r\n\r\n" +
                "Stay on your Sheet and follow these steps:\r\n\r\n" +
                "6. From the top menu, open Extensions → Apps Script.\r\n\r\n" +
                "7. You will see Code.gs in the editor.\r\n" +
                "   Select all text (Ctrl+A) and delete it.\r\n\r\n" +
                "8. Open Downloads\\kod.txt, copy all the content.\r\n" +
                "   Paste it into the editor (Ctrl+V).\r\n\r\n" +
                "9. Click the 💾 Save icon at the top left.\r\n\r\n" +
                "10. Click Deploy → New deployment at the top right.\r\n" +
                "    In the window:\r\n" +
                "    • Type → Web App\r\n" +
                "    • Execute as → Me\r\n" +
                "    • Who has access → Anyone\r\n" +
                "    • Click Deploy and grant permissions if prompted.";

            btnNext.Enabled = true;
        }

         
        private void ShowStep5()
        {
            lblStepTitle.Text = stepTitles[5];
            panelStep5.Visible = true;

            lblStep5Info.Text =
                "After deployment, Google will provide you with a\r\n" +
                "Deployment ID.\r\n\r\n" +
                "It starts with \"AKfycb...\" and is quite long.\r\n\r\n" +
                "Copy and paste that ID into the field below.\r\n" +
                "Your license exe will be created automatically when you click Next.";

            txtDeploymentId.Text = deploymentId;
            btnNext.Enabled = txtDeploymentId.Text.Trim().Length > 10;
        }

        
        private void ShowCompleted()
        {
            lblStepTitle.Text = "🎉   Setup Completed!";
            UpdateProgress(6);
            panelStep5.Visible = false;
            btnNext.Visible = false;
            btnBack.Enabled = false;

            string exePath = BuildLicenseExe();

            string msg =
                "✅   Your license exe is ready:\r\n\r\n" +
                "📦   " + exePath + "\r\n\r\n" +
                "─────────────────────────────────────────────────────────────\r\n\r\n" +
                "DISTRIBUTION INSTRUCTIONS:\r\n\r\n" +
                "• Place the generated license exe in the same folder as\r\n" +
                "  your original application exe.\r\n\r\n" +
                "• Send the keys from keys.txt to your users.\r\n\r\n" +
                "WHAT HAPPENS FOR THE USER:\r\n\r\n" +
                "• User opens the license exe and enters a key.\r\n" +
                "• Real-time verification via Google Sheets.\r\n" +
                "• HWID check: prevents key usage on other devices.\r\n" +
                "• Expiration check: denies access if duration expired.\r\n" +
                "• Original application starts if all checks pass.";

            panelFinal.Visible = true;
            lblFinalInfo.Text = msg;
        }

        
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentStep == 5)
            {
                deploymentId = txtDeploymentId.Text.Trim();
                ShowCompleted();
                return;
            }
            ShowStep(currentStep + 1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StopCountdown();
            ShowStep(currentStep - 1);
        }

        private void btnSelectExe_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select the .exe file to protect";
                ofd.Filter = "Executable Files (*.exe)|*.exe";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedExePath = ofd.FileName;
                    lblSelectedExe.Text = "✅   " + selectedExePath;
                    btnNext.Enabled = true;
                }
            }
        }

        private void txtDeploymentId_TextChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = txtDeploymentId.Text.Trim().Length > 10;
        }

        private void btnOpenKeysTxt_Click(object sender, EventArgs e)
        {
            if (File.Exists(savedTxtPath))
                Process.Start("explorer.exe", "/select,\"" + savedTxtPath + "\"");
        }

        private void btnOpenCodeTxt_Click(object sender, EventArgs e)
        {
            if (File.Exists(savedCodePath))
                Process.Start("notepad.exe", "\"" + savedCodePath + "\"");
        }

        
        private List<string> GenerateKeys(int count)
        {
            var keys = new HashSet<string>();
            var rng = new RNGCryptoServiceProvider();
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

            while (keys.Count < count)
            {
                var sb = new StringBuilder();
                for (int seg = 0; seg < 3; seg++)
                {
                    if (seg > 0) sb.Append('-');
                    var buf = new byte[4];
                    rng.GetBytes(buf);
                    for (int i = 0; i < 4; i++)
                        sb.Append(chars[buf[i] % chars.Length]);
                }
                keys.Add(sb.ToString());
            }
            return keys.ToList();
        }

        private string GetDownloadsFolder() =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

        private string SaveKeysTxt(List<string> keys)
        {
            string path = Path.Combine(GetDownloadsFolder(), "keys.txt");
            File.WriteAllLines(path, keys, Encoding.UTF8);
            return path;
        }

        private string SaveCodeTxt()
        {
            string path = Path.Combine(GetDownloadsFolder(), "kod.txt");
            File.WriteAllText(path, GetAppsScriptCode(), Encoding.UTF8);
            return path;
        }

        private string GetAppsScriptCode()
        {
            return
@"function doGet(e) {
  var lock = LockService.getScriptLock();
  try {
    lock.waitLock(10000);

    var key   = e.parameter.key;
    var hwid  = e.parameter.hwid;
    var ss    = SpreadsheetApp.getActiveSpreadsheet();
    var sheet = ss.getSheets()[0];
    var data  = sheet.getRange(""A:E"").getValues();

    for (var i = 0; i < data.length; i++) {
      if (data[i][0] == key) {
        var status        = data[i][1];
        var savedHwid     = data[i][2];
        var excelDuration = data[i][4];
        var licenseDays   = (excelDuration === """" || excelDuration == null) ? 30 : excelDuration;
        var row   = i + 1;
        var now   = new Date();

        if (status === ""Active"") {
          sheet.getRange(row, 2, 1, 3).setValues([[""Used"", hwid, now]]);
          return ContentService.createTextOutput(""SUCCESS|"" + licenseDays);
        }

        if (status === ""Used"") {
          if (savedHwid !== hwid)
            return ContentService.createTextOutput(""WRONG_HWID"");

          var start = new Date(data[i][3]);
          var diff  = (now - start) / (1000 * 60 * 60 * 24);

          if (diff <= licenseDays) {
            var remaining = Math.ceil(licenseDays - diff);
            return ContentService.createTextOutput(""SUCCESS|"" + remaining);
          } else {
            sheet.getRange(row, 2).setValue(""Expired"");
            return ContentService.createTextOutput(""EXPIRED"");
          }
        }

        if (status === ""Expired"")
          return ContentService.createTextOutput(""EXPIRED"");
      }
    }
    return ContentService.createTextOutput(""INVALID_KEY"");
  } finally {
    lock.releaseLock();
  }
}";
        }

        
        private string BuildLicenseExe()
        {
            string deployUrl = "https://script.google.com/macros/s/" + deploymentId + "/exec";
            string exeName = Path.GetFileNameWithoutExtension(selectedExePath) + "_License.exe";
            string outPath = Path.Combine(GetDownloadsFolder(), exeName);

            string tempDir = Path.Combine(Path.GetTempPath(), "LC_" + Guid.NewGuid().ToString("N").Substring(0, 8));
            Directory.CreateDirectory(tempDir);
            string srcPath = Path.Combine(tempDir, "LicCheck.cs");

            string src = BuildCheckerSource(deployUrl, selectedExePath);
            File.WriteAllText(srcPath, src, Encoding.UTF8);

            string csc = FindCsc();
            if (csc == null)
            {
                string fallback = Path.Combine(GetDownloadsFolder(), "LicenseCheck_source.cs");
                File.WriteAllText(fallback, src, Encoding.UTF8);
                MessageBox.Show(
                    "C# compiler (csc.exe) not found.\r\n\r\n" +
                    "Source code saved to:\r\n" + fallback + "\r\n\r\n" +
                    "You can compile it on another computer with Visual Studio installed.",
                    "Compiler Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return fallback;
            }

            string args =
                $"/target:winexe /optimize+ " +
                $"/out:\"{outPath}\" " +
                $"/reference:System.dll " +
                $"/reference:System.Core.dll " +
                $"/reference:System.Drawing.dll " +
                $"/reference:System.Windows.Forms.dll " +
                $"/reference:System.Net.dll " +
                $"\"{srcPath}\"";

            var psi = new ProcessStartInfo
            {
                FileName = csc,
                Arguments = args,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var proc = Process.Start(psi);
            string stderr = proc.StandardError.ReadToEnd();
            string stdout = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            try { Directory.Delete(tempDir, true); } catch { }

            if (proc.ExitCode != 0)
            {
                string errFile = Path.Combine(GetDownloadsFolder(), "compilation_error.txt");
                File.WriteAllText(errFile, stderr + "\r\n" + stdout);
                MessageBox.Show(
                    "Compilation failed.\r\n\r\n" +
                    "Error details saved to:\r\n" + errFile,
                    "Compilation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return errFile;
            }

            return outPath;
        }

        private string FindCsc()
        {
            string[] paths =
            {
                @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe",
                @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe",
                @"C:\Windows\Microsoft.NET\Framework64\v3.5\csc.exe",
                @"C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe"
            };
            foreach (var p in paths)
                if (File.Exists(p)) return p;
            return null;
        }

        
        private string BuildCheckerSource(string deployUrl, string protectedExe)
        {
            string exeFileName = Path.GetFileName(protectedExe).Replace("\\", "\\\\").Replace("\"", "\\\"");

            return
$@"using System;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace LicenseCheck
{{
    static class Program
    {{
        [STAThread]
        static void Main()
        {{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLicense());
        }}
    }}

    public class FormLicense : Form
    {{
        private TextBox  txtKey;
        private Button   btnActivate;
        private Label    lblStatus;
        private Panel    panelTop;
        private Label    lblTitle;
        private Label    lblSub;

        public FormLicense()
        {{
            BuildUI();
        }}

        private void BuildUI()
        {{
            this.Text             = ""License Activation"";
            this.ClientSize       = new Size(500, 340);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.BackColor       = Color.FromArgb(14, 14, 20);

            panelTop             = new Panel();
            panelTop.BackColor = Color.FromArgb(20, 20, 32);
            panelTop.Size      = new Size(500, 72);
            panelTop.Location  = new Point(0, 0);
            this.Controls.Add(panelTop);

            lblTitle             = new Label();
            lblTitle.Text        = ""License Activation"";
            lblTitle.Font        = new Font(""Segoe UI"", 16f, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(100, 190, 255);
            lblTitle.AutoSize  = true;
            lblTitle.Location  = new Point(20, 10);
            panelTop.Controls.Add(lblTitle);

            lblSub             = new Label();
            lblSub.Text        = ""{exeFileName}"";
            lblSub.Font        = new Font(""Segoe UI"", 9f);
            lblSub.ForeColor = Color.FromArgb(120, 120, 155);
            lblSub.AutoSize  = true;
            lblSub.Location  = new Point(22, 46);
            panelTop.Controls.Add(lblSub);

            var lblInstr = new Label();
            lblInstr.Text        = ""Enter your license key ( XXXX-XXXX-XXXX )"";
            lblInstr.Font        = new Font(""Segoe UI"", 9.5f);
            lblInstr.ForeColor = Color.FromArgb(180, 180, 210);
            lblInstr.AutoSize  = true;
            lblInstr.Location  = new Point(28, 92);
            this.Controls.Add(lblInstr);

            txtKey               = new TextBox();
            txtKey.Font          = new Font(""Consolas"", 15f, FontStyle.Bold);
            txtKey.Size          = new Size(310, 36);
            txtKey.Location      = new Point(28, 122);
            txtKey.MaxLength     = 14;
            txtKey.CharacterCasing = CharacterCasing.Upper;
            txtKey.BackColor     = Color.FromArgb(30, 30, 48);
            txtKey.ForeColor     = Color.FromArgb(70, 200, 110);
            txtKey.BorderStyle = BorderStyle.FixedSingle;
            txtKey.TextChanged += TxtKey_TextChanged;
            this.Controls.Add(txtKey);

            btnActivate                = new Button();
            btnActivate.Text           = ""Activate"";
            btnActivate.Font           = new Font(""Segoe UI"", 10f, FontStyle.Bold);
            btnActivate.Size           = new Size(120, 36);
            btnActivate.Location       = new Point(352, 122);
            btnActivate.BackColor      = Color.FromArgb(50, 130, 255);
            btnActivate.ForeColor      = Color.White;
            btnActivate.FlatStyle      = FlatStyle.Flat;
            btnActivate.FlatAppearance.BorderSize = 0;
            btnActivate.Enabled        = false;
            btnActivate.Click         += BtnActivate_Click;
            this.Controls.Add(btnActivate);

            lblStatus             = new Label();
            lblStatus.Font        = new Font(""Segoe UI"", 9.5f);
            lblStatus.ForeColor = Color.FromArgb(200, 200, 220);
            lblStatus.Size      = new Size(444, 80);
            lblStatus.Location  = new Point(28, 178);
            this.Controls.Add(lblStatus);

            var sep = new Panel();
            sep.BackColor = Color.FromArgb(48, 48, 72);
            sep.Size      = new Size(444, 1);
            sep.Location  = new Point(28, 170);
            this.Controls.Add(sep);

            var lblFooter = new Label();
            lblFooter.Text        = ""This application is licensed. Unauthorized distribution is prohibited."";
            lblFooter.Font        = new Font(""Segoe UI"", 8f);
            lblFooter.ForeColor = Color.FromArgb(70, 70, 95);
            lblFooter.AutoSize  = true;
            lblFooter.Location  = new Point(28, 305);
            this.Controls.Add(lblFooter);
        }}

        private void TxtKey_TextChanged(object sender, EventArgs e)
        {{
            string t     = txtKey.Text;
            string digits = t.Replace(""-"", """");

            if (t.Length == 4  && !t.EndsWith(""-"")) {{ txtKey.Text = t + ""-""; txtKey.SelectionStart = txtKey.Text.Length; }}
            if (t.Length == 9  && !t.EndsWith(""-"") && t[4] == '-') {{ txtKey.Text = t + ""-""; txtKey.SelectionStart = txtKey.Text.Length; }}

            btnActivate.Enabled = Regex.IsMatch(txtKey.Text, @""^[A-Z0-9]{{4}}-[A-Z0-9]{{4}}-[A-Z0-9]{{4}}$"");
        }}

        private void BtnActivate_Click(object sender, EventArgs e)
        {{
            string key  = txtKey.Text.Trim().ToUpper();
            string hwid = GetHwid();

            lblStatus.ForeColor = Color.FromArgb(200, 190, 60);
            lblStatus.Text      = ""⏳   Connecting to server..."";
            btnActivate.Enabled = false;
            Application.DoEvents();

            try
            {{
                string url     = ""{deployUrl}?key="" + Uri.EscapeDataString(key) + ""&hwid="" + Uri.EscapeDataString(hwid);
                var    wc      = new WebClient();
                string response = wc.DownloadString(url);

                if (response.StartsWith(""SUCCESS""))
                {{
                    string[] parts   = response.Split('|');
                    string   remaining = parts.Length > 1 ? parts[1] : ""?"";
                    lblStatus.ForeColor = Color.FromArgb(70, 200, 110);
                    lblStatus.Text      = ""✅   License valid! Remaining days: "" + remaining + ""\r\nLaunching application..."";
                    Application.DoEvents();
                    Thread.Sleep(1400);

                    string dir       = AppDomain.CurrentDomain.BaseDirectory;
                    string target    = Path.Combine(dir, ""{exeFileName}"");
                    if (File.Exists(target))
                        System.Diagnostics.Process.Start(target);
                    else
                    {{
                        using (var ofd = new OpenFileDialog())
                        {{
                            ofd.Title  = ""Select {exeFileName} location"";
                            ofd.Filter = ""Exe (*.exe)|*.exe"";
                            if (ofd.ShowDialog() == DialogResult.OK)
                                System.Diagnostics.Process.Start(ofd.FileName);
                        }}
                    }}
                    this.Close();
                    return;
                }}

                switch (response)
                {{
                    case ""WRONG_HWID"":
                        lblStatus.ForeColor = Color.FromArgb(255, 75, 75);
                        lblStatus.Text      = ""❌   This key is already activated on another device.\r\n   Each key is unique to one device."";
                        break;
                    case ""EXPIRED"":
                        lblStatus.ForeColor = Color.FromArgb(255, 140, 40);
                        lblStatus.Text      = ""⌛   License expired.\r\n   Contact the seller to renew."";
                        break;
                    case ""INVALID_KEY"":
                        lblStatus.ForeColor = Color.FromArgb(255, 75, 75);
                        lblStatus.Text      = ""❌   Invalid key. Please check and try again."";
                        break;
                    default:
                        lblStatus.ForeColor = Color.FromArgb(255, 75, 75);
                        lblStatus.Text      = ""⚠   Unexpected response: "" + response;
                        break;
                }}
            }}
            catch (Exception ex)
            {{
                lblStatus.ForeColor = Color.FromArgb(255, 75, 75);
                lblStatus.Text      = ""🌐   Connection error. Please check your internet.\r\n"" + ex.Message;
            }}

            btnActivate.Enabled = true;
        }}

        private string GetHwid()
        {{
            try
            {{
                var mc  = new ManagementClass(""win32_processor"");
                var moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                    return mo.Properties[""processorID""].Value.ToString();
            }}
            catch {{ }}
            return Environment.MachineName + ""-"" + Environment.UserName;
        }}
    }}
}}";
        }

        
        private void StartCountdown()
        {
            countdownSeconds = 10;
            countdownTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            countdownTimer.Tick += CountdownTick;
            countdownTimer.Start();
        }

        private void StopCountdown()
        {
            if (countdownTimer != null && countdownTimer.Enabled)
            {
                countdownTimer.Stop();
                countdownTimer.Dispose();
                countdownTimer = null;
            }
            countdownSeconds = 10;
        }

        private void CountdownTick(object sender, EventArgs e)
        {
            countdownSeconds--;
            if (countdownSeconds <= 0)
            {
                StopCountdown();
                btnNext.Enabled = true;
                ReplaceCountdownLine("✅   If you have completed all steps, click Next.");
            }
            else
            {
                ReplaceCountdownLine("⏱   Next button will be active in " + countdownSeconds + " seconds...");
            }
        }

        private void ReplaceCountdownLine(string newLine)
        {
            string t = lblStep2Info.Text;
            int idx = t.LastIndexOf("⏱");
            if (idx < 0) idx = t.LastIndexOf("✅   If");
            if (idx >= 0)
                lblStep2Info.Text = t.Substring(0, idx) + newLine;
        }

        
        private void UpdateProgress(int step)
        {
            progressBar.Value = Math.Min(step * 100 / 6, 100);
            lblProgress.Text = step < 6 ? "Step " + (step + 1) + " / 6" : "Completed";
        }
    }
}
