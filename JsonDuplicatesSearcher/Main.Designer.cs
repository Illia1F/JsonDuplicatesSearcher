using System.Windows.Forms;

namespace JsonDuplicatesSearcher
{
    partial class Main
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.jtb = new JsonDuplicatesSearcher.Controls.JsonTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbFiels = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearchDuplicates = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.jtb, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 611);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // jtb
            // 
            this.jtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jtb.Location = new System.Drawing.Point(3, 86);
            this.jtb.Name = "jtb";
            this.jtb.Size = new System.Drawing.Size(578, 475);
            this.jtb.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtbFiels);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 77);
            this.panel1.TabIndex = 1;
            // 
            // rtbFiels
            // 
            this.rtbFiels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFiels.Location = new System.Drawing.Point(9, 23);
            this.rtbFiels.Name = "rtbFiels";
            this.rtbFiels.Size = new System.Drawing.Size(560, 40);
            this.rtbFiels.TabIndex = 1;
            this.rtbFiels.Text = "name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compare by (fields splitted by delimiter \";\")";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSearchDuplicates);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 567);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 41);
            this.panel2.TabIndex = 2;
            // 
            // btnSearchDuplicates
            // 
            this.btnSearchDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchDuplicates.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSearchDuplicates.Location = new System.Drawing.Point(496, 3);
            this.btnSearchDuplicates.Name = "btnSearchDuplicates";
            this.btnSearchDuplicates.Size = new System.Drawing.Size(82, 35);
            this.btnSearchDuplicates.TabIndex = 0;
            this.btnSearchDuplicates.Text = "Search";
            this.btnSearchDuplicates.UseVisualStyleBackColor = true;
            this.btnSearchDuplicates.Click += new System.EventHandler(this.btnSearchDuplicates_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 611);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Json Duplicates Searcher";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Controls.JsonTextBox jtb;
        private Panel panel1;
        private RichTextBox rtbFiels;
        private Label label1;
        private Panel panel2;
        private Button btnSearchDuplicates;
    }
}