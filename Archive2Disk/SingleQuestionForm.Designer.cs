namespace Archive2Disk
{
    partial class SingleQuestionForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bt_ok = new System.Windows.Forms.Button();
            this.lb_question = new System.Windows.Forms.Label();
            this.lb_error = new System.Windows.Forms.Label();
            this.tb_answer = new System.Windows.Forms.TextBox();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.bt_ok, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lb_question, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_error, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_answer, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.bt_cancel, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(662, 120);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(584, 93);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 1;
            this.bt_ok.Text = "OK";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.Bt_ok_Click);
            // 
            // lb_question
            // 
            this.lb_question.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lb_question, 3);
            this.lb_question.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_question.Location = new System.Drawing.Point(3, 0);
            this.lb_question.MaximumSize = new System.Drawing.Size(650, 22);
            this.lb_question.Name = "lb_question";
            this.lb_question.Size = new System.Drawing.Size(650, 22);
            this.lb_question.TabIndex = 0;
            this.lb_question.Text = "question";
            this.lb_question.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_error
            // 
            this.lb_error.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lb_error, 3);
            this.lb_error.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_error.ForeColor = System.Drawing.Color.Red;
            this.lb_error.Location = new System.Drawing.Point(3, 30);
            this.lb_error.Name = "lb_error";
            this.lb_error.Size = new System.Drawing.Size(656, 30);
            this.lb_error.TabIndex = 2;
            this.lb_error.Text = "error";
            this.lb_error.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_answer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tb_answer, 4);
            this.tb_answer.Location = new System.Drawing.Point(3, 63);
            this.tb_answer.Name = "tb_answer";
            this.tb_answer.Size = new System.Drawing.Size(656, 22);
            this.tb_answer.TabIndex = 1;
            // 
            // bt_cancel
            // 
            this.bt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_cancel.Location = new System.Drawing.Point(503, 93);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 3;
            this.bt_cancel.Text = "Cancel";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.Bt_cancel_Click);
            // 
            // SingleQuestionForm
            // 
            this.AcceptButton = this.bt_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_cancel;
            this.ClientSize = new System.Drawing.Size(683, 138);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SingleQuestionForm";
            this.Text = "SingleQuestionForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Label lb_question;
        private System.Windows.Forms.Label lb_error;
        private System.Windows.Forms.TextBox tb_answer;
        private System.Windows.Forms.Button bt_cancel;
    }
}