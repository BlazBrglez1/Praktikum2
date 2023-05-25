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
            listBoxKode = new ListBox();
            fileSystemWatcher1 = new FileSystemWatcher();
            listView1 = new ListView();
            columnHeader2 = new ColumnHeader();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            pdfViewer1 = new Apitron.PDF.Controls.PDFViewer();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(21, 201);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Naloži";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBoxKode
            // 
            listBoxKode.FormattingEnabled = true;
            listBoxKode.ItemHeight = 15;
            listBoxKode.Location = new Point(21, 51);
            listBoxKode.Name = "listBoxKode";
            listBoxKode.Size = new Size(197, 124);
            listBoxKode.TabIndex = 1;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            fileSystemWatcher1.Created += fileSystemWatcher1_Created;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            listView1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            listView1.Location = new Point(12, 335);
            listView1.Name = "listView1";
            listView1.Size = new Size(465, 163);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ime Datoteke";
            columnHeader2.Width = 300;
            // 
            // button2
            // 
            button2.Location = new Point(310, 300);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 3;
            button2.Text = "Dodaj načrt";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(123, 300);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 301);
            label1.Name = "label1";
            label1.Size = new Size(105, 18);
            label1.TabIndex = 6;
            label1.Text = "Iskanje načrtov:";
            // 
            // pdfViewer1
            // 
            pdfViewer1.Document = null;
            pdfViewer1.EnableSearch = true;
            pdfViewer1.Location = new Point(494, 51);
            pdfViewer1.Name = "pdfViewer1";
            pdfViewer1.SearchHighlightColor = Color.FromArgb(128, 255, 255, 0);
            pdfViewer1.Size = new Size(631, 698);
            pdfViewer1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(494, 20);
            label2.Name = "label2";
            label2.Size = new Size(271, 21);
            label2.TabIndex = 8;
            label2.Text = "PREGLED NATISNJENIH NAČRTOV:";
            label2.UseWaitCursor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 787);
            Controls.Add(label2);
            Controls.Add(pdfViewer1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(listView1);
            Controls.Add(listBoxKode);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBoxKode;
        private FileSystemWatcher fileSystemWatcher1;
        private Button button2;
        private ListView listView1;
        private ColumnHeader columnHeader2;
        private Label label1;
        private TextBox textBox1;
        private Apitron.PDF.Controls.PDFViewer pdfViewer1;
        private Label label2;
    }
}