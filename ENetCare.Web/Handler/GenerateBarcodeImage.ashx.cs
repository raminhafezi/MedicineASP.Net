﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace ENetPlay.Handler
{
    /// <summary>
    /// Summary description for GenerateBarcodeImage
    /// </summary>
    public class GenerateBarcodeImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string strData = context.Request.QueryString["d"];
            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE11;
            const int height = 150;
            const int width = 400;

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            b.IncludeLabel = true;
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            System.Drawing.Image barcodeImage = null;

            barcodeImage = b.Encode(type, strData.Trim(), System.Drawing.ColorTranslator.FromHtml("#000000"), System.Drawing.ColorTranslator.FromHtml("#FFFFFF"), width, height);

            context.Response.ContentType = "image/gif";
            System.IO.MemoryStream MemStream = new System.IO.MemoryStream(); 

            barcodeImage.Save(MemStream, ImageFormat.Gif);
            MemStream.WriteTo(context.Response.OutputStream);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}