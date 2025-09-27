using System.Diagnostics;

namespace MinMenu
{
    public partial class MinMenuForm : Form
    {
        private bool isClosing = false;

        public MinMenuForm(string dir)
        {
            InitializeComponent();
            SetupForm(dir);
        }

        private void SetupForm(string dir)
        {
            this.Shown += (s, e) =>
            {
                if (this.ContextMenuStrip != null)
                {
                    this.ContextMenuStrip.Show(Cursor.Position);
                }
                else
                {
                    SafeClose();
                }
            };
            this.Opacity = 0;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
            this.Deactivate += (s, e) => SafeClose();
            ContextMenuStrip mainMenu = new ContextMenuStrip();
            LoadLinksFromDirectory(dir, mainMenu.Items);
            this.ContextMenuStrip = mainMenu;
        }

        private void LoadLinksFromDirectory(string directoryPath, ToolStripItemCollection menuItems)
        {
            if (!Directory.Exists(directoryPath)) return;
            try
            {
                foreach (string subDir in Directory.GetDirectories(directoryPath))
                {
                    ToolStripMenuItem subMenu = new ToolStripMenuItem(Path.GetFileName(subDir));
                    LoadLinksFromDirectory(subDir, subMenu.DropDownItems);
                    if (subMenu.DropDownItems.Count > 0)
                        menuItems.Add(subMenu);
                }
                foreach (string file in Directory.GetFiles(directoryPath, "*.lnk"))
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem(
                        Path.GetFileNameWithoutExtension(file),
                        Icon.ExtractAssociatedIcon(file)?.ToBitmap()
                    );
                    menuItem.Click += (s, e) =>
                    {
                        OpenLink(file);
                        SafeClose();
                    };
                    menuItems.Add(menuItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading links: {ex.Message}");
            }
        }

        private void OpenLink(string linkPath)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = linkPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening link: {ex.Message}");
            }
        }

        private void SafeClose()
        {
            if (!isClosing)
            {
                isClosing = true;
                this.Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.ContextMenuStrip?.Visible == true)
            {
                if ((keyData >= Keys.A && keyData <= Keys.Z) || (keyData >= Keys.D0 && keyData <= Keys.D9))
                {
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
