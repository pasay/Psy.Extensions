using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.Security.Cryptography;

namespace System
{
    public static class SerializeClass
    {
        #region Enum
        #region FormatterType
        public enum FormatterType
        {
            Xml,
            XmlCrypto,
            Binary,
        }
        #endregion
        #endregion

        #region Struct
        #region SymmetricAlgorithm
        public static System.Security.Cryptography.DESCryptoServiceProvider DESC = new DESCryptoServiceProvider()
        {
            Key = new byte[8] { 
                1,2,127,128,128,127,2,1
            },

             IV  = new byte[8] { 
               128,127,1,2,2,1,127,128
            }
        };
        public static System.Security.Cryptography.MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        //public static System.Security.Cryptography.SHA512CryptoServiceProvider SHA512 = new SHA512CryptoServiceProvider();
        #endregion

        #region RetVal
        public struct RetVal
        {
            public bool Return;
            public ExceptionClass Message;

            public override bool Equals(Object obj)
            {
                if (Object.ReferenceEquals(null, obj)) { return false; }
                return obj is RetVal && this == (RetVal)obj;
            }
            public override int GetHashCode()
            {
                return Return.GetHashCode()
                        ^ Message.GetHashCode(); 
            }
            public static bool operator ==(RetVal x, RetVal y)
            {
                if (Object.ReferenceEquals(null, x) && Object.ReferenceEquals(null, y)) { return true; }
                if (Object.ReferenceEquals(null, x) || Object.ReferenceEquals(null, y)) { return false; }

                return x.Return == y.Return;
            }
            public static bool operator !=(RetVal x, RetVal y)
            {
                if (Object.ReferenceEquals(null, x) && Object.ReferenceEquals(null, y)) { return false; }
                if (Object.ReferenceEquals(null, x) || Object.ReferenceEquals(null, y)) { return true; }

                return !(x.Return == y.Return);
            }
            public static bool operator ==(RetVal x, bool y)
            {
                if (Object.ReferenceEquals(null, x)) { return false; }
                return x.Return == y;
            }
            public static bool operator !=(RetVal x, bool y)
            {
                if (Object.ReferenceEquals(null, x)) { return false; }
                return !(x.Return == y);
            }
        }
        #endregion
        #endregion

        #region Formatter
        #region Serialize
        public static RetVal Serialize<SOURCE>(this SOURCE value, string file, FormatterType SerializeType)
        {
            return Serialize(file, SerializeType, value);
        }
        public static RetVal Serialize<SOURCE>(this string file, FormatterType SerializeType, SOURCE value)
        {
            if (string.IsNullOrEmpty(file))
            {
                RetVal r = new RetVal();
                r.Message = new ExceptionClass("Dosya yolu belirtilmemiş.");
                r.Return = false;
                return r;
            }

            FileInfo f = new FileInfo(file);

            return f.Serialize(SerializeType, value);
        }
        public static RetVal Serialize<SOURCE>(this FileInfo file, FormatterType SerializeType, SOURCE value)
        {
            switch (SerializeType)
            {
                case FormatterType.Binary:
                    return file.SerializeBINARY(value);
                case FormatterType.XmlCrypto:
                    return file.SerializeXmlCrypto(value, DESC);
                default:
                //case FormatterType.XML:
                    return file.SerializeXML(value);
            }
        }
        #endregion

        #region Deserialize
        public static RetVal Deserialize<DESTINATION>(this DESTINATION value, string file, FormatterType SerializeType)
        {
            return Deserialize(file, SerializeType, ref value);
        }
        public static RetVal Deserialize<DESTINATION>(this string file, FormatterType SerializeType, ref DESTINATION value)
        {
            if ((string.IsNullOrEmpty(file)))
            {
                RetVal r = new RetVal();
                r.Message = new ExceptionClass ("Dosya yolu belirtilmemiş.");
                r.Return = false;
                return r;
            }

            FileInfo f = new FileInfo(file);

            return f.Deserialize(SerializeType, ref value);
        }
        public static RetVal Deserialize<DESTINATION>(this FileInfo file, FormatterType SerializeType, ref DESTINATION value)
        {
            switch (SerializeType)
            {
                case FormatterType.Binary:
                    return file.DeserializeBINARY(ref value);
                case FormatterType.XmlCrypto:
                    return file.DeserializeXMLCrypto(ref value, DESC);
                default:
                    //case FormatterType.XML:
                    return file.DeserializeXML(ref value);
            }
        }
        #endregion
        #endregion

