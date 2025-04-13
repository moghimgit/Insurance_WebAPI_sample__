namespace Insurance_WebAPI_sample__.Model
{
    public class Coverage
    {
        public int CoverageId { get; set; }
        public string CoverageName { get; set; } // نام پوشش
        public decimal MinInvestment { get; set; } // حداقل سرمایه
        public decimal MaxInvestment { get; set; } // حداکثر سرمایه
        public decimal Rate { get; set; } // نرخ محاسبه حق بیمه

    }
}
