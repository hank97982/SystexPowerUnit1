using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ConsoleAppServer.Bean
{
    [Serializable()]
    [XmlRoot("unoffset_qtype_accsum")]
    public class unoffset_qtype_accsum
    {
        [XmlElement("errcode")]
        [JsonPropertyName("errcode")]
        public string? errcode { get; set; }             //錯誤代碼
        [XmlElement("errmsg")]
        [JsonPropertyName("errmsg")]
        public string? errmsg { get; set; }              //錯誤訊息
        [XmlElement("bqty")]
        [JsonPropertyName("bqty")]
        public decimal? bqty { get; set; }               //昨日總庫存股數
        [XmlElement("cost")]
        [JsonPropertyName("cost")]
        public decimal? cost { get; set; }               //總付出成本
        [XmlElement("marketvalue")]
        [JsonPropertyName("marketvalue")]
        public decimal? marketvalue { get; set; }        //總現值(市值)
        [XmlElement("profit")]
        [JsonPropertyName("profit")]
        public decimal? profit { get; set; }             //損益試算
        [XmlElement("pl_ratio")]
        [JsonPropertyName("pl_ratio")]
        public string? pl_ratio { get; set; }            //報酬率(估)
        [XmlElement("fee")]
        [JsonPropertyName("fee")]
        public decimal? fee { get; set; }                //手續費
        [XmlElement("tax")]
        [JsonPropertyName("tax")]
        public decimal? tax { get; set; }                //交易稅
        [XmlElement("estimateAmt")]
        [JsonPropertyName("estimateAmt")]
        public decimal? estimateAmt { get; set; }        //預估賣出價金
        [XmlElement("estimateFee")]
        [JsonPropertyName("estimateFee")]
        public decimal? estimateFee { get; set; }        //預估賣出手續費
        [XmlElement("estimateTax")]
        [JsonPropertyName("estimateTax")]
        public decimal? estimateTax { get; set; }        //預估賣出交易稅
        [XmlArray("unoffset_qtype_sum")]
        [XmlArrayItem("unoffset_qtype_sum", typeof(Unoffset_qtype_sum))]
        [JsonPropertyName("unoffset_qtype_sum")]
        public List<Unoffset_qtype_sum>? unoffset_qtype_sum { get; set; }        //個股未實現損益
    }
    public class Unoffset_qtype_sum
    {
        [XmlElement("stock")]
        [JsonPropertyName("stock")]
        public string? stock { get; set; }               //股票代碼
        [XmlElement("stocknm")]
        [JsonPropertyName("stocknm")]
        public string? stocknm { get; set; }             //股票名稱
        [XmlElement("ttype")]
        [JsonPropertyName("ttype")]
        public string? ttype { get; set; }               //交易別 0:現股 
        [XmlElement("ttypename")]
        [JsonPropertyName("ttypename")]
        public string? ttypename { get; set; }           //交易類別名稱
        [XmlElement("bstype")]
        [JsonPropertyName("bstype")]
        public string? bstype { get; set; }              //買賣別(B/S)
        [XmlElement("bqty")]
        [JsonPropertyName("bqty")]
        public decimal? bqty { get; set; }               //昨日庫存股數
        [XmlElement("cost")]
        [JsonPropertyName("cost")]
        public decimal? cost { get; set; }               //成本金額
        [XmlElement("avgprice")]
        [JsonPropertyName("avgprice")]
        public decimal? avgprice { get; set; }           //均價
        [XmlElement("lastprice")]
        [JsonPropertyName("lastprice")]
        public decimal? lastprice { get; set; }          //現價
        [XmlElement("marketvalue")]
        [JsonPropertyName("marketvalue")]
        public decimal? marketvalue { get; set; }        //現值(市值)
        [XmlElement("estimateAmt")]
        [JsonPropertyName("estimateAmt")]
        public decimal? estimateAmt { get; set; }        //預估賣出價金
        [XmlElement("estimateFee")]
        [JsonPropertyName("estimateFee")]
        public decimal? estimateFee { get; set; }        //預估賣出手續費
        [XmlElement("estimateTax")]
        [JsonPropertyName("estimateTax")]
        public decimal? estimateTax { get; set; }        //預估賣出交易稅
        [XmlElement("profit")]
        [JsonPropertyName("profit")]
        public decimal? profit { get; set; }             //預估損益
        [XmlElement("pl_ratio")]
        [JsonPropertyName("pl_ratio")]
        public string? pl_ratio { get; set; }            //報酬率
        [XmlElement("fee")]
        [JsonPropertyName("fee")]
        public decimal? fee { get; set; }                //手續費
        [XmlElement("tax")]
        [JsonPropertyName("tax")]
        public decimal? tax { get; set; }                //交易稅
        [XmlElement("amt")]
        [JsonPropertyName("amt")]
        public decimal? amt { get; set; }                //成交價金
        [XmlArray("unoffset_qtype_detail")]
        [XmlArrayItem("unoffset_qtype_detail", typeof(Unoffset_qtype_detail))]
        [JsonPropertyName("unoffset_qtype_detail")]
        public List<Unoffset_qtype_detail>? unoffset_qtype_detail { get; set; }      //未實現損益 – 個股明細

    }
    public class Unoffset_qtype_detail
    {
        [XmlElement("tdate")]
        [JsonPropertyName("tdate")]
        public string? tdate { get; set; }               //交易日期
        [XmlElement("ttype")]
        [JsonPropertyName("ttype")]
        public string? ttype { get; set; }               //交易別 0:現股
        [XmlElement("ttypename")]
        [JsonPropertyName("ttypename")]
        public string? ttypename { get; set; }           //交易類別名稱
        [XmlElement("bstype")]
        [JsonPropertyName("bstype")]
        public string? bstype { get; set; }              //買賣別(B/S)
        [XmlElement("dseq")]
        [JsonPropertyName("dseq")]
        public string? dseq { get; set; }                //委託書號
        [XmlElement("dno")]
        [JsonPropertyName("dno")]
        public string? dno { get; set; }                 //分單號碼k
        [XmlElement("bqty")]
        [JsonPropertyName("bqty")]
        public decimal? bqty { get; set; }               //庫存股數
        [XmlElement("mprice")]
        [JsonPropertyName("mprice")]
        public decimal? mprice { get; set; }             //成交價
        [XmlElement("mamt")]
        [JsonPropertyName("mamt")]
        public decimal? mamt { get; set; }               //成交價金
        [XmlElement("lastprice")]
        [JsonPropertyName("lastprice")]
        public decimal? lastprice { get; set; }          //現價
        [XmlElement("marketvalue")]
        [JsonPropertyName("marketvalue")]
        public decimal? marketvalue { get; set; }        //現值(市值)
        [XmlElement("fee")]
        [JsonPropertyName("fee")]
        public decimal? fee { get; set; }                //手續費
        [XmlElement("tax")]
        [JsonPropertyName("tax")]
        public decimal? tax { get; set; }                //交易稅
        [XmlElement("cost")]
        [JsonPropertyName("cost")]
        public decimal? cost { get; set; }               //付出成本
        [XmlElement("estimateAmt")]
        [JsonPropertyName("estimateAmt")]
        public decimal? estimateAmt { get; set; }        //預估賣出價金
        [XmlElement("estimateFee")]
        [JsonPropertyName("estimateFee")]
        public decimal? estimateFee { get; set; }        //預估賣出手續費
        [XmlElement("estimateTax")]
        [JsonPropertyName("estimateTax")]
        public decimal? estimateTax { get; set; }        //預估賣出交易稅
        [XmlElement("profit")]
        [JsonPropertyName("profit")]
        public decimal? profit { get; set; }             //預估損益
        [XmlElement("pl_ratio")]
        [JsonPropertyName("pl_ratio")]
        public decimal? pl_ratio { get; set; }           //報酬率

    }
}
