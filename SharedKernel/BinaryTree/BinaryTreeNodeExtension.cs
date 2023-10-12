// namespace SharedKernel.BinaryTree;
//
// public static class BinaryTreeNodeExtension
// {
//     public static BinaryTreeNode<T>? Successor<T>(this BinaryTreeNode<T> node)
//     {
//         if (node.Right != null)
//         {
//             return node.Right.Minimum();
//         }
//
//         BinaryTreeNode<T>? current = node.Parent;
//
//         while (current != null && node == current.Right)
//         {
//             node = current;
//             current = current.Parent;
//         }
//
//         return current;
//     }
//
//     /// <summary>
//     /// Searches for the predecessor of a node.
//     /// </summary>
//     /// <typeparam name="T">The type of the values.</typeparam>
//     /// <param name="node">The node.</param>
//     /// <returns>The predecessor node.</returns>
//     public static BinaryTreeNode<T>? Predecessor<T>(BinaryTreeNode<T> node)
//     {
//         if (node.Left != null)
//         {
//             return node.Left.Maximum();
//         }
//
//         BinaryTreeNode<T>? current = node.Parent;
//
//         while (current != null && node == current.Left)
//         {
//             node = current;
//             current = current.Parent;
//         }
//
//         return current;
//     }
// }