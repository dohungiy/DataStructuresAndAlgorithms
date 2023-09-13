namespace SharedKernel.LinkedList.SinglyLinkedList;

public class SinglyLinkedList<T> : ISinglyLinkedList<T>
{
    #region [PROPERTIES + CONSTRUCTORS]

    internal SinglyLinkedListNode<T>? head;
    internal SinglyLinkedListNode<T>? tail;
    internal int count;
    
    public SinglyLinkedList()
    {
        head = tail = null;
        count = 0;
    }
    
    #endregion
    
    #region [IMPLEMENTE PROPERTIES]
    
    public int Count
    {
        get { return count; }
    }

    public SinglyLinkedListNode<T>? First
    {
        get { return head; }
    }

    public SinglyLinkedListNode<T>? Last
    {
        get { return tail; }
    }
    
    #endregion
    
    #region [IMPLEMENTE METHODS]
    
    /// <summary>
    /// Add after
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public SinglyLinkedListNode<T> AddAfter(SinglyLinkedListNode<T> node, T value)
    {
        ValidateNode(node);
        SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(node.list!, value);
        InsertNodeAfter(node, newNode);

        return newNode;
    }
    
    /// <summary>
    /// Add after
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public void AddAfter(SinglyLinkedListNode<T> node, SinglyLinkedListNode<T> newNode)
    {
        ValidateNode(node);
        ValidateNewNode(newNode);
        InsertNodeAfter(node, newNode);
        newNode.list = this;
    }

    /// <summary>
    ///  Add before
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public SinglyLinkedListNode<T> AddBefore(SinglyLinkedListNode<T> node, T value)
    {
        ValidateNode(node);
        SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(node.list!, value);
        InsertNodeBefore(node, newNode);

        return newNode;
    }

    /// <summary>
    ///  Add before
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public void AddBefore(SinglyLinkedListNode<T> node, SinglyLinkedListNode<T> newNode)
    {
        ValidateNode(node);
        ValidateNewNode(newNode);
        InsertNodeBefore(node, newNode);
        newNode.list = this;
    }

    /// <summary>
    ///  Add first
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public SinglyLinkedListNode<T> AddFirst(T value)
    {
        SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(this, value);
        if (head is null)
        {
            InsertNodeToEmptyList(newNode);
        }
        else
        {
            InsertNodeBefore(head, newNode);
            head = newNode;
        }
        return newNode;
    }

    public void AddFirst(SinglyLinkedListNode<T> node)
    {
        ValidateNewNode(node);

        if (head is null)
        {
            InsertNodeToEmptyList(node);
        }
        else
        {
            InsertNodeBefore(head, node);
        }
        
        node.list = this;
    }
    

    /// <summary>
    /// Add last
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public SinglyLinkedListNode<T> AddLast(T value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Add last
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public void AddLast(SinglyLinkedListNode<T> node)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Clear
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public void Clear()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Contains
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public bool Contains(T value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Find
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public SinglyLinkedListNode<T>? Find(T value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Find last
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public SinglyLinkedListNode<T>? FindLast(T value)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Display with Condition
    /// Create: 12/09/2023 - By: Đỗ Chí Hùng
    /// </summary>
    public void DisplayWithCondition(Func<T, T, bool> condition, Action<T> act)
    {
        throw new NotImplementedException();
    }

    #endregion
    

    #region [INTERNAL METHODS]
    
    // After: sau
    // Before: Trước
    
    private void InternalRemoveNode(SinglyLinkedListNode<T> node)
    {
        if (node == head)
        {
            head = null;
        }
        else
        {
            SinglyLinkedListNode<T> current = head;
            while (current.next is not null && current.next != node)
            {
                current = current.next;
            }

            if (node == tail)
            {
                current.next = null;
                tail = current;
            }
            else
            {
                current.next = node.next;
            }
            
        }
        node.Invalidate();
        count--;
    }
    
    private void InsertNodeToEmptyList(SinglyLinkedListNode<T> newNode)
    {
        newNode.next = newNode;
        head = newNode;
        count++;
    }
    private void InsertNodeBefore(SinglyLinkedListNode<T> node, SinglyLinkedListNode<T> newNode)
    {
        if (node == head)
        {
            newNode.next = head;
            head = newNode;
            count++;
            return;
        }
        
        SinglyLinkedListNode<T> current = head;
        while (current.next is not null && current.next != node)
        {
            current = current.next;
        }

        if (current.next is null)
        {
            throw new InvalidOperationException("The provided node is not in the list.");
        }

        newNode.next = node;
        current.next = newNode;
        count++;
    }
    
    private void InsertNodeAfter(SinglyLinkedListNode<T> node, SinglyLinkedListNode<T> newNode)
    {
        if (node == tail)
        {
            tail = node;
        }
        
        newNode.next = node.next;
        node.next = newNode;
        count++;
    }
    
    private static void ValidateNewNode(SinglyLinkedListNode<T> node)
    {
        ArgumentNullException.ThrowIfNull(node);

        if (node.list is not null)
        {
            throw new InvalidOperationException("Invalid node");
        }
    }
    
    private void ValidateNode(SinglyLinkedListNode<T> node)
    {
        ArgumentNullException.ThrowIfNull(node);

        if (node.list != this)
        {
            throw new InvalidOperationException("Invalid node");
        }
    }
    #endregion
}