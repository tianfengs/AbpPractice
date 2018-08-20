using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeiboWindow
{
    public partial class Form1 : Form//这是Form1代码后置类,是个分部类，UI布局代码在另一个分离的类中
    {
        private WeiboService _weiboService;
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _weiboService = new WeiboService();//当窗体加载事件触发时，实例化一个服务类
        }

        #region 没有使用AOP版本
        //private void btnUpdate_Click(object sender, EventArgs e)//更新按钮的单击事件
        //{
        //    var thread = new Thread(GetMsg);//初始化一个新的线程来处理GetMsg方法
        //    thread.Start();//开启线程
        //}

        //void GetMsg()
        //{
        //    var msg = _weiboService.GetMessage();
        //    if (InvokeRequired)

        //        Invoke(new Action(() => UpdateListboxItems(msg)));
        //    else
        //        UpdateListboxItems(msg);
        //}

        //void UpdateListboxItems(string msg)
        //{
        //    listBox.Items.Add(msg);
        //}

        #endregion

        #region 使用了AOP版本
        private void btnUpdate_Click(object sender, EventArgs e)//更新按钮的单击事件
        {
            GetMsg();
        }

        [WorkerThread]
        void GetMsg()
        {
            var msg = _weiboService.GetMessage();
            UpdateListboxItems(msg);
        }

        [UIThread]
        void UpdateListboxItems(string msg)
        {
            listBox.Items.Add(msg);
        }

        #endregion
    }
}
