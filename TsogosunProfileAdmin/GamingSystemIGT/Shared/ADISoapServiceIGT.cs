using System.IO;
using System.Net;
using System.Text;


namespace tsogosun.com.GamingSystemIGT.Shared
{
    public class ADISoapServiceIGT : IADISoapServiceIGT
    {
        public ADISoapServiceIGT()
        {

        }

        public string GetResponse(string ipAddress, string requestBody)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(@ipAddress);
            myHttpWebRequest.Method = "POST";

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(requestBody);

            // Set the content type of the data being posted.
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            // Set the content length of the string being posted.
            myHttpWebRequest.ContentLength = byte1.Length;

            Stream newStream = myHttpWebRequest.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();
            // Pipes the stream to a higher level stream reader with the required encoding format.
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            return readStream.ReadToEnd().ToString();

        }
    }
}
