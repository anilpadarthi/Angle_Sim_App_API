using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SIMAPI.Data.Models.OrderListModels;

namespace SIMAPI.Business.Helper.PDF
{
    public class PDFInvoice
    {

        //public byte[] GenerateInvoice(InvoiceDetailModel invoiceDetailModel, bool IsVATInvoice)
        //{
        //    QuestPDF.Settings.License = LicenseType.Community;
        //    var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images", "logo.png");
        //    var logoBytes = File.ReadAllBytes(logoPath);
        //    return Document.Create(container =>
        //    {
        //        container.Page(page =>
        //        {
        //            page.Size(PageSizes.A4);
        //            page.Margin(30);
        //            page.DefaultTextStyle(x => x.FontSize(10));

        //            if (IsVATInvoice)
        //            {
        //                page.Header().Row(row =>
        //                {

        //                    //row.ConstantItem(120).Height(60).Image(logoBytes);
        //                    row.RelativeItem().Column(col =>
        //                    {
        //                        col.Item().Text("Angle Sims").Bold().FontSize(14);
        //                    });

        //                    row.RelativeItem().Column(col =>
        //                    {
        //                        col.Item().Text("Angles Solutions Pvt. Limited").Bold().FontSize(14);
        //                        col.Item().Text("Unit 7, Manor Way Industrial Estate");
        //                        col.Item().Text("Curzon Drive, RM17 6BG");
        //                    });
        //                });
        //            }

        //            // **Header Section**
        //            //page.Header().Column(col =>
        //            //{
        //            //    col.Item().Table(table =>
        //            //    {
        //            //        table.ColumnsDefinition(columns =>
        //            //        {
        //            //            columns.RelativeColumn(300);
        //            //            columns.RelativeColumn(300);
        //            //        });

        //            //        if (IsVATInvoice)
        //            //        {
        //            //            table.Cell().Element(cell =>
        //            //            {
        //            //                cell.Border(0).Padding(0).Text("Leap").AlignLeft().FontSize(12).FontColor(Colors.Red.Medium);
        //            //            });
        //            //        }
        //            //        else
        //            //        {
        //            //            table.Cell().Element(cell =>
        //            //            {
        //            //                cell.Border(0).Padding(0).Text(invoiceDetailModel.OrderPaymentType).AlignLeft().FontSize(12).FontColor(Colors.Red.Medium);
        //            //            });
        //            //        }
        //            //        table.Cell().Element(cell =>
        //            //        {
        //            //            cell.Border(0).Padding(0).Text("INVOICE: INV" + invoiceDetailModel.OrderId).FontSize(12).AlignRight().FontColor(Colors.Red.Medium);
        //            //        });
        //            //    });

        //            //    col.Item().AlignRight().Text("Order ID: 100" + invoiceDetailModel.OrderId);
        //            //    col.Item().AlignRight().Text("Date: " + invoiceDetailModel.CreatedDate.ToString("MMMM dd yyyy"));
        //            //    col.Item().AlignRight().Text(invoiceDetailModel.OrderPaymentType);
        //            //    col.Item().AlignRight().Text(invoiceDetailModel.UserName + "/" + invoiceDetailModel.AreaName);

        //            //    //row.ConstantItem(100).Image("logo.png", ImageScaling.FitWidth); // Add logo
        //            //});

        //            page.Content().Column(col =>
        //            {
        //                // Header
        //                col.Item().ShowOnce().Table(table =>
        //                {
        //                    table.ColumnsDefinition(columns =>
        //                    {
        //                        columns.RelativeColumn(300);
        //                        columns.RelativeColumn(300);
        //                    });


        //                    table.Cell().Element(cell =>
        //                    {
        //                        cell.Border(0).Padding(0).Text(invoiceDetailModel.OrderPaymentType).AlignLeft().FontSize(14).Bold();
        //                    });

        //                    table.Cell().Element(cell =>
        //                    {
        //                        cell.Border(0).Padding(0).Text("INV" + invoiceDetailModel.OrderId).FontSize(14).Bold().AlignRight();
        //                    });
        //                });

