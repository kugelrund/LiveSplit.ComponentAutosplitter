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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblUsedEvents = new System.Windows.Forms.Label();
            this.chkPauseGameTime = new System.Windows.Forms.CheckBox();
            this.btnChangeEvent = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvSegmentEvents = new System.Windows.Forms.DataGridView();
            this.Segment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegmentEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsedEvents
            // 
            this.lblUsedEvents.AutoSize = true;
            this.lblUsedEvents.Location = new System.Drawing.Point(10, 7);
            this.lblUsedEvents.Name = "lblUsedEvents";
            this.lblUsedEvents.Size = new System.Drawing.Size(172, 13);
            this.lblUsedEvents.TabIndex = 5;
            this.lblUsedEvents.Text = "Split on these events (in this order):";
            // 
            // chkPauseGameTime
            // 
            this.chkPauseGameTime.AutoSize = true;
            this.chkPauseGameTime.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this, "PauseGameTime", true));
            this.chkPauseGameTime.Location = new System.Drawing.Point(13, 416);
            this.chkPauseGameTime.Name = "chkPauseGameTime";
            this.chkPauseGameTime.Size = new System.Drawing.Size(173, 17);
            this.chkPauseGameTime.TabIndex = 14;
            this.chkPauseGameTime.Text = "Pause game time when loading";
            this.chkPauseGameTime.UseVisualStyleBackColor = true;
            // 
            // btnChangeEvent
            // 
            this.btnChangeEvent.Location = new System.Drawing.Point(374, 23);
            this.btnChangeEvent.Name = "btnChangeEvent";
            this.btnChangeEvent.Size = new System.Drawing.Size(87, 23);
            this.btnChangeEvent.TabIndex = 16;
            this.btnChangeEvent.Text = "Change Event";
            this.btnChangeEvent.UseVisualStyleBackColor = true;
            this.btnChangeEvent.Click += new System.EventHandler(this.btnChangeEvent_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(374, 143);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(87, 23);
            this.btnMoveUp.TabIndex = 17;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(374, 172);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(87, 23);
            this.btnMoveDown.TabIndex = 18;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(374, 387);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 23);
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
            this.dgvSegmentEvents.Location = new System.Drawing.Point(13, 23);
            this.dgvSegmentEvents.Name = "dgvSegmentEvents";
            this.dgvSegmentEvents.RowHeadersVisible = false;
            this.dgvSegmentEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSegmentEvents.Size = new System.Drawing.Size(355, 387);
            this.dgvSegmentEvents.TabIndex = 20;
            this.dgvSegmentEvents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSegmentEvents_CellDoubleClick);
            // 
            // Segment
            // 
            this.Segment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.Segment.DefaultCellStyle = dataGridViewCellStyle1;
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
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSegmentEvents);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnChangeEvent);
            this.Controls.Add(this.chkPauseGameTime);
            this.Controls.Add(this.lblUsedEvents);
            this.Name = "Settings";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(470, 457);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegmentEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsedEvents;
        private System.Windows.Forms.CheckBox chkPauseGameTime;
        private System.Windows.Forms.Button btnChangeEvent;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvSegmentEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn Segment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
    }
}
