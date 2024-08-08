using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftedAccessArray2D<T>
{
    public ShiftedAccessArray2D(int x, int y)
    {
        _array = new T[x, y];
    }

    public ShiftedAccessArray2D(T[,] array)
    {
        _array = array.Clone() as T[,];
    }

    public T this[int x, int y]
    {
        get 
        {
            Vector2Int shiftedIndex = LoopValueInArray(new Vector2Int(x, y) - Shift);
            return _array[shiftedIndex.x, shiftedIndex.y]; 
        }
        set
        {
            Vector2Int loopedIndex = LoopValueInArray(new Vector2Int(x, y) - Shift);
            _array[loopedIndex.x, loopedIndex.y] = value;
        }
    }

    private Vector2Int _shift;
    public Vector2Int Shift
    {
        get => _shift;
        set => _shift = LoopValueInArray(value);
    }

    private readonly T[,] _array;
    public T[,] Array
    {
        get
        {
            var shiftedArray = new T[_array.GetLength(0), _array.GetLength(1)];

            for (int x = 0; x < _array.GetLength(0); x++)
            {
                for (int y = 0; y < _array.GetLength(1); y++)
                {
                    shiftedArray[x, y] = this[x, y];
                }
            }

            return shiftedArray;
        }
    }

    public void ForEach(Action<T> action)
    {
        for (int x = 0; x < _array.GetLength(0); x++)
        {
            for (int y = 0; y < _array.GetLength(1); y++)
            {
                action.Invoke(Array[x, y]);
            }
        }
    }

    public int GetLength(int dimension) => _array.GetLength(dimension);

    private Vector2Int LoopValueInArray(Vector2Int val)
    {
        Vector2Int res = new(
            val.x % _array.GetLength(0), 
            val.y % _array.GetLength(1));

        if (res.x < 0) res.x = _array.GetLength(0) + res.x;
        if (res.y < 0) res.y = _array.GetLength(1) + res.y;
        return res;
    }
}
