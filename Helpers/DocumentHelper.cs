using ClosedXML.Excel;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Storage;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Helpers
{
    public static class DocumentHelper
    {
        public static string ExportToExcel<T>(List<T> data, string fileName) where T : class
        {
            var filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{fileName}";

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(typeof(T).Name);

            //Retorna las propiedades de la entidad que se pasó como parámetro genérico
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Encabezados
            for ( int i = 0 ; i < properties.Length ; i++ )
            {
                worksheet.Cell(1, i + 1).Value = properties[ i ].Name;
                worksheet.Cell(1, i + 1).Style.Font.Bold = true;
            }


            // Datos
            for ( int row = 0 ; row < data.Count ; row++ )
            {
                var item = data[ row ];
                for ( int col = 0 ; col < properties.Length ; col++ )
                {
                    var value = properties[ col ].GetValue(item);
                    worksheet.Cell(row + 2, col + 1).Value = value?.ToString() ?? "";
                }
            }

            worksheet.Columns().AdjustToContents();
            worksheet.Columns().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            workbook.SaveAs(filePath);

            return filePath;
        }

        public static async Task<string> ExportToPDFAsync<T>(List<T> data, string fileName) where T : class
        {
            if ( data == null || data.Count == 0 )
                await ToastHelper.GetToastAsync("No hay datos para exportar.", ToastDuration.Short, 14);

            // Obtiene las propiedades públicas de la entidad

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Ruta del archivo donde se guardará el PDF

            var filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{fileName}";

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    // Márgenes y fuente
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    // Encabezado
                    page.Header()
                        .Text(fileName)
                        .SemiBold()
                        .FontSize(14)
                        .AlignCenter();

                    // Contenido principal: tabla
                    page.Content().Table(table =>
                    {
                        // Columnas basadas en las propiedades
                        table.ColumnsDefinition(columns =>
                        {
                            foreach ( var _ in properties )
                                columns.RelativeColumn();
                        });

                        // Encabezados
                        table.Header(header =>
                        {
                            foreach ( var prop in properties )
                            {
                                header.Cell()
                                       .BorderBottom(2)
                                       .Padding(7)
                                      .Text(prop.Name);
                            }
                        });

                        // Filas con los valores
                        foreach ( var item in data )
                        {
                            foreach ( var prop in properties )
                            {
                                var value = prop.GetValue(item);
                                string? textValue = value switch
                                {
                                    null => "",
                                    DateTime dt => dt.ToShortDateString(),
                                    _ => value.ToString()
                                };
                                table.Cell()
                                     .Text(textValue ?? string.Empty);
                            }
                        }
                    });

                    // Pie de página
                    page.Footer()
                        .AlignRight()
                        .Text($"Generado el {DateTime.Now:g}");
                });
            });

            // Generar el PDF
            document.GeneratePdf(filePath);
            return filePath;
        }
    }
}
