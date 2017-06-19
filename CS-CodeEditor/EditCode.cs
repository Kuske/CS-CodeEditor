using System;
// using Kuske.NewComers.KeyWordCheck;

namespace Kuske.NewComers.CodeEditor
{
    class Indent
    {

        static public int GetTab_Num(string text, int Line_Num)
        {
            int ans = 0;

            int NowLine = 1;
            for (int a = 0; a < text.Length; a++)
            {
                if (NowLine == Line_Num)
                {
                    for (int b = 0; ; b++)
                    {
                        if (text[a + b] != '\t') break;
                        else ans++;
                    }
                    return ans;
                }
                if (text[a] == '\n') NowLine++;
            }
            return 0;
        }

        static public string SetAllIndent(string Code)
        {

            // 現在の行で必要なタブの数
            int NowIndent = 0;
            int NowLineTab = 0;

            // 配列の要素数
            for (int a = 0; a < Code.Length; a++)
            {
                if (Code[a] == '\t')
                {
                    NowLineTab++;

                    if (a < Code.Length - 1)
                    {
                        
                        if (NowIndent < NowLineTab)
                        {
                            Code = Code.Remove(a, 1);
                        }

                        if (Code[a + 1] == '}')
                        {
                            Code = Code.Remove(a, 1);
                        }
                    }
                }

                if (Code[a] == '\n')
                {
                    NowLineTab = 0;
                    if (a + 1 < Code.Length)
                    {

                        // 最初のインデントを確認  
                        for (int indent_num = 0; a + indent_num <= Code.Length; indent_num++)
                        {
                            if (Code[a + indent_num + 1] != '\t')
                            {
                                if (indent_num <= NowIndent)
                                {
                                    // インデントを追加
                                    for (int i = 0; i < NowIndent - indent_num; i++)
                                    {
                                        Code = Code.Insert(a + 1, "\t");
                                    }
                                }
                                else
                                {
                                    // タブを消す
                                    Code = Code.Remove(a + 1, indent_num - NowIndent);
                                }
                                break;
                            }

                            // インデントの更新
                            if (Code[a + 1] == '{') NowIndent++;
                            if (Code[a + 1] == '}') NowIndent--;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    // インデントの更新
                    if (Code[a] == '{') NowIndent++;
                    if (Code[a] == '}') NowIndent--;
                }

            }

            return Code;
        }
    }
}