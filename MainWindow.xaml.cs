using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace seewoTool_WPF{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{
        public MainWindow(){
            InitializeComponent();
            Title = "希沃工具箱 by zhangjing-GitHub-Code@github.com";
        }
        string EN_PNAME = "EasiNote";
        string PPTSvc_PNAME = "PPTService";
        private void lograw(string msg)
        {
            string rawt = LogTxt.Text;
            rawt += msg;
            LogTxt.Text = rawt;
        }
        public void logln(string msg)
        {
            lograw(msg+"\n");
        }
        public void lognow(string text){
            string ctime = DateTime.Now.ToLongTimeString(); //"Placeholder";
            logln("[" + ctime + "] " + text);
        }
        private bool killProcName(string pname,string palias)
        {
            var pces = Process.GetProcessesByName(pname);
            if (pces.Length <= 0)
            {
                lognow("没有打开的"+palias+"!");
                return false;
            }
            foreach (var pcs in pces)
            {
                try
                {
                    lognow("尝试结束PID: " + pcs.Id);
                    pcs.Kill();
                    pcs.WaitForExit();
                }
                catch (InvalidOperationException)
                {
                    lognow("进程已退出");
                }
                catch (Win32Exception ec)
                {
                    lognow("失败，错误信息：" + ec);
                    return false;
                }
            }
            return true;
        }
        private void btnKillEN5_clk(object sender, RoutedEventArgs e){
            lognow("开始结束EN5进程");
            if (killProcName(EN_PNAME, "希沃白板"))
            {
                lognow("成功!");
            }
        }
        private void btnKillPPTSvc_clk(object sender, RoutedEventArgs e){
            lognow("开始结束PPT工具");
            if (killProcName(PPTSvc_PNAME, "PPT工具"))
            {
                lognow("成功!");
            }
        }
    }
}
