using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace HW5_Ray
{
    

    public partial class Form1 : Form
    {
        string filePath = "";
        Tree tr = new Tree();
       public class Node
        {
            public Char Value;
            public Node(char c)
            {
                Value = c;
            }
        }
        TreeNode Find (TreeNodeCollection arr, string str) // хз почему но стандартный метод не робит
        {
            foreach (TreeNode item in arr)
            {
                if (item.Text.CompareTo(str) == 0)
                    return item;
            }
            return null;
        }
        string FindElement (string elmemetToFind, TreeNode tn)
        {
            TreeNode newTN = null;
            char elem = elmemetToFind[0];
            if(tn != null)
            {
                if (Find(tn.Nodes, elem.ToString()) == null)
                    return "";
                else
                    newTN = Find(tn.Nodes, elem.ToString());
            }
            else
            {
                if (Find(treeView1.Nodes, elem.ToString())==null)
                    return "";
                else
                    newTN = Find(treeView1.Nodes, elem.ToString());
            }
            return elem.ToString() + FindElement(elmemetToFind.Remove(0, 1),newTN);
        }
        void InsertElement(String str)
        {
            Insert(null ,str);
        }
        void Insert(TreeNode tn, String str)
        { 
            TreeNode newTN = null;
            if (str.Length == 0)
                return;
            char elem = str[0];
            while (!char.IsLetter(elem))
            {
                str = str.Remove(0, 1);
                if (str.Length == 0)
                    return;
                elem = str[0];
            }

            if(tn != null)
            {
                if (Find(tn.Nodes, elem.ToString()) == null)
                    newTN = tn.Nodes.Add(elem.ToString());
                else
                    newTN = Find(tn.Nodes, elem.ToString());
            }
            else
            {
                if (Find(treeView1.Nodes, elem.ToString())==null)
                    newTN = treeView1.Nodes.Add(elem.ToString());
                else
                    newTN = Find(treeView1.Nodes, elem.ToString());
            }
            Insert(newTN, str.Remove(0, 1));
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор - Бурыгин Антон");
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string[] dataFile;
            openFileDialog1.InitialDirectory = "D:\\gtmp\\Documents\\VisualStudio\\Projects\\Data_Romanenkov\\HW5_Ray";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                textBox2.Text = filePath;
                dataFile = File.ReadAllText(filePath).Split(new char[] { ' ' });
                foreach (var item in dataFile)
                {
                    InsertElement(item);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text += "Лучевой поиск элемента " + textBox1.Text + Environment.NewLine;
            textBox3.Text += "Элемент с максимальным сходством : ";
            textBox3.Text += FindElement(textBox1.Text, null) + Environment.NewLine+Environment.NewLine;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text += "Бинарный поиск элемента " + textBox1.Text + Environment.NewLine;
            tr.Add(textBox1.Text);
            if (tr.isExist == true)
            {
                textBox3.Text += "Элемент " + textBox1.Text + "  уже существует" + Environment.NewLine + Environment.NewLine;
            }
            else
            {
                textBox3.Text += "Элемент " + textBox1.Text + "  был добавлен" + Environment.NewLine + Environment.NewLine;
            }



        }
    }
}
