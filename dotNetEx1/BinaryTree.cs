using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace dotNetEx1
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T data;
        public TreeNode<T> parent = null;
        public TreeNode<T> left = null;
        public TreeNode<T> right = null;

        public TreeNode(T Data)
        {
            data = Data;
        }
    }
    public class BinaryTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root = null;

        public void Add(T info)
        {
            if (root == null)
            {
                root = new TreeNode<T>(info);
                return;
            }
            else
            {
                TreeNode<T> current = root;
                TreeNode<T> elem = new TreeNode<T>(info);
                while (current != null)
                {
                    if (current.data.CompareTo(elem.data) == 0)
                        return;
                    else if (current.data.CompareTo(elem.data) > 0)
                    {
                        if (current.left == null)
                        {
                            current.left = elem;
                            elem.parent = current;
                            return;
                        }
                        else
                        {
                            current = current.left;
                        }
                    }
                    else
                    {
                        if (current.right == null)
                        {
                            current.right = elem;
                            elem.parent = current;
                            return;
                        }
                        else
                        {
                            current = current.right;
                        }
                    }
                }
            }
            
        }

        public TreeNode<T> Search(T val)
        {
            TreeNode<T> current = root;
            while (current != null)
            {
                if (current.data.CompareTo(val) == 0)
                {
                    return current;
                }
                else if (current.data.CompareTo(val) > 0)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
            return null;
        }

        public TreeNode<T> Minimum(TreeNode<T> node)
        {
            if (node.left == null)
            {
                return node;
            }
            return Minimum(node.left);
        }

        public TreeNode<T> Maximum(TreeNode<T> node)
        {
            if (node.right == null)
            {
                return node;
            }

            return Maximum(node.right);
        }

        public TreeNode<T> Next(TreeNode<T> node)
        {
            if (node.right == null)
            {
                return Minimum(node.right);
            }

            TreeNode<T> parent = node.parent;
            while (parent != null && node == parent.right)
            {
                node = parent;
                parent = parent.parent;
            }

            return parent;
        }

        public TreeNode<T> Prev(TreeNode<T> node)
        {
            if (node.left == null)
            {
                return Maximum(node.right);
            }

            TreeNode<T> parent = node.parent;
            while (parent != null && node == parent.left)
            {
                node = parent;
                parent = parent.parent;
            }

            return parent;
        }

        public bool Remove(T val)
        {
            TreeNode<T> elem = Search(val);
            if (elem == null)
            {
                return false;
            }
            else
            {
                TreeNode<T> parent = elem.parent;
                if (elem.left == null && elem.right == null)
                {
                    if (parent.left == elem)
                    {
                        parent.left = null;
                    }

                    if (parent.right == elem)
                    {
                        parent.right = null;
                    }

                    return true;
                }
                else if (elem.left == null || elem.right == null)
                {
                    if (elem.left == null)
                    {
                        if (parent.left == elem)
                        {
                            parent.left = elem.right;

                        }
                        else
                        {
                            parent.right = elem.right;
                        }

                        elem.right.parent = parent;
                    }
                    else
                    {
                        if (parent.left == elem)
                        {
                            parent.left = elem.left;

                        }
                        else
                        {
                            parent.right = elem.left;
                        }

                        elem.left.parent = parent;
                    }

                    return true;
                }
                else
                {
                    TreeNode<T> min = Minimum(elem.right);
                    elem.data = min.data;
                    if (min.parent.right == min)
                    {
                        min.parent.right = min.right;
                    }
                    else
                    {
                        min.parent.left = min.right;
                    }

                    return true;
                }
            }
        }
    }
}
