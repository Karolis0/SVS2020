using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakalauras_2020.Forms.Mappers
{
    static class ItemMapper
    {
        public static int selectedId = -1;

        public static int SelectItemId()
        {
            ItemMapperGUI iEdt = new ItemMapperGUI();
            iEdt.ShowDialog();
            return selectedId;
        }
    }
}
