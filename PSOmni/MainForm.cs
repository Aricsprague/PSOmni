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
            CommandRunner runner = new();

            CommandResult result =
                await runner.RunAsync(
                    "cmd",
                    "/c echo Hello, PS Omni!");

            MessageBox.Show(result.StandardOutput);
        }
    }
}
