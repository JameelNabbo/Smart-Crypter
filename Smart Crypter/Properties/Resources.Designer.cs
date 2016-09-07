﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Smart_Crypter.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Smart_Crypter.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to public static string AES_Decrypt(string TexT, string iKey)
        ///        {
        ///            AesManaged AES_256 = new AesManaged();
        ///            MD5CryptoServiceProvider HashAES = new MD5CryptoServiceProvider();
        ///            string Decrypt = &quot;&quot;;
        ///            byte[] Hash = HashAES.ComputeHash(ASCIIEncoding.ASCII.GetBytes(iKey));
        ///            AES_256.Key = Hash;
        ///            AES_256.Mode = CipherMode.ECB;
        ///            byte[] Buffer1 = Convert.FromBase64String(TexT);
        ///            Decrypt = System.Text.ASCIIEncoding.ASCI [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AESDecrypt {
            get {
                return ResourceManager.GetString("AESDecrypt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        internal static System.IO.UnmanagedMemoryStream Clicking_Sounds {
            get {
                return ResourceManager.GetStream("Clicking_Sounds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to public static string RC2_Decrypt(string intext, string pass)
        ///        {
        ///            RC2CryptoServiceProvider RC2 = new RC2CryptoServiceProvider();
        ///            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        ///            string decrypt = &quot;&quot;;
        ///            byte[] Code = MD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass));
        ///            RC2.Key = Code;
        ///            RC2.Mode = CipherMode.ECB;
        ///            byte[] base64 = Convert.FromBase64String(intext);
        ///            decrypt = System. [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RC2Decrypt {
            get {
                return ResourceManager.GetString("RC2Decrypt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to public static string ReverseString(string s)
        ///        {
        ///            char[] arr = s.ToCharArray();
        ///            Array.Reverse(arr);
        ///            return new string(arr);
        ///        }.
        /// </summary>
        internal static string ReverseString {
            get {
                return ResourceManager.GetString("ReverseString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to public static string RijndaelDecrypt(string UDecryptU, string UKeyU)
        ///        {
        ///            RijndaelManaged XoAesProviderX = new RijndaelManaged();
        ///            byte[] XbtCipherX = null;
        ///            byte[] XbtSaltX = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        ///            Rfc2898DeriveBytes XoKeyGeneratorX = new Rfc2898DeriveBytes(UKeyU, XbtSaltX);
        ///            XoAesProviderX.Key = XoKeyGeneratorX.GetBytes(XoAesProviderX.Key.Length);
        ///            XoAesProviderX.IV = XoKeyGeneratorX.GetBytes(XoAesProviderX.IV. [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RijndaelDecrypt {
            get {
                return ResourceManager.GetString("RijndaelDecrypt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to public static string TDesDecrypt(string txt, string pass)
        ///        {
        ///            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        ///            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        ///            string decrypt = &quot;&quot;;
        ///
        ///            byte[] Kode = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pass));
        ///            tdes.Key = Kode;
        ///            tdes.Mode = CipherMode.ECB;
        ///            byte[] base64 = Convert.FromBase64String(txt);
        ///            decrypt = System.T [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TDesDecrypt {
            get {
                return ResourceManager.GetString("TDesDecrypt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to public static string VernamDecrypt(string input, string pass)
        ///        {
        ///            StringBuilder Out1 = new StringBuilder();
        ///            foreach(char ch in input)
        ///            {
        ///                string tmp = Strings.ChrW(Strings.AscW(ch) / (Strings.AscW(pass) % 30)).ToString();
        ///             Out1.Append(tmp);
        ///            }
        ///            return Out1.ToString();
        ///            }.
        /// </summary>
        internal static string VernamDecrypt {
            get {
                return ResourceManager.GetString("VernamDecrypt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to public static string VigenereDecrypt(string text, string pass)
        ///        {
        ///            string morocco = null;
        ///            for (int i = 1; i &lt;= text.Length;i++ )
        ///            {
        ///                int tmp = Strings.AscW(Strings.GetChar(text, i)) - Strings.AscW(Strings.GetChar(pass, i % pass.Length + 1));
        ///                morocco += Strings.ChrW(tmp);
        ///            }
        ///            return morocco;
        ///        }.
        /// </summary>
        internal static string VigenereDecrypt {
            get {
                return ResourceManager.GetString("VigenereDecrypt", resourceCulture);
            }
        }
    }
}
