﻿using BookstoreApp.Services.Providers.Contracts;
using BookstoreApp.Services.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookstoreApp.Services.Providers
{
    public class PDFExporter : IPDFExporter
    {
        public void ExportOrders(IEnumerable<OrderViewModel> orders)
        {
            string date = ($"y{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}" +
                           $"h{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.pdf");

            string fileName = $"D:\\OrderReport{date}";

            FileStream fs = new FileStream(fileName, FileMode.Create);
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.AddSubject("Customer Orders");

            document.Open();
            document.Add(new Paragraph("Completed Orders:"));
            document.Add(new Paragraph(Environment.NewLine));

            if (!orders.Any())
            {
                document.Add(new Paragraph("There are no completed orders"));

            }
            else
            {
                foreach (var order in orders)
                {
                    document.Add(new Paragraph($"Client: {order.Username}\nClient name: {order.FirstName + " " + order.LastName}\nDate of order: {order.ReceivedOrderTime}\n"));
                    decimal totalPrice = 0;
                    foreach (var book in order.Books)
                    {
                        totalPrice += book.Price;
                        document.Add(new Paragraph($"Title: {book.Title}\nPrice: {book.Price}"));
                        document.Add(new Paragraph(Environment.NewLine));
                    }

                    document.Add(new Paragraph($"Total Price: {totalPrice} $"));
                    document.Add(new Paragraph(Environment.NewLine));
                }
            }

            document.Close();
            writer.Close();
            fs.Close();
        }
    }
}
