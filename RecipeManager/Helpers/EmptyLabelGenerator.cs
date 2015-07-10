using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace RecipeManager.Helpers
{
  public class EmptyLabelGenerator
  {
    public static double[] CreateEmptyLabel(string originalFile, string watermarked)
    {
      int page = 1;
      double[] dimensions = new double[2];

      PdfReader reader = new PdfReader(originalFile);
      using (FileStream fs = new FileStream(watermarked, FileMode.Create, FileAccess.Write, FileShare.None))
      using (PdfStamper stamper = new PdfStamper(reader, fs))
      {
        PdfLayer layer = new PdfLayer("BackgroundColor", stamper.Writer);

        Rectangle rect = reader.GetPageSize(page);
        PdfContentByte cb = stamper.GetOverContent(page);

        cb.BeginLayer(layer);

        CMYKColor green = new CMYKColor(0.0809f, 0f, 0.1915f, 0.0784f); //TO DO: get green color
        CMYKColor white = new CMYKColor(0f, 0f, 0f, 0f);
        cb.SetColorFill(white);
        cb.SetColorStroke(white);

        // draw name label
        double widthDiff = 23;
        double startHeight = rect.Height - 3;
        double midHeight = rect.Height - 18;
        double endHeight = rect.Height - 27;
        double startWidth = rect.Width * 1 / 3;
        double firstMidWidth = startWidth + widthDiff;
        double endWidth = rect.Width;
        double secondMidWidth = endWidth - widthDiff;

        dimensions[0] = rect.Width;
        dimensions[1] = rect.Height;

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

        cb.SetColorFill(white);
        cb.SetColorStroke(white);

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

        startHeight = rect.Height - 85;
        double height = 48;

        cb.MoveTo(0, startHeight);
        cb.LineTo(rect.Width, startHeight);
        cb.LineTo(rect.Width, startHeight - height);
        cb.LineTo(0, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = rect.Height - 143;
        startWidth = rect.Width - 85;

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
        height = 3.2;
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

        startHeight = rect.Height - 179.5;
        height = 3.23;
        width = 17;
        startWidth = 25;

        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = startHeight - 5.5;
        startWidth = 37;

        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = startHeight - 5.5;
        startWidth = 29;

        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = startHeight - 5.5;
        startWidth = 32;
        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = startHeight - 5.5;
        startWidth = 24;

        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = startHeight - 5.5;
        startWidth = 51;

        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = startHeight - 5.5;
        startWidth = 36;

        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = startHeight - 5.5;
        startWidth = 23;

        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = startHeight - 5.5;
        startWidth = 22;

        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        startHeight = rect.Height - 167;
        height = 3;
        width = 17;
        startWidth = 25;

        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        width = 12;
        startWidth = 112;

        cb.MoveTo(startWidth, startHeight);
        cb.LineTo(startWidth + width, startHeight);
        cb.LineTo(startWidth + width, startHeight - height);
        cb.LineTo(startWidth, startHeight - height);
        cb.ClosePathFillStroke();

        cb.EndLayer();
      }
      return dimensions;
    }

  }
}