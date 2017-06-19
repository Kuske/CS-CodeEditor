using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kuske.NewComers.CodeEditor;
using System.IO;
using System.Diagnostics;

namespace CS_CodeEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // インデントをそろえる
            {
                int Now_Pos = richTextBox1.SelectionStart;
                int Now_Line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);

                richTextBox1.Text = Indent.SetAllIndent(richTextBox1.Text);
                richTextBox1.Text = Indent.SetAllIndent(richTextBox1.Text);

                richTextBox1.SelectionStart = Now_Pos + Indent.GetTab_Num(richTextBox1.Text, Now_Line);
                
                if(richTextBox1.Text.Length > 0)
                {
                    if (richTextBox1.Text[Math.Min(richTextBox1.SelectionStart, Math.Max(0, richTextBox1.Text.Length - 1))] == '}')
                        --richTextBox1.SelectionStart;
                }
            }

            // 色の変更
            {
                string[] SearchWord = {
                      "using"
                    , "string"
                };

                for(int a = 0; a < SearchWord.GetLength(2); a++)
                {
                    int FoundIndex = richTextBox1.Text.IndexOf(SearchWord[a]);
                    while(0 <= FoundIndex)
                    {
                        richTextBox1.Select(FoundIndex, SearchWord[a].Length);
                        richTextBox1.SelectionColor = Color.Blue;
                        
                        if (FoundIndex + SearchWord[a].Length < )
                    }
                }

            }

            richTextBox1.Font = new Font("Consolas", 14);

        }
    }
}
