namespace ExibitionConnectedLayer
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
            insertOwnerToolStripMenuItem = new ToolStripMenuItem();
            deleteContractToolStripMenuItem = new ToolStripMenuItem();
            updateCompanyToolStripMenuItem = new ToolStripMenuItem();
            dataTableSelectToolStripMenuItem = new ToolStripMenuItem();
            createContractToolStripMenuItem = new ToolStripMenuItem();
            removeProductsToolStripMenuItem = new ToolStripMenuItem();
            btnExecute = new ToolStripButton();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            createDatasetToolStripMenuItem = new ToolStripMenuItem();
            PrintOwnerTableToolStripMenuItem = new ToolStripMenuItem();
            FillDataSetAdapterToolStripMenuItem = new ToolStripMenuItem();
            ModifyDataSetAdapterToolStripMenuItem = new ToolStripMenuItem();
            DeleteRowFromTableToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStrip1.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // rtbResult
            // 
            rtbResult.BackColor = Color.MintCream;
            rtbResult.Location = new Point(12, 38);
            rtbResult.Name = "rtbResult";
            rtbResult.Size = new Size(826, 357);
            rtbResult.TabIndex = 0;
            rtbResult.Text = "";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.LightBlue;
            toolStrip1.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem, btnExecute, toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(852, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripMenuItem
            // 
            ToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadingToolStripMenuItem, insertOwnerToolStripMenuItem, deleteContractToolStripMenuItem, updateCompanyToolStripMenuItem, dataTableSelectToolStripMenuItem, createContractToolStripMenuItem, removeProductsToolStripMenuItem });
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
            loadingToolStripMenuItem.Size = new Size(370, 26);
            loadingToolStripMenuItem.Text = "Загрузка";
            loadingToolStripMenuItem.ToolTipText = "Подключение к БД";
            loadingToolStripMenuItem.Click += loadingToolStripMenuItem_Click;
            // 
            // insertOwnerToolStripMenuItem
            // 
            insertOwnerToolStripMenuItem.CheckOnClick = true;
            insertOwnerToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            insertOwnerToolStripMenuItem.Name = "insertOwnerToolStripMenuItem";
            insertOwnerToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D1;
            insertOwnerToolStripMenuItem.Size = new Size(370, 26);
            insertOwnerToolStripMenuItem.Text = "Добавление владельца";
            insertOwnerToolStripMenuItem.ToolTipText = "Скрипт INSERT";
            insertOwnerToolStripMenuItem.Click += insertOwnerToolStripMenuItem_Click;
            // 
            // deleteContractToolStripMenuItem
            // 
            deleteContractToolStripMenuItem.CheckOnClick = true;
            deleteContractToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            deleteContractToolStripMenuItem.Name = "deleteContractToolStripMenuItem";
            deleteContractToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D2;
            deleteContractToolStripMenuItem.Size = new Size(370, 26);
            deleteContractToolStripMenuItem.Text = "Удаление контракта";
            deleteContractToolStripMenuItem.ToolTipText = "скрипт DELETE";
            deleteContractToolStripMenuItem.Click += deleteContractToolStripMenuItem_Click;
            // 
            // updateCompanyToolStripMenuItem
            // 
            updateCompanyToolStripMenuItem.CheckOnClick = true;
            updateCompanyToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            updateCompanyToolStripMenuItem.Name = "updateCompanyToolStripMenuItem";
            updateCompanyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D3;
            updateCompanyToolStripMenuItem.Size = new Size(370, 26);
            updateCompanyToolStripMenuItem.Text = "Изменить название компании";
            updateCompanyToolStripMenuItem.ToolTipText = "скрипт UPDATE";
            updateCompanyToolStripMenuItem.Click += updateCompanyToolStripMenuItem_Click;
            // 
            // dataTableSelectToolStripMenuItem
            // 
            dataTableSelectToolStripMenuItem.CheckOnClick = true;
            dataTableSelectToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            dataTableSelectToolStripMenuItem.Name = "dataTableSelectToolStripMenuItem";
            dataTableSelectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D4;
            dataTableSelectToolStripMenuItem.Size = new Size(370, 26);
            dataTableSelectToolStripMenuItem.Text = "Данные выбранной таблицы";
            dataTableSelectToolStripMenuItem.ToolTipText = "скрипт SELECT TOP";
            dataTableSelectToolStripMenuItem.Click += dataTableSelectToolStripMenuItem_Click;
            // 
            // createContractToolStripMenuItem
            // 
            createContractToolStripMenuItem.CheckOnClick = true;
            createContractToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            createContractToolStripMenuItem.Name = "createContractToolStripMenuItem";
            createContractToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D5;
            createContractToolStripMenuItem.Size = new Size(370, 26);
            createContractToolStripMenuItem.Text = "Заключение договора";
            createContractToolStripMenuItem.ToolTipText = "Процедура";
            createContractToolStripMenuItem.Click += createContractToolStripMenuItem_Click;
            // 
            // removeProductsToolStripMenuItem
            // 
            removeProductsToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            removeProductsToolStripMenuItem.Name = "removeProductsToolStripMenuItem";
            removeProductsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D6;
            removeProductsToolStripMenuItem.Size = new Size(370, 26);
            removeProductsToolStripMenuItem.Text = "Убрать продукцию с выставки";
            removeProductsToolStripMenuItem.ToolTipText = "Транзакция";
            removeProductsToolStripMenuItem.Click += removeProductsToolStripMenuItem_Click;
            // 
            // btnExecute
            // 
            btnExecute.BackColor = Color.CadetBlue;
            btnExecute.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnExecute.ForeColor = SystemColors.Control;
            btnExecute.Image = (Image)resources.GetObject("btnExecute.Image");
            btnExecute.ImageTransparentColor = Color.Magenta;
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(94, 22);
            btnExecute.Text = "Выполнить";
            btnExecute.Click += btnExecute_Click;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { createDatasetToolStripMenuItem, PrintOwnerTableToolStripMenuItem, FillDataSetAdapterToolStripMenuItem, ModifyDataSetAdapterToolStripMenuItem, DeleteRowFromTableToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(68, 22);
            toolStripDropDownButton1.Text = "Файл2";
            // 
            // createDatasetToolStripMenuItem
            // 
            createDatasetToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            createDatasetToolStripMenuItem.Name = "createDatasetToolStripMenuItem";
            createDatasetToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.Q;
            createDatasetToolStripMenuItem.Size = new Size(475, 26);
            createDatasetToolStripMenuItem.Text = "Заполнение DataSet таблицами";
            createDatasetToolStripMenuItem.ToolTipText = "CreateDataSet";
            createDatasetToolStripMenuItem.Click += createDatasetToolStripMenuItem_Click;
            // 
            // PrintOwnerTableToolStripMenuItem
            // 
            PrintOwnerTableToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            PrintOwnerTableToolStripMenuItem.Name = "PrintOwnerTableToolStripMenuItem";
            PrintOwnerTableToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D1;
            PrintOwnerTableToolStripMenuItem.Size = new Size(475, 26);
            PrintOwnerTableToolStripMenuItem.Text = "Вывести содержимое таблицы Owner";
            PrintOwnerTableToolStripMenuItem.ToolTipText = "PrintTable";
            PrintOwnerTableToolStripMenuItem.Click += PrintOwnerTableToolStripMenuItem_Click;
            // 
            // FillDataSetAdapterToolStripMenuItem
            // 
            FillDataSetAdapterToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            FillDataSetAdapterToolStripMenuItem.Name = "FillDataSetAdapterToolStripMenuItem";
            FillDataSetAdapterToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D2;
            FillDataSetAdapterToolStripMenuItem.Size = new Size(475, 26);
            FillDataSetAdapterToolStripMenuItem.Text = "Заполнение данных из MS SQL Server";
            FillDataSetAdapterToolStripMenuItem.ToolTipText = "FillDataSetAdapter";
            FillDataSetAdapterToolStripMenuItem.Click += FillDataSetAdapterToolStripMenuItem_Click;
            // 
            // ModifyDataSetAdapterToolStripMenuItem
            // 
            ModifyDataSetAdapterToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            ModifyDataSetAdapterToolStripMenuItem.Name = "ModifyDataSetAdapterToolStripMenuItem";
            ModifyDataSetAdapterToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D3;
            ModifyDataSetAdapterToolStripMenuItem.Size = new Size(475, 26);
            ModifyDataSetAdapterToolStripMenuItem.Text = "Модификация данных из MS SQL Server";
            ModifyDataSetAdapterToolStripMenuItem.ToolTipText = "ModifyDataSetAdapter";
            ModifyDataSetAdapterToolStripMenuItem.Click += ModifyDataSetAdapterToolStripMenuItem_Click;
            // 
            // DeleteRowFromTableToolStripMenuItem
            // 
            DeleteRowFromTableToolStripMenuItem.Font = new Font("Century Gothic", 9F);
            DeleteRowFromTableToolStripMenuItem.Name = "DeleteRowFromTableToolStripMenuItem";
            DeleteRowFromTableToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D4;
            DeleteRowFromTableToolStripMenuItem.Size = new Size(475, 26);
            DeleteRowFromTableToolStripMenuItem.Text = "Удаление данных 1 строки таблицы Contract";
            DeleteRowFromTableToolStripMenuItem.ToolTipText = "DeleteRowFromTable";
            DeleteRowFromTableToolStripMenuItem.Click += DeleteRowFromTableToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = SystemColors.Control;
            statusStrip.Font = new Font("Cascadia Mono", 8.5F, FontStyle.Bold);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 409);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(852, 22);
            statusStrip.Stretch = false;
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 16);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(852, 431);
            Controls.Add(rtbResult);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip1);
            Font = new Font("Century Gothic", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "ADO.NET: connected layer + disconnected layer";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbResult;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton ToolStripMenuItem;
        private ToolStripMenuItem loadingToolStripMenuItem;
        private ToolStripMenuItem insertOwnerToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripButton btnExecute;
        private ToolStripMenuItem deleteContractToolStripMenuItem;
        private ToolStripMenuItem updateCompanyToolStripMenuItem;
        private ToolStripMenuItem dataTableSelectToolStripMenuItem;
        private ToolStripMenuItem createContractToolStripMenuItem;
        private ToolStripMenuItem removeProductsToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem createDatasetToolStripMenuItem;
        private ToolStripMenuItem PrintOwnerTableToolStripMenuItem;
        private ToolStripMenuItem FillDataSetAdapterToolStripMenuItem;
        private ToolStripMenuItem ModifyDataSetAdapterToolStripMenuItem;
        private ToolStripMenuItem DeleteRowFromTableToolStripMenuItem;
    }
}
