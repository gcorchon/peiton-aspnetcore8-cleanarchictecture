using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Peiton.Configuration;
using Peiton.Core;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

[Injectable(typeof(IPDFService), ServiceLifetime.Singleton)]
public class PDFService(IOptions<AppSettings> options, IRazorService razorService) : IPDFService
{
    public async Task<byte[]> RenderAsync<T>(string templatePath, T data)
    {
        var html = await razorService.RenderAsync(templatePath, data);
        return await this.RenderAsync(html);
    }

    public async Task<byte[]> RenderAsync(string html)
    {
        var guid = Guid.NewGuid().ToString();
        var htmlPath = Path.Combine(Path.GetTempPath(), guid + ".html");
        var pdfPath = Path.Combine(Path.GetTempPath(), guid + ".pdf");

        File.WriteAllText(htmlPath, html);

        Process process = new Process();
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.FileName = options.Value.WkhtmlToPdf;
        process.StartInfo.Arguments = string.Format("-T 30 -L 20 -R 20 -B 30 -q \"{0}\" \"{1}\"", htmlPath, pdfPath);
        process.Start();
        process.WaitForExit();

        File.Delete(htmlPath);

        var data = await File.ReadAllBytesAsync(pdfPath);
        File.Delete(pdfPath);
        return data;
    }


    /*

        public byte[] ExportBinary(string html, string path)
        {
            var guid = Guid.NewGuid().ToString();
            var htmlPath = Path.Combine(path, guid + ".html");
            var pdfPath = Path.Combine(path, guid + ".pdf");

            File.WriteAllText(htmlPath, html);

            Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = ConfigurationManager.AppSettings["PATH_TO_WKHTMLTOPDF"];
            process.StartInfo.Arguments = string.Format("-T 30 -L 20 -R 20 -B 30 -q \"{0}\" \"{1}\"", htmlPath, pdfPath);
            process.Start();
            process.WaitForExit();

            File.Delete(htmlPath);

            var data = File.ReadAllBytes(pdfPath);
            File.Delete(pdfPath);
            return data;

        }
    */
    /*
        public byte[] ExportBinary(string html, string headerUrl, string path)
        {
            var guid = Guid.NewGuid().ToString();
            var htmlPath = Path.Combine(path, guid + ".html");
            var pdfPath = Path.Combine(path, guid + ".pdf");

            File.WriteAllText(htmlPath, html);

            Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = ConfigurationManager.AppSettings["PATH_TO_WKHTMLTOPDF"];
            process.StartInfo.Arguments = string.Format("-T 35 -L 20 -R 20 -B 30 -q --header-html \"{2}\" --no-header-line \"{0}\" \"{1}\"", htmlPath, pdfPath, headerUrl);
            process.Start();
            process.WaitForExit();

            File.Delete(htmlPath);

            var data = File.ReadAllBytes(pdfPath);
            File.Delete(pdfPath);
            return data;
        }
        */
}