        //                //col.Item().ShowOnce().AlignRight().Text("Order ID: 100" + invoiceDetailModel.OrderId);
        //                col.Item().ShowOnce().PaddingTop(5).AlignRight().Text(invoiceDetailModel.CreatedDate.ToString("MMMM dd yyyy"));
        //                //col.Item().ShowOnce().PaddingTop(5).AlignRight().Text(invoiceDetailModel.OrderPaymentType);
        //                col.Item().ShowOnce().PaddingTop(5).AlignRight().Text(invoiceDetailModel.UserName + "/" + invoiceDetailModel.AreaName);

        //                // Line seperator
        //                col.Item().ShowOnce().PaddingTop(10).PaddingBottom(10).LineHorizontal(1).LineColor(Colors.Black);

        //                if (!IsVATInvoice)
        //                {
        //                    col.Item().PaddingBottom(10).AlignCenter().Text("DELIVERY NOTE").Bold().FontSize(14);
        //                }

        //                col.Item().Table(table =>
        //                {
        //                    table.ColumnsDefinition(columns =>
        //                    {
        //                        columns.RelativeColumn(300); // Customer Details
        //                        if (IsVATInvoice)
        //                        {
        //                            columns.RelativeColumn(300);   // Seller Details
        //                        }
        //                    });


        //                    table.Header(header =>
        //                    {
        //                        header.Cell().Element(CellNoBorderStyle).Border(0).Text("Shop ID: " + (invoiceDetailModel.OldShopId ?? invoiceDetailModel.ShopId)).Bold();
        //                        if (IsVATInvoice)
        //                        {
        //                            header.Cell().Element(CellNoBorderStyle).Border(0).Text("Seller ").Bold();
        //                        }
        //                    });

        //                    table.Cell().Element(cell =>
        //                    {
        //                        cell.Table(innerTable =>
        //                        {
        //                            innerTable.ColumnsDefinition(innerColumns =>
        //                            {
        //                                innerColumns.RelativeColumn();  // Define a single column for customer details
        //                            });
        //                            innerTable.Cell().Element(CellNoBorderStyle).Border(0).Text(invoiceDetailModel.ShopName);
        //                            innerTable.Cell().Element(CellNoBorderStyle).Border(0).Text(invoiceDetailModel.ContactName);
        //                            innerTable.Cell().Element(CellNoBorderStyle).Border(0).Text(invoiceDetailModel.ShippingAddress);
        //                            innerTable.Cell().Element(CellNoBorderStyle).Border(0).Text(invoiceDetailModel.ShopEmail);
        //                            innerTable.Cell().Element(CellNoBorderStyle).Border(0).Text(invoiceDetailModel.PhoneNumber);
        //                        });
        //                    });
        //                    if (IsVATInvoice)
        //                    {
        //                        table.Cell().Element(cell =>
        //                        {
        //                            cell.Table(innerTable =>
        //                            {
        //                                innerTable.ColumnsDefinition(innerColumns =>
        //                                {
        //                                    innerColumns.RelativeColumn();  // Define a single column for customer details
        //                                });
        //                                innerTable.Cell().Element(CellNoBorderStyle).Border(0).Text("Angles Solutions Pvt. Limited").Bold();
        //                                innerTable.Cell().Element(CellNoBorderStyle).Border(0).Text("Unit 7, Manor Way Industrial Estate");
        //                                innerTable.Cell().Element(CellNoBorderStyle).Border(0).Text("Curzon Drive, RM17 6BG");
        //                            });
        //                        });
        //                    }
        //                });


        //                // **Table Section**
        //                col.Item().PaddingTop(5).Table(table =>
        //                {
        //                    table.ColumnsDefinition(columns =>
        //                    {
        //                        columns.ConstantColumn(100);  // Product Code
        //                        columns.RelativeColumn(3);   // Product Name
        //                        columns.ConstantColumn(80);  // Quantity
        //                        columns.ConstantColumn(80);  // Price
        //                        columns.ConstantColumn(80); // Total
        //                    });

