using System;
using System.IO;
using Library.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests
{
    
    [TestClass]
    public class Parser_UnitTest
    {
        private static string txtTestPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Tests/testTXT.txt");
        private static string pdfTestPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Tests/testPDF.txt");
        private static string xlsxTestPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Tests/testXLSX.txt");

        public string TestQuery_1() => "First,Line,First,Line\nFirst,Line,First,Line\nFirst,Line,First,Line\nFirst,Line,First,Line\n";
        public string TestQuery_2() => "Second,Line,Second,Line\nSecond,Line,Second,Line\nSecond,Line,Second,Line\nSecond,Line,Second,Line\n";
        public string TestQuery_3() => "Third,Line,Third,Line\nThird,Line,Third,Line\nThird,Line,Third,Line\nThird,Line,Third,Line\n";
        public string EmptySpace() => "**********************************\n\n";


        [TestMethod]
        public void TextFile_UnitMethod()
        {
            ForExecution testDelegate = new ForExecution(TestQuery_1);
            testDelegate += TestQuery_2;
            testDelegate += EmptySpace;
            testDelegate += TestQuery_3;

            TEXT txt = new TEXT();
            txt.SetToFile(txtTestPath, testDelegate);
        }

        [TestMethod]
        public void ExcelFile_UnitMethod()
        {
            ForExecution testDelegate = new ForExecution(TestQuery_1);
            testDelegate += TestQuery_2;
            testDelegate += EmptySpace;
            testDelegate += TestQuery_3;

            XLSX excel = new XLSX();
            excel.SetToFile(xlsxTestPath, testDelegate);
        }

        [TestMethod]
        public void PdfFile_UnitMethod()
        {
            ForExecution testDelegate = new ForExecution(TestQuery_1);
            testDelegate += TestQuery_2;
            testDelegate += EmptySpace;
            testDelegate += TestQuery_3;

            PDF pdf = new PDF();
            pdf.SetToFile(xlsxTestPath, testDelegate);
        }
    }
}
