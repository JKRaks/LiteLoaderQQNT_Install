using Liteloader.Core;

namespace Liteloader
{
    public partial class Main : Base
    {
        public Main()
        {
            InitializeComponent();
            LoactionService local = new(this);
            txtQVersion.Text = local.GetQVersion();
        }

        private async void btnFrameUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateService service = new(this);
                await CallSyncFunc(sender, () => { service.UpdateFramework(ckbUseProxy.Checked); });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSetLocation_Click(object sender, EventArgs e)
        {
            try
            {
                using OpenFileDialog ofd = new();
                ofd.AddExtension = true;
                ofd.Filter = "QQ运行文件|QQ.exe";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtInstall.Text = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("未选择文件");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnInjet_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInstall.Text))
                {
                    MessageBox.Show("未选择文件");
                    return;
                }
                else
                {
                    LoactionService local = new(this);
                    await CallSyncFunc(sender, () => { local.Inject(txtInstall.Text, txtQVersion.Text); });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Plugin plugin = new();
            plugin.ShowDialog();
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                LoactionService local = new(this);
                await CallSyncFunc(sender, () => { local.Reset(); });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
