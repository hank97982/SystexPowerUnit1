
namespace WinFormsAppClient.Bean
{
    public class unoffset_qtype_accsum
    {
        public string? errcode { get; set; }             //錯誤代碼
        public string? errmsg { get; set; }              //錯誤訊息
        public decimal? bqty { get; set; }               //昨日總庫存股數
        public decimal? cost { get; set; }               //總付出成本
        public decimal? marketvalue { get; set; }        //總現值(市值)
        public decimal? profit { get; set; }             //損益試算
        public string? pl_ratio { get; set; }            //報酬率(估)
        public decimal? fee { get; set; }                //手續費
        public decimal? tax { get; set; }                //交易稅
        public decimal? estimateAmt { get; set; }        //預估賣出價金
        public decimal? estimateFee { get; set; }        //預估賣出手續費
        public decimal? estimateTax { get; set; }        //預估賣出交易稅
        public List<Unoffset_qtype_sum>? unoffset_qtype_sum { get; set; }        //個股未實現損益
    }
    public class Unoffset_qtype_sum
    {
        public string? stock { get; set; }               //股票代碼
        public string? stocknm { get; set; }             //股票名稱
        public string? ttype { get; set; }               //交易別 0:現股 
        public string? ttypename { get; set; }           //交易類別名稱
        public string? bstype { get; set; }              //買賣別(B/S)
        public decimal? bqty { get; set; }               //昨日庫存股數
        public decimal? cost { get; set; }               //成本金額
        public decimal? avgprice { get; set; }           //均價
        public decimal? lastprice { get; set; }          //現價
        public decimal? marketvalue { get; set; }        //現值(市值)
        public decimal? estimateAmt { get; set; }        //預估賣出價金
        public decimal? estimateFee { get; set; }        //預估賣出手續費
        public decimal? estimateTax { get; set; }        //預估賣出交易稅
        public decimal? profit { get; set; }             //預估損益
        public string? pl_ratio { get; set; }            //報酬率
        public decimal? fee { get; set; }                //手續費
        public decimal? tax { get; set; }                //交易稅
        public decimal? amt { get; set; }                //成交價金
        public List<Unoffset_qtype_detail>? unoffset_qtype_detail { get; set; }      //未實現損益 – 個股明細

    }
    public class Unoffset_qtype_detail
    {
        public string? tdate { get; set; }               //交易日期
        public string? ttype { get; set; }               //交易別 0:現股
        public string? ttypename { get; set; }           //交易類別名稱
        public string? bstype { get; set; }              //買賣別(B/S)
        public string? dseq { get; set; }                //委託書號
        public string? dno { get; set; }                 //分單號碼k
        public decimal? bqty { get; set; }               //庫存股數
        public decimal? mprice { get; set; }             //成交價
        public decimal? mamt { get; set; }               //成交價金
        public decimal? lastprice { get; set; }          //現價
        public decimal? marketvalue { get; set; }        //現值(市值)
        public decimal? fee { get; set; }                //手續費
        public decimal? tax { get; set; }                //交易稅
        public decimal? cost { get; set; }               //付出成本
        public decimal? estimateAmt { get; set; }        //預估賣出價金
        public decimal? estimateFee { get; set; }        //預估賣出手續費
        public decimal? estimateTax { get; set; }        //預估賣出交易稅
        public decimal? profit { get; set; }             //預估損益
        public decimal? pl_ratio { get; set; }           //報酬率

    }
}