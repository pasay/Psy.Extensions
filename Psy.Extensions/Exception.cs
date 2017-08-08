using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// This class can use with serializable
    /// </summary>
    public class ExceptionClass
    {
        public ExceptionClass()
        {
        }

        public ExceptionClass(string message)
        {
            Message = message;
        }
        public ExceptionClass(string message, ExceptionClass innerException)
        {
            Message = message;
            _InnerException = innerException;
        }
        public ExceptionClass(Exception exception)
        {
            if (exception != null)
            {
                Message = exception.Message;
                Source = exception.Source;
                StackTrace = exception.StackTrace;

                if (exception.InnerException != null)
                {
                    _InnerException = new ExceptionClass();
                    ConvertException(ref _InnerException, exception.InnerException);
                }
            }
        }
        public ExceptionClass(string message, Exception innerException)
        {
            Message = message;
            ConvertException(ref _InnerException, innerException);
        }

        private void ConvertException(ref ExceptionClass myException, Exception innerException)
        {
            if (innerException != null)
            {
                myException = new ExceptionClass();
                myException.Message = innerException.Message;
                myException.Source = innerException.Source;
                myException.StackTrace = innerException.StackTrace;

                if (innerException.InnerException != null)
                {
                    myException._InnerException = new ExceptionClass();
                    ConvertException(ref myException._InnerException, innerException.InnerException);
                }
            }
        }
        
        public DateTime Time = DateTime.Now;

        public ExceptionClass InnerException
        {
            get
            {
                return _InnerException;
            }
            set
            {
                _InnerException = value;
            }
        }
        private ExceptionClass _InnerException;

        public string Message 
        { 
            get{
                if (_message == null) { return ""; }

                return _message;
            }
            set{
                if (value == null) { value = ""; }

                _message = value;
            }
        }
        private string _message = "";

        public string Source
        {
            get
            {
                if (_source == null) { return ""; }

                return _source;
            }
            set
            {
                if (value == null) { value = ""; }

                _source = value;
            }
        }
        private string _source = "";

        public string StackTrace
        {
            get
            {
                if (_stackTrace == null) { return ""; }

                return _stackTrace;
            }
            set
            {
                if (value == null) { value = ""; }

                _stackTrace = value;
            }
        }
        private string _stackTrace = "";

        public override string ToString()
        {
            string str = "";

            if (string.IsNullOrEmpty(Message) == false)
            {
                str += Message;
            }

            if (string.IsNullOrEmpty(Source) == false)
            {
                if (string.IsNullOrEmpty(str) == false)
                {
                    str += Environment.NewLine;
                }
                str += Source;
            }

            if (string.IsNullOrEmpty(StackTrace) == false)
            {
                if (string.IsNullOrEmpty(str) == false)
                {
                    str += Environment.NewLine;
                }
                str += StackTrace;
            }

            if (_InnerException != null)
            {
                str += "\n\nInnerException\n" + _InnerException.ToString();
            }

            return str ?? "";
        }
    }
}
