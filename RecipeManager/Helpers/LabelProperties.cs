using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace RecipeManager.Helpers
{
  public class LabelProperties
  {

    //template coordinates
    //recipe name fontInfo
    //recipe name coordinates
    //type fontInfo
    //type coordinates
    //macro recipe/size fontInfo
    //macro recipe/size coordinates
    //macros fontInfo
    //macros coordinates


  }

  public class FontInfo
  {
    public double FontSize { get; set; }
    public string FontType { get; set; }
    public string FontEncoding { get; set; }
  }
}