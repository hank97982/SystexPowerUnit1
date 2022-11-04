using System.Diagnostics;
using System.Windows.Forms;
using WinFormsAppClient.Bean;
using WinFormsAppClient.Controller;

namespace WinFormsAppClient
{

    public partial class MainForm : Form
    {
        private MainController _controller;
        public MainForm()
        {
            InitializeComponent();
            _controller = new MainController(this);
            Init();
        }

        private void Init()
        {
            cbConnectType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbConnectType.Items.Add(ConnectTypeItems.Json);
            cbConnectType.Items.Add(ConnectTypeItems.Xml);
            cbConnectType.SelectedIndex = 0;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            List<string> strings = new List<string>();
            if (txtbhno.Text == "")
            {
                strings.Add("分公司");
            }
            if (txtcseq.Text == "")
            {
                strings.Add("帳號");
            }
            if (txtbhno.Text == "" || txtcseq.Text == "")
            {
                MessageAlert(String.Join(",", strings) + "欄位不得為空");
                return;
            }
            dataGridView1.DataSource = 
                _controller.AskForSearch(cbConnectType.SelectedIndex,
                                     txtbhno.Text,
                                     txtcseq.Text);

        }

        public void MessageAlert(string messageStr)
        {
            MessageBox.Show(messageStr, "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}