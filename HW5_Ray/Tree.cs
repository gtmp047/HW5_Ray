using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_Ray
{
    class Tree
    {
        public class TreeNode
        {
            public TreeNode Left;
            public TreeNode Right;
        }
        public TreeNode Node = new TreeNode();
        public bool isExist = false;
        string GetByteFromString(String str)
        {
            string tmp = "";
            for (int i = 0; i < str.Length; i++)
            {
                for (int y = 0; y < 8; y++)
                {
                    tmp += (str[i] >> y & 1).ToString();
                }
            }
            return tmp;
        }
        public void Add(String str)
        {
            isExist = true;
            AddRecursion(ref Node, GetByteFromString(str));
        }
        private void AddRecursion(ref TreeNode node, String val)
        {
            if (val.Length == 0)
                return;
            Char elem = val[0]; 
            if (elem.CompareTo('0') == 0) // есть такой уже элемент уже;
            {
                if(node.Left == null)
                {
                    isExist = false;
                    node.Left = new TreeNode();
                }
                AddRecursion(ref node.Left, val.Remove(0,1));
            }
            else
            {
                if (node.Right == null)
                {
                    isExist = false;
                    node.Right = new TreeNode();
                }
                AddRecursion(ref node.Right, val.Remove(0, 1));
            }
        }
    }
}
