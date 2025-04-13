using System.ComponentModel.DataAnnotations;

namespace Insurance_WebAPI_sample__.Model
{
    public class InsuranceRequest
    {
        [Key] public int RequestId { get; set; }// کلید اصل
        public string? RequestTitle { get; set; } // عنوان درخواست
        public ICollection<CoverageSelection>? Coverages { get; set; } // پوشش‌های انتخاب‌شده
        public decimal TotalPremium { get; set; } // حق بیمه خالص

    }
}
