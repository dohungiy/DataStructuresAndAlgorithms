namespace SharedKernel.BinaryTree;

public class BinaryTreeNode<T>
{
    
    public BinaryTreeNode(T value)
    {
        Value = value;
    }
    
    /// <summary>
    /// Gets the value.
    /// </summary>
    public T Value { get; set; }
    
    /// <summary>
    /// Gets or sets the parent node.
    /// </summary>
    public BinaryTreeNode<T>? Parent { get; set; }

    /// <summary>
    /// Gets or sets the left child node.
    /// </summary>
    public BinaryTreeNode<T>? Left { get; set; }

    /// <summary>
    /// Gets or sets the right child node.
    /// </summary>
    public BinaryTreeNode<T>? Right { get; set; }
    
    /// <inheritdoc/>
    public override string? ToString()
    {
        return Value?.ToString();
    }
}