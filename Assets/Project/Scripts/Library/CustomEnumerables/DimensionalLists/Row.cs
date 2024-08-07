using System.Collections.Generic;

namespace DimensionalLists
{
    [System.Serializable]
    public class Row<T>
    {
        public List<Cell<T>> Cells = new();
        public Cell<T> this[int index] => Cells[index];
    }
}