namespace Insurance_WebAPI_sample__.Model
{
    public class CoverageSelection
    {
        public int CoverageSelectionId { get; set; }
        public int InsuranceRequestId { get; set; }
        public int CoverageId { get; set; }
        public decimal InvestmentAmount { get; set; } // سرمایه وارد شده
        public decimal CalculatedPremium { get; set; } // حق بیمه پوشش محاسبه شده

    }
}
