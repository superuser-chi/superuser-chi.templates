using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core
{
    public class FetchData<T>
    {
        public IEnumerable<T> Rows { get; set; }
        public int RowCount { get; set; }

        public FetchData(IEnumerable<T> _Rows, int _RowCount)
        {
            Rows = _Rows;
            RowCount = _RowCount;
        }
    }
}