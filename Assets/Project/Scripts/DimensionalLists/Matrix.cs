using System;
using System.Collections.Generic;

namespace DimensionalLists
{
    [System.Serializable]
    public class Matrix<T>
    {
        public List<Row<T>> Rows = new();
        public Cell<T> this[int x, int y] => Rows[y][x];

        public T[,] ToArray()
        {
            T[,] array = new T[GetLongestRow(), Rows.Count];

            for (int x = 0; x < GetLongestRow(); x++)
            {
                for (int y = 0; y < Rows.Count; y++)
                {
                    if (x >= Rows[y].Cells.Count) continue;
                    array[x, y] = this[x, y].Value;
                }
            }

            return array;
        }

        public int GetLongestRow()
        {
            int maxLength = 0;

            foreach (var row in Rows)
                if (row.Cells.Count > maxLength) maxLength = row.Cells.Count;

            return maxLength;
        }
    }
}
