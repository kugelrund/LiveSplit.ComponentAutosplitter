namespace LiveSplit.ComponentAutosplitter
{
    partial class Settings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblUsedEvents = new System.Windows.Forms.Label();
            this.btnChangeEvent = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvSegmentEvents = new System.Windows.Forms.DataGridView();
            this.Segment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpEventList = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEventListControls = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegmentEvents)).BeginInit();
            this.tlpEventList.SuspendLayout();
            this.tlpEventListControls.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsedEvents
            // 
            this.lblUsedEvents.AutoSize = true;
            this.lblUsedEvents.Location = new System.Drawing.Point(4, 0);
            this.lblUsedEvents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsedEvents.Name = "lblUsedEvents";
            this.lblUsedEvents.Size = new System.Drawing.Size(233, 17);
            this.lblUsedEvents.TabIndex = 5;
            this.lblUsedEvents.Text = "Split on these events (in this order):";
            // 
            // btnChangeEvent
            // 
            this.btnChangeEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeEvent.Location = new System.Drawing.Point(0, 0);
            this.btnChangeEvent.Margin = new System.Windows.Forms.Padding(0);
            this.btnChangeEvent.Name = "btnChangeEvent";
            this.btnChangeEvent.Size = new System.Drawing.Size(155, 30);
            this.btnChangeEvent.TabIndex = 16;
            this.btnChangeEvent.Text = "Change Event";
            this.btnChangeEvent.UseVisualStyleBackColor = true;
            this.btnChangeEvent.Click += new System.EventHandler(this.btnChangeEvent_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveUp.Location = new System.Drawing.Point(0, 188);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(155, 30);
            this.btnMoveUp.TabIndex = 17;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveDown.Location = new System.Drawing.Point(0, 223);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(155, 30);
            this.btnMoveDown.TabIndex = 18;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(0, 411);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(155, 31);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvSegmentEvents
            // 
            this.dgvSegmentEvents.AllowUserToAddRows = false;
            this.dgvSegmentEvents.AllowUserToDeleteRows = false;
            this.dgvSegmentEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSegmentEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Segment,
            this.Event});
            this.dgvSegmentEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSegmentEvents.Location = new System.Drawing.Point(4, 24);
            this.dgvSegmentEvents.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSegmentEvents.Name = "dgvSegmentEvents";
            this.dgvSegmentEvents.RowHeadersVisible = false;
            this.dgvSegmentEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSegmentEvents.Size = new System.Drawing.Size(473, 440);
            this.dgvSegmentEvents.TabIndex = 20;
            this.dgvSegmentEvents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSegmentEvents_CellDoubleClick);
            // 
            // Segment
            // 
            this.Segment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Segment.DefaultCellStyle = dataGridViewCellStyle3;
            this.Segment.FillWeight = 40F;
            this.Segment.HeaderText = "Start this segment";
            this.Segment.Name = "Segment";
            this.Segment.ReadOnly = true;
            // 
            // Event
            // 
            this.Event.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Event.FillWeight = 60F;
            this.Event.HeaderText = "on this event";
            this.Event.Name = "Event";
            this.Event.ReadOnly = true;
            // 
            // tlpEventList
            // 
            this.tlpEventList.ColumnCount = 2;
            this.tlpEventList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpEventList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEventList.Controls.Add(this.lblUsedEvents, 0, 0);
            this.tlpEventList.Controls.Add(this.dgvSegmentEvents, 0, 1);
            this.tlpEventList.Controls.Add(this.tlpEventListControls, 1, 1);
            this.tlpEventList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEventList.Location = new System.Drawing.Point(0, 0);
            this.tlpEventList.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEventList.Name = "tlpEventList";
            this.tlpEventList.RowCount = 2;
            this.tlpEventList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEventList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEventList.Size = new System.Drawing.Size(642, 468);
            this.tlpEventList.TabIndex = 21;
            // 
            // tlpEventListControls
            // 
            this.tlpEventListControls.ColumnCount = 1;
            this.tlpEventListControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEventListControls.Controls.Add(this.btnChangeEvent, 0, 0);
            this.tlpEventListControls.Controls.Add(this.btnClear, 0, 6);
            this.tlpEventListControls.Controls.Add(this.btnMoveUp, 0, 2);
            this.tlpEventListControls.Controls.Add(this.btnMoveDown, 0, 4);
            this.tlpEventListControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEventListControls.Location = new System.Drawing.Point(484, 23);
            this.tlpEventListControls.Name = "tlpEventListControls";
            this.tlpEventListControls.RowCount = 7;
            this.tlpEventListControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpEventListControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEventListControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpEventListControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpEventListControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpEventListControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEventListControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpEventListControls.Size = new System.Drawing.Size(155, 442);
            this.tlpEventListControls.TabIndex = 21;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpEventList, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(642, 468);
            this.tlpMain.TabIndex = 22;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(642, 468);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegmentEvents)).EndInit();
            this.tlpEventList.ResumeLayout(false);
            this.tlpEventList.PerformLayout();
            this.tlpEventListControls.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUsedEvents;
        private System.Windows.Forms.Button btnChangeEvent;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvSegmentEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn Segment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.TableLayoutPanel tlpEventList;
        private System.Windows.Forms.TableLayoutPanel tlpEventListControls;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
    }
}
