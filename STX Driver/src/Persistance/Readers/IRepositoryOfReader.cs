using System.Collections.Generic;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Persistance.Readers
{
    interface IRepositoryOfReaders
    {
        List<Reader> GetItems();

        Reader GetItem(string address);
        Reader GetItem(int i);
        Reader GetItem(object num);
    }
}