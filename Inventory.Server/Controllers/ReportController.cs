using Inventory.Server.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using Inventory.Server.Models;
using AspNetCore.Reporting;
namespace Inventory.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPurchaseRepository _purchaseRepository;
        public ReportController(IWebHostEnvironment webHostEnvironment, IPurchaseRepository purchaseRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            this._purchaseRepository = purchaseRepository;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [HttpGet]
        [Route("GetReport")]
        public IActionResult GetReport(int? reportType)
        {
            var pur_obj = _purchaseRepository.GetSearchByPurchase(null, 1);

            string mimeType = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rdPurchase.rdlc";

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("header_title", "Purchase Information");
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSet1", pur_obj.Results);
            // For PDF
            if (reportType == 1)
            {
                var result = localReport.Execute(RenderType.Pdf, extension, param, mimeType);
                return File(result.MainStream, contentType: "application/pdf");
            }
            // excel
            else if (reportType == 2)
            {
                var result = localReport.Execute(RenderType.Excel, extension, param, mimeType);
                return File(result.MainStream, contentType: "application/msexcel",fileDownloadName:"test.xls");
            }
            else return Content(string.Empty);
        }
    }
}
