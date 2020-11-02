namespace WindowsFormsApp1
{
    partial class UnicornDemo
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
            this.TypedText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ServerModeRadio = new System.Windows.Forms.RadioButton();
            this.ClientModeRadio = new System.Windows.Forms.RadioButton();
            this.LogBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.ReceivedText = new System.Windows.Forms.TextBox();
            this.InitializeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.TerminateButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TypedText
            // 
            this.TypedText.Location = new System.Drawing.Point(187, 116);
            this.TypedText.Name = "TypedText";
            this.TypedText.Size = new System.Drawing.Size(249, 22);
            this.TypedText.TabIndex = 0;
            this.TypedText.TextChanged += new System.EventHandler(this.twoWayText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Typed here";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(328, 18);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(108, 35);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Open";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ServerModeRadio);
            this.groupBox1.Controls.Add(this.ClientModeRadio);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 97);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Side";
            // 
            // ServerModeRadio
            // 
            this.ServerModeRadio.AutoSize = true;
            this.ServerModeRadio.Location = new System.Drawing.Point(26, 57);
            this.ServerModeRadio.Name = "ServerModeRadio";
            this.ServerModeRadio.Size = new System.Drawing.Size(71, 21);
            this.ServerModeRadio.TabIndex = 1;
            this.ServerModeRadio.TabStop = true;
            this.ServerModeRadio.Text = "Server";
            this.ServerModeRadio.UseVisualStyleBackColor = true;
            // 
            // ClientModeRadio
            // 
            this.ClientModeRadio.AutoSize = true;
            this.ClientModeRadio.Location = new System.Drawing.Point(26, 28);
            this.ClientModeRadio.Name = "ClientModeRadio";
            this.ClientModeRadio.Size = new System.Drawing.Size(64, 21);
            this.ClientModeRadio.TabIndex = 0;
            this.ClientModeRadio.TabStop = true;
            this.ClientModeRadio.Text = "Client";
            this.ClientModeRadio.UseVisualStyleBackColor = true;
            // 
            // LogBox
            // 
            this.LogBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.LogBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LogBox.HideSelection = false;
            this.LogBox.Location = new System.Drawing.Point(1, 183);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(515, 176);
            this.LogBox.TabIndex = 2;
            this.LogBox.UseCompatibleStateImageBehavior = false;
            this.LogBox.View = System.Windows.Forms.View.Details;
            this.LogBox.SelectedIndexChanged += new System.EventHandler(this.LogBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Typed there";
            // 
            // ReceivedText
            // 
            this.ReceivedText.Enabled = false;
            this.ReceivedText.Location = new System.Drawing.Point(187, 145);
            this.ReceivedText.Name = "ReceivedText";
            this.ReceivedText.Size = new System.Drawing.Size(249, 22);
            this.ReceivedText.TabIndex = 6;
            // 
            // InitializeButton
            // 
            this.InitializeButton.Location = new System.Drawing.Point(187, 18);
            this.InitializeButton.Name = "InitializeButton";
            this.InitializeButton.Size = new System.Drawing.Size(102, 35);
            this.InitializeButton.TabIndex = 7;
            this.InitializeButton.Text = "Initialize";
            this.InitializeButton.UseVisualStyleBackColor = true;
            this.InitializeButton.Click += new System.EventHandler(this.InitializeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(187, 62);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(102, 34);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TerminateButton
            // 
            this.TerminateButton.Location = new System.Drawing.Point(328, 62);
            this.TerminateButton.Name = "TerminateButton";
            this.TerminateButton.Size = new System.Drawing.Size(108, 34);
            this.TerminateButton.TabIndex = 9;
            this.TerminateButton.Text = "Terminate";
            this.TerminateButton.UseVisualStyleBackColor = true;
            this.TerminateButton.Click += new System.EventHandler(this.TerminateButton_Click);
            // 
            // UnicornDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 362);
            this.Controls.Add(this.TerminateButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.InitializeButton);
            this.Controls.Add(this.ReceivedText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TypedText);
            this.MaximumSize = new System.Drawing.Size(537, 409);
            this.MinimumSize = new System.Drawing.Size(537, 409);
            this.Name = "UnicornDemo";
            this.Text = "Unicorn Test";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TypedText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ServerModeRadio;
        private System.Windows.Forms.RadioButton ClientModeRadio;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView LogBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ReceivedText;
        private System.Windows.Forms.Button InitializeButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button TerminateButton;
    }
}

