using System.Collections.Generic;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Persistance
{
    interface IRepositoryOfReader
    {
        List<Reader> GetItems();

        void SetSessionNumberToReader(int num, Reader reader);
    }
}