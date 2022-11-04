using ConsoleAppServer.Controller;
using System.Net;
using System.Net.Sockets;

namespace ConsoleAppServer
{
    public class Program
    {

        static void Main(string[] args)
        {
            MainController mainController = new MainController(new Program()); 
            Console.Write("bhno:");
            string bhno = "592S";
            Console.WriteLine();
            Console.Write("cseq:");
            string cseq = "0000116";
            Console.WriteLine();

            mainController.Search(bhno, cseq);

        }

    }
}