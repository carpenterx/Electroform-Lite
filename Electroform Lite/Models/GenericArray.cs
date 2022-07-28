using System;

namespace Electroform_Lite.Models;

internal class GenericArray<T>
{
    private readonly int _maxSize;
    private int _currentIndex;
    private T[] _items;

    public GenericArray(int maxSize = 10)
    {
        _maxSize = maxSize;
        _items = new T[maxSize];
        _currentIndex = 0;
    }

    public T GetItemAt(int index)
    {
        return _items[index];
    }

    public void SetItemAt(int index, T item)
    {
        _items[index] = item;
    }

    public void SwapItems(T item1, T item2)
    {
        int index1 = GetIndex(item1);
        int index2 = GetIndex(item2);
        SwapItems(index1, index2);
    }

    public void SwapItems(int item1Index, T item2)
    {
        int index2 = GetIndex(item2);
        SwapItems(item1Index, index2);
    }

    public void SwapItems(T item1, int item2Index)
    {
        int index1 = GetIndex(item1);
        SwapItems(index1, item2Index);
    }

    public void SwapItems(int index1, int index2)
    {
        if (index1 > -1 && index2 > -1)
        {
            (_items[index2], _items[index1]) = (_items[index1], _items[index2]);
        }
    }

    private int GetIndex(T item)
    {
        for (int i = 0; i <= _currentIndex; i++)
        {
            if (_items[i].Equals(item))
            {
                return i;
            }
        }
        return -1;
    }

    public void Push(T item)
    {
        if (_currentIndex >= _maxSize)
        {
            throw new InvalidOperationException("Stack is full");
        }

        _items[_currentIndex++] = item;
    }

    public T Pop()
    {
        _currentIndex--;

        if (_currentIndex >= 0)
        {
            return _items[_currentIndex];
        }

        _currentIndex = 0;
        throw new InvalidOperationException("Stack is empty");
    }
}
