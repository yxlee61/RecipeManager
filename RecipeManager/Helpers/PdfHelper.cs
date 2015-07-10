using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace RecipeManager.Helpers
{
  public class PdfHelper
  {

    public static string ExtractText(string fileName)
    {
      PdfReader reader = new PdfReader(fileName);
      string text = PdfTextExtractor.GetTextFromPage(reader, 1);

      return text;
    }

    public static void Create(string originalFile)
    {
      string[] delimiters = { "." };
      string[] tokens = originalFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
      string copyFile = tokens[0] + "-copy." + tokens[1];
      //string copyFile = "C:\\Users\\Yan Xin\\documents\\visual studio 2013\\Projects\\RecipeManager\\RecipeManager\\Test\\label1-copy.pdf";

      using (FileStream fs = new FileStream(originalFile, FileMode.Create, FileAccess.Write, FileShare.None))
      using (Document doc = new Document(PageSize.LETTER))
      using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
      {
        doc.Open();
        doc.Add(new Paragraph("Hi! I'm Original"));
        doc.Close();
      }

      PdfReader reader = new PdfReader(originalFile);
      using (FileStream fs = new FileStream(copyFile, FileMode.Create, FileAccess.Write, FileShare.None))
      using (PdfStamper stamper = new PdfStamper(reader, fs)) { }

    }

    public static void Watermark(string originalFile, string watermarked)
    {
      int page = 1;

      PdfReader reader = new PdfReader(originalFile);
      using (FileStream fs = new FileStream(watermarked, FileMode.Create, FileAccess.Write, FileShare.None))
      using (PdfStamper stamper = new PdfStamper(reader, fs))
      {
        PdfLayer layer = new PdfLayer("Text", stamper.Writer);

        Rectangle rect = reader.GetPageSize(page);
        PdfContentByte cb = stamper.GetOverContent(page);

        

        cb.EndLayer();
      }
    }

    public static void ResetMacrosDetails(string originalFile, string watermarked)
    {
      int page = 1;

      PdfReader reader = new PdfReader(originalFile);
      using (FileStream fs = new FileStream(watermarked, FileMode.Create, FileAccess.Write, FileShare.None))
      using (PdfStamper stamper = new PdfStamper(reader, fs))
      {
        PdfLayer layer = new PdfLayer("Text", stamper.Writer);

        Rectangle rect = reader.GetPageSize(page);
        PdfContentByte cb = stamper.GetOverContent(page);

        CMYKColor color = new CMYKColor(0f, 0f, 0f, 0f);
        cb.SetColorFill(color);
        cb.SetColorStroke(color);

        cb.BeginLayer(layer);

        double startHeight = rect.Height - 85;
        double height = 48;

        cb.MoveTo(0, startHeight);
        cb.LineTo(rect.Width, startHeight);
        cb.LineTo(rect.Width, startHeight - height);
        cb.LineTo(0, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = rect.Height - 143;
        double startWidth = rect.Width - 85;

        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(rect.Width, startHeight);
        cb.LineTo(rect.Width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = rect.Height - 150;
        double width = 65;
        height = 7;
        startWidth = 5;
        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = rect.Height - 179.5;
        height = 3;
        width = 4;
        startWidth = 115;

        for (int i = 0; i < 7; i++)
        {
          cb.MoveTo(startWidth, startHeight);
          cb.LineTo(startWidth + width, startHeight);
          cb.LineTo(startWidth + width, startHeight - height);
          cb.LineTo(startWidth, startHeight - height);
          cb.ClosePathFillStroke();

          startHeight = startHeight - 5.5;
        }

        startHeight = startHeight - 13;
        height = 2.7;

        for (int i = 0; i < 4; i++)
        {
          cb.MoveTo(startWidth, startHeight);
          cb.LineTo(startWidth + width, startHeight);
          cb.LineTo(startWidth + width, startHeight - height);
          cb.LineTo(startWidth, startHeight - height);
          cb.ClosePathFillStroke();

          startHeight = startHeight - 5.5;
        }


        cb.EndLayer();
      }
    }

    public static void ResetMacros(string originalFile, string watermarked)
    {
      int page = 1;

      PdfReader reader = new PdfReader(originalFile);
      using (FileStream fs = new FileStream(watermarked, FileMode.Create, FileAccess.Write, FileShare.None))
      using (PdfStamper stamper = new PdfStamper(reader, fs))
      {
        PdfLayer layer = new PdfLayer("Text", stamper.Writer);

        Rectangle rect = reader.GetPageSize(page);
        PdfContentByte cb = stamper.GetOverContent(page);

        CMYKColor color = new CMYKColor(0f, 0f, 0f, 0f);
        cb.SetColorFill(color);
        cb.SetColorStroke(color);

        cb.BeginLayer(layer);

        double mealLabelStartHeight = rect.Height - 30;
        double mealLabelHeight = 8;
        double mealLabelStartWidth = rect.Width / 3;
        double mealLabelWidth = 120;

        cb.MoveTo(mealLabelStartWidth, mealLabelStartHeight);
        cb.LineTo(mealLabelStartWidth + mealLabelWidth, mealLabelStartHeight);
        cb.LineTo(mealLabelStartWidth + mealLabelWidth, mealLabelStartHeight - mealLabelHeight);
        cb.LineTo(mealLabelStartWidth, mealLabelStartHeight - mealLabelHeight);
        cb.ClosePathFillStroke();

        double macrosStartHeight = rect.Height - 55;
        double macrosStartWidth = rect.Width / 3 + 5;
        double macrosWidth = 20;
        double macrosHeight = 10;

        for (int i = 0; i < 4; i++)
        {
          cb.MoveTo(macrosStartWidth, macrosStartHeight);
          cb.LineTo(macrosStartWidth + macrosWidth, macrosStartHeight);
          cb.LineTo(macrosStartWidth + macrosWidth, macrosStartHeight - macrosHeight);
          cb.LineTo(macrosStartWidth, macrosStartHeight - macrosHeight);
          cb.ClosePathFillStroke();

          macrosStartWidth = macrosStartWidth + macrosWidth + 13;
        }
        // Close the layer
        cb.EndLayer();
      }
    }

    public static void ResetBackgroundColor(string originalFile, string watermarked, string color)
    {
      int page = 1;

      PdfReader reader = new PdfReader(originalFile);
      using (FileStream fs = new FileStream(watermarked, FileMode.Create, FileAccess.Write, FileShare.None))
      using (PdfStamper stamper = new PdfStamper(reader, fs))
      {
        PdfLayer layer = new PdfLayer("BackgroundColor", stamper.Writer);

        Rectangle rect = reader.GetPageSize(page);
        PdfContentByte cb = stamper.GetOverContent(page);

        cb.BeginLayer(layer);

        // set color
        CMYKColor chosenColor;
        CMYKColor green = new CMYKColor(0.0809f, 0f, 0.1915f, 0.0784f); //TO DO: get green color

        // set template color
        if (color.Equals("yellow", StringComparison.OrdinalIgnoreCase))
        {
          chosenColor = new CMYKColor(0f, 0.2092f, 0.7741f, 0.0627f);
        }
        else if (color.Equals("red", StringComparison.OrdinalIgnoreCase))
        {
          chosenColor = new CMYKColor(0f, 0.7564f, 0.7372f, 0.3882f);
        }
        else if (color.Equals("purple", StringComparison.OrdinalIgnoreCase))
        {
          chosenColor = new CMYKColor(0.5118f, 0.6693f, 0f, 0.5020f);
        }
        else
        {
          chosenColor = new CMYKColor(0f, 0f, 0f, 0f);
        }

        cb.SetColorFill(chosenColor);
        cb.SetColorStroke(chosenColor);

        // draw name label
        double widthDiff = 23;
        double startHeight = rect.Height - 3;
        double midHeight = rect.Height - 18;
        double endHeight = rect.Height - 27;
        double startWidth = rect.Width * 1 / 3;
        double firstMidWidth = startWidth + widthDiff;
        double endWidth = rect.Width;
        double secondMidWidth = endWidth - widthDiff;

        cb.MoveTo(rect.Width * 1 / 3, startHeight);
        cb.LineTo(rect.Width, startHeight);
        cb.LineTo(rect.Width, midHeight);
        cb.CurveTo(secondMidWidth + (endWidth - secondMidWidth) / 1.4, endHeight + (midHeight - endHeight) / 4, secondMidWidth, endHeight);
        cb.LineTo(firstMidWidth, endHeight);
        cb.CurveTo(firstMidWidth - (firstMidWidth - startWidth) / 1.4, endHeight + (midHeight - endHeight) / 4, startWidth, midHeight);
        cb.ClosePathFillStroke();

        // reset flag 
        cb.SetColorFill(green);
        cb.SetColorStroke(green);

        startHeight = endHeight - 0.5;
        double heightDiff = 8.5;
        widthDiff = 13;

        cb.MoveTo(endWidth - widthDiff, startHeight);
        cb.LineTo(endWidth, startHeight);
        cb.LineTo(endWidth, startHeight - heightDiff);
        cb.LineTo(endWidth - widthDiff, startHeight - heightDiff);
        cb.ClosePathFillStroke();

        startHeight = startHeight - heightDiff - 2;
        cb.MoveTo(endWidth - widthDiff, startHeight);
        cb.LineTo(endWidth, startHeight);
        cb.LineTo(endWidth, startHeight - heightDiff);
        cb.LineTo(endWidth - widthDiff, startHeight - heightDiff);
        cb.ClosePathFillStroke();

        startHeight = startHeight - heightDiff - 2;
        cb.MoveTo(endWidth - widthDiff, startHeight);
        cb.LineTo(endWidth, startHeight);
        cb.LineTo(endWidth, startHeight - heightDiff);
        cb.LineTo(endWidth - widthDiff, startHeight - heightDiff);
        cb.ClosePathFillStroke();

        double mealLabelStartHeight = rect.Height - 30;
        double mealLabelHeight = 8;
        double mealLabelStartWidth = rect.Width / 3;
        double mealLabelWidth = 120;

        cb.MoveTo(mealLabelStartWidth, mealLabelStartHeight);
        cb.LineTo(mealLabelStartWidth + mealLabelWidth, mealLabelStartHeight);
        cb.LineTo(mealLabelStartWidth + mealLabelWidth, mealLabelStartHeight - mealLabelHeight);
        cb.LineTo(mealLabelStartWidth, mealLabelStartHeight - mealLabelHeight);
        cb.ClosePathFillStroke();

        double macrosStartHeight = rect.Height - 55;
        double macrosStartWidth = rect.Width / 3 + 5;
        double macrosWidth = 20;
        double macrosHeight = 10;

        for (int i = 0; i < 4; i++)
        {
          cb.MoveTo(macrosStartWidth, macrosStartHeight);
          cb.LineTo(macrosStartWidth + macrosWidth, macrosStartHeight);
          cb.LineTo(macrosStartWidth + macrosWidth, macrosStartHeight - macrosHeight);
          cb.LineTo(macrosStartWidth, macrosStartHeight - macrosHeight);
          cb.ClosePathFillStroke();

          macrosStartWidth = macrosStartWidth + macrosWidth + 13;
        }

        // Close the layer
        cb.EndLayer();
      }
    }

    

    public static string FontExtraction(string originalFile)
    {
      PdfReader reader = new PdfReader(originalFile);
      TextWithFontExtractionStrategy strategy = new TextWithFontExtractionStrategy();
      string output = PdfTextExtractor.GetTextFromPage(reader, 1, strategy);

      return output;
    }

  }
}