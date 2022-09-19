using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTOL.Scripts
{
    public class BugsRadar_
    {
        private static string apikey = "01400aa048e34f479b4c9bf034b50c825dc74347ebab478aa89b7ec96ba2b458";

        public static void SendException(Exception Exception)
        {
            SendExceptionService(Exception, "", "", "");
        }

        public static void SendException(Exception Exception,
                                         string CustomMessage)
        {
            SendExceptionService(Exception, CustomMessage + "", "", "");
        }

        public static void SendException(Exception Exception,
                                         string CustomMessage,
                                         string Module)
        {
            SendExceptionService(Exception, CustomMessage + "", Module + "", "");
        }

        public static void SendException(Exception Exception,
                                         string CustomMessage,
                                         string Module,
                                         string Version)
        {
            SendExceptionService(Exception, CustomMessage, Module, Version);
        }

        private static void SendExceptionService(Exception _Exception, string CustomMessage, string Module, string Version)
        {
            if (_Exception.InnerException != null)
            {
                POST("https://bugsradar.com/api/v1/SendException.ashx",
                "ApiKey=" + apikey +
                     "&CurrentVersion=" + Version +
                     "&Module=" + Module +
                     "&ExceptionType=" + _Exception.GetType().ToString() +
                     "&Message=" + SanitizeString(_Exception.Message) +
                     "&Source=" + _Exception.Source +
                     "&StackTrace=" + SanitizeString(_Exception.StackTrace) +
                     "&InnerMessage=" + SanitizeString(_Exception.InnerException.Message) +
                     "&InnerSource=" + _Exception.InnerException.Source +
                     "&InnerStackTrace=" + SanitizeString(_Exception.InnerException.StackTrace) +
                     "&CustomMessage=" + SanitizeString(CustomMessage));

            }
            else
            {
                POST("https://bugsradar.com/api/v1/SendException.ashx",
                     "ApiKey=" + apikey +
                     "&CurrentVersion=" + Version +
                     "&Module=" + Module +
                     "&ExceptionType=" + _Exception.GetType().ToString() +
                     "&Message=" + SanitizeString(_Exception.Message) +
                     "&Source=" + _Exception.Source +
                     "&StackTrace=" + SanitizeString(_Exception.StackTrace) +
                     "&InnerMessage= &InnerSource= &InnerStackTrace= " +
                     "&CustomMessage=" + SanitizeString(CustomMessage));
            }
        }

        private static void POST(string Url, string Data)
        {
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
                req.Method = "POST";
                req.Timeout = 100000;
                req.ContentType = "application/x-www-form-urlencoded";
                byte[] sentData = System.Text.Encoding.GetEncoding(65001).GetBytes(Data);
                req.ContentLength = sentData.Length;
                System.IO.Stream sendStream = req.GetRequestStream();
                sendStream.Write(sentData, 0, sentData.Length);
                sendStream.Close();
            }
            catch { }
        }

        private static string SanitizeString(string _string)
        {
            string result = _string;
            result = result.Replace("%", "%25");
            result = result.Replace("<", "%3C");
            result = result.Replace(">", "%3E");
            result = result.Replace("#", "%23");
            result = result.Replace("{", "%7B");
            result = result.Replace("}", "%7D");
            result = result.Replace("|", "%7C");
            result = result.Replace("\\", "%5C");
            result = result.Replace("^", "%5E");
            result = result.Replace("~", "%7E");
            result = result.Replace("[", "%5B");
            result = result.Replace("]", "%5D");
            result = result.Replace("`", "%60");
            result = result.Replace(";", "%3B");
            result = result.Replace("/", "%2F");
            result = result.Replace("?", "%3F");
            result = result.Replace(":", "%3A");
            result = result.Replace("@", "%40");
            result = result.Replace("=", "%3D");
            result = result.Replace("&", "%26");
            result = result.Replace("$", "%24");
            return result;
        }
    }
}
