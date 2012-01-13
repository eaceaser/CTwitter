namespace PCTwitter {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Data;
  using System.Text;
  using System.Windows.Forms;

  public class VerificationInput : Form {
    public VerificationInput() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {

    }

    private void label1_Click(object sender, EventArgs e) {

    }

    private void button2_Click(object sender, EventArgs e) {

    }

    private void button1_Click(object sender, EventArgs e) {

    }

    private void code_TextChanged(object sender, EventArgs e) {

    }

    public string GetCode() { return code.Text; }

    private TableLayoutPanel tableLayoutPanel1;

        /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.code = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.ok = new System.Windows.Forms.Button();
      this.cancel = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // code
      // 
      this.code.Name = "code";
      this.code.TabIndex = 0;
      this.code.TextChanged += new System.EventHandler(this.code_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Name = "label1";
      this.label1.TabIndex = 1;
      this.label1.Text = "Verification Code";
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // ok
      // 
      this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ok.Name = "ok";
      this.ok.TabIndex = 2;
      this.ok.Text = "OK";
      this.ok.UseVisualStyleBackColor = true;
      this.ok.Click += new System.EventHandler(this.button1_Click);
      // 
      // cancel
      // 
      this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancel.Name = "cancel";
      this.cancel.TabIndex = 3;
      this.cancel.Text = "Cancel";
      this.cancel.UseVisualStyleBackColor = true;
      this.cancel.Click += new System.EventHandler(this.button2_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.code, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.ok, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.cancel, 1, 1);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.TabIndex = 4;
      // 
      // VerificationInput
      // 
      this.AcceptButton = this.ok;
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancel;
      this.Controls.Add(this.tableLayoutPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "VerificationInput";
      this.Text = "Input Verification Code";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.Form1_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox code;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button ok;
    private System.Windows.Forms.Button cancel;
  }
}