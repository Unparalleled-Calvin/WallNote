using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WallNote
{
    public partial class WallNote : Form
    {
        public WallNote()
        {
            InitializeComponent();
        }

        private void changeWallpaper_Click(object sender, EventArgs e)
        {
            OpenFileDialog GetData = new OpenFileDialog();     //以打开的方式
            GetData.Multiselect = false;                       //该值确定是否可以选择多个文件
            GetData.Title = "请选择文件";                       //标题
            int last = parameters.filePath.LastIndexOf(@"\");
            GetData.InitialDirectory = last != -1 ? parameters.filePath.Substring(0, last + 1) : @"C:\";                 //默认路径
            GetData.Filter = "图像文件(*.png;*.jpg;*.jpeg;*.bmp;)|*.png;*.jpg;*.jpeg;*.bmp;";
            if (GetData.ShowDialog() == DialogResult.OK)
            {     //如果选择了文件
                string script = GetData.FileName;                    //script赋值为所选文件的路径
                wallpaperPath.Text = "壁纸路径：" + script;
                parameters.filePath = script;
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            string cmd = "util.exe" + " -p " + parameters.filePath.Replace(" ", "/") + " -n " + note.Text.Replace("\r\n", "\\n").Replace(" ", "/").Replace("-", "\\-") + " -c " + parameters.noteColor + " -l " + this.XPos.Value + "," + this.YPos.Value + " -s " + fontSize.Text;
            cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
            using (Process p = new Process())
            {
                p.StartInfo.FileName = parameters.cmdPath;
                p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;          //不显示程序窗口
                p.Start();//启动程序

                //向cmd窗口写入命令
                p.StandardInput.WriteLine(cmd);
                p.StandardInput.AutoFlush = true;

                //获取cmd窗口的输出信息
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();//等待程序执行完退出进程
                p.Close();
            }
            File.WriteAllText("record", parameters.noteColor + "\r\n" + parameters.filePath + "\r\n" + this.fontSize.Text + "\r\n" + this.XPos.Value + "," + this.YPos.Value + "\r\n" + this.note.Text);
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void noteColor_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            //如果选中颜色，单击“确定”按钮则改变文本框的文本颜色
            if (dr == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                note.ForeColor = color;
                parameters.noteColor = " " + color.R + "," + color.G + "," + color.B;
            }
        }

        private Color getColor(string rgb)
        {
            string[] RGB = rgb.Split(",");
            return Color.FromArgb(int.Parse(RGB[0]), int.Parse(RGB[1]), int.Parse(RGB[2]));
        }

    }
}
