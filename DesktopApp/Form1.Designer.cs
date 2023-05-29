namespace DesktopApp
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
            button1 = new Button();
            fileSystemWatcher1 = new FileSystemWatcher();
            listView1 = new ListView();
            columnHeader2 = new ColumnHeader();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            pdfViewer1 = new Apitron.PDF.Controls.PDFViewer();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            label5 = new Label();
            tableLayoutPanel9 = new TableLayoutPanel();
            listBoxKode = new ListBox();
            label4 = new Label();
            label3 = new Label();
            listBoxBrez = new ListBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            tableLayoutPanel8 = new TableLayoutPanel();
            panel1 = new Panel();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = SystemColors.ScrollBar;
            button1.Cursor = Cursors.Hand;
            button1.Dock = DockStyle.Left;
            button1.Location = new Point(175, 3);
            button1.Name = "button1";
            button1.Size = new Size(274, 26);
            button1.TabIndex = 0;
            button1.Text = "Naloži";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            fileSystemWatcher1.Created += fileSystemWatcher1_Created;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            listView1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            listView1.Location = new Point(3, 85);
            listView1.Name = "listView1";
            listView1.Size = new Size(587, 199);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Shranjeni načrti";
            columnHeader2.Width = 300;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = SystemColors.ScrollBar;
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(84, 293);
            button2.Name = "button2";
            button2.Size = new Size(425, 52);
            button2.TabIndex = 3;
            button2.Text = "Dodaj načrt";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left;
            textBox1.Location = new Point(138, 8);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 6;
            label1.Text = "Iskanje načrtov:";
            // 
            // pdfViewer1
            // 
            pdfViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pdfViewer1.Document = null;
            pdfViewer1.EnableSearch = true;
            pdfViewer1.Location = new Point(4, 44);
            pdfViewer1.Name = "pdfViewer1";
            pdfViewer1.SearchHighlightColor = Color.FromArgb(128, 255, 255, 0);
            pdfViewer1.Size = new Size(594, 653);
            pdfViewer1.TabIndex = 7;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(4, 1);
            label2.Name = "label2";
            label2.Size = new Size(594, 39);
            label2.TabIndex = 8;
            label2.Text = "PREGLED NAROČILA";
            label2.UseWaitCursor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.84F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.16F));
            tableLayoutPanel1.Size = new Size(1221, 773);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 63);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1215, 707);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(pdfViewer1, 0, 1);
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Cursor = Cursors.No;
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(610, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 5.67107773F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 94.3289261F));
            tableLayoutPanel3.Size = new Size(602, 701);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel7, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 48.7142868F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 51.2857132F));
            tableLayoutPanel4.Size = new Size(601, 701);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 0, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel9, 0, 1);
            tableLayoutPanel5.Location = new Point(4, 4);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6766462F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 88.32336F));
            tableLayoutPanel5.Size = new Size(593, 334);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.Anchor = AnchorStyles.Left;
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 415F));
            tableLayoutPanel6.Controls.Add(label5, 0, 0);
            tableLayoutPanel6.Controls.Add(button1, 1, 0);
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(587, 32);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Underline, GraphicsUnit.Point);
            label5.Location = new Point(3, 6);
            label5.Name = "label5";
            label5.Size = new Size(155, 20);
            label5.TabIndex = 4;
            label5.Text = "Naloži naročilo ročno";
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.84838F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.15162F));
            tableLayoutPanel9.Controls.Add(listBoxKode, 0, 1);
            tableLayoutPanel9.Controls.Add(label4, 1, 0);
            tableLayoutPanel9.Controls.Add(label3, 0, 0);
            tableLayoutPanel9.Controls.Add(listBoxBrez, 1, 1);
            tableLayoutPanel9.Location = new Point(3, 44);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 255F));
            tableLayoutPanel9.Size = new Size(587, 284);
            tableLayoutPanel9.TabIndex = 1;
            // 
            // listBoxKode
            // 
            listBoxKode.Dock = DockStyle.Fill;
            listBoxKode.FormattingEnabled = true;
            listBoxKode.ItemHeight = 15;
            listBoxKode.Location = new Point(3, 32);
            listBoxKode.Name = "listBoxKode";
            listBoxKode.Size = new Size(269, 249);
            listBoxKode.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(278, 9);
            label4.Name = "label4";
            label4.Size = new Size(201, 20);
            label4.TabIndex = 2;
            label4.Text = "Kode brez najdenih načrtov";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 9);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 1;
            label3.Text = "Najdene kode";
            label3.UseWaitCursor = true;
            // 
            // listBoxBrez
            // 
            listBoxBrez.BackColor = Color.White;
            listBoxBrez.Dock = DockStyle.Fill;
            listBoxBrez.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxBrez.FormattingEnabled = true;
            listBoxBrez.ItemHeight = 20;
            listBoxBrez.Location = new Point(278, 32);
            listBoxBrez.Name = "listBoxBrez";
            listBoxBrez.Size = new Size(306, 249);
            listBoxBrez.TabIndex = 2;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(listView1, 0, 1);
            tableLayoutPanel7.Controls.Add(tableLayoutPanel8, 0, 0);
            tableLayoutPanel7.Controls.Add(button2, 0, 2);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(4, 345);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 3;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 28.5714283F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 71.42857F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tableLayoutPanel7.Size = new Size(593, 352);
            tableLayoutPanel7.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 299F));
            tableLayoutPanel8.Controls.Add(textBox1, 1, 0);
            tableLayoutPanel8.Controls.Add(label1, 0, 0);
            tableLayoutPanel8.Location = new Point(3, 40);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(434, 39);
            tableLayoutPanel8.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(label6);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1215, 54);
            panel1.TabIndex = 1;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(519, 10);
            label6.Name = "label6";
            label6.Size = new Size(236, 25);
            label6.TabIndex = 0;
            label6.Text = "TISKANJE NAČRTOV";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1221, 773);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Tiskalec načrtov";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private FileSystemWatcher fileSystemWatcher1;
        private Button button2;
        private ListView listView1;
        private ColumnHeader columnHeader2;
        private Label label1;
        private TextBox textBox1;
        private Apitron.PDF.Controls.PDFViewer pdfViewer1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel9;
        private ListBox listBoxKode;
        private ListBox listBoxBrez;
        private Label label5;
        private Panel panel1;
        private Label label6;
    }
}