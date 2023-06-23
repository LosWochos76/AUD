using System.Collections;

public class ArrayList<T> : ICollection<T>
{
    private int size;
    private int count = 0;
    private T[] data;

    public ArrayList(int size)
    {
        this.size = size;
        this.data = new T[size];
    }

    public ArrayList() : this(10)
    {
    }

    public int Count
    {
        get { return count; }
    }

    public bool IsReadOnly {
        get 
        { 
            return false; 
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index > count - 1)
                throw new ArgumentException("Bad index!");
            
            return data[index];
        }

        set
        {
            if (index < 0 || index > count - 1)
                throw new ArgumentException("Bad index!");
            
            data[index] = value;
        }
    }

    public void Add(T item)
    {
        if (count == size)
        {
            T[] new_data = new T[size * 2];
            Array.Copy(data, new_data, size);
            data = new_data;
            size *= 2;
        }

        data[count] = item;
        count++;
    }

    public void Clear()
    {
        Array.Clear(data);
    }

    private int IndexOf(T item)
    {
        if (item is null)
            return -1;

        for (int i=0; i<count; i++)
            if (data[i] is not null && data[i].Equals(item))
                return i;
        
        return -1;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) != -1;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        Array.Copy(data, 0, array, arrayIndex, count);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new ArrayListEnumerator<T>(this);
    }

    public bool Remove(T item)
    {
        if (count == 0)
            return false;

        int index = IndexOf(item);
        if (index > -1)
        {
            T[] new_data = new T[size];
            Array.Copy(data, 0, new_data, 0, index);
            Array.Copy(data, index+1, new_data, index, count - 1);
            data = new_data;
            count--;
            return true;
        }

        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new ArrayListEnumerator<T>(this);
    }
}