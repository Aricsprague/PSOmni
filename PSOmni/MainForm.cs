using PSOmni.Configuration;
using PSOmni.Domain;
using PSOmni.Infrastructure;
using PSOmni.Services;

namespace PSOmni
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            AppSettings settings = new();

            CommandRunner runner = new();

            AdbService adb = new(runner, settings);

            StartupService startup = new(adb);

            while (!await startup.InitializeAsync())
            {
                DialogResult result = MessageBox.Show(
                    "Automatic connection failed.\n\n" +
                    "Verify Wireless Debugging is enabled and your tablet is connected to Wi-Fi.",
                    "PS Omni",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    Close();
                    return;
                }
            }

            MessageBox.Show("Tablet Connected");
        }
    }
}
