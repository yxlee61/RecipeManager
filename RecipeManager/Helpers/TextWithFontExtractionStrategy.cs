﻿using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;

namespace RecipeManager.Helpers
{
  public class TextWithFontExtractionStrategy : ITextExtractionStrategy
  {

    private StringBuilder result = new StringBuilder();

    private Vector lastBaseLine;
    private string lastFont;
    private float lastFontSize;

    private enum TextRenderMode
    {
      FillText = 0,
      StrokeText = 1,
      FillThenStrokeText = 2,
      Invisible = 3,
      FillTextAndAddToPathForClipping = 4,
      StrokeTextAndAddToPathForClipping = 5,
      FillThenStrokeTextAndAddToPathForClipping = 6,
      AddTextToPaddForClipping = 7
    }

    public void RenderText(iTextSharp.text.pdf.parser.TextRenderInfo renderInfo)
    {
      string curFont = renderInfo.GetFont().PostscriptFontName;
      //Check if faux bold is used
      if ((renderInfo.GetTextRenderMode() == (int)TextRenderMode.FillThenStrokeText))
      {
        curFont += "-Bold";
      }

      //This code assumes that if the baseline changes then we're on a newline
      Vector curBaseline = renderInfo.GetBaseline().GetStartPoint();
      Vector topRight = renderInfo.GetAscentLine().GetEndPoint();
      iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(curBaseline[Vector.I1], curBaseline[Vector.I2], topRight[Vector.I1], topRight[Vector.I2]);
      Single curFontSize = rect.Height;

      //See if something has changed, either the baseline, the font or the font size
      if ((this.lastBaseLine == null) || (curBaseline[Vector.I2] != lastBaseLine[Vector.I2]) || (curFontSize != lastFontSize) || (curFont != lastFont))
      {
        //if we've put down at least one span tag close it
        if ((this.lastBaseLine != null))
        {
          this.result.AppendLine("</span>");
        }
        //If the baseline has changed then insert a line break
        if ((this.lastBaseLine != null) && curBaseline[Vector.I2] != lastBaseLine[Vector.I2])
        {
          this.result.AppendLine("<br />");
        }
        //Create an HTML tag with appropriate styles
        this.result.AppendFormat("<span style=\"font-family:{0};font-size:{1}\">", curFont, curFontSize);
      }

      //Append the current text
      this.result.Append(renderInfo.GetText());

      //Set currently used properties
      this.lastBaseLine = curBaseline;
      this.lastFontSize = curFontSize;
      this.lastFont = curFont;
    }

    public string GetResultantText()
    {
      //If we wrote anything then we'll always have a missing closing tag so close it here
      if (result.Length > 0)
      {
        result.Append("</span>");
      }
      return result.ToString();
    }

    //Not needed
    public void BeginTextBlock() { }
    public void EndTextBlock() { }
    public void RenderImage(ImageRenderInfo renderInfo) { }
  }

}