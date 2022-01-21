using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Replication
{
    public partial class Form1 : Form
    {
        string Subscriber_login = ConfigurationManager.AppSettings["Subscriber_login"];
        string Subscriber_password = ConfigurationManager.AppSettings["Subscriber_password"];
        string Subscriber_db = ConfigurationManager.AppSettings["Subscriber_db"];
        string Subscriber = ConfigurationManager.AppSettings["Subscriber"]; 
        string Subscriber_job = ConfigurationManager.AppSettings["Subscriber_job"];
        string Tb,str,Tips;
        DataTable table;
        Thread thread1, thread2;
        List<string> ischeck = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Tips = "等待发布";
                string sql = @"SELECT A.* FROM  SYSOBJECTS A JOIN SYSOBJECTS B ON A.ID=B.PARENT_OBJ AND A.XTYPE='U' AND B.XTYPE='PK' WHERE A.category<>2 ORDER BY A.name";
                table = DbHelperP.ExecuteDataTable(sql);
                Dgv_Table.DataSource = table;
                thread1 = new Thread(new ThreadStart(ChangeLbTips));
                thread1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form1_Load出错！请查看日志");
                LogHelper.LogInfo(DateTime.Now.ToString() + ex.ToString());
                System.Environment.Exit(0);
            }
        }

        private void ChangeLbTips()
        {
            while (true)
            {
                threadlab();
                Thread.Sleep(100);
            }
        }

        private delegate void lable();
        private void threadlab()
        {
            if (LbTips.InvokeRequired == false)
            {
                LbTips.Text = Tips;
            }
            else
            {
                lable l = new lable(threadlab);
                LbTips.Invoke(l, null);
            }
        }

        private void CheckTable()
        {
            try
            {
                foreach (DataGridViewRow row in Dgv_Table.Rows)
                {
                    if (row.Cells["selected"].Value != null)
                    {
                        if (row.Cells["selected"].Value.ToString() == "True")
                            ischeck.Add(row.Cells[1].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CheckTable出错！请查看日志");
                LogHelper.LogInfo(DateTime.Now.ToString() + ex.ToString());
                System.Environment.Exit(0);
            }
        }

        private void Btn_Publication_Click(object sender, EventArgs e)
        {
            try
            {
                Tb = TbName.Text.Trim();
                if (string.IsNullOrEmpty(Tb))
                {
                    MessageBox.Show("请输入发布名称！");
                    return;
                }
                if (Tips != "等待发布")
                {
                    thread2.Abort();
                }
                CheckTable();
                string msg = RadiobuttonCheck();
                switch (msg)
                {
                    case "全部同步":
                        thread2 = new Thread(new ThreadStart(AllPublication));
                        thread2.Start();
                        //AllPublication();
                        break;
                    case "选中同步":
                        thread2 = new Thread(new ThreadStart(CheckPublication));
                        thread2.Start();
                        //CheckPublication();
                        break;
                    case "选中不同步":
                        thread2 = new Thread(new ThreadStart(UnCheckPublication));
                        thread2.Start();
                        //UnCheckPublication();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Btn_Publication_Click出错！请查看日志");
                LogHelper.LogInfo(DateTime.Now.ToString() + ex.ToString());
                System.Environment.Exit(0);
            }
        }

        private void Publication()
        {
            //Tips = "禁用订阅数据库触发器";
            //DbHelperP.ExecuteSqlS("EXEC sp_msforeachtable 'alter table ? disable trigger all'");
            //LogHelper.LogInfo(DateTime.Now.ToString() + " 已禁用订阅数据库的触发器");
            //Tips = "禁用订阅数据库update作业";
            //DbHelperP.ExecuteSqlS("EXEC msdb.dbo.sp_update_job @job_name = '" + Subscriber_job + "', @enabled = 0");
            //LogHelper.LogInfo(DateTime.Now.ToString() + " 已禁用订阅数据库的" + Subscriber_job + "作业");
            Tips = "正在发布.";
            DbHelperP.ExecuteSql(string.Format(@"sp_replicationdboption @dbname='" + Subscriber_db + "',@optname='publish',@value='true'"));
            Tips = Tips.Insert(Tips.Length, ".");
            str = string.Format(@"sp_addlogreader_agent @job_login = null, @job_password = null, @publisher_security_mode = 0, @publisher_login = '" + Subscriber_login + "', @publisher_password = '" + Subscriber_password + "'");
            DbHelperP.ExecuteSql(str);
            Tips = Tips.Insert(Tips.Length, ".");
            str = string.Format(@"sp_addpublication @publication = '" + Tb + "', @sync_method = N'concurrent', @retention = 0, @allow_push = N'true', @allow_pull = N'true', @allow_anonymous = N'true', @enabled_for_internet = N'false', @snapshot_in_defaultfolder = N'true', @compress_snapshot = N'false', @ftp_port = 21, @ftp_login = N'anonymous', @allow_subscription_copy = N'false', @add_to_active_directory = N'false', @repl_freq = N'continuous', @status = N'active', @independent_agent = N'true', @immediate_sync = N'true', @allow_sync_tran = N'false', @autogen_sync_procs = N'false', @allow_queued_tran = N'false', @allow_dts = N'false', @replicate_ddl = 1, @allow_initialize_from_backup = N'false', @enabled_for_p2p = N'false', @enabled_for_het_sub = N'false'");
            DbHelperP.ExecuteSql(str);
            Tips = Tips.Insert(Tips.Length, ".");
            str = string.Format(@"sp_addpublication_snapshot @publication='" + Tb + "',@frequency_type = 1, @frequency_interval = 0, @frequency_relative_interval = 0, @frequency_recurrence_factor = 0, @frequency_subday = 0, @frequency_subday_interval = 0, @active_start_time_of_day = 0, @active_end_time_of_day = 235959, @active_start_date = 0, @active_end_date = 0, @job_login = null, @job_password = null, @publisher_security_mode = 0, @publisher_login = N'" + Subscriber_login + "', @publisher_password = N'" + Subscriber_password + "'");
            DbHelperP.ExecuteSql(str);
        }

        private void Subscription()
        {
            Tips = "正在订阅.";
            str = string.Format(@"sp_addsubscription @publication='" + Tb + "',@subscriber='" + Subscriber + "',@subscription_type='push'");
            DbHelperP.ExecuteSql(str);
            Tips = Tips.Insert(Tips.Length, ".");
            str = string.Format(@"sp_addpushsubscription_agent @publication='" + Tb + "',@subscriber='" + Subscriber + "',@subscriber_db='" + Subscriber_db + "',@job_login=NULL,@job_password=NULL,@subscriber_security_mode='0',@subscriber_login='" + Subscriber_login + "',@subscriber_password='" + Subscriber_password + "'");
            DbHelperP.ExecuteSql(str);
            Tips = Tips.Insert(Tips.Length, ".");
            str = string.Format(@"sys.sp_reinitsubscription @publication = '" + Tb + "',@subscriber = '" + Subscriber + "',@destination_db = '" + Subscriber_db + "',@article = N'all'");
            DbHelperP.ExecuteSql(str);
            Tips = Tips.Insert(Tips.Length, ".");
            str = string.Format(@"sys.sp_startpublication_snapshot @publication='" + Tb + "'");
            DbHelperP.ExecuteSql(str);
            Tips = "发布订阅完成！";
            MessageBox.Show("请等待发布服务器初始化快照之后查看发布订阅状态是否正常！");
        }

        private void AllPublication()
        {
            Publication();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Tips = "正在发布" + table.Rows[i]["name"].ToString() + " " + i + "/" + table.Rows.Count;
                str = string.Format(@"sp_addarticle @publication ='" + Tb + "',@article='" + table.Rows[i]["name"].ToString() + "',@source_owner='dbo',@source_object='" + table.Rows[i]["name"].ToString() + "'");
                DbHelperP.ExecuteSql(str);
            }
            Subscription();
        }

        private void CheckPublication()
        {
            Publication();
            for (int i = 0; i < ischeck.Count; i++)
            {
                str = string.Format(@"sp_addarticle @publication ='" + Tb + "',@article='" + ischeck[i].ToString() + "',@source_owner='dbo',@source_object='" + ischeck[i].ToString() + "'");
                DbHelperP.ExecuteSql(str);
            }
            Subscription();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread1.Abort();
            if (Tips != "等待发布")
            {
                thread2.Abort();
            }
        }

        private void UnCheckPublication()
        {
            Publication();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (!ischeck.Contains(table.Rows[i]["name"].ToString()))
                {
                    str = string.Format(@"sp_addarticle @publication ='" + Tb + "',@article='" + table.Rows[i]["name"].ToString() + "',@source_owner='dbo',@source_object='" + table.Rows[i]["name"].ToString() + "'");
                    DbHelperP.ExecuteSql(str);
                }
            }
            Subscription();
        }

        private string RadiobuttonCheck()
        {
            string msg = "";
            if (radioButton1.Checked)
            {
                msg = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                msg = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                msg = radioButton3.Text;
            }
            return msg;
        }
    }
}
