﻿namespace Common.Controls.NameGeneration
{
	partial class LetterCounterEditor
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
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDownSteps = new System.Windows.Forms.NumericUpDown();
			this.textBoxStartLetter = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSteps)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Start Letter:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Steps:";
			// 
			// numericUpDownSteps
			// 
			this.numericUpDownSteps.Location = new System.Drawing.Point(75, 31);
			this.numericUpDownSteps.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownSteps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownSteps.Name = "numericUpDownSteps";
			this.numericUpDownSteps.Size = new System.Drawing.Size(44, 20);
			this.numericUpDownSteps.TabIndex = 2;
			this.numericUpDownSteps.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownSteps.ValueChanged += new System.EventHandler(this.numericUpDownSteps_ValueChanged);
			// 
			// textBoxStartLetter
			// 
			this.textBoxStartLetter.Location = new System.Drawing.Point(75, 5);
			this.textBoxStartLetter.Name = "textBoxStartLetter";
			this.textBoxStartLetter.Size = new System.Drawing.Size(44, 20);
			this.textBoxStartLetter.TabIndex = 7;
			this.textBoxStartLetter.TextChanged += new System.EventHandler(this.textBoxStartLetter_TextChanged);
			// 
			// LetterCounterEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textBoxStartLetter);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDownSteps);
			this.Controls.Add(this.label1);
			this.Name = "LetterCounterEditor";
			this.Size = new System.Drawing.Size(133, 63);
			this.Load += new System.EventHandler(this.NumericCounterEditor_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSteps)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDownSteps;
		private System.Windows.Forms.TextBox textBoxStartLetter;
	}
}
