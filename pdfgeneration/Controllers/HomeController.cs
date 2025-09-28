
using Microsoft.AspNetCore.Mvc;
using pdfgeneration.Services;
using static Org.BouncyCastle.Crypto.Fips.FipsKdf;

namespace pdfgeneration.Controllers
{
    public class HomeController : Controller
    {
        private readonly PdfService _pdfService;

        public HomeController(PdfService pdfService)
        {
            _pdfService = pdfService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GeneratePdf(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                // Handle empty input
                return RedirectToAction("Index"); // Redirect back to the form
            }

            // Generate PDF using the input content
            byte[] pdfBytes = _pdfService.GeneratePdf(content);

            // Return the generated PDF as a file download
            return File(pdfBytes, "application/pdf", "generated.pdf");
        }
    }
}