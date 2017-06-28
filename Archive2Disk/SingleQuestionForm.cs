using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archive2Disk
{
    public partial class SingleQuestionForm : Form
    {
        public SingleQuestionForm()
        {
            InitializeComponent();
            this.lb_error.Text = "";
        }

        public void SetOkButtonText(string txt)
        {
            if (txt == null || txt.Trim() == "") this.bt_ok.Text = "Ok";
            this.bt_ok.Text = txt;
        }

        public void SetCancelButtonText(string txt)
        {
            if (txt == null || txt.Trim() == "") this.bt_cancel.Text = "Cancel";
            this.bt_cancel.Text = txt;
        }

        public void SetQuestion(string txt)
        {
            if (txt == null || txt.Trim() == "") this.lb_question.Text = "?";
            this.lb_question.Text = txt;
        }

        public void SetError(string txt)
        {
            if (txt == null || txt.Trim() == "") this.lb_error.Text = "";
            this.lb_error.Text = txt;
        }

        public void PresetAnswer(string txt)
        {
            if (txt == null || txt.Trim() == "") this.tb_answer.Text = "";
            this.tb_answer.Text = txt;
        }

        public string Ask()
        {
            this.ShowDialog();
            return this.tb_answer.Text;
        }

        public static string Ask(string question, string proposed_answer, string txtOk, string txtCancel, string error)
        {
            SingleQuestionForm sqf = new SingleQuestionForm();
            sqf.SetQuestion(question);
            sqf.PresetAnswer(proposed_answer);
            sqf.SetOkButtonText(txtOk);
            sqf.SetCancelButtonText(txtCancel);
            sqf.SetError(error);
            return sqf.Ask();
        }

        private void Bt_ok_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Bt_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
