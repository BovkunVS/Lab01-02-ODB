namespace Lab01
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            rtbResult = new RichTextBox();
            toolStrip1 = new ToolStrip();
            ToolStripMenuItem = new ToolStripDropDownButton();
            loadingToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // rtbResult
            // 
            rtbResult.BackColor = Color.MintCream;
            rtbResult.Dock = DockStyle.Bottom;
            rtbResult.Location = new Point(0, 25);
            rtbResult.Name = "rtbResult";
            rtbResult.Size = new Size(900, 425);
            rtbResult.TabIndex = 0;
            rtbResult.Text = "";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.LightBlue;
            toolStrip1.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(900, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripMenuItem
            // 
            ToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadingToolStripMenuItem });
            ToolStripMenuItem.Image = (Image)resources.GetObject("ToolStripMenuItem.Image");
            ToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            ToolStripMenuItem.Name = "ToolStripMenuItem";
            ToolStripMenuItem.Size = new Size(60, 22);
            ToolStripMenuItem.Text = "Файл";
            // 
            // loadingToolStripMenuItem
            // 
            loadingToolStripMenuItem.BackColor = SystemColors.Control;
            loadingToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            loadingToolStripMenuItem.Name = "loadingToolStripMenuItem";
            loadingToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            loadingToolStripMenuItem.Size = new Size(224, 26);
            loadingToolStripMenuItem.Text = "Загрузка";
            loadingToolStripMenuItem.Click += loadingToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(900, 450);
            Controls.Add(toolStrip1);
            Controls.Add(rtbResult);
            Font = new Font("Century Gothic", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "ADO.NET: connected layer";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbResult;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton ToolStripMenuItem;
        private ToolStripMenuItem loadingToolStripMenuItem;
    }
}
