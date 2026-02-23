namespace Ex05.UI
{
    partial class FormGameSettings
    {
        private System.ComponentModel.IContainer components = null;
        
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
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.tbPlayer1Name = new System.Windows.Forms.TextBox();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.tbPlayer2Name = new System.Windows.Forms.TextBox();
            this.cbPlayer2IsComputer = new System.Windows.Forms.CheckBox();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.nudCols = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.labelRows = new System.Windows.Forms.Label();
            this.labelCols = new System.Windows.Forms.Label();
            this.labelPlayers = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(71, 46);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(69, 20);
            this.labelPlayer1.TabIndex = 0;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // tbPlayer1Name
            // 
            this.tbPlayer1Name.Location = new System.Drawing.Point(168, 42);
            this.tbPlayer1Name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPlayer1Name.Name = "tbPlayer1Name";
            this.tbPlayer1Name.Size = new System.Drawing.Size(112, 26);
            this.tbPlayer1Name.TabIndex = 1;
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Location = new System.Drawing.Point(71, 84);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(69, 20);
            this.labelPlayer2.TabIndex = 2;
            this.labelPlayer2.Text = "Player 2:";
            // 
            // tbPlayer2Name
            // 
            this.tbPlayer2Name.Location = new System.Drawing.Point(168, 80);
            this.tbPlayer2Name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPlayer2Name.Name = "tbPlayer2Name";
            this.tbPlayer2Name.Size = new System.Drawing.Size(112, 26);
            this.tbPlayer2Name.TabIndex = 3;
            // 
            // cbPlayer2IsComputer
            // 
            this.cbPlayer2IsComputer.AutoSize = true;
            this.cbPlayer2IsComputer.Location = new System.Drawing.Point(37, 85);
            this.cbPlayer2IsComputer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbPlayer2IsComputer.Name = "cbPlayer2IsComputer";
            this.cbPlayer2IsComputer.Size = new System.Drawing.Size(22, 21);
            this.cbPlayer2IsComputer.TabIndex = 4;
            this.cbPlayer2IsComputer.UseVisualStyleBackColor = true;
            this.cbPlayer2IsComputer.CheckedChanged += new System.EventHandler(this.cbPlayer2IsComputer_CheckedChanged);
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(34, 132);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.labelBoardSize.TabIndex = 5;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // nudRows
            // 
            this.nudRows.Location = new System.Drawing.Point(125, 171);
            this.nudRows.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(50, 26);
            this.nudRows.TabIndex = 6;
            this.nudRows.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // nudCols
            // 
            this.nudCols.Location = new System.Drawing.Point(290, 171);
            this.nudCols.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudCols.Name = "nudCols";
            this.nudCols.Size = new System.Drawing.Size(50, 26);
            this.nudCols.TabIndex = 7;
            this.nudCols.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(87, 238);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(263, 29);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(57, 174);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(53, 20);
            this.labelRows.TabIndex = 9;
            this.labelRows.Text = "Rows:";
            // 
            // labelCols
            // 
            this.labelCols.AutoSize = true;
            this.labelCols.Location = new System.Drawing.Point(225, 174);
            this.labelCols.Name = "labelCols";
            this.labelCols.Size = new System.Drawing.Size(44, 20);
            this.labelCols.TabIndex = 10;
            this.labelCols.Text = "Cols:";
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(34, 11);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(60, 20);
            this.labelPlayers.TabIndex = 11;
            this.labelPlayers.Text = "Players";
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 299);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.labelCols);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.nudCols);
            this.Controls.Add(this.nudRows);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.cbPlayer2IsComputer);
            this.Controls.Add(this.tbPlayer2Name);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.tbPlayer1Name);
            this.Controls.Add(this.labelPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.FormGameSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.TextBox tbPlayer1Name;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.TextBox tbPlayer2Name;
        private System.Windows.Forms.CheckBox cbPlayer2IsComputer;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.NumericUpDown nudCols;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.Label labelCols;
        private System.Windows.Forms.Label labelPlayers;
    }
}