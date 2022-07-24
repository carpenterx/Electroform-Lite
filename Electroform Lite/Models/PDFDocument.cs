namespace Electroform_Lite.Models;

internal class PDFDocument : Document
{
    public override void Export()
    {
        Console.WriteLine("Export PDF Document");
    }

    public void Export(string watermark)
    {
        Console.WriteLine($"Export PDF Document with watermark: {watermark}");
    }
}
