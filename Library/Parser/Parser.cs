using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Parser
{
    // TODO: Предусмотреть сохранение в файлы формата xlsx/pdf/text информацию
    /* 1) Сколько раз брали каждую книгу, по каждому абоненту за указанный период
     * 2) Информацию о взятых книгах, сгруппированных по жанрам
     */

    public delegate string ForExecution();
    public interface Parser
    {
        void SetToFile(string path, Delegate methods);

    }

}
