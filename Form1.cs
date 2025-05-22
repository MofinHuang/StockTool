using StockTool.Services;

namespace StockTool
{
    public partial class Form1 : Form
    {
        private Thread _thread;
        private bool _threadIsRun = false;
        private bool _isTask = false;
        private bool _isShow = false;
        private void ShowText(string msg)
        {
            if (listBox1.InvokeRequired)
            {
                // Use Invoke to execute the delegate on the UI thread
                listBox1.Invoke((MethodInvoker)delegate
                {
                    if (listBox1.Items.Count > 100) { listBox1.Items.Clear(); }
                    listBox1.Items.Insert(0, string.Format("{0} {1}", DateTime.Now.ToString("HH:mm:ss"), msg));
                });
            }
            else
            {
                if (listBox1.Items.Count > 100) { listBox1.Items.Clear(); }
                listBox1.Items.Insert(0, string.Format("{0} {1}", DateTime.Now.ToString("HH:mm:ss"), msg));
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            contextMenuStrip1.Items.Add("Task start", null, this.btnStart_Click);
            contextMenuStrip1.Items.Add("Task stop", null, this.btnStart_Click);
            contextMenuStrip1.Items.Add("---");
            contextMenuStrip1.Items.Add("Show", null, this.btnShow_Click);
            contextMenuStrip1.Items.Add("Hide", null, this.btnShow_Click);
            contextMenuStrip1.Items.Add("---");
            contextMenuStrip1.Items.Add("Exit", null, this.btnClose_Click);
            _isShow = true;

            btnStart.Text = "Stop";
            btnStart.BackColor = Color.Pink;
            _thread = new Thread(DoWork);
            _thread.Start();
            _threadIsRun = true;
            _isTask = true;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_threadIsRun)
            {
                btnStart.Text = "Start";
                btnStart.BackColor = Color.Green;
                _threadIsRun = false;
            }
            else
            {
                btnStart.Text = "Stop";
                btnStart.BackColor = Color.Pink;
                if (_thread == null || !_thread.IsAlive)
                {
                    _thread = new Thread(DoWork);
                    _thread.Start();
                }
                _threadIsRun = true;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (_isShow)
            {
                this.Hide();
                _isShow = false;
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                _isShow = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _isTask = false;
            _threadIsRun = false;
            this.ShowText("System is closing...");
            Thread.Sleep(5000);
            GC.SuppressFinalize(this);
            Application.Exit();
        }
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }
        private void DoWork()
        {
            while (_threadIsRun)
            {
                this.ShowText("");
                //if (_isTask && DateTime.Now.Second == 0)
                if (_isTask && DateTime.Now.Second == 0 &&
                    Convert.ToDouble(DateTime.Now.ToString("HHmm")) >= 899 &&
                    Convert.ToDouble(DateTime.Now.ToString("HHmm")) < 1331)
                {
                    _isTask = false;
                    this.ShowText("Task start!!");
                    this.ShowText(LogicService.Execute());
                    this.ShowText("Task end!!");
                    _isTask = true;
                }
                Thread.Sleep(1000);
            }
        }
    }
}