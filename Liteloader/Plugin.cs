using Liteloader.Core;
using Liteloader.Core.Output;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liteloader
{
    public partial class Plugin : Base
    {
        readonly PluginService service;

        public Plugin()
        {
            InitializeComponent();
            dgvPlugin.CellEndEdit += EditPlugin;
            dgvPlugin.UserAddedRow += AddPlugin;
            service = new PluginService(this);
            dgvPlugin.DataSource = service.GetPluginInfos();
            dgvPlugin.Refresh();
            dgvPlugin.AllowUserToAddRows = true;
        }

        private async void btnUpdatePlugin_Click(object sender, EventArgs e)
        {
            try
            {
                bool proxy = ckbUseProxy.Checked;
                btnUpdatePlugin.Enabled = false;
                await service.UpdatePlugin(proxy);
                btnUpdatePlugin.Enabled = true;
                MessageBox.Show("更新完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddPlugin(object? sender, DataGridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[0].Value = Guid.NewGuid().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void EditPlugin(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var rowIndex = e.RowIndex;
                DataGridViewRow row = dgvPlugin.Rows[rowIndex];
                PluginInfoOutput infoOutput = new()
                {
                    Id = row.Cells[0].Value?.ToString() ?? Guid.NewGuid().ToString(),
                    Name = row.Cells[1].Value?.ToString(),
                    Repo = row.Cells[2].Value?.ToString(),
                    Description = row.Cells[3].Value?.ToString(),
                    Branch = row.Cells[4].Value?.ToString()
                };
                if (string.IsNullOrEmpty(infoOutput.Name) && string.IsNullOrEmpty(infoOutput.Repo))
                {
                    service.DelSource(infoOutput.Id);
                }
                else
                {
                    service.UpdateSource(infoOutput);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
