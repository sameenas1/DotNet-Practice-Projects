using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;

namespace pdfgeneration.Services
{
    public class PdfService
    {
        public byte[] GeneratePdf(string content)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (var writer = new PdfWriter(stream))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);
                        document.Add(new Paragraph(content));
                    }
                }

                return stream.ToArray();
            }
        }
    }
}