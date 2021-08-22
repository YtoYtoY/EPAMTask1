using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Parser
{
    public class PDF : Parser
    {
        public void SetToFile(string path, Delegate methods)
        {
            Microsoft.Office.Interop.Word.Application wordapp = new Microsoft.Office.Interop.Word.Application();
            wordapp.Visible = true;

            var doc = wordapp.Documents.Add();

            var paragraph = doc.Content.Paragraphs.Add();

            paragraph.Range.Text = "Heading 1";
            paragraph.Range.Font.Bold = 1;
            paragraph.Format.SpaceAfter = 24;

            string text = string.Empty;
            var delegates = methods.GetInvocationList();
            foreach (var item in delegates)
            {

                text += ((ForExecution)item)();

            }
            
            // Writing

            doc.SaveAs2(path, 17);
            doc.SaveAs2(path, 16);

            wordapp.Quit();
        }
    }
}
