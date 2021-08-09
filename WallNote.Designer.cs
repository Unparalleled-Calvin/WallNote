
using System.IO;
namespace WallNote
{
    public static class parameters
    {
        static parameters()
        {
            try
            {
                string[] record = File.ReadAllText("record").Split("\r\n");
                noteColor = record[0];
                filePath = record[1];
                fontSize = record[2];
                notePos = record[3];
                note = record[4];
                for (int i = 5; i < record.Length; i++)
                {
                    note += "\r\n" + record[i];
                }
            }
            catch (IOException e)
            {
                noteColor = "0,0,0";
                fontSize = "5";
                notePos = "0.75,0.5";
                filePath = "";
                note = "";
            }
        }
        public static string cmdPath = @"C:\Windows\System32\cmd.exe";
        public static string noteColor = "0,0,0";
        public static string filePath = "";
        public static string fontSize = "5";
        public static string notePos = "0.75,0.5";
        public static string note = "";
    }


    partial class WallNote
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WallNote));
            this.changeWallpaper = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.note = new System.Windows.Forms.TextBox();
            this.wallpaperPath = new System.Windows.Forms.Label();
            this.noteColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.YPos = new System.Windows.Forms.NumericUpDown();
            this.XPos = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.YPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPos)).BeginInit();
            this.SuspendLayout();
            // 
            // changeWallpaper
            // 
            this.changeWallpaper.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changeWallpaper.AutoSize = true;
            this.changeWallpaper.Location = new System.Drawing.Point(121, 378);
            this.changeWallpaper.Name = "changeWallpaper";
            this.changeWallpaper.Size = new System.Drawing.Size(150, 50);
            this.changeWallpaper.TabIndex = 0;
            this.changeWallpaper.Text = "修改路径";
            this.changeWallpaper.UseVisualStyleBackColor = true;
            this.changeWallpaper.Click += new System.EventHandler(this.changeWallpaper_Click);
            // 
            // confirm
            // 
            this.confirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirm.AutoSize = true;
            this.confirm.Location = new System.Drawing.Point(326, 378);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(150, 50);
            this.confirm.TabIndex = 1;
            this.confirm.Text = "确认";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancel.AutoSize = true;
            this.cancel.Location = new System.Drawing.Point(531, 378);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(150, 50);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "添加备忘：";
            // 
            // note
            // 
            this.note.AcceptsReturn = true;
            this.note.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.note.Location = new System.Drawing.Point(121, 115);
            this.note.Multiline = true;
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(559, 209);
            this.note.TabIndex = 4;
            this.note.Text = parameters.note;
            this.note.ForeColor = getColor(parameters.noteColor);
            // 
            // wallpaperPath
            // 
            this.wallpaperPath.AutoSize = true;
            this.wallpaperPath.Location = new System.Drawing.Point(121, 341);
            this.wallpaperPath.Name = "wallpaperPath";
            this.wallpaperPath.Size = new System.Drawing.Size(100, 24);
            this.wallpaperPath.TabIndex = 5;
            this.wallpaperPath.Text = "壁纸路径：" + parameters.filePath;
            // 
            // noteColor
            // 
            this.noteColor.Location = new System.Drawing.Point(588, 32);
            this.noteColor.Name = "noteColor";
            this.noteColor.Size = new System.Drawing.Size(92, 36);
            this.noteColor.TabIndex = 6;
            this.noteColor.Text = "文本颜色";
            this.noteColor.UseVisualStyleBackColor = true;
            this.noteColor.Click += new System.EventHandler(this.noteColor_Click);
            // 
            // fontSize
            // 
            this.fontSize.FormattingEnabled = true;
            this.fontSize.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            });
            this.fontSize.Location = new System.Drawing.Point(504, 34);
            this.fontSize.Name = "fontSize";
            this.fontSize.Size = new System.Drawing.Size(59, 32);
            this.fontSize.TabIndex = 7;
            this.fontSize.SelectedIndex = int.Parse(parameters.fontSize) - 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "字号：";
            // 
            // YPos
            // 
            this.YPos.DecimalPlaces = 2;
            this.YPos.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.YPos.Location = new System.Drawing.Point(353, 35);
            this.YPos.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.YPos.Name = "YPos";
            this.YPos.Size = new System.Drawing.Size(65, 30);
            this.YPos.TabIndex = 8;
            this.YPos.Value = decimal.Parse(parameters.notePos.Split(",")[1]);
            // 
            // XPos
            // 
            this.XPos.DecimalPlaces = 2;
            this.XPos.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.XPos.Location = new System.Drawing.Point(252, 35);
            this.XPos.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.XPos.Name = "XPos";
            this.XPos.Size = new System.Drawing.Size(66, 30);
            this.XPos.TabIndex = 9;
            this.XPos.Value = decimal.Parse(parameters.notePos.Split(",")[0]);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "x:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "y:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "备忘位置：";
            // 
            // WallNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 472);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.XPos);
            this.Controls.Add(this.YPos);
            this.Controls.Add(this.fontSize);
            this.Controls.Add(this.noteColor);
            this.Controls.Add(this.wallpaperPath);
            this.Controls.Add(this.note);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.changeWallpaper);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WallNote";
            this.Text = "WallNote";
            ((System.ComponentModel.ISupportInitialize)(this.YPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeWallpaper;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox note;
        private System.Windows.Forms.Label wallpaperPath;
        private System.Windows.Forms.Button noteColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox fontSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown YPos;
        private System.Windows.Forms.NumericUpDown XPos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

