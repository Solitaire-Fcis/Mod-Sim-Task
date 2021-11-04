namespace MultiQueueSimulation
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serversText = new System.Windows.Forms.TextBox();
            this.methodText = new System.Windows.Forms.TextBox();
            this.criteriaText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.stoppingNum = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.interarrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cumulativeProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Servers";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stopping Criteria";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // serversText
            // 
            this.serversText.Enabled = false;
            this.serversText.Location = new System.Drawing.Point(109, 21);
            this.serversText.Name = "serversText";
            this.serversText.ReadOnly = true;
            this.serversText.Size = new System.Drawing.Size(23, 20);
            this.serversText.TabIndex = 3;
            // 
            // methodText
            // 
            this.methodText.Enabled = false;
            this.methodText.Location = new System.Drawing.Point(109, 47);
            this.methodText.Name = "methodText";
            this.methodText.ReadOnly = true;
            this.methodText.Size = new System.Drawing.Size(23, 20);
            this.methodText.TabIndex = 4;
            // 
            // criteriaText
            // 
            this.criteriaText.Location = new System.Drawing.Point(109, 75);
            this.criteriaText.Name = "criteriaText";
            this.criteriaText.ReadOnly = true;
            this.criteriaText.Size = new System.Drawing.Size(23, 20);
            this.criteriaText.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Selection Method";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Stopping Number";
            // 
            // stoppingNum
            // 
            this.stoppingNum.Location = new System.Drawing.Point(109, 101);
            this.stoppingNum.Name = "stoppingNum";
            this.stoppingNum.ReadOnly = true;
            this.stoppingNum.Size = new System.Drawing.Size(23, 20);
            this.stoppingNum.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.interarrivalTime,
            this.probability,
            this.cumulativeProbability,
            this.range});
            this.dataGridView1.Location = new System.Drawing.Point(147, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 183);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // interarrivalTime
            // 
            this.interarrivalTime.HeaderText = "Interarrival Time";
            this.interarrivalTime.Name = "interarrivalTime";
            // 
            // probability
            // 
            this.probability.HeaderText = "Probability";
            this.probability.Name = "probability";
            // 
            // cumulativeProbability
            // 
            this.cumulativeProbability.HeaderText = "Cumulative Probability";
            this.cumulativeProbability.Name = "cumulativeProbability";
            // 
            // range
            // 
            this.range.HeaderText = "Range";
            this.range.Name = "range";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 54);
            this.button1.TabIndex = 11;
            this.button1.Text = "proceed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 373);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.stoppingNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.criteriaText);
            this.Controls.Add(this.methodText);
            this.Controls.Add(this.serversText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox serversText;
        private System.Windows.Forms.TextBox methodText;
        private System.Windows.Forms.TextBox criteriaText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox stoppingNum;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn interarrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn probability;
        private System.Windows.Forms.DataGridViewTextBoxColumn cumulativeProbability;
        private System.Windows.Forms.DataGridViewTextBoxColumn range;
        private System.Windows.Forms.Button button1;
    }
}

