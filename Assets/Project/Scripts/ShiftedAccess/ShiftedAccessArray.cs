using System;
using UnityEngine;

public class ShiftedAccessArray<T>
{
    public ShiftedAccessArray(int length)
    {
        _array = new T[length];
    }

    public ShiftedAccessArray(T[] array)
    {
        _array = array.Clone() as T[];
    }

    public T this[int x]
    {
        get { return _array[LoopValueInArray(x - Shift)]; }
        set { _array[LoopValueInArray(x - Shift)] = value; }
    }

    private int _shift;
    public int Shift
    { 
        get => _shift;
        set => _shift = LoopValueInArray(value);
    }

    private readonly T[] _array;
    public T[] Array
    { 
        get
        {
            var shiftedArray = new T[_array.Length];

            for (int x = 0; x < _array.Length; x++)
            {
                shiftedArray[x] = this[x];
            }

            return shiftedArray;
        }
    }

    public void ForEach(Action<T> action)
    {
        for (int x = 0; x < _array.Length; x++)
        {
            action.Invoke(Array[x]);
        }
    }

    public int GetLength(int dimension) => _array.GetLength(dimension);

    private int LoopValueInArray(int val)
    {
        int res = val % _array.Length;
        if (res < 0) res = _array.Length + res;
        return res;
    }
}