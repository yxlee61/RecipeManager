using System;
using System.Collections.Generic;
using System.IO;
using RecipeManager.Models;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace RecipeManager.Helpers
{
  public class LabelGenerator
  {

    //public void LabelGenerator(LabelProperties prop, Size sizeInfo)
    //{
    //  // generate label
    //}

    private void drawTemplate(string color)
    {
      color = color.ToLower();
      CMYKColor chosenColor;
      switch (color)
      {
        case ("yellow"):
          chosenColor = new CMYKColor(0f, 0.2092f, 0.7741f, 0.0627f);
          break;
        case ("red"):
          chosenColor = new CMYKColor(0f, 0.7564f, 0.7372f, 0.3882f);
          break;
        case ("purple"):
          chosenColor = new CMYKColor(0.5118f, 0.6693f, 0f, 0.5020f);
          break;
        default:
          chosenColor = new CMYKColor(0f, 0f, 0f, 0f);
          break;
      }
      
      
    }
  }
}