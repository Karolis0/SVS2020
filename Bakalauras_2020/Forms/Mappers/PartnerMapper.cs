using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakalauras_2020.Forms.Mappers
{
    static class PartnerMapper
    {
        public static int selectedId = -1;

        public static int SelectPartnerId(bool Supplier = false, bool Customer = false)
        {
            PartnerMapperGUI iEdt = new PartnerMapperGUI();
            iEdt.RequestCustomer = Customer;
            iEdt.RequestSupplier = Supplier;
            iEdt.ShowDialog();
            return selectedId;
        }
    }
}
