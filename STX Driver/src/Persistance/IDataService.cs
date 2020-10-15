using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace STX_Driver.src.Persistance
{
    public interface IDataBase
    {
        object DbReader(IDataReader rd);
    }
}
