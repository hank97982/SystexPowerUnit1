

namespace ConsoleAppServer.Bean
{
    public class MSTMBBean
    {
        public string? STOCK { get; set; }           //證卷代號
        public string? CNAME { get; set; }           //中文名稱
        public string? ENAME { get; set; }           //英文名稱
        public string? MTYPE { get; set; }           //市場別 T-上市 O-上櫃 R-興櫃
        public string? STYPE { get; set; }           //股票類別
        public string? SCLASS { get; set; }          //股票分類
        public string? TSDATE { get; set; }          //交易起始日期
        public string? TEDATE { get; set; }          //交易截止日期
        public string? CLDATE { get; set; }          //收盤日期
        public string? CPRICE { get; set; }          //收盤價
        public string? TPRICE { get; set; }          //漲停價
        public string? BPRICE { get; set; }          //跌停價
        public string? TSTATUS { get; set; }         //交易狀況 0-停止交易 1-交易所警示 2-證券商警示 3-注意股票
        public string? BRKNO { get; set; }           //承銷/委任商代號
        public string? IDATE { get; set; }           //債息基準日期
        public string? IRATE { get; set; }           //債息利率
        public string? IDAY { get; set; }            //年息天數
        public string? CURRENCY { get; set; }        //幣別
        public string? COUNTRY { get; set; }         //國家
        public string? SHARE { get; set; }           //單位股數
        public string? WARNING { get; set; }         //警示股
        public string? TMARK { get; set; }           //交易註記(0.一般股票 1.全額股票 2.全額股票&分盤撮合 3.管理)
        public string? MFLAG { get; set; }
        public string? WMARK { get; set; }           //處置註記(1.處置股票 2.在處置股票 3.彈性處置股票)
        public string? TAXTYPE { get; set; }         //稅率類別
        public string? PTYPE { get; set; }
        public string? DRDATE { get; set; }          //除權日期
        public string? PDRDATE { get; set; }         //假除權日
        public string? CDIV { get; set; }            //現金股利
        public string? SDIV { get; set; }            //股票股利
        public string? CNTDTYPE { get; set; }        //現股當沖別(Y:可當沖,N:不可當沖)
        public string? TRDATE { get; set; }          //轉檔日期
        public string? TRTIME { get; set; }          //轉檔時間
        public string? MODDATE { get; set; }         //異動日期
        public string? MODTIME { get; set; }         //異動時間
        public string? MODUSER { get; set; }         //異動人員
    }
}
