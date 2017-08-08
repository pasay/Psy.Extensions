using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace System.IO
{
    /// <summary>
    /// Dosya işlemlerinde kolaylıklar sağlamaktadır.
    /// </summary>
    public static class FileClass
    {
        #region OpenToExplorer
        public static void OpenToExplorer(this FileSystemInfo name)
        {
            OpenToExplorer(name.FullName);
        }
        public static void OpenToExplorer(this string name)
        {
            FileSystemInfo f = new FileInfo(name);
            if (f.Exists == false) 
            {
                f = new DirectoryInfo(name);
                if (f.Exists == false) { return; }
            }

            ProcessStartInfo pi = new ProcessStartInfo("explorer.exe");
            if (f is FileInfo )
            {
                pi.Arguments = "/select, \"" + f.FullName + "\"";
            }
            else
            {
                pi.Arguments = "\"" + f.FullName + "\"";
            }

            pi.WindowStyle = ProcessWindowStyle.Normal;
            Process.Start(pi);
        }
        #endregion

        #region FileRename
        public static FileInfo FileRename(this FileInfo filename, string NewFileName)
        {
            NewFileName = FileRename(filename.FullName, NewFileName);
            FileInfo f = new FileInfo(NewFileName);
            return f;
        }
        public static string FileRename(this string filename, string NewFileName)
        {
            if (string.IsNullOrEmpty(filename)) { return ""; }
            FileInfo fOld = new FileInfo(filename);
            if (fOld.Exists == false) { return ""; }
            if (NewFileName == null) { NewFileName = ""; }
            if (fOld.Name.ToUpperInvariant() == NewFileName.ToUpperInvariant())
            {
                //Dosya Adı değiştirilmemiş.
                return filename;
            }

            //Yeni dosya adını oluştur.
            string fileNameHeader = fOld.Name.Remove(fOld.Name.LastIndexOf(fOld.Extension));
            NewFileName = NewFileName.StartsWith(".") ? NewFileName : "." + NewFileName;
            NewFileName = fileNameHeader + NewFileName;

            FileInfo fNew = new FileInfo(Path.Combine(fOld.Directory.FullName, NewFileName));
            try
            {
                //Yeni dosya adı mevcutta bulunuyor mu?
                if (fNew.Exists) { fNew.Delete(); }
                //Burada şu anda replace işlemi yapılamıyor
                //File.Replace(fOld.FullName, fNew.FullName, fNew.FullName);
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(fOld.FullName, NewFileName);
            }
            catch
            {
            }

            return fNew.FullName;
        }
        public static FileInfo FileRenameExtensions(this FileInfo filename, string NewFileExt)
        {
            NewFileExt = FileRenameExtensions(filename.FullName, NewFileExt);
            FileInfo f = new FileInfo(NewFileExt);
            return f;
        }
        public static string FileRenameExtensions(this string filename, string NewFileExt)
        {
            if (string.IsNullOrEmpty(filename)) { return ""; }
            FileInfo fOld = new FileInfo(filename);
            if (fOld.Exists == false) { return ""; }
            if (NewFileExt == null) { NewFileExt = ""; }

            if (fOld.Extension.ToUpperInvariant() == "." + NewFileExt.TrimStart(new char[] { '.' }).ToUpperInvariant())
            {
                //Dosya Uzantısı değiştirilmemiş.
                return filename;
            }

            //Yeni dosya adını oluştur.
            string fileNameHeader = fOld.Name.Remove(fOld.Name.LastIndexOf(fOld.Extension));
            NewFileExt = NewFileExt.StartsWith(".") ? NewFileExt : "." + NewFileExt;
            NewFileExt = fileNameHeader + NewFileExt;

            FileInfo fNew = new FileInfo(Path.Combine(fOld.Directory.FullName, NewFileExt));
            try
            {
                //Yeni dosya adı mevcutta bulunuyor mu?
                if (fNew.Exists) { fNew.Delete(); }
                //Burada şu anda replace işlemi yapılamıyor
                //File.Replace(fOld.FullName, fNew.FullName, fNew.FullName);
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(fOld.FullName, NewFileExt);
            }
            catch
            {
            }

            return fNew.FullName;
        }
        #endregion

        #region GetAssembly
        public static Assembly GetAssembly(this FileInfo filename)
        {
            return GetAssembly(filename.FullName);
        }
        public static Assembly GetAssembly(this string filename)
        {
            Assembly _assembly = null;

            if (string.IsNullOrEmpty(filename)) { return _assembly; }
            try
            {
                _assembly = Assembly.Load(File.ReadAllBytes(filename));
                //_assembly = Assembly.LoadFile(filename);
            }
            catch
            {
            }

            return _assembly;
        }
        public static Version GetAssemblyVersion(this Assembly assembly)
        {
            if (assembly == null) { return new Version(); }

            return assembly.GetName().Version;
        }
        public static string GetAssemblyTitle(this Assembly assembly)
        {
            if (assembly == null) { return ""; }

            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title.Length > 0) return titleAttribute.Title;
            }
            return System.IO.Path.GetFileNameWithoutExtension(assembly.CodeBase);
        }
        public static string GetAssemblyProductName(this Assembly assembly)
        {
            if (assembly == null) { return ""; }

            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
        }
        public static string GetAssemblyDescription(this Assembly assembly)
        {
            if (assembly == null) { return ""; }

            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }
        public static string GetAssemblyCopyrightHolder(this Assembly assembly)
        {
            if (assembly == null) { return ""; }

            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }
        public static string GetAssemblyCompanyName(this Assembly assembly)
        {
            if (assembly == null) { return ""; }

            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
        #endregion

        #region File Read/Save
        public static bool Save(this string text, string fullFilename)
        {
            try
            {
                System.IO.File.WriteAllText(fullFilename, text);
                return true;
            }
            catch
            {
            }

            return false;
        }
        #endregion

        #region GetRunFolder
        /// <summary>
        /// DLL 'in bulunduğu adresi vermektedir.
        /// </summary>
        public static string GetRunFolder()
        {
            if (string.IsNullOrEmpty(_getRunFolder) == false) { return _getRunFolder; }
            try
            {
                FileInfo fileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);

                _getRunFolder = fileInfo.Directory.FullName;
            }
            catch
            {
            }

            return _getRunFolder;
        }
        private static string _getRunFolder = "";


        /// <summary>
        /// DLL 'in bulunduğu adrese verilen dosya bilgisini ekleyerek geri dönderir.
        /// </summary>
        public static string GetRunFolderCombine(this string addPath)
        {
            string folder = GetRunFolder();

            if (string.IsNullOrWhiteSpace(addPath)) { return folder; }

            return Path.Combine(folder.Trim(new char[] { '\\' }), addPath.Trim(new char[] { '\\' }));
        }
        #endregion

        #region Run
        /// <summary>
        /// Exe dosyayı çalıştırır.
        /// </summary>
        public static Process Run(this string exeFile, string args = "")
        {
            try
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(exeFile, args);
                p.StartInfo.UseShellExecute = false;
                p.Start();

                return p;
            }
            catch
            {
                try
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(exeFile, args);
                    p.StartInfo.UseShellExecute = true;
                    p.Start();

                    return p;
                }
                catch
                {
                }
            }

            return null;
        }
        #endregion

        #region GetEnumToListStringFromDll
        public static List<System.ConvertionClass.CL_Enum> GetEnumToListStringFromDll(string enumName)
        {
            Assembly dll;
            List<System.ConvertionClass.CL_Enum> retVal = new List<System.ConvertionClass.CL_Enum>();

            try
            {
                if (string.IsNullOrEmpty(enumName))
                {
                    return retVal;
                }

                string[] s = enumName.Split(new string[] { ".", "+" }, StringSplitOptions.RemoveEmptyEntries);
                if (s == null || s.Length < 2)
                {
                    return retVal;
                }

                dll = (s[0] + ".dll").GetAssembly();
                if (dll == null)
                {
                    return retVal;
                }

                int i = 0;
                string enumVal = s[i];
                for (i = 1; i < s.Length - 1; i++)
                {
                    enumVal += "." + s[i];
                }
                enumVal += "+" + s[i];

                Type myEnum = dll.GetType(enumVal);


                retVal =  myEnum.ToConvertEnumClassList();
            }
            catch
            {
                retVal = new List<System.ConvertionClass.CL_Enum>();
            }
            finally
            {
                dll = null;
            }
            
            return retVal;
        }
        #endregion
    }
}
