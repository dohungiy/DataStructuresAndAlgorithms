namespace SharedKernel.LinkedList.SinglyLinkedList;

public class SinglyLinkedListNode<T>
{
    #region [PROPERTIES + CONSTRUCTORS]
    
    internal SinglyLinkedList<T>? list;
    internal SinglyLinkedListNode<T>? next;
    internal T item;

    public SinglyLinkedListNode(T value)
    {
        item = value;
    }
    
    #endregion

    internal SinglyLinkedListNode(SinglyLinkedList<T> list, T value)
    {
        this.list = list;
        item = value;
    }

    public SinglyLinkedList<T>? List
    {
        get { return list; }
    }

    public SinglyLinkedListNode<T>? Next
    {
        get { return next == null || next == list!.head ? null : next; }
    }
    
    public T Value
    {
        get { return item; }
        set { item = value; }
    }
    
    internal void Invalidate()
    {
        list = null;
        next = null;
    }
}