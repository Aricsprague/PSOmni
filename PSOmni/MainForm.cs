using PSOmni.Configuration;
using PSOmni.Domain;
using PSOmni.Infrastructure;

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

            bool connected = await adb.IsDeviceConnectedAsync();

            MessageBox.Show(
                connected ? "Tablet Connected" : "Tablet Not Connected");
        }
    }
}
