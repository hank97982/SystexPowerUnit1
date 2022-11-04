namespace WinFormsAppClient
{
    partial class MainForm
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
            this.txtbhno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcseq = new System.Windows.Forms.TextBox();
            this.btnSearchJson = new System.Windows.Forms.Button();
            this.cbConnectType = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbhno
            // 
            this.txtbhno.Location = new System.Drawing.Point(79, 12);
            this.txtbhno.Name = "txtbhno";
            this.txtbhno.Size = new System.Drawing.Size(125, 27);
            this.txtbhno.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "分公司";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "帳號";
            // 
            // txtcseq
            // 
            this.txtcseq.Location = new System.Drawing.Point(267, 12);
            this.txtcseq.Name = "txtcseq";
            this.txtcseq.Size = new System.Drawing.Size(125, 27);
            this.txtcseq.TabIndex = 3;
            // 
            // btnSearchJson
            // 
            this.btnSearchJson.Location = new System.Drawing.Point(455, 12);
            this.btnSearchJson.Name = "btnSearchJson";
            this.btnSearchJson.Size = new System.Drawing.Size(152, 29);
            this.btnSearchJson.TabIndex = 4;
            this.btnSearchJson.Text = "我要查詢";
            this.btnSearchJson.UseVisualStyleBackColor = true;
            this.btnSearchJson.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbConnectType
            // 
            this.cbConnectType.FormattingEnabled = true;
            this.cbConnectType.Location = new System.Drawing.Point(626, 12);
            this.cbConnectType.Name = "cbConnectType";
            this.cbConnectType.Size = new System.Drawing.Size(151, 27);
            this.cbConnectType.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(797, 352);
            this.dataGridView1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbConnectType);
            this.Controls.Add(this.btnSearchJson);
            this.Controls.Add(this.txtcseq);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbhno);
            this.Name = "MainForm";
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtbhno;
        private Label label1;
        private Label label2;
        private TextBox txtcseq;
        private Button btnSearchJson;
        private ComboBox cbConnectType;
        private DataGridView dataGridView1;
    }
}