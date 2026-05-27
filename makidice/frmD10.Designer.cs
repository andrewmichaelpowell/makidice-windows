namespace makidice
{
    partial class frmD10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmD10));
            lblDice = new Label();
            tbDice = new TextBox();
            lblDifficulty = new Label();
            tbDifficulty = new TextBox();
            btnRoll = new Button();
            lblSuccesses = new Label();
            lblResult = new Label();
            SuspendLayout();
            // 
            // lblDice
            // 
            lblDice.AutoSize = true;
            lblDice.Location = new Point(16, 25);
            lblDice.Margin = new Padding(4, 0, 4, 0);
            lblDice.Name = "lblDice";
            lblDice.Size = new Size(65, 20);
            lblDice.TabIndex = 0;
            lblDice.Text = "Dice";
            // 
            // tbDice
            // 
            tbDice.Location = new Point(87, 20);
            tbDice.Margin = new Padding(4, 5, 4, 5);
            tbDice.Name = "tbDice";
            tbDice.Size = new Size(33, 27);
            tbDice.TabIndex = 1;
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.Location = new Point(16, 66);
            lblDifficulty.Margin = new Padding(4, 0, 4, 0);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(69, 20);
            lblDifficulty.TabIndex = 2;
            lblDifficulty.Text = "Difficulty";
            // 
            // tbDifficulty
            // 
            tbDifficulty.Location = new Point(87, 62);
            tbDifficulty.Margin = new Padding(4, 5, 4, 5);
            tbDifficulty.Name = "tbDifficulty";
            tbDifficulty.Size = new Size(33, 27);
            tbDifficulty.TabIndex = 3;
            // 
            // btnRoll
            // 
            btnRoll.Location = new Point(141, 17);
            btnRoll.Margin = new Padding(4, 5, 4, 5);
            btnRoll.Name = "btnRoll";
            btnRoll.Size = new Size(91, 35);
            btnRoll.TabIndex = 4;
            btnRoll.Text = "Roll";
            btnRoll.UseVisualStyleBackColor = true;
            btnRoll.Click += btnRoll_Click;
            // 
            // lblSuccesses
            // 
            lblSuccesses.AutoSize = true;
            lblSuccesses.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSuccesses.Location = new Point(13, 98);
            lblSuccesses.Margin = new Padding(4, 0, 4, 0);
            lblSuccesses.Name = "lblSuccesses";
            lblSuccesses.Size = new Size(155, 31);
            lblSuccesses.TabIndex = 5;
            lblSuccesses.Text = "Successes:";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResult.Location = new Point(175, 98);
            lblResult.Margin = new Padding(4, 0, 4, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 31);
            lblResult.TabIndex = 6;
            // 
            // frmD10
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(253, 148);
            Controls.Add(lblResult);
            Controls.Add(lblSuccesses);
            Controls.Add(btnRoll);
            Controls.Add(tbDifficulty);
            Controls.Add(lblDifficulty);
            Controls.Add(tbDice);
            Controls.Add(lblDice);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmD10";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "D10 System";
            Load += frmD10_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDice;
        private System.Windows.Forms.TextBox tbDice;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.TextBox tbDifficulty;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Label lblSuccesses;
        private System.Windows.Forms.Label lblResult;
    }
}