        //                    // **Table Header**
        //                    table.Header(header =>
        //                    {
        //                        header.Cell().Element(CellStyleWithBackground).Text("Product Code").Bold();
        //                        header.Cell().Element(CellStyleWithBackground).Text("Product Name").Bold();
        //                        header.Cell().Element(CellStyleWithBackground).AlignCenter().Text("Quantity").Bold();
        //                        header.Cell().Element(CellStyleWithBackground).AlignCenter().Text("Price").Bold();
        //                        header.Cell().Element(CellStyleWithBackground).AlignCenter().Text("Total").Bold();
        //                    });

        //                    foreach (var item in invoiceDetailModel.Items)
        //                    {
        //                        if (item.IsBundle == 1)
        //                        {
        //                            table.Cell().Element(CellStyle).Text(item.ProductCode).Bold();
        //                            table.Cell().Element(CellStyle).Text(item.ProductName).Bold();
        //                            table.Cell().Element(CellStyle).AlignCenter().Text(item.Qty.ToString()).Bold();
        //                            table.Cell().Element(CellStyle).AlignRight().Text("£ " + item.SalePrice.ToString()).Bold();
        //                            table.Cell().Element(CellStyle).AlignRight().Text("£ " + (item.Qty * item.SalePrice).ToString()).Bold();
        //                        }
        //                        else
        //                        {
        //                            table.Cell().Element(CellStyle).Text(item.ProductCode);
        //                            table.Cell().Element(CellStyle).Text(item.ProductName);
        //                            table.Cell().Element(CellStyle).AlignCenter().Text(item.Qty.ToString());
        //                            table.Cell().Element(CellStyle).AlignRight().Text("£ " + item.SalePrice.ToString());
        //                            table.Cell().Element(CellStyle).AlignRight().Text("£ " + (item.Qty * item.SalePrice).ToString());
        //                        }
        //                    }
        //                });


        //                //Total table
        //                col.Item().PaddingTop(20).AlignRight().Table(table =>
        //                {
        //                    table.ColumnsDefinition(columns =>
        //                    {
        //                        if (IsVATInvoice)
        //                        {
        //                            columns.ConstantColumn(160);
        //                            columns.ConstantColumn(120);
        //                            columns.ConstantColumn(100);
        //                            columns.ConstantColumn(100);
        //                        }
        //                        else
        //                        {
        //                            columns.ConstantColumn(240);
        //                            columns.ConstantColumn(120);
        //                            columns.ConstantColumn(120);
        //                        }

        //                    });

        //                    if (IsVATInvoice)
        //                    {
        //                        table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Payment Details").Bold();
        //                    }

        //                    table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Payment Terms").Bold();
        //                    table.Cell().Element(CellStyle).AlignRight().Text("Item Total").Bold();
        //                    table.Cell().Element(CellStyle).AlignRight().Text("£ " + invoiceDetailModel.ItemTotal).Bold();

        //                    if (IsVATInvoice)
        //                    {
        //                        table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Bank: LLOYDS");
        //                    }
        //                    table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Immediate");
        //                    table.Cell().Element(CellStyle).AlignRight().Text("Delivery Charges").Bold();
        //                    table.Cell().Element(CellStyle).AlignRight().Text("£ " + invoiceDetailModel.DeliveryCharges).Bold();

        //                    if (IsVATInvoice)
        //                    {
        //                        table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Account No : 52784560");
        //                    }

        //                    if (IsVATInvoice)
        //                    {
        //                        table.Cell().Element(CellNoBorderStyle).AlignLeft().Text(" ").Bold();
        //                        table.Cell().Element(CellStyle).AlignRight().Text("VAT 20%").Bold();
        //                        table.Cell().Element(CellStyle).AlignRight().Text("£ " + invoiceDetailModel.VatAmount).Bold();
        //                    }
        //                    if (IsVATInvoice)
        //                    {
        //                        table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Sort Code : 77-04-01");
        //                    }
        //                    if (invoiceDetailModel.DiscountAmount > 0)
        //                    {
        //                        table.Cell().Element(CellNoBorderStyle).AlignLeft().Text(" ").Bold();
        //                        table.Cell().Element(CellStyle).AlignRight().Text("Discount").Bold();
        //                        table.Cell().Element(CellStyle).AlignRight().Text("£ " + invoiceDetailModel.DiscountPercentage + "% : £ " + invoiceDetailModel.DiscountAmount).Bold();
        //                    }
        //                    table.Cell().Element(CellNoBorderStyle).AlignLeft().Text(" ").Bold();
        //                    table.Cell().Element(CellStyle).AlignRight().Text("Total Amount").Bold();
        //                    table.Cell().Element(CellStyle).AlignRight().Text("£ " + (IsVATInvoice ? invoiceDetailModel.TotalWithVATAmount : invoiceDetailModel.TotalWithOutVATAmount)).Bold();
        //                });
        //            });

