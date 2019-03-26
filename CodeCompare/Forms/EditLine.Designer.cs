namespace CodeCompare.Forms
{
    partial class EditLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditLine));
            this.txtLine1 = new System.Windows.Forms.RichTextBox();
            this.txtLine2 = new System.Windows.Forms.RichTextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSave = new VistaButtonTest.VistaButton();
            this.btnCancel = new VistaButtonTest.VistaButton();
            this.lblLineDifference = new System.Windows.Forms.Label();
            this.btnChangeView = new VistaButtonTest.VistaButton();
            this.SuspendLayout();
            // 
            // txtLine1
            // 
            this.txtLine1.AcceptsTab = true;
            this.txtLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLine1.BackColor = System.Drawing.Color.White;
            this.txtLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLine1.DetectUrls = false;
            this.txtLine1.Location = new System.Drawing.Point(2, 0);
            this.txtLine1.Name = "txtLine1";
            this.txtLine1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtLine1.Size = new System.Drawing.Size(280, 246);
            this.txtLine1.TabIndex = 5;
            this.txtLine1.Text = "";
            this.txtLine1.TextChanged += new System.EventHandler(this.txtLine1_TextChanged);
            // 
            // txtLine2
            // 
            this.txtLine2.AcceptsTab = true;
            this.txtLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLine2.BackColor = System.Drawing.Color.White;
            this.txtLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLine2.DetectUrls = false;
            this.txtLine2.Location = new System.Drawing.Point(310, 1);
            this.txtLine2.Name = "txtLine2";
            this.txtLine2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtLine2.Size = new System.Drawing.Size(280, 245);
            this.txtLine2.TabIndex = 6;
            this.txtLine2.Text = "";
            this.txtLine2.TextChanged += new System.EventHandler(this.txtLine2_TextChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Image = global::CodeCompare.Properties.Resources.RightArrowSingleSmall;
            this.btnCopy.Location = new System.Drawing.Point(283, 112);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(26, 23);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.ButtonColor = System.Drawing.Color.DarkGray;
            this.btnSave.ButtonText = "Save";
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.DimGray;
            this.btnSave.Location = new System.Drawing.Point(384, 252);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BaseColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.ButtonColor = System.Drawing.Color.DarkGray;
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.GlowColor = System.Drawing.Color.DimGray;
            this.btnCancel.Location = new System.Drawing.Point(490, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblLineDifference
            // 
            this.lblLineDifference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLineDifference.AutoSize = true;
            this.lblLineDifference.BackColor = System.Drawing.Color.Transparent;
            this.lblLineDifference.Location = new System.Drawing.Point(-1, 262);
            this.lblLineDifference.Name = "lblLineDifference";
            this.lblLineDifference.Size = new System.Drawing.Size(82, 13);
            this.lblLineDifference.TabIndex = 4;
            this.lblLineDifference.Text = "Lines are equal:";
            // 
            // btnChangeView
            // 
            this.btnChangeView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeView.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeView.BaseColor = System.Drawing.Color.WhiteSmoke;
            this.btnChangeView.ButtonColor = System.Drawing.Color.DarkGray;
            this.btnChangeView.ButtonText = "Change View";
            this.btnChangeView.ForeColor = System.Drawing.Color.Black;
            this.btnChangeView.GlowColor = System.Drawing.Color.DimGray;
            this.btnChangeView.Location = new System.Drawing.Point(267, 252);
            this.btnChangeView.Name = "btnChangeView";
            this.btnChangeView.Size = new System.Drawing.Size(108, 29);
            this.btnChangeView.TabIndex = 11;
            this.btnChangeView.Click += new System.EventHandler(this.btnChangeView_Click);
            // 
            // EditLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.BackgroundImage = global::CodeCompare.Properties.Resources.GrayBackGroundArrow1;
            this.ClientSize = new System.Drawing.Size(592, 284);
            this.Controls.Add(this.btnChangeView);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtLine2);
            this.Controls.Add(this.txtLine1);
            this.Controls.Add(this.lblLineDifference);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditLine";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Line";
            this.Load += new System.EventHandler(this.EditLine_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditLine_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.EditLine_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtLine1;
        private System.Windows.Forms.RichTextBox txtLine2;
        private System.Windows.Forms.Button btnCopy;
        private VistaButtonTest.VistaButton btnSave;
        private VistaButtonTest.VistaButton btnCancel;
        private System.Windows.Forms.Label lblLineDifference;
        private VistaButtonTest.VistaButton btnChangeView;
    }
}