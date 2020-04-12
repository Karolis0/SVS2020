using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakalauras_2020.Forms.Mappers
{
    static class WarehouseLocMapper
    {
        public static int selectedId = -1;

        public static int SelectLocId()
        {
            WarehouseLocMapperGUI iEdt = new WarehouseLocMapperGUI();
            iEdt.ShowDialog();
            return selectedId;
        }
    }
}
