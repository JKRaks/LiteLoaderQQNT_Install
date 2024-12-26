namespace Liteloader
{
    partial class Plugin
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plugin));
            dgvPlugin = new DataGridView();
            pluginInfoOutputBindingSource = new BindingSource(components);
            btnUpdatePlugin = new Button();
            ckbUseProxy = new CheckBox();
            Id = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            repoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            branchDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aboutDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvPlugin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pluginInfoOutputBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvPlugin
            // 
            dgvPlugin.AllowUserToAddRows = false;
            dgvPlugin.AllowUserToDeleteRows = false;
            dgvPlugin.AllowUserToResizeColumns = false;
            dgvPlugin.AllowUserToResizeRows = false;
            dgvPlugin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPlugin.AutoGenerateColumns = false;
            dgvPlugin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvPlugin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlugin.Columns.AddRange(new DataGridViewColumn[] { Id, nameDataGridViewTextBoxColumn, repoDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, branchDataGridViewTextBoxColumn, aboutDataGridViewTextBoxColumn });
            dgvPlugin.DataSource = pluginInfoOutputBindingSource;
            dgvPlugin.EnableHeadersVisualStyles = false;
            dgvPlugin.Location = new Point(12, 41);
            dgvPlugin.MultiSelect = false;
            dgvPlugin.Name = "dgvPlugin";
            dgvPlugin.RowHeadersVisible = false;
            dgvPlugin.Size = new Size(712, 146);
            dgvPlugin.TabIndex = 0;
            // 
            // pluginInfoOutputBindingSource
            // 
            pluginInfoOutputBindingSource.DataSource = typeof(Core.Output.PluginInfoOutput);
            // 
            // btnUpdatePlugin
            // 
            btnUpdatePlugin.Location = new Point(12, 12);
            btnUpdatePlugin.Name = "btnUpdatePlugin";
            btnUpdatePlugin.Size = new Size(75, 23);
            btnUpdatePlugin.TabIndex = 3;
            btnUpdatePlugin.Text = "更新插件";
            btnUpdatePlugin.UseVisualStyleBackColor = true;
            btnUpdatePlugin.Click += btnUpdatePlugin_Click;
            // 
            // ckbUseProxy
            // 
            ckbUseProxy.AutoSize = true;
            ckbUseProxy.Checked = true;
            ckbUseProxy.CheckState = CheckState.Checked;
            ckbUseProxy.Location = new Point(93, 14);
            ckbUseProxy.Name = "ckbUseProxy";
            ckbUseProxy.Size = new Size(59, 21);
            ckbUseProxy.TabIndex = 7;
            ckbUseProxy.Text = "Proxy";
            ckbUseProxy.UseVisualStyleBackColor = true;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Visible = false;
            Id.Width = 26;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "插件名称";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // repoDataGridViewTextBoxColumn
            // 
            repoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            repoDataGridViewTextBoxColumn.DataPropertyName = "Repo";
            repoDataGridViewTextBoxColumn.HeaderText = "仓库名";
            repoDataGridViewTextBoxColumn.Name = "repoDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "描述";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // branchDataGridViewTextBoxColumn
            // 
            branchDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            branchDataGridViewTextBoxColumn.DataPropertyName = "Branch";
            branchDataGridViewTextBoxColumn.HeaderText = "更新链路";
            branchDataGridViewTextBoxColumn.Name = "branchDataGridViewTextBoxColumn";
            branchDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            // 
            // aboutDataGridViewTextBoxColumn
            // 
            aboutDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            aboutDataGridViewTextBoxColumn.DataPropertyName = "About";
            aboutDataGridViewTextBoxColumn.HeaderText = "远端详情";
            aboutDataGridViewTextBoxColumn.Name = "aboutDataGridViewTextBoxColumn";
            // 
            // Plugin
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(736, 199);
            Controls.Add(ckbUseProxy);
            Controls.Add(btnUpdatePlugin);
            Controls.Add(dgvPlugin);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Plugin";
            Text = "插件源";
            ((System.ComponentModel.ISupportInitialize)dgvPlugin).EndInit();
            ((System.ComponentModel.ISupportInitialize)pluginInfoOutputBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPlugin;
        private BindingSource pluginInfoOutputBindingSource;
        private Button btnUpdatePlugin;
        private CheckBox ckbUseProxy;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn repoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn branchDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aboutDataGridViewTextBoxColumn;
    }
}