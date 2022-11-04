using WinFormsAppClient.Controller;
using HankLibrary;
using System.Text;
using System.Configuration;

namespace WinFormsAppClient.Model
{
    public class MainModel
    {
        private MainController _controller;
        private SockClient _sockClient;
        public MainModel(MainController controller)
        {
            _controller = controller;
            _sockClient = new SockClient(Encoding.UTF8);
            _sockClient.SocketStart(ConfigurationManager.ConnectionStrings["SocketAddressStr"].ConnectionString,
                Convert.ToInt32(ConfigurationManager.ConnectionStrings["SocketPortStr"].ConnectionString));
        }

        public string RequestSender(string formatStr)
        {
            string receiveJsonStr = "";
            try
            {
                _sockClient.SocketSend(formatStr);
                receiveJsonStr = _sockClient.SocketReceive(4096);
            }
            catch (Exception ex)
            {
                _controller.MessageAlert(ex.Message);
            }

            return receiveJsonStr;
        }
    }
}