        #region BinaryFormatter
        #region Serialize
        //public static RetVal SerializeBINARY<SOURCE>(this SOURCE value, string file)
        //{
        //    return SerializeBINARY(file, value);
        //}
        public static RetVal SerializeBINARY<SOURCE>(this string file, SOURCE value)
        {
            if (string.IsNullOrEmpty(file))
            {
                RetVal r = new RetVal();
                r.Message = new ExceptionClass("Dosya yolu belirtilmemiş.");
                r.Return = false;
                return r;
            }

            FileInfo f = new FileInfo(file);

            return f.SerializeBINARY(value);
        }
        public static RetVal SerializeBINARY<SOURCE>(this FileInfo file, SOURCE value)
        {
            RetVal r = new RetVal();

            try
            {
                file = new FileInfo(file.FullName);
                if (file.Directory.Exists == false)
                {
                    file.Directory.Create();
                }

                file = new FileInfo(file.FullName);
                if (file.Exists)
                {
                    file.Delete();
                }

                using (Stream stream = File.Open(file.FullName, FileMode.Create))
                {
                    BinaryFormatter bFormatter = new BinaryFormatter();
                    bFormatter.Serialize(stream, value);
                    stream.Close();
                }

                r.Message = new ExceptionClass ("İşlem Başarılı");
                r.Return = true;
            }
            catch (Exception Error)
            {
                r.Message = new ExceptionClass( Error);
                r.Return = false;
            }

            file = null;
            return r;
        }
        #endregion

        #region Deserialize
        public static RetVal DeserializeBINARY<SOURCE>(this SOURCE value, string file)
        {
            return DeserializeBINARY(file, ref value);
        }
        public static RetVal DeserializeBINARY<SOURCE>(this string file, ref SOURCE value)
        {
            if (string.IsNullOrEmpty(file))
            {
                RetVal r = new RetVal();
                r.Message = new ExceptionClass("Dosya bulunamadı.");
                r.Return = false;
                return r;
            }

            FileInfo f = new FileInfo(file);

            return f.DeserializeBINARY(ref value);
        }
        public static RetVal DeserializeBINARY<DESTINATION>(this FileInfo file, ref DESTINATION value)
        {
            RetVal r = new RetVal();

            try
            {
                file = new FileInfo(file.FullName);
                if (!file.Exists)
                {
                    r.Message = new ExceptionClass("Dosya bulunamadı.");
                    r.Return = false;
                    return r;
                }

                using (Stream stream = File.Open(file.FullName, FileMode.Open))
                {
                    BinaryFormatter bFormatter = new BinaryFormatter();
                    value = (DESTINATION)bFormatter.Deserialize(stream);
                    stream.Close();
                }

                r.Message = new ExceptionClass("İşlem Başarılı");
                r.Return = true;
            }
            catch (Exception Error)
            {
                r.Message = new ExceptionClass(Error);
                r.Return = false;
            }

            file = null;
            return r;
        }
        #endregion
        #endregion

        #region XMLFormatter
        #region Serialize
        public static RetVal SerializeXML<SOURCE>(this SOURCE value, string file)
        {
            return SerializeXML(file, value);
        }
        public static RetVal SerializeXML<SOURCE>(this string file, SOURCE value)
        {
            if (string.IsNullOrEmpty(file))
            {
                RetVal r = new RetVal();
                r.Message = new ExceptionClass("Dosya bulunamadı.");
                r.Return = false;
                return r;
            }

            FileInfo f = new FileInfo(file);

            return f.SerializeXML(value);
        }
        public static RetVal SerializeXML<SOURCE>(this FileInfo file, SOURCE value)
        {
            RetVal r = new RetVal();

            try
            {
                file = new FileInfo(file.FullName);
                if (file.Directory.Exists == false)
                {
                    file.Directory.Create();
                }

                file = new FileInfo(file.FullName);
                if (file.Exists)
                {
                    file.Delete();
                }
                
                using (Stream stream = File.Open(file.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SOURCE));
                    XmlTextWriter writer = new XmlTextWriter(stream, Encoding.Default);
                    writer.Formatting = Formatting.Indented;
                    serializer.Serialize(writer, value);
                    writer.Close();
                }

                r.Message = new ExceptionClass("İşlem Başarılı");
                r.Return = true;
            }
            catch (Exception Error)
            {
                try
                {
                    file = new FileInfo(file.FullName);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
                catch
                {
                }

                r.Message = new ExceptionClass(Error);
                r.Return = false;
            }

            file = null;
            return r;
        }
        #endregion

        #region Deserialize
        public static RetVal DeserializeXML<DESTINATION>(this string file, ref DESTINATION value)
        {
            if (string.IsNullOrEmpty(file))
            {
                RetVal r = new RetVal();
                r.Message = new ExceptionClass("Dosya bulunamadı.");
                r.Return = false;
                return r;
            }

            FileInfo f = new FileInfo(file);

            return f.DeserializeXML(ref value);
        }
        public static RetVal DeserializeXML<DESTINATION>(this FileInfo file, ref DESTINATION value)
        {
            RetVal r = new RetVal();

            file = new FileInfo(file.FullName);
            if (!file.Exists)
            {
                r.Message = new ExceptionClass("Dosya bulunamadı.");
                r.Return = false;
                file = null;
                return r;
            }

            int count = 0;
            while (true)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(DESTINATION));