        //            // Footer Section
        //            if (IsVATInvoice)
        //            {
        //                page.Footer().Column(col =>
        //                {
        //                    col.Item().AlignCenter().Text(
        //                        "All sales are made according to Angles Solutions PVT.Limited’s Standard terms and Conditions."
        //                    ).FontSize(10);

        //                    col.Item().PaddingTop(10).LineHorizontal(1);

        //                    col.Item().AlignCenter().Text(
        //                        "ANGLES SOLUTIONS PVT LIMITED"
        //                    ).Bold().FontSize(9);

        //                    col.Item().AlignCenter().Text(
        //                        "Unit 7, Manor Way Industrial Estate, Curzon Drive, RM17 6BG"
        //                    ).FontSize(9);

        //                    col.Item().AlignCenter().Text(
        //                        "Registered in England 08827945 | VAT Registered No. 270 961 491"
        //                    ).FontSize(9);
        //                });
        //            }
        //            else
        //            {
        //                page.Footer().AlignCenter().Text("Any shortages must be informed immediately.");
        //            }
        //        });
        //    }).GeneratePdf();
        //}


        public byte[] GenerateInvoice(InvoiceDetailModel model, bool isVATInvoice)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Element(c => InvoiceHeader(c, model, isVATInvoice));

                    page.Content().Column(col =>
                    {
                        col.Item().Element(c => InvoiceInfo(c, model));
                        col.Item().Element(c => ProductTable(c, model));
                        col.Item().Element(c => InvoiceTotals(c, model, isVATInvoice));
                    });

