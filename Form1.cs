using Ping.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetFiWiSignal();

            //NotifyIconオブジェクトを作成する
            //this.componentsが存在しないならば、省略する
            this.NoticeIcon = new NotifyIcon(this.components);
            //アイコンを設定する
            this.NoticeIcon.Icon = GetPingIconFromBitmap(Resources.Ping_4);
            //NotifyIconをタスクトレイに表示する
            this.NoticeIcon.Visible = true;
            //アイコンの上にマウスポインタを移動した時に表示される文字列
            this.NoticeIcon.Text = "Ping";
            //アイコンを右クリックしたときに表示するコンテキストメニュー
            //ContextMenuStrip1はすでに用意されているものとする
            this.NoticeIcon.ContextMenuStrip = this.MainContext;
        }

        public void GetFiWiSignal()
        {
            Task task = Task.Run(async() => {

                while (true)
                {
                    string result = await GetCmdResult("netsh wlan show interface | findstr %");
                    string ping_per = result.Replace(" ", "").Replace("シグナル", "").Replace(":", "");

                    string ping_per_num = result.Replace(" ", "").Replace("シグナル", "").Replace(":", "").Replace("%", "");
                    int ping = int.Parse(ping_per_num);

                    Bitmap img = GetPingImageFromPer(ping);
                    Icon icon = GetPingIconFromBitmap(img);

                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)(() => {
                            NowPing.Text = ping_per;
                            PingLevel.Image = img;
                            this.Icon = icon;
                            this.NoticeIcon.Text = ping_per;
                        }));
                    }
                    else
                    {
                        NowPing.Text = result;
                        PingLevel.Image = img;
                        this.Icon = icon;
                        this.NoticeIcon.Text = ping_per;
                    }

                    await Task.Delay(500);
                }
            });
        }

        private Bitmap GetPingImageFromPer(int per)
        {
            Bitmap ping_0 = Properties.Resources.Ping_0;
            Bitmap ping_1 = Properties.Resources.Ping_1;
            Bitmap ping_2 = Properties.Resources.Ping_2;
            Bitmap ping_3 = Properties.Resources.Ping_3;
            Bitmap ping_4 = Properties.Resources.Ping_4;

            if (per >= 1 && per <= 24)
            {
                return ping_1;
            }

            if (per >= 25 && per <= 49)
            {
                return ping_2;
            }

            if (per >= 50 && per <= 74)
            {
                return ping_3;
            }

            if (per >= 75 && per <= 100)
            {
                return ping_4;
            }

            return ping_0;
        }

        private Icon GetPingIconFromBitmap(Bitmap bitmap)
        {
            Icon icon = Icon.FromHandle(bitmap.GetHicon());
            return icon;
        }

        public async Task<string> GetCmdResult(string cmdline)
        {
            //Processオブジェクトを作成
            Process p = new Process();

            //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
            p.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            //出力を読み取れるようにする
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;
            //ウィンドウを表示しないようにする
            p.StartInfo.CreateNoWindow = true;
            //コマンドラインを指定（"/c"は実行後閉じるために必要）
            p.StartInfo.Arguments = "/c " + cmdline;

            //起動
            p.Start();

            //出力を読み取る
            string results = await p.StandardOutput.ReadToEndAsync();

            //プロセス終了まで待機する
            //WaitForExitはReadToEndの後である必要がある
            //(親プロセス、子プロセスでブロック防止のため)
            p.WaitForExit();
            p.Close();

            //出力された結果を表示
            return results;
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void ShowItemClick(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void NotifyIconClick(object sender, EventArgs e)
        {
            this.Visible = true;
        }
    }
}
