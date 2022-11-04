using ConsoleAppServer.Bean;
using ConsoleAppServer.Controller;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace ConsoleAppServer.Model
{
    public class MainModel : BaseModel
    {
        private MainController _controller;
        private Stopwatch stopwatch = new Stopwatch();

        public MainModel(MainController controller) : base()
        {
            this._controller = controller;
        }


        public void Search(string bhno, string cseq)
        {
            unoffset_qtype_accsum accsum = new unoffset_qtype_accsum();
            //aObject.Key = 0;
            //aObject.Value = "VA";
            accsum.errcode = "0(固定)";
            accsum.errmsg = "成功(固定)";



            List<Unoffset_qtype_sum> listSum = new List<Unoffset_qtype_sum>();

            SqlCommand cmd = _cndb.CreateCommand();
            string commend = "SELECT STOCK AS stock," +
                                " (SELECT MSTMB.CNAME FROM MSTMB WHERE STOCK = TCNUD.STOCK) AS stocknm," +
                                " SUM(BQTY) AS bqty," +
                                " SUM(COST) AS cost," +
                                " (SUM(BQTY) / SUM(COST)) AS avgprice," +
                                " (SELECT MSTMB.CPRICE FROM MSTMB WHERE STOCK = TCNUD.STOCK) AS lastprice" +
                                " FROM TCNUD WHERE BHNO = @BHNO AND CSEQ = @CSEQ" +
                                " GROUP BY STOCK;";
            cmd.CommandText = commend;
            cmd.Parameters.AddWithValue("@BHNO", bhno);
            cmd.Parameters.AddWithValue("@CSEQ", cseq);
            _cndb.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            decimal? bqtySumDouble = 0;
            decimal? costSumDouble = 0;
            decimal? marketvalueSumDouble = 0;
            decimal? estimateAmtSumDouble = 0;
            decimal? estimateFeeSumDouble = 0;
            decimal? estimateTaxSumDouble = 0;
            decimal? profitSumDouble = 0;
            decimal? feeSumDouble = 0;
            decimal? taxSumDouble = 0;
            decimal? amtSumDouble = 0;
            while (dr.Read())
            {

                Unoffset_qtype_sum sum = new Unoffset_qtype_sum();
                sum.stock = dr["stock"].ToString();
                sum.stocknm = dr["stocknm"].ToString();
                sum.ttype = "0";
                sum.ttypename = "現買";
                sum.bstype = "B";


                SqlCommand cmd1 = _cndbDouble.CreateCommand();
                string commend1 = "SELECT TDATE AS tdate," +
                    " DSEQ AS dseq," +
                    " DNO AS dno," +
                    " BQTY AS bqty," +
                    " PRICE AS mprice," +
                    " FEE AS fee," +
                    " COST AS cost," +
                    " (SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)AS lastprice" +
                    " FROM TCNUD WHERE BHNO = @BHNO AND CSEQ = @CSEQ;";
                cmd1.CommandText = commend1;
                cmd1.Parameters.AddWithValue("@BHNO", bhno);
                cmd1.Parameters.AddWithValue("@CSEQ", cseq);
                cmd1.Parameters.AddWithValue("@STOCK", sum.stock);
                _cndbDouble.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                List<Unoffset_qtype_detail>? unoffset_qtype_detail = new List<Unoffset_qtype_detail>();

                decimal? bqtySum = 0;
                decimal? costSum = 0;
                decimal? marketvalueSum = 0;
                decimal? estimateAmtSum = 0;
                decimal? estimateFeeSum = 0;
                decimal? estimateTaxSum = 0;
                decimal? profitSum = 0;
                decimal? feeSum = 0;
                decimal? taxSum = 0;
                decimal? amtSum = 0;
                while (dr1.Read())
                {
                    Unoffset_qtype_detail detail = new Unoffset_qtype_detail();
                    detail.tdate = dr1["tdate"].ToString();
                    detail.ttype = "0";
                    detail.ttypename = "現買";
                    detail.bstype = "B";
                    detail.dseq = dr1["dseq"].ToString();
                    detail.dno = dr1["dno"].ToString();
                    detail.bqty = Convert.ToDecimal(dr1["bqty"].ToString());
                    detail.mprice = Convert.ToDecimal(dr1["mprice"].ToString());
                    detail.mamt = detail.mprice * detail.bqty;
                    detail.lastprice = Convert.ToDecimal(dr1["lastprice"].ToString());
                    detail.fee = Convert.ToDecimal(dr1["fee"].ToString());
                    detail.tax = 0;
                    detail.cost = Convert.ToDecimal(dr1["cost"].ToString());
                    detail.estimateAmt = detail.lastprice * detail.bqty;
                    detail.estimateFee = detail.estimateAmt * detail.fee * 0.001425m;
                    detail.estimateTax = detail.estimateAmt * detail.tax * 0.003m;
                    detail.marketvalue = detail.estimateAmt - detail.estimateFee - detail.estimateTax;
                    detail.profit = detail.marketvalue - detail.cost;
                    detail.pl_ratio = detail.profit / detail.cost;
                    bqtySum += detail.bqty;
                    costSum += detail.cost;
                    marketvalueSum += detail.marketvalue;
                    estimateAmtSum += detail.estimateAmt;
                    estimateFeeSum += detail.estimateFee;
                    estimateTaxSum += detail.estimateTax;
                    profitSum += detail.profit;
                    feeSum += detail.fee;
                    taxSum += detail.tax;
                    amtSum += detail.mamt;
                    unoffset_qtype_detail.Add(detail);
                }
                _cndbDouble.Close();
                sum.bqty = bqtySum;
                sum.cost = costSum;
                sum.avgprice = Convert.ToDecimal(dr["avgprice"].ToString());
                sum.lastprice = Convert.ToDecimal(dr["lastprice"].ToString());
                sum.marketvalue = marketvalueSum;
                sum.estimateAmt = estimateAmtSum;
                sum.estimateFee = estimateFeeSum;
                sum.estimateTax = estimateTaxSum;
                sum.profit = profitSum;
                sum.pl_ratio = ((sum.profit / sum.cost)*1).ToString();
                sum.fee = feeSum;
                sum.tax = taxSum;
                sum.amt = amtSum;
                bqtySumDouble += sum.bqty;
                costSumDouble += sum.cost;
                marketvalueSumDouble += sum.marketvalue;
                profitSumDouble += sum.profit;
                feeSumDouble += sum.fee;
                taxSumDouble += sum.tax;
                estimateAmtSumDouble += sum.estimateAmt;
                estimateFeeSumDouble += sum.estimateFee;
                estimateTaxSumDouble += sum.estimateTax;


                listSum.Add(sum);
                sum.unoffset_qtype_detail = unoffset_qtype_detail;

            }
            accsum.bqty = bqtySumDouble;
            accsum.cost = costSumDouble;
            accsum.marketvalue = marketvalueSumDouble;
            accsum.profit = profitSumDouble;
            accsum.pl_ratio = ((accsum.profit / accsum.cost) * 1).ToString();
            accsum.fee = feeSumDouble;
            accsum.tax = taxSumDouble;
            accsum.estimateAmt = estimateAmtSumDouble;
            accsum.estimateFee = estimateFeeSumDouble;
            accsum.estimateTax = estimateTaxSumDouble;
            _cndb.Close();

            accsum.unoffset_qtype_sum = listSum;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Console.WriteLine(JsonSerializer.Serialize(accsum, options));
            Console.WriteLine(Util.Util.Serialize(accsum));


        }

        #region
        //public List<Unoffset_qtype_detail> Unoffset_qtype_detail(string bhno, string cseq, string stock)
        //{
        //    stopwatch.Start();
        //    SqlCommand cmd1 = _cndb.CreateCommand();
        //    string commend1 = "SELECT TDATE AS tdate," +
        //        " DSEQ AS dseq," +
        //        " DNO AS dno," +
        //        " BQTY AS bqty," +
        //        " PRICE AS mprice," +
        //        " FEE AS fee," +
        //        " COST AS cost," +
        //        " (SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)AS lastprice" +
        //        " FROM TCNUD WHERE BHNO = @BHNO AND CSEQ = @CSEQ;";
        //    cmd1.CommandText = commend1;
        //    cmd1.Parameters.AddWithValue("@BHNO", bhno);
        //    cmd1.Parameters.AddWithValue("@CSEQ", cseq);
        //    cmd1.Parameters.AddWithValue("@STOCK", stock);
        //    _cndb.Open();
        //    SqlDataReader dr1 = cmd1.ExecuteReader();
        //    List<Unoffset_qtype_detail>? unoffset_qtype_detail = new List<Unoffset_qtype_detail>();

        //    if (dr1.Read() == false)
        //    {
        //        Console.WriteLine("查無相關資料!");
        //        return unoffset_qtype_detail;
        //    }

        //    while (dr1.Read())
        //    {
        //        Unoffset_qtype_detail detail = new Unoffset_qtype_detail();
        //        detail.tdate = dr1["tdate"].ToString();
        //        detail.ttype = "0";
        //        detail.ttypename = "現買";
        //        detail.bstype = "B";
        //        detail.dseq = dr1["dseq"].ToString();
        //        detail.dno = dr1["dno"].ToString();
        //        detail.bqty = Convert.ToDecimal(dr1["bqty"].ToString());
        //        detail.mprice = Convert.ToDecimal(dr1["mprice"].ToString());
        //        detail.mamt = detail.mprice * detail.bqty;
        //        detail.lastprice = Convert.ToDecimal(dr1["lastprice"].ToString());
        //        detail.fee = Convert.ToDecimal(dr1["fee"].ToString());
        //        detail.tax = 0;
        //        detail.cost = Convert.ToDecimal(dr1["cost"].ToString());
        //        detail.estimateAmt = detail.lastprice * detail.bqty;
        //        detail.estimateFee = detail.estimateAmt * detail.fee * 0.001425m;
        //        detail.estimateTax = detail.estimateAmt * detail.tax * 0.003m;
        //        detail.marketvalue = detail.estimateAmt - detail.estimateFee - detail.estimateTax;
        //        detail.profit = detail.marketvalue - detail.cost;
        //        detail.pl_ratio = detail.profit / detail.cost;
        //        unoffset_qtype_detail.Add(detail);
        //    }
        //    _cndb.Close();
        //    stopwatch.Stop();
        //    return unoffset_qtype_detail;

        #region SQL語法解決計算

        //stopwatch.Start();
        //SqlCommand cmd = _cndb.CreateCommand();
        //string commend = "SELECT TDATE AS tdate," +
        //    "DSEQ AS dseq," +
        //    "DNO AS dno," +
        //    "BQTY AS bqty," +
        //    "PRICE AS mprice," +
        //    "FEE AS fee," +
        //    "COST AS cost," +
        //    "(SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)AS lastprice" +
        //    "FROM TCNUD WHERE BHNO = @BHNO AND CSEQ = @CSEQ;";
        //cmd.CommandText = commend;
        //cmd.Parameters.AddWithValue("@BHNO", bhno);
        //cmd.Parameters.AddWithValue("@CSEQ", cseq);
        //_cndb.Open();
        //SqlDataReader dr = cmd.ExecuteReader();
        //if (dr.Read() == false)
        //{
        //    Console.WriteLine("查無相關資料!");
        //    return;
        //}
        //List<Unoffset_qtype_detail>? unoffset_qtype_detail = new List<Unoffset_qtype_detail>();

        //while (dr.Read())
        //{
        //    Unoffset_qtype_detail detail = new Unoffset_qtype_detail();
        //    detail.tdate = dr["tdate"].ToString();
        //    detail.ttype = "0";
        //    detail.ttypename = "現買";
        //    detail.bstype = "B";
        //    detail.dseq = dr["dseq"].ToString();
        //    detail.dno = dr["dno"].ToString();
        //    detail.bqty = Convert.ToDecimal(dr["bqty"].ToString());
        //    detail.mprice = Convert.ToDecimal(dr["mprice"].ToString());
        //    detail.mamt = detail.mprice * detail.bqty;
        //    detail.lastprice = Convert.ToDecimal(dr["lastprice"].ToString());
        //    detail.fee = Convert.ToDecimal(dr["fee"].ToString());
        //    detail.tax = 0;
        //    detail.cost = Convert.ToDecimal(dr["cost"].ToString());
        //    detail.estimateAmt = detail.lastprice * detail.bqty;
        //    detail.estimateFee = detail.estimateAmt * detail.fee * 0.001425m;
        //    detail.estimateTax = detail.estimateAmt * detail.tax * 0.003m;
        //    detail.marketvalue = detail.estimateAmt - detail.estimateFee - detail.estimateTax;
        //    detail.profit = detail.marketvalue - detail.cost;
        //    detail.pl_ratio = detail.profit / detail.cost;
        //    unoffset_qtype_detail.Add(detail);
        //}
        //_cndb.Close();
        //stopwatch.Stop();
        #endregion

        #region SQL語法解決計算
        //stopwatch.Start();
        //SqlCommand cmd = _cndb.CreateCommand();
        //string commend = "SELECT TDATE AS tdate," +
        //    " '0' AS ttype," +
        //    " '現買' AS ttypename," +
        //    " 'B' AS bstype," +
        //    " DSEQ AS dseq," +
        //    " DNO AS dno," +
        //    " BQTY AS bqty," +
        //    " PRICE AS mprice," +
        //    " (BQTY*PRICE) AS mamt," +
        //    " (SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK) AS lastprice," +
        //    " ((SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*BQTY)-" +
        //    " ((SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*FEE*0.001425)-" +
        //    " ((SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*0*0.003) AS marketvalue," +
        //    " FEE AS fee," +
        //    " 0 AS tax," +
        //    " COST AS cost," +
        //    " (SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*BQTY AS estimateAmt," +
        //    " (SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*FEE*0.001425 AS estimateFee," +
        //    " (SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*0*0.003 AS estimateTax," +
        //    " ((SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*BQTY)-" +
        //    " ((SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*FEE*0.001425)-" +
        //    " ((SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*0*0.003)-COST AS profit," +
        //    " ((SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*BQTY)-" +
        //    " ((SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*FEE*0.001425)-" +
        //    " (((SELECT CPRICE FROM MSTMB WHERE MSTMB.STOCK = TCNUD.STOCK)*0*0.003)-COST)/COST AS pl_ratio" +
        //    " FROM TCNUD WHERE BHNO = '592S' AND CSEQ = '0000116';";
        //cmd.CommandText = commend;
        //cmd.Parameters.AddWithValue("@BHNO", bhno);
        //cmd.Parameters.AddWithValue("@CSEQ", cseq);
        //_cndb.Open();
        //SqlDataReader dr = cmd.ExecuteReader();
        //if (dr.Read() == false)
        //{
        //    Console.WriteLine("查無相關資料!");
        //    return;
        //}
        //List<Unoffset_qtype_detail>? unoffset_qtype_detail =new List<Unoffset_qtype_detail>();
        //while (dr.Read())
        //{
        //    Unoffset_qtype_detail detail = new Unoffset_qtype_detail();
        //    detail.tdate = dr["tdate"].ToString();
        //    detail.ttype = dr["ttype"].ToString();
        //    detail.ttypename = dr["ttypename"].ToString();
        //    detail.bstype = dr["bstype"].ToString();
        //    detail.dseq = dr["dseq"].ToString();
        //    detail.dno = dr["dno"].ToString();
        //    detail.bqty = Convert.ToDecimal(dr["bqty"].ToString());
        //    detail.mprice = Convert.ToDecimal(dr["mprice"].ToString());
        //    detail.mamt = Convert.ToDecimal(dr["mamt"].ToString());
        //    detail.lastprice = Convert.ToDecimal(dr["lastprice"].ToString());
        //    detail.marketvalue = Convert.ToDecimal(dr["marketvalue"].ToString());
        //    detail.fee = Convert.ToDecimal(dr["fee"].ToString());
        //    detail.tax = Convert.ToDecimal(dr["tax"].ToString());
        //    detail.cost = Convert.ToDecimal(dr["cost"].ToString());
        //    detail.estimateAmt = Convert.ToDecimal(dr["estimateAmt"].ToString());
        //    detail.estimateFee = Convert.ToDecimal(dr["estimateFee"].ToString());
        //    detail.estimateTax = Convert.ToDecimal(dr["estimateTax"].ToString());
        //    detail.profit = Convert.ToDecimal(dr["profit"].ToString());
        //    detail.pl_ratio = Convert.ToDecimal(dr["pl_ratio"].ToString());
        //    unoffset_qtype_detail.Add(detail);
        //}
        //_cndb.Close();
        //stopwatch.Stop();
        #endregion

        //}
        #endregion

        #region
        //public void SecondStair(string bhno, string cseq, List<Unoffset_qtype_detail> unoffset_qtype_detail)
        //{

        //    foreach (var item in unoffset_qtype_detail)
        //    {
        //        SqlCommand cmd = _cndb.CreateCommand();
        //        string commend = "SELECT STOCK AS stock," +
        //                            " (SELECT MSTMB.CNAME FROM MSTMB WHERE STOCK = TCNUD.STOCK) AS stocknm," +
        //                            " SUM(BQTY) AS bqty," +
        //                            " SUM(COST) AS cost," +
        //                            " (SUM(BQTY) / SUM(COST)) AS avgprice," +
        //                            " (SELECT MSTMB.CPRICE FROM MSTMB WHERE STOCK = TCNUD.STOCK) AS lastprice" +
        //                            " FROM TCNUD WHERE BHNO = @BHNO AND CSEQ = @CSEQ" +
        //                            " GROUP BY STOCK;";
        //        cmd.CommandText = commend;
        //        cmd.Parameters.AddWithValue("@BHNO", bhno);
        //        cmd.Parameters.AddWithValue("@CSEQ", cseq);
        //        _cndb.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            var total =  from list in unoffset_qtype_detail
        //                         group list by list.
        //            Unoffset_qtype_sum sum = new Unoffset_qtype_sum();
        //            sum.stock = dr["stock"].ToString();
        //            sum.stocknm = dr["stocknm"].ToString();
        //            sum.ttype = "0";
        //            sum.ttypename = "現買";
        //            sum.bstype = "B";
        //            sum.bqty = Convert.ToDecimal(dr["bqty"].ToString());
        //            sum.cost = Convert.ToDecimal(dr["cost"].ToString());
        //            sum.avgprice = Convert.ToDecimal(dr["avgprice"].ToString());
        //            sum.lastprice = Convert.ToDecimal(dr["lastprice"].ToString());
        //            sum.marketvalue = 
        //        }
        //        _cndb.Close();
        //    }   
        //}


        //public void Search(string bhno, string cseq)
        //{
        //    unoffset_qtype_accsum accsum = new unoffset_qtype_accsum();
        //    //aObject.Key = 0;
        //    //aObject.Value = "VA";

        //    List<Unoffset_qtype_sum> listSum = new List<Unoffset_qtype_sum>();
        //    for (int j = 0; j < 5; j++)
        //    {
        //        Unoffset_qtype_sum sum = new Unoffset_qtype_sum();
        //        //bObject.Key = j;
        //        //bObject.Value = "VB";
        //        listSum.Add(sum);

        //        List<Unoffset_qtype_detail> listDetail = new List<Unoffset_qtype_detail>();
        //        for (int i = 0; i < 2; i++)
        //        {
        //            Unoffset_qtype_detail detail = new Unoffset_qtype_detail();
        //            //cObject.Key = i;
        //            //cObject.Value = "VC";
        //            listDetail.Add(detail);
        //        }
        //        sum.unoffset_qtype_detail = listDetail;
        //    }
        //    accsum.unoffset_qtype_sum = listSum;

        //    var options = new JsonSerializerOptions
        //    {
        //        WriteIndented = true
        //    };
        //    Console.WriteLine(JsonSerializer.Serialize(accsum, options));
        //}
        #endregion

        #region
        //public void Unoffset_qtype_sum(string bhno, string cseq)
        //{

        //    SqlCommand cmd = _cndb.CreateCommand();
        //    string commend = "SELECT STOCK AS stock," +
        //                        " (SELECT MSTMB.CNAME FROM MSTMB WHERE STOCK = TCNUD.STOCK) AS stocknm," +
        //                        " SUM(BQTY) AS bqty," +
        //                        " SUM(COST) AS cost," +
        //                        " (SUM(BQTY) / SUM(COST)) AS avgprice," +
        //                        " (SELECT MSTMB.CPRICE FROM MSTMB WHERE STOCK = TCNUD.STOCK) AS lastprice" +
        //                        " FROM TCNUD WHERE BHNO = @BHNO AND CSEQ = @CSEQ" +
        //                        " GROUP BY STOCK;";
        //    cmd.CommandText = commend;
        //    cmd.Parameters.AddWithValue("@BHNO", bhno);
        //    cmd.Parameters.AddWithValue("@CSEQ", cseq);
        //    _cndb.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        Unoffset_qtype_sum sum = new Unoffset_qtype_sum();
        //        sum.stock = dr["stock"].ToString();
        //        sum.stocknm = dr["stocknm"].ToString();
        //        sum.ttype = "0";
        //        sum.ttypename = "現買";
        //        sum.bstype = "B";
        //        sum.bqty = Convert.ToDecimal(dr["bqty"].ToString());
        //        sum.cost = Convert.ToDecimal(dr["cost"].ToString());
        //        sum.avgprice = Convert.ToDecimal(dr["avgprice"].ToString());
        //        sum.lastprice = Convert.ToDecimal(dr["lastprice"].ToString());
        //    }
        //    _cndb.Close();

        //}
        #endregion
    }
}
