using System;
using System.IO;
using Library.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.DataBase;
using Library.DataBase.ORM;
using System.Collections.Generic;

namespace Library.Tests
{
    
    [TestClass]
    public class Parser_UnitTest
    {
        private static string txtTestPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Tests/testTXT.txt");
        private static string pdfTestPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Tests/testPDF.docx");
        private static string xlsxTestPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Tests/testXLSX.xlsx");

        private static DateTime first = new DateTime(2020, 2, 8, 0, 0, 0);
        private static DateTime last = DateTime.Now;

        ForExecutionEmpty testEmptyDelegate = new ForExecutionEmpty(Queries.GetTakenBooksByGenre_Query);
        ForExecutionDate testDateDelegate = new ForExecutionDate(Queries.GetBooksInformByTime_Query);

        [TestMethod]
        public void TextFile_UnitMethod()
        {
            Library.GetAll();
            TEXT txt = new TEXT();
            txt.SetToFile(txtTestPath, testEmptyDelegate, testDateDelegate, first, last);
        }

        [TestMethod]
        public void ExcelFile_UnitMethod()
        {
            Library.GetAll();
            XLSX excel = new XLSX();
            excel.SetToFile(xlsxTestPath, testEmptyDelegate, testDateDelegate, first, last);
        }

        [TestMethod]
        public void PdfFile_UnitMethod()
        {
            Library.GetAll();
            PDF pdf = new PDF();
            pdf.SetToFile(pdfTestPath, testEmptyDelegate, testDateDelegate, first, last);
        }
    }
}
