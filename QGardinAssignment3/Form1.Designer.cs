namespace QGardinAssignment3
{
    partial class MainForm
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
            this.gBoxControl = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.gBoxControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxControl
            // 
            this.gBoxControl.Controls.Add(this.btnLoad);
            this.gBoxControl.Controls.Add(this.btnSave);
            this.gBoxControl.Controls.Add(this.btnGenerate);
            this.gBoxControl.Controls.Add(this.labelY);
            this.gBoxControl.Controls.Add(this.labelX);
            this.gBoxControl.Controls.Add(this.txtY);
            this.gBoxControl.Controls.Add(this.txtX);
            this.gBoxControl.Location = new System.Drawing.Point(12, 9);
            this.gBoxControl.Name = "gBoxControl";
            this.gBoxControl.Size = new System.Drawing.Size(370, 88);
            this.gBoxControl.TabIndex = 0;
            this.gBoxControl.TabStop = false;
            this.gBoxControl.Text = "Game Control";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(284, 48);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(63, 27);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(284, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(198, 32);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(63, 27);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(17, 58);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(39, 13);
            this.labelY.TabIndex = 1;
            this.labelY.Text = "Tiles Y";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(17, 32);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(39, 13);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "Tiles X";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(81, 55);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 0;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(81, 29);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 501);
            this.Controls.Add(this.gBoxControl);
            this.Name = "MainForm";
            this.Text = "N-Puzzle Game";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gBoxControl.ResumeLayout(false);
            this.gBoxControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxControl;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
    }
}

