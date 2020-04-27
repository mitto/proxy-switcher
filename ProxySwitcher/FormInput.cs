using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProxySwitcher
{
	public partial class FormInput : Form
	{
		private string caption = " ";
		private string title = " ";

		public FormInput(string caption)
		{
			InitializeComponent();

			this.caption = caption;
		}

		public FormInput(string caption, string title)
		{
			InitializeComponent();

			this.caption = caption;
			this.title = title;
		}

		public FormInput(string caption, string title, string body)
		{
			InitializeComponent();

			this.caption = caption;
			this.title = title;

			textBox1.Text = body;
		}

		public string InputText
		{
			get
			{
				return textBox1.Text;
			}
			set
			{
				textBox1.Text = value;
			}
		}

		private void FormInput_Load(object sender, EventArgs e)
		{
			this.Text = title;
			label1.Text = caption;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

	}
}
