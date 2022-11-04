using WinFormsAppClient.Model;
using WinFormsAppClient.Bean;
using HankLibrary.JsonConvert;
using System.Diagnostics;
using WinFormsAppClient.Utils;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Data;

namespace WinFormsAppClient.Controller
{
    public class MainController
    {
        private MainForm _form;
        private MainModel _model;
        public MainController(MainForm mainForm)
        {
            _form = mainForm;
            _model = new MainModel(this);
        }

        public void MessageAlert(string messageStr)
        {
            _form.MessageAlert(messageStr);
        }

        public DataTable? AskForSearch(int selectItem, params string[] InputString)
        {
            DataTable dt = new DataTable();
            //如何遍歷物件內的成員並賦予值?
            root requestBean = new root() { bhno = InputString[0], cseq = InputString[1] };
            if (ConnectTypeItems.Json.GetHashCode() == selectItem)
            {
                string sendJsonStr = JsonConvert.ObjectInJsonOut(requestBean);
                string receiveJsonStr = _model.RequestSender(sendJsonStr);



                
                return dt;
            }
            if (ConnectTypeItems.Xml.GetHashCode() == selectItem)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlSerializer xmlSerializer = new XmlSerializer(requestBean.GetType());
                //StringBuilder,StringReader,StringWriter的差異?
                StringWriter sw = new StringWriter(new StringBuilder());
                xmlSerializer.Serialize(sw, requestBean, ns);
                string receiveXmlStr =_model.RequestSender(sw.ToString());



                return dt;
            }
            _form.MessageAlert("超出項目的發送格式!!");
            return null;

        }
    }
}
