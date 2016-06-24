﻿namespace LiveSplit.ComponentAutosplitter
{
    partial class ChangeEventForm
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
            this.lstEventTypes = new System.Windows.Forms.ListBox();
            this.lblAttributes = new System.Windows.Forms.Label();
            this.dgvAttributes = new System.Windows.Forms.DataGridView();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.AttributeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstEventTypes
            // 
            this.lstEventTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEventTypes.FormattingEnabled = true;
            this.lstEventTypes.Location = new System.Drawing.Point(3, 3);
            this.lstEventTypes.Name = "lstEventTypes";
            this.lstEventTypes.Size = new System.Drawing.Size(318, 115);
            this.lstEventTypes.TabIndex = 0;
            this.lstEventTypes.SelectedIndexChanged += new System.EventHandler(this.lstTypes_SelectedIndexChanged);
            // 
            // lblAttributes
            // 
            this.lblAttributes.AutoSize = true;
            this.lblAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAttributes.Location = new System.Drawing.Point(3, 121);
            this.lblAttributes.Name = "lblAttributes";
            this.lblAttributes.Size = new System.Drawing.Size(318, 20);
            this.lblAttributes.TabIndex = 1;
            this.lblAttributes.Text = "Attributes:";
            this.lblAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvAttributes
            // 
            this.dgvAttributes.AllowUserToAddRows = false;
            this.dgvAttributes.AllowUserToDeleteRows = false;
            this.dgvAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributes.ColumnHeadersVisible = false;
            this.dgvAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttributeName,
            this.AttributeValue});
            this.dgvAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttributes.Location = new System.Drawing.Point(3, 144);
            this.dgvAttributes.Name = "dgvAttributes";
            this.dgvAttributes.RowHeadersVisible = false;
            this.dgvAttributes.Size = new System.Drawing.Size(318, 74);
            this.dgvAttributes.TabIndex = 2;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lstEventTypes, 0, 0);
            this.tlpMain.Controls.Add(this.dgvAttributes, 0, 2);
            this.tlpMain.Controls.Add(this.lblAttributes, 0, 1);
            this.tlpMain.Controls.Add(this.btnOk, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.Size = new System.Drawing.Size(324, 252);
            this.tlpMain.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOk.Location = new System.Drawing.Point(246, 225);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // AttributeName
            // 
            this.AttributeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AttributeName.HeaderText = "";
            this.AttributeName.Name = "AttributeName";
            // 
            // AttributeValue
            // 
            this.AttributeValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AttributeValue.HeaderText = "";
            this.AttributeValue.Name = "AttributeValue";
            // 
            // ChangeEventForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 252);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ChangeEventForm";
            this.Text = "ChangeEvent";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstEventTypes;
        private System.Windows.Forms.Label lblAttributes;
        private System.Windows.Forms.DataGridView dgvAttributes;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeValue;
    }
}