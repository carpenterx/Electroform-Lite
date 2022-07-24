using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electroform_Lite.Models;

internal class SealedPDFDocument : PDFDocument
{
    public sealed override void Export()
    {
        Console.WriteLine("Export Sealed PDF Document");
    }
}
