using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace System.Drawing
{
    public static class Draw
    {
        #region EN_ClearArea
        public enum EN_ClearArea
        {
            NONE,
            BORDERAREA,
            BORDERALL,
            AREA,
            ALL
        }
        #endregion

        #region WrapTextToGraphics
        public static void WrapTextToGraphics(this Graphics g, string text, Font font, Size _sizeArea, Color ClearAreaBackColor, EN_ClearArea ClearArea, Brush ForeColor)
        {
            g.WrapTextToGraphics(text, font, _sizeArea, ClearAreaBackColor, ClearArea, ForeColor, 0);
        }
        public static void WrapTextToGraphics(this Graphics g, string text, Font font, Size _sizeArea, Color ClearAreaBackColor, EN_ClearArea ClearArea, Brush ForeColor, int padAll)
        {
            g.WrapTextToGraphics(text, font, _sizeArea, ClearAreaBackColor, ClearArea, ForeColor, padAll, padAll, padAll, padAll);
        }
        public static void WrapTextToGraphics(this Graphics g, string text, Font font, Size _sizeArea, Color ClearAreaBackColor, EN_ClearArea ClearArea, Brush ForeColor, int padLeft, int padRight, int padTop, int padBottom)
        {
            switch (ClearArea)
            {
                case EN_ClearArea.AREA:
                    g.FillRectangle(new SolidBrush(ClearAreaBackColor), padLeft, padTop, _sizeArea.Width - padRight, _sizeArea.Height - padBottom);
                    break;
                case EN_ClearArea.BORDERAREA:
                    g.DrawRectangle(new Pen(ClearAreaBackColor), padLeft, padTop, _sizeArea.Width - padRight, _sizeArea.Height - padBottom);
                    break;
                case EN_ClearArea.BORDERALL:
                    g.Clear(ClearAreaBackColor);
                    g.DrawRectangle(new Pen(ClearAreaBackColor), 0, 0, _sizeArea.Width, _sizeArea.Height);
                    break;
                case EN_ClearArea.ALL:
                    g.Clear(ClearAreaBackColor);
                    break;
                case EN_ClearArea.NONE:
                default:
                    break;
            }
            g.DrawString(text.WrapTextToText(font, _sizeArea,  padLeft,  padRight,  padTop,  padBottom).ToString(), font, ForeColor, new PointF(padLeft, padTop));
        }
        #endregion

        #region WrapTextToText
        public static StringBuilder WrapTextToText(this string text, Font font, Size _sizeArea)
        {
            return WrapTextToText(text, font, _sizeArea, 0);
        }
        public static StringBuilder WrapTextToText(this string text, Font font, Size _sizeArea, int padAll)
        {
            return WrapTextToText(text, font, _sizeArea, padAll, padAll, padAll, padAll);
        }
        public static StringBuilder WrapTextToText(this string text, Font font, Size _sizeArea, int padLeft, int padRight, int padTop, int padBottom)
        {
            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    List<string> originalLines = text.Split(new[] { " " }, StringSplitOptions.None).ToList();

                    _sizeArea = new Size(_sizeArea.Width - (padLeft + padRight), _sizeArea.Height - (padTop + padBottom));
                    var wrapBuilder = new StringBuilder();
                    StringBuilder wrapBuilderMevcut;

                    float MevcutSatirGenislik = 0;
                    float itemGenislik = 0;

                    for (int i = 0; i < originalLines.Count; i++)
                    {
                        if (MevcutSatirGenislik == 0)
                        {
                            itemGenislik = g.MeasureString(originalLines[i], font).Width;
                        }
                        else
                        {
                            itemGenislik = g.MeasureString(" " + originalLines[i], font).Width;
                        }

                        if (itemGenislik + MevcutSatirGenislik <= _sizeArea.Width)
                        {
                            if (MevcutSatirGenislik == 0)
                            {
                                #region Harf Harf Arama Yap Kelime Sığmıyorsa
                                if (itemGenislik > _sizeArea.Width)
                                {
                                    wrapBuilderMevcut = new StringBuilder();
                                    for (int j = 0; j < originalLines[i].Length; j++)
                                    {
                                        if (g.MeasureString(wrapBuilderMevcut.ToString() + originalLines[i][j], font).Width > _sizeArea.Width)
                                        {
                                            string gec = originalLines[i];
                                            originalLines[i] = wrapBuilder.ToString();
                                            originalLines.Insert(i, gec.Substring(j));
                                            break;
                                        }
                                        wrapBuilderMevcut.Append(originalLines[i][j]);
                                    }
                                    i--;
                                    continue;
                                }
                                #endregion

                                #region Kelime Sığıyorsa Ekle
                                else
                                {
                                    wrapBuilder.Append(originalLines[i]);
                                }
                                #endregion
                            }
                            else
                            {
                                wrapBuilder.Append(" " + originalLines[i]);
                            }

                            MevcutSatirGenislik += itemGenislik;
                        }
                        else
                        {
                            if (g.MeasureString(wrapBuilder + Environment.NewLine + "...", font).Height > _sizeArea.Height)
                            {
                                wrapBuilder.Append("...");
                                break;
                            }

                            if (MevcutSatirGenislik == 0)
                            {
                                #region Harf Harf Arama Yap Kelime Sığmıyorsa
                                if (itemGenislik > _sizeArea.Width)
                                {
                                    wrapBuilderMevcut = new StringBuilder();
                                    for (int j = 0; j < originalLines[i].Length; j++)
                                    {
                                        if (g.MeasureString(wrapBuilderMevcut.ToString() + originalLines[i][j], font).Width > _sizeArea.Width)
                                        {
                                            string gec = originalLines[i];
                                            originalLines[i] = gec.Substring(0, j);
                                            originalLines.Insert(i + 1, gec.Substring(j));
                                            break;
                                        }
                                        wrapBuilderMevcut.Append(originalLines[i][j]);
                                    }
                                    i--;
                                    continue;
                                }
                                #endregion

                                #region Kelime Sığıyorsa Ekle
                                else
                                {
                                    wrapBuilder.Append(originalLines[i]);
                                }
                                #endregion
                            }

                            MevcutSatirGenislik = 0;

                            wrapBuilder.AppendLine();
                            i--;
                        }
                    }

                    return wrapBuilder;
                }
            }
        }
        #endregion

        #region WrapTextToList
        public static List<List<string>> WrapTextToList(this string text, Font font, Size _sizeArea)
        {
            return WrapTextToList(text, font, _sizeArea, 0);
        }
        public static List<List<string>> WrapTextToList(this string text, Font font, Size _sizeArea, int padAll)
        {
            return WrapTextToList(text, font, _sizeArea, padAll, padAll, padAll, padAll);
        }
        public static List<List<string>> WrapTextToList(this string text, Font font, Size _sizeArea, int padLeft, int padRight, int padTop, int padBottom, string splitStr = " ")
        {
            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    List<string> originalLines = text.Split(new string[] { splitStr }, StringSplitOptions.None).ToList();
                    List<List<string>> newLines = new List<List<string>>();
                    bool newLineActive = true;

                    _sizeArea = new Size(_sizeArea.Width - (padLeft + padRight), _sizeArea.Height - (padTop + padBottom));
                    var wrapBuilder = new StringBuilder();
                    StringBuilder wrapBuilderMevcut;

                    float MevcutSatirGenislik = 0;
                    float itemGenislik = 0;

                    for (int i = 0; i < originalLines.Count; i++)
                    {
                        if (MevcutSatirGenislik == 0)
                        {
                            itemGenislik = g.MeasureString(originalLines[i], font).Width;
                        }
                        else
                        {
                            itemGenislik = g.MeasureString(" " + originalLines[i], font).Width;
                        }

                        if (itemGenislik + MevcutSatirGenislik <= _sizeArea.Width)
                        {
                            if (MevcutSatirGenislik == 0)
                            {
                                #region Harf Harf Arama Yap Kelime Sığmıyorsa
                                if (itemGenislik > _sizeArea.Width)
                                {
                                    wrapBuilderMevcut = new StringBuilder();
                                    for (int j = 0; j < originalLines[i].Length; j++)
                                    {
                                        if (g.MeasureString(wrapBuilderMevcut.ToString() + originalLines[i][j], font).Width > _sizeArea.Width)
                                        {
                                            string gec = originalLines[i];
                                            originalLines[i] = wrapBuilder.ToString();
                                            originalLines.Insert(i, gec.Substring(j));
                                            break;
                                        }
                                        wrapBuilderMevcut.Append(originalLines[i][j]);
                                    }
                                    i--;
                                    continue;
                                }
                                #endregion

                                #region Kelime Sığıyorsa Ekle
                                else
                                {
                                    if (newLineActive)
                                    {
                                        newLines.Add(new List<string>());
                                        newLineActive = false;
                                    }
                                    newLines[newLines.Count - 1].Add(originalLines[i]);
                                    wrapBuilder.Append(originalLines[i]);
                                }
                                #endregion
                            }
                            else
                            {
                                if (newLineActive)
                                {
                                    newLines.Add(new List<string>());
                                    newLineActive = false;
                                }
                                newLines[newLines.Count - 1].Add(originalLines[i]);
                                wrapBuilder.Append(" " + originalLines[i]);
                            }

                            MevcutSatirGenislik += itemGenislik;
                        }
                        else
                        {
                            if (g.MeasureString(wrapBuilder + Environment.NewLine + "new line ...", font).Height > _sizeArea.Height)
                            {
                                if (newLineActive)
                                {
                                    newLines.Add(new List<string>());
                                    newLineActive = false;
                                }
                                newLines[newLines.Count - 1].Add("...");
                                wrapBuilder.Append("...");
                                break;
                            }

                            if (MevcutSatirGenislik == 0)
                            {
                                #region Harf Harf Arama Yap Kelime Sığmıyorsa
                                if (itemGenislik > _sizeArea.Width)
                                {
                                    wrapBuilderMevcut = new StringBuilder();
                                    for (int j = 0; j < originalLines[i].Length; j++)
                                    {
                                        if (g.MeasureString(wrapBuilderMevcut.ToString() + originalLines[i][j], font).Width > _sizeArea.Width)
                                        {
                                            string gec = originalLines[i];
                                            originalLines[i] = gec.Substring(0, j);
                                            originalLines.Insert(i + 1, gec.Substring(j));
                                            break;
                                        }
                                        wrapBuilderMevcut.Append(originalLines[i][j]);
                                    }
                                    i--;
                                    continue;
                                }
                                #endregion

                                #region Kelime Sığıyorsa Ekle
                                else
                                {
                                    if (newLineActive)
                                    {
                                        newLines.Add(new List<string>());
                                        newLineActive = false;
                                    }
                                    newLines[newLines.Count - 1].Add(originalLines[i]);
                                    wrapBuilder.Append(originalLines[i]);
                                }
                                #endregion
                            }

                            MevcutSatirGenislik = 0;

                            newLineActive = true;
                            wrapBuilder.AppendLine();
                            i--;
                        }
                    }

                    return newLines;
                }
            }
        }
        #endregion

        #region Fon_MeasureString
        public static SizeF Fon_MeasureString(this string s, Font font)
        {
            SizeF result;
            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    result = g.MeasureString(s, font);
                }
            }

            return result;
        }

        public static SizeF Fon_MeasureString(this Font font, string s)
        {
            SizeF result;
            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    result = g.MeasureString(s, font);
                }
            }

            return result;
        }
        #endregion
    }
}