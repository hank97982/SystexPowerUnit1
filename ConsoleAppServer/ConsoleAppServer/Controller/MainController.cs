using ConsoleAppServer.Model;

namespace ConsoleAppServer.Controller
{
    public class MainController
    {
        private Program _program;
        private MainModel _model;
        public MainController(Program program)
        {
            _program = program;
            _model = new MainModel(this);
        }

        public void Search(string bhno, string cseq)
        {
            _model.Search(bhno, cseq);
        }
    }
}
