using System.Drawing;

namespace Ex05.UI
{
    partial class FormGame
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
            this.tableLayoutPanelBoard = new System.Windows.Forms.TableLayoutPanel();
            this.panelBoardHost = new System.Windows.Forms.Panel();
            this.panelScore = new System.Windows.Forms.TableLayoutPanel();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelScore.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelBoard
            // 
            this.tableLayoutPanelBoard.ColumnCount = 1;
            this.tableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBoard.Dock = System.Windows.Forms.DockStyle.None;
            this.tableLayoutPanelBoard.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelBoard.Name = "tableLayoutPanelBoard";
            this.tableLayoutPanelBoard.RowCount = 1;
            this.tableLayoutPanelBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBoard.Size = new System.Drawing.Size(794, 399);
            this.tableLayoutPanelBoard.TabIndex = 0;
            this.tableLayoutPanelBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanelBoard_Paint);
            // 
            // panelBoardHost
            // 
            this.panelBoardHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoardHost.Location = new System.Drawing.Point(3, 3);
            this.panelBoardHost.Margin = System.Windows.Forms.Padding.Empty;
            this.panelBoardHost.Name = "panelBoardHost";
            this.panelBoardHost.Padding = System.Windows.Forms.Padding.Empty;
            this.panelBoardHost.Size = new System.Drawing.Size(794, 399);
            this.panelBoardHost.TabIndex = 2;
            // 
            // panelScore
            // 
            this.panelScore.ColumnCount = 2;
            this.panelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelScore.Controls.Add(this.labelPlayer2Score, 1, 0);
            this.panelScore.Controls.Add(this.labelPlayer1Score, 0, 0);
            this.panelScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScore.Location = new System.Drawing.Point(3, 408);
            this.panelScore.Name = "panelScore";
            this.panelScore.RowCount = 1;
            this.panelScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelScore.Size = new System.Drawing.Size(794, 39);
            this.panelScore.TabIndex = 0;
            this.panelScore.Paint += new System.Windows.Forms.PaintEventHandler(this.panelScore_Paint);
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelPlayer2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer2Score.Location = new System.Drawing.Point(400, 0);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.labelPlayer2Score.Size = new System.Drawing.Size(140, 39);
            this.labelPlayer2Score.TabIndex = 1;
            this.labelPlayer2Score.Text = "Player 2: 0";
            this.labelPlayer2Score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPlayer2Score.Click += new System.EventHandler(this.labelPlayer2Score_Click);
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelPlayer1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1Score.Location = new System.Drawing.Point(254, 0);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.labelPlayer1Score.Size = new System.Drawing.Size(140, 39);
            this.labelPlayer1Score.TabIndex = 0;
            this.labelPlayer1Score.Text = "Player 1: 0";
            this.labelPlayer1Score.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPlayer1Score.Click += new System.EventHandler(this.labelPlayer1Score_Click);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelBoard, 0, 0);
            this.panelBoardHost.Controls.Add(this.tableLayoutPanelBoard);
            this.tableLayoutPanelMain.Controls.Add(this.panelBoardHost, 0, 0);

            this.tableLayoutPanelMain.Controls.Add(this.panelScore, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "FormGame";
            this.Text = "FormGame";
            this.panelScore.ResumeLayout(false);
            this.panelScore.PerformLayout();
            this.panelBoardHost.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBoard;
        private System.Windows.Forms.TableLayoutPanel panelScore;
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Label labelPlayer2Score;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;

        private System.Windows.Forms.Panel panelBoardHost;

    }
}