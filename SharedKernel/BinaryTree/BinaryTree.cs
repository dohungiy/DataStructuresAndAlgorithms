using System.Collections;

namespace SharedKernel.BinaryTree;

public class BinaryTree<T> : IComparer<T>
{
    /// <summary>
    /// Gets or sets the root of the tree.
    /// </summary>
    public BinaryTreeNode<T>? Root { get; set; }

    public BinaryTree()
    {
        Root = null;
    }

    public void Insert(T value)
    {
        Insert(new BinaryTreeNode<T>(value));
    }

    public void Insert(BinaryTreeNode<T> node)
    {
        BinaryTreeNode<T>? parent = null;
        BinaryTreeNode<T>? current = Root;

        while (current is not null)
        {
            parent = current;

            // node.Value > current.Value => 1
            // node.Value < current.Value => -1
            // node.Value > current.Value => 0

            int compared = this.Compare(node.Value, current.Value);
            if (compared < 0)
            {
                current = current.Left;
            }
            else if (compared > 0)
            {
                current = current.Right;
            }
            else
            {
                throw new ArgumentException($"A node with value {node.Value} already exists!");
            }
        }

        node.Parent = parent;

        if (parent == null)
        {
            Root = node;
        }
        else if (this.Compare(node.Value, parent.Value) < 0) // node.Value < current.Value
        {
            parent.Left = node;
        }
        else
        {
            parent.Right = node;
        }
    }

    public void Delete(T value)
    {
        Root = DeleteRec(Root, value);
    }

    private BinaryTreeNode<T>? DeleteRec(BinaryTreeNode<T>? root, T value)
    {
        if (root == null)
        {
            return null;
        }

        // Di chuyển xuống cây để tìm nút cần xóa
        int compared = this.Compare(value, root.Value);

        if (compared < 0)
        {
            root.Left = DeleteRec(root.Left, value);
        }
        else if (compared > 0)
        {
            root.Right = DeleteRec(root.Right, value);
        }
        else
        {
            // Nếu nút có một hoặc không có con
            if (root.Left == null)
            {
                return root.Right;
            }
            else if (root.Right == null)
            {
                return root.Left;
            }

            // Nếu nút có hai con, tìm nút kế tiếp trong thứ tự tăng dần
            root.Value = FindMinValue(root.Right);

            // Xóa nút kế tiếp
            root.Right = DeleteRec(root.Right, root.Value);
        }

        return root;
    }

    private T FindMinValue(BinaryTreeNode<T> root)
    {
        T minValue = root.Value;
        while (root.Left != null)
        {
            minValue = root.Left.Value;
            root = root.Left;
        }

        return minValue;
    }

    public void Replace(BinaryTreeNode<T> node, BinaryTreeNode<T>? replacement)
    {
        if (node.Parent == null)
        {
            Root = replacement;
        }
        else if (node == node.Parent.Left)
        {
            node.Parent.Left = replacement;
        }
        else
        {
            node.Parent.Right = replacement;
        }

        if (replacement != null)
        {
            replacement.Parent = node.Parent;
        }
    }

    public BinaryTreeNode<T>? Search(T value)
    {
        BinaryTreeNode<T>? current = Root;

        while (current != null)
        {
            int compared = this.Compare(value, current.Value);

            if (compared < 0)
            {
                current = current.Left;
            }
            else if (compared > 0)
            {
                current = current.Right;
            }
            else
            {
                return current;
            }
        }

        return current;
    }

    public void InOrderTraversal()
    {
        if (Root != null)
        {
            InOrderTraversal(Root.Left);
            Console.Write(Root.Value + " ");
            InOrderTraversal(Root.Right);
        }
    }

    public void InOrderTraversal(BinaryTreeNode<T>? root)
    {
        if (root != null)
        {
            InOrderTraversal(root.Left);
            Console.Write(root.Value + " ");
            InOrderTraversal(root.Right);
        }
    }

    public virtual int Compare(T? x, T? y)
    {
        return Comparer<T>.Default.Compare(x, y);
    }
}