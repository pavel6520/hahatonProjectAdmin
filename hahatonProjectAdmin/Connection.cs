using System.IO;
using System.Net;
using System.Text;

namespace hahatonProjectUser
{
    static class Connection
    {
        private static HttpWebRequest req;
        private static HttpWebResponse resp;

        /// <summary> 
        /// Создает запрос к серверу 
        /// </summary> 
        /// <param name="host">Адрес сервера</param> 
        static public bool Request(string host, string text)
        {
            try
            {
                req = (HttpWebRequest)WebRequest.Create(host);//запрос 
                req.Method = "POST";

                byte[] dataArray = Encoding.UTF8.GetBytes(text);
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = dataArray.Length;

                try
                {
                    using (Stream dataStream = req.GetRequestStream())
                    {
                        dataStream.Write(dataArray, 0, dataArray.Length);
                    }
                }
                catch
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary> 
        /// Возвращает ответ сервера 
        /// </summary> 
        static public string Response()
        {
            try
            {
                resp = (HttpWebResponse)req.GetResponse();//ответ 
            }
            catch
            {
                return null;
            }

            try
            {
                using (StreamReader stream = new StreamReader(
                resp.GetResponseStream(), Encoding.UTF8))
                {
                    return stream.ReadToEnd();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
