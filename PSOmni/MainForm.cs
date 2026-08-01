using PSOmni.Configuration;
using PSOmni.Domain;
using PSOmni.Infrastructure;
using PSOmni.Services;

namespace PSOmni
{
    /// <summary>Main application window responsible for user interactions and initiating synchronization operations.</summary>
    public partial class MainForm : Form
    {
        private readonly AppSettings _settings;
        private readonly CommandRunner _commandRunner;
        private readonly AdbService _adbService;
        private readonly StartupService _startupService;
        private readonly SyncService _syncService;

        /// <summary>Initializes the main form and required services.</summary>
        public MainForm()
        {
            InitializeComponent();

            _settings = new AppSettings();

            _commandRunner = new CommandRunner();

            _adbService = new AdbService(
                _commandRunner,
                _settings);

            _startupService = new StartupService(
                _adbService);

            SyncPaths paths = new()
            {
                RemoteMemoryCard = "/sdcard/Android/data/xyz.aethersx2.android/files/memcards/Dark Cloud.ps2",
                LocalMemoryCard = @"C:\Emulation\PCSX2\memcards\Dark Cloud.ps2"
            };

            _syncService = new SyncService(
                _adbService,
                paths);
        }

        private void SetConnectionStatus(
            bool connected,
            string profileName = "")
        {
            if (connected)
            {
                statusIndicatorImage.Image = Properties.Resources.GreenCheck;

                activeProfileLabel.Text = profileName;
            }
            else
            {
                statusIndicatorImage.Image = Properties.Resources.RedX;

                activeProfileLabel.Text = "Not Connected";
            }
        }

        private void SetStatus(
            string text)
        {
            statusStripLabel.Text = text;
        }

        private void SetBusy(
            bool busy)
        {
            statusProgressBar.Visible = busy;

            if (busy)
            {
                statusProgressBar.Style =
                    ProgressBarStyle.Marquee;
            }
        }

        private async void MainForm_Load(
            object sender,
            EventArgs e)
        {
            await InitializeApplicationAsync();

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

        private async Task InitializeApplicationAsync()
        {
            SetBusy(true);

            SetStatus("Connecting...");

            bool connected =
                await _startupService.InitializeAsync();

            if (connected)
            {
                SetConnectionStatus(
                    true,
                    "Dark Cloud");

                SetStatus("Ready");
            }
            else
            {
                SetConnectionStatus(false);

                SetStatus("Connection Failed");
            }

            SetBusy(false);
        }

        private void ToggleUi(bool enabled)
        {
            pullButton.Enabled = enabled;
            pushButton.Enabled = enabled;

            statusProgressBar.Visible = !enabled;

            if (!enabled)
                statusProgressBar.Style = ProgressBarStyle.Marquee;
        }

        private async void PullButton_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleUi(false);
                SetStatus("Pulling memory card...");

                await _syncService.PullMemoryCardAsync();

                SetStatus("Pull complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                SetStatus("Pull failed.");
            }
            finally
            {
                ToggleUi(true);
            }
        }
        private async void PushButton_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleUi(false);
                SetStatus("Pushing memory card...");

                await _syncService.PushMemoryCardAsync();

                SetStatus("Push complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                SetStatus("Push failed.");
            }
            finally
            {
                ToggleUi(true);
            }
        }
    }
}
