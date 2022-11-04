

namespace ConsoleAppServer.Bean
{
    public class TCNUDBean
    {
        public string? TDATE { get; set; }           //成交日期
        public string? BHNO { get; set; }            //分公司代號
        public string? CSEQ { get; set; }            //客戶帳號
        public string? STOCK { get; set; }           //股票代號
        public string? PRICE { get; set; }           //單價
        public string? QTY { get; set; }             //股數
        public string? BQTY { get; set; }            //未償還股數
        public string? FEE { get; set; }             //手續費
        public string? COST { get; set; }            //成本
        public string? DSEQ { get; set; }            //委託書號
        public string? DNO { get; set; }             //分單號
        public string? ADJDATE { get; set; }         //調整日期
        public string? WTYPE { get; set; }           
        public string? TRDATE { get; set; }          //轉檔日期
        public string? TRTIME { get; set; }          //轉檔時間
        public string? MODDATE { get; set; }         //異動日期
        public string? MODTIME { get; set; }         //異動時間
        public string? MODEUSER { get; set; }        //異動人員
        public string? IOFLAG { get; set; }
    }
}
