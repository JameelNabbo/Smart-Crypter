//  EncryptionProvider.cs
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
using System.Security.Cryptography;
using System.Text;

namespace Smart_Crypter
{
    class EncryptionProvider
    {
        //AES(acronym of Advanced Encryption Standard) is a symmetric encryption algorithm.
        //The algorithm was developed by two Belgian cryptographer Joan Daemen and Vincent Rijmen.
        //AES was designed to be efficient in both hardware and software, and supports a block length of 128 bits and key lengths of 128, 192, and 256 bits.

        public static string AES_Encrypt(string Intext, string iKey)
        {
            AesManaged aesManaged = new AesManaged();
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] key = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(iKey));
            aesManaged.Key = key;
            aesManaged.Mode = CipherMode.ECB;
            byte[] bytes = Encoding.ASCII.GetBytes(Intext);
            return Convert.ToBase64String(aesManaged.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
        }
        //#####################################################################

        //RC2 Encryption
        //Encryption.This takes a 64-bit input quantity stored in words
        //R[0], ..., R[3] and encrypts it "in place" (the result is left in
        //R[0], ..., R[3]).
        //Decryption.The inverse operation to encryption.
        public static string RC2_Encrypt(string input, string pass)
        {
            RC2CryptoServiceProvider RC2 = new RC2CryptoServiceProvider();
            MD5CryptoServiceProvider Hash_RC2 = new MD5CryptoServiceProvider();
            string encrypted = "";
            try
            {
                byte[] hash = Hash_RC2.ComputeHash(Encoding.ASCII.GetBytes(pass));
                RC2.Key = hash;
                RC2.Mode = CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESEncrypter = RC2.CreateEncryptor();
                byte[] Buffer = Encoding.ASCII.GetBytes(input);
                encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
                return encrypted;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        //#####################################################################
       
            
            
        //    Rijndael is the block cipher algorithm recently chosen by the National Institute of 
        //    Science and Technology(NIST) as the Advanced Encryption Standard(AES). It supercedes the Data
        //    Encryption Standard(DES). NIST selected Rijndael as the standard symmetric key encryption algorithm 
        //    to be used to encrypt sensitive(unclassified) American federal information.The choice was based on a 
        //    careful and comprehensive analysis of the security and efficiency characteristics of Rijndael's algorithm.
        public static string Rijndaelcrypt(string File, string Key)
        {
            RijndaelManaged oAesProvider = new RijndaelManaged();
            byte[] btClear = null;
            byte[] btSalt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Rfc2898DeriveBytes oKeyGenerator = new Rfc2898DeriveBytes(Key, btSalt);
            oAesProvider.Key = oKeyGenerator.GetBytes(oAesProvider.Key.Length);
            oAesProvider.IV = oKeyGenerator.GetBytes(oAesProvider.IV.Length);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, oAesProvider.CreateEncryptor(), CryptoStreamMode.Write);
            btClear = System.Text.Encoding.UTF8.GetBytes(File);
            cs.Write(btClear, 0, btClear.Length);
            cs.Close();
            File = Convert.ToBase64String(ms.ToArray());
            return File;
        }




        //#####################################################################

        //Triple DES uses a "key bundle" that comprises three DES keys, K1, K2 and K3, each of 56 bits(excluding parity bits). The encryption algorithm is:
        //ciphertext = EK3(DK2(EK1(plaintext)))
        //I.e., DES encrypt with K1, DES decrypt with K2, then DES encrypt with K3.
        //Decryption is the reverse:
        //plaintext = DK1(EK2(DK3(ciphertext)))
        //I.e., decrypt with K3, encrypt with K2, then decrypt with K1.
        //Each triple encryption encrypts one block of 64 bits of data.


        public static string TripleDes(string input, string key)
        {
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] key2 = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(key));
            tripleDESCryptoServiceProvider.Key = key2;
            tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            return Convert.ToBase64String(tripleDESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
        }

        //#####################################################################

        //Plaintext ⊕ Key = Ciphertext
        //Ciphertext ⊕ Key = Plaintext
        public static string VernamII(string input, string pass)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char @string = input[i];
                string value = Strings.ChrW(Strings.AscW(@string) * (Strings.AscW(pass) % 30)).ToString();
                stringBuilder.Append(value);
            }
            return stringBuilder.ToString();
        }

        //#####################################################################
        // C_i = E_K(M_i) = (M_i+K_i) mod
        // M_i = D_K(C_i) = (C_i - K_i) mod
        public static string Vigenere(string text, string pass)
        {
            string text2 = null;
            for (int i = 1; i <= text.Length; i++)
            {
                int charCode = Strings.AscW(Strings.GetChar(text, i)) + Strings.AscW(Strings.GetChar(pass, i % pass.Length + 1));
                text2 += Strings.ChrW(charCode);
            }
            return text2;
        }

    }
}