                    using (Stream stream = File.Open(file.FullName, FileMode.Open, FileAccess.Read))
                    {
                        value = (DESTINATION)serializer.Deserialize(stream);
                        stream.Close();
                        stream.Dispose();
                        GC.SuppressFinalize(stream);
                        GC.Collect();
                    }
                    break;
                }
                catch (Exception Error)
                {
                    r.Message = new ExceptionClass(Error);
                    r.Return = false;
                    if (count++ > 3)
                    {
                        file = null;
                        return r; 
                    }
                    Threading.Thread.Sleep(500);
                }
            }

            r.Message = new ExceptionClass("İşlem Başarılı");
            r.Return = true;

            file = null;
            return r;
        }
        public static RetVal DeserializeXML<DESTINATION>(this Stream stream, ref DESTINATION value)
        {
            RetVal r = new RetVal();

            if (stream == null)
            {
                r.Message = new ExceptionClass("Dosya bulunamadı.");
                r.Return = false;
                return r;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DESTINATION));
                value = (DESTINATION)serializer.Deserialize(stream);
                stream.Close();
                stream.Dispose();
                GC.SuppressFinalize(stream);
                GC.Collect();
            }
            catch (Exception Error)
            {
                r.Message = new ExceptionClass(Error);
                r.Return = false;
                return r;
            }

            r.Message = new ExceptionClass("İşlem Başarılı");
            r.Return = true;

            return r;
        }
        #endregion
        #endregion

        #region XMLFormatterCrypto
        #region SerializeXmlCrypto
        public static RetVal SerializeXmlCrypto<SOURCE>(this  SOURCE value,string file, SymmetricAlgorithm key)
        {
            return SerializeXmlCrypto(file, value, key);
        }
        public static RetVal SerializeXmlCrypto<SOURCE>(this string file, SOURCE value, SymmetricAlgorithm key)
        {
            if (string.IsNullOrEmpty(file))
            {
                RetVal r = new RetVal();
                r.Message = new ExceptionClass("Dosya bulunamadı.");
                r.Return = false;
                return r;
            }

            FileInfo f = new FileInfo(file);

            return f.SerializeXmlCrypto(value, key);
        }
        public static RetVal SerializeXmlCrypto<SOURCE>(this FileInfo file, SOURCE value, SymmetricAlgorithm key)
        {
            RetVal r = new RetVal();

            try
            {
                file = new FileInfo(file.FullName);
                if (file.Directory.Exists == false)
                {
                    file.Directory.Create();
                }

                file = new FileInfo(file.FullName);
                if (file.Exists)
                {
                    file.Delete();
                }

                using (Stream stream = File.Open(file.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (CryptoStream cs = new CryptoStream(stream, key.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(SOURCE));
                        serializer.Serialize(cs, value);
                    }
                }

                r.Message = new ExceptionClass("İşlem Başarılı");
                r.Return = true;
            }
            catch (Exception Error)
            {
                r.Message = new ExceptionClass(Error);
                r.Return = false;
            }

            file = null;
            return r;
        }
        #endregion

        #region DeserializeXMLCrypto
        public static RetVal DeserializeXMLCrypto<DESTINATION>(this DESTINATION value, string file, SymmetricAlgorithm key)
        {
            return DeserializeXMLCrypto(file, ref value, key);
        }
        public static RetVal DeserializeXMLCrypto<DESTINATION>(this string file, ref DESTINATION value, SymmetricAlgorithm key)
        {
            if (string.IsNullOrEmpty(file))
            {
                RetVal r = new RetVal();
                r.Message = new ExceptionClass("Dosya yolu belirtilmemiş.");
                r.Return = false;
                return r;
            }

            FileInfo f = new FileInfo(file);

            return f.DeserializeXMLCrypto(ref value, key);
        }
        public static RetVal DeserializeXMLCrypto<DESTINATION>(this FileInfo file, ref DESTINATION value, SymmetricAlgorithm key)
        {
            RetVal r = new RetVal();

            try
            {
                file = new FileInfo(file.FullName);
                if (!file.Exists)
                {
                    r.Message = new ExceptionClass("Dosya bulunamadı.");
                    r.Return = false;
                    return r;
                }

                using (FileStream fs = File.Open(file.FullName , FileMode.Open))
                {
                    using (CryptoStream stream = new CryptoStream(fs, key.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        XmlSerializer xmlser = new XmlSerializer(typeof(DESTINATION));
                        value = (DESTINATION)xmlser.Deserialize(stream);
                    }
                }

                r.Message = new ExceptionClass("İşlem Başarılı");
                r.Return = true;
            }
            catch (Exception Error)
            {
                r.Message = new ExceptionClass(Error);
                r.Return = false;
            }

            file = null;
            return r;
        }
        #endregion
        #endregion
    }
}
