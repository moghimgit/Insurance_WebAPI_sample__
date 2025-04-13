using Insurance_WebAPI_sample__.Model;
using Insurance_WebAPI_sample__.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Insurance_WebAPI_sample__.Controllers
{
    public class InsuranceController : ControllerBase
    {

        private readonly InsuranceDbContext _context;

        public InsuranceController(InsuranceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// ثبت درخواست جدید
        /// </summary>
        /// <param name="Create_Coverages">جزئیات درخواست</param>
        /// <returns>نتیجه ثبت درخواست</returns>
        /// 

        [HttpPost("create")]
        public async Task<IActionResult> CreateRequest([FromBody] InsuranceRequest request)
        {
            if (request == null || request.Coverages == null || request.Coverages.Count == 0)
            {
                return BadRequest("اطلاعات درخواست ناقص است.");
            }

            decimal totalPremium = 0;

            foreach (var coverage in request.Coverages)
            {
                var dbCoverage = await _context.Coverages.FindAsync(coverage.CoverageId);

                if (dbCoverage == null)
                {
                    return BadRequest($"پوشش با شناسه {coverage.CoverageId} یافت نشد.");
                }

                if (coverage.InvestmentAmount < dbCoverage.MinInvestment || coverage.InvestmentAmount > dbCoverage.MaxInvestment)
                {
                    return BadRequest($"سرمایه برای پوشش {dbCoverage.CoverageName} خارج از محدوده مجاز است.");
                }

                // محاسبه حق بیمه برای پوشش
                coverage.CalculatedPremium = coverage.InvestmentAmount * dbCoverage.Rate;
                totalPremium += coverage.CalculatedPremium;
            }

            // ذخیره درخواست و حق بیمه خالص
            request.TotalPremium = totalPremium;
            _context.InsuranceRequests.Add(request);
            await _context.SaveChangesAsync();

            return Ok(request);
        }

        /// <summary>
        /// ثبت درخواست جدید
        /// </summary>
        /// <param name="Requests_Your_Coverages">جزئیات دریافت نتیجه</param>
        /// <returns>نتیجه  درخواست</returns>
        /// 

        [HttpGet("requests")]
        public async Task<IActionResult> GetRequests()
        {
            var requests = await _context.InsuranceRequests
                .Include(r => r.Coverages)
                .ToListAsync();

            return Ok(requests);
        }


    }
}
