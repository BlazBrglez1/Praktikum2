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
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 163);
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
            listBoxKode.Location = new Point(12, 37);
            listBoxKode.Name = "listBoxKode";
            listBoxKode.Size = new Size(117, 109);
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
            listView1.Location = new Point(292, 53);
            listView1.Name = "listView1";
            listView1.Size = new Size(416, 293);
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
            button2.Location = new Point(576, 21);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 3;
            button2.Text = "Dodaj načrt";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(403, 21);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(292, 22);
            label1.Name = "label1";
            label1.Size = new Size(105, 18);
            label1.TabIndex = 6;
            label1.Text = "Iskanje načrtov:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}