                    page.Footer().Element(c => InvoiceFooter(c, isVATInvoice));
                });
            }).GeneratePdf();
        }

        void InvoiceHeader(IContainer container, InvoiceDetailModel model, bool isVAT)
        {
            if (isVAT)
            {
                container.Column(col =>
                {
                    col.Item().Row(row =>
                    {
                        row.ConstantItem(200)
                            .Text("Angle Sims")
                            .FontSize(18)
                            .Bold();

                        row.RelativeItem().AlignRight().Column(company =>
                        {
                            company.Item().AlignRight().Text("Angles Solutions Pvt. Limited").Bold().FontSize(14);
                            company.Item().AlignRight().Text("Unit 7, Manor Way Industrial Estate");
                            company.Item().AlignRight().Text("Curzon Drive, RM17 6BG");
                        });
                    });

                    col.Item().PaddingTop(8).LineHorizontal(1);
                });
            }
            else
            {
                container.Column(col =>
                {
                    col.Item().AlignCenter().Row(row =>
                    {
                        row.ConstantItem(480).
                        AlignCenter()
                            .Text("Delivery Note")
                            .FontSize(18)
                            .Bold();
                    });

                    col.Item().PaddingTop(8).LineHorizontal(1);
                });
            }
        }

        void InvoiceInfo(IContainer container, InvoiceDetailModel model)
        {
            container.PaddingTop(10).Row(row =>
            {
                row.RelativeItem().AlignLeft().Column(c =>
                {
                    c.Item().Text("Address").Bold();
                    c.Item().Text($"Shop ID: {model.ShopId}");
                    c.Item().Text(model.ShopName);
                    c.Item().Text(model.ContactName);
                    c.Item().Text(model.ShippingAddress);
                    c.Item().Text(model.ShopEmail);
                    c.Item().Text(model.PhoneNumber);
                });

                row.RelativeItem().AlignRight().Column(c =>
                {
                    c.Item().AlignRight().Text($"INV {model.OrderId}").Bold();
                    c.Item().AlignRight().Text(model.CreatedDate.ToString("MMMM dd yyyy"));
                    c.Item().AlignRight().Text($"{model.UserName}/{model.AreaName}");
                });
            });
        }

        void CustomerSellerSection(IContainer container, InvoiceDetailModel model, bool isVAT)
        {

        }

        void ProductTable(IContainer container, InvoiceDetailModel model)
        {
            container.PaddingTop(20).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(120);
                    columns.RelativeColumn(3);
                    columns.ConstantColumn(80);
                    columns.ConstantColumn(80);
                    columns.ConstantColumn(80);
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyleWithBackground).Text("Product Code").Bold();
                    header.Cell().Element(CellStyleWithBackground).Text("Product Name").Bold();
                    header.Cell().Element(CellStyleWithBackground).AlignCenter().Text("Qty").Bold();
                    header.Cell().Element(CellStyleWithBackground).AlignRight().Text("Price").Bold();
                    header.Cell().Element(CellStyleWithBackground).AlignRight().Text("Total").Bold();
                });

                foreach (var item in model.Items)
                {
                    table.Cell().Element(CellStyle).Text(item.ProductCode);
                    table.Cell().Element(CellStyle).Text(item.ProductName);
                    table.Cell().Element(CellStyle).AlignCenter().Text(item.Qty.ToString());
                    table.Cell().Element(CellStyle).AlignRight().Text($"£ {item.SalePrice:0.00}");
                    table.Cell().Element(CellStyle).AlignRight().Text($"£ {(item.Qty * item.SalePrice):0.00}");
                }
            });
        }

        void InvoiceTotals(IContainer container, InvoiceDetailModel model, bool isVAT)
        {
            container.PaddingTop(20).AlignRight().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                            {
                                if (isVAT)
                                {
                                    columns.ConstantColumn(160);
                                    columns.ConstantColumn(120);
                                    columns.ConstantColumn(100);
                                    columns.ConstantColumn(100);
                                }
                                else
                                {
                                    columns.ConstantColumn(240);
                                    columns.ConstantColumn(120);
                                    columns.ConstantColumn(120);
                                }

                            });

                if (isVAT)
                {
                    table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Payment Details").Bold();
                }

                table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Payment Terms").Bold();
                table.Cell().Element(CellStyle).AlignRight().Text("Item Total").Bold();
                table.Cell().Element(CellStyle).AlignRight().Text("£ " + model.ItemTotal).Bold();

                if (isVAT)
                {
                    table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Bank: LLOYDS");
                }
                table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Immediate");
                table.Cell().Element(CellStyle).AlignRight().Text("Delivery Charges").Bold();
                table.Cell().Element(CellStyle).AlignRight().Text("£ " + model.DeliveryCharges).Bold();

                if (isVAT)
                {
                    table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Account No : 52784560");
                }

                if (isVAT)
                {
                    table.Cell().Element(CellNoBorderStyle).AlignLeft().Text(" ").Bold();
                    table.Cell().Element(CellStyle).AlignRight().Text("VAT 20%").Bold();
                    table.Cell().Element(CellStyle).AlignRight().Text("£ " + model.VatAmount).Bold();
                }
                if (isVAT)
                {
                    table.Cell().Element(CellNoBorderStyle).AlignLeft().Text("Sort Code : 77-04-01");
                }
                if (model.DiscountAmount > 0)
                {
                    table.Cell().Element(CellNoBorderStyle).AlignLeft().Text(" ").Bold();
                    table.Cell().Element(CellStyle).AlignRight().Text("Discount").Bold();
                    table.Cell().Element(CellStyle).AlignRight().Text("£ " + model.DiscountPercentage + "% : £ " + model.DiscountAmount).Bold();
                }
                table.Cell().Element(CellNoBorderStyle).AlignLeft().Text(" ").Bold();
                table.Cell().Element(CellStyle).AlignRight().Text("Total Amount").Bold();
                table.Cell().Element(CellStyle).AlignRight().Text("£ " + (isVAT ? model.TotalWithVATAmount : model.TotalWithOutVATAmount)).Bold();
            });
        }

        void InvoiceFooter(IContainer container, bool isVAT)
        {
            if (!isVAT)
            {
                container.AlignCenter().Text("Any shortages must be informed immediately.");
                return;
            }

            container.Column(col =>
            {
                col.Item().AlignCenter().Text(
                    "All sales are made according to Angles Solutions PVT.Limited’s Standard terms and Conditions."
                ).FontSize(9);

                col.Item().PaddingTop(5).LineHorizontal(1);

                col.Item().AlignCenter().Text("ANGLES SOLUTIONS PVT LIMITED").Bold().FontSize(9);
                col.Item().AlignCenter().Text("Unit 7, Manor Way Industrial Estate, Curzon Drive, RM17 6BG").FontSize(9);
                col.Item().AlignCenter().Text("Registered in England 08827945 | VAT Registered No. 270 961 491").FontSize(9);
            });
        }

        public byte[] GenerateReceipt(PaymentReceiptModel model)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(35);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    // HEADER SECTION
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("LEAP-TEL")
                                .FontSize(20)
                                .Bold()
                                .FontColor(Colors.Blue.Medium);

                            col.Item().Text("Telecom Solutions");
                            col.Item().Text("Customer Support: 03330119880");
                            col.Item().Text("info@leap-tel.com");
                        });

                        row.RelativeItem().AlignRight().Column(col =>
                        {
                            col.Item().Text("PAYMENT RECEIPT")
                                .FontSize(18)
                                .Bold();

                            col.Item().PaddingTop(5)
                                .Text($"Receipt No : {model.ReceiptNo}");

                            col.Item()
                                .Text($"Date : {model.PaymentDate:dd MMM yyyy}");
                        });
                    });

                    page.Content().Column(col =>
                    {
                        col.Item().PaddingVertical(10).LineHorizontal(1);

                        // CUSTOMER INFO BLOCK
                        col.Item().PaddingVertical(5).Text("Customer Details")
                            .Bold()
                            .FontSize(13);

                        col.Item().Text($"Customer Name : {model.CustomerName}");
                        col.Item().Text($"Order ID : {model.OrderId}");
                        col.Item().Text($"Payment Method : {model.PaymentMethod}");

                        col.Item().PaddingVertical(10).LineHorizontal(1);

                        // PAYMENT SUMMARY TABLE STYLE
                        col.Item().PaddingVertical(5).Text("Payment Summary")
                            .Bold()
                            .FontSize(13);

                        col.Item().Border(1).Padding(10).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.ConstantColumn(120);
                            });

                            table.Cell().Text("Description").Bold();
                            table.Cell().AlignRight().Text("Amount").Bold();

                            table.Cell().Text("Payment Received");
                            table.Cell().AlignRight().Text($"£ {model.AmountPaid:F2}");
                        });


                        // SIGNATURE AREA
                        col.Item().AlignRight().Column(sig =>
                        {
                            sig.Item().Text("Authorized Signature");
                            sig.Item().PaddingTop(10)
                                .Text("____________________________");
                        });
                    });

                    // FOOTER SECTION
                    page.Footer().AlignCenter().Column(col =>
                    {
                        col.Item().Text("This is a system generated receipt and does not require a physical signature.")
                            .FontSize(9)
                            .FontColor(Colors.Grey.Darken2);
                    });
                });
            })
            .GeneratePdf();

        }

        private static IContainer CellStyle(IContainer container) =>
            container.Border(1, Unit.Point).Padding(5).AlignMiddle();

        private static IContainer CellNoBorderStyle(IContainer container) =>
            container.Border(0).Padding(3).AlignMiddle();

        private static IContainer CellStyleWithBackground(IContainer container)
        {
            return container
                .Border(1)
                .Background(Colors.Grey.Lighten2) // Light Gray Background
                .Padding(5)
                .AlignMiddle();
        }
    }
}

