using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahira_Hotel_Travel.Helper
{
    public interface IViewMethod
    {
        void add();
        void edit(string id);
        void delete(string id);
        bool isFieldStillEmpty();
        void loadData();
    }
}
