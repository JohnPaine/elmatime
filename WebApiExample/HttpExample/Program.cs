using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using EleWise.ELMA.Serialization;

namespace HttpExample
{
    class Program
    {
        //создаем токен прложения
        public static string ApplicationToken = "FCD9913007A3A1483D55700EAC702C41A42B3CE4F887538ADC37FACBC397160F57612B2DBC8E839A61C6A05D24508177C48EFE4D3898931C46F4C91B52F133E3";
        static void Main(string[] args)
        {
            //создаем веб запрос
            HttpWebRequest req = WebRequest.Create(String.Format("http://localhost:2016/API/REST/Authorization/LoginWith?username=admin")) as HttpWebRequest;
            req.Headers.Add("ApplicationToken", ApplicationToken);
            req.Method = "POST";
            req.Timeout = 10000;
            req.ContentType = "application/json; charset=utf-8";

            //данные для отправки. используется для передачи пароля. пароль нужно записать вместо пустой строки
            var sentData = Encoding.UTF8.GetBytes("");
            req.ContentLength = sentData.Length;
            Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);

            //получение ответа
            var res = req.GetResponse() as HttpWebResponse;
            var resStream = res.GetResponseStream();
            var sr = new StreamReader(resStream, Encoding.UTF8);

            var result = sr.ReadToEnd();
            Console.WriteLine(result);
            Console.ReadKey();


            //достаем необходимые данные
            var dict = new JsonSerializer().Deserialize(result, typeof(Dictionary<string, string>)) as Dictionary<string, string>;
            var authToken = dict["AuthToken"];
            var sessionToken = dict["SessionToken"];

            //var authToken = "8f616079-af23-4e8d-9e05-f4c879bbc4cd";
            //var sessionToken = "0871639509C517C8318B9C2A6E4286CBDCB8C1A98188565DC2EBA533E2A63964AC570F89F72830464120FF2D1B692B4FE2D99B2C38B7C406347DCAE04624A210";

            LoadTask(authToken, sessionToken);
            //ExecuteTask(authToken, sessionToken);
            //LoadTaskList(authToken, sessionToken);
        }

        /// <summary>
        /// Загрузка задачи
        /// </summary>
        /// <param name="authToken"></param>
        public static void LoadTask(string authToken, string sessionToken)
        {
            var typeUid = "f532ef81-20e1-467d-89a4-940c57a609bc";
            var entityId = "1";

            
            HttpWebRequest checkTokenReq = WebRequest.Create(String.Format("http://localhost:2016/API/REST/Authorization/CheckToken?token={0}", authToken)) as HttpWebRequest;
            checkTokenReq.Method = "GET";
            checkTokenReq.Timeout = 10000;
            checkTokenReq.ContentType = "application/json; charset=utf-8";
            try
            {
                //если ошибки нет, то забераем токены сессии и авторизации из полученного ответа
                var res1 = checkTokenReq.GetResponse() as HttpWebResponse;
                var resStream1 = res1.GetResponseStream();
                var sr1 = new StreamReader(resStream1, Encoding.UTF8);
                var result = sr1.ReadToEnd();
                Console.WriteLine(result);
                Console.ReadKey();

                var dict = new JsonSerializer().Deserialize(result, typeof(Dictionary<string, string>)) as Dictionary<string, string>;
                authToken = dict["AuthToken"];
                sessionToken = dict["SessionToken"];
            }
            catch (Exception)
            {
                //если при выполнении запроса произошла ошибка, заного запускаем запрос авторизации
                HttpWebRequest req = WebRequest.Create(String.Format("http://localhost:2016/API/REST/Authorization/LoginWith?username=admin")) as HttpWebRequest;
                req.Headers.Add("ApplicationToken", ApplicationToken);
                req.Headers.Add("SessionToken", sessionToken);
                req.Method = "POST";
                req.Timeout = 10000;
                req.ContentType = "application/json; charset=utf-8";

                var sentData = Encoding.UTF8.GetBytes("");
                req.ContentLength = sentData.Length;
                Stream sendStream = req.GetRequestStream();
                sendStream.Write(sentData, 0, sentData.Length);

                //получение ответа
                var res1 = req.GetResponse() as HttpWebResponse;
                var resStream1 = res1.GetResponseStream();
                var sr1 = new StreamReader(resStream1, Encoding.UTF8);
                var result = sr1.ReadToEnd();

                var dict = new JsonSerializer().Deserialize(result, typeof(Dictionary<string, string>)) as Dictionary<string, string>;
                authToken = dict["AuthToken"];
                sessionToken = dict["SessionToken"];
            }

            HttpWebRequest taskReq = WebRequest.Create(String.Format("http://localhost:2016/API/REST/Entity/Load?type={0}&id={1}", typeUid, entityId)) as HttpWebRequest;
            taskReq.Method = "GET";            
            taskReq.Headers.Add("AuthToken", authToken);
            taskReq.Headers.Add("SessionToken", sessionToken);
            taskReq.Timeout = 10000;
            taskReq.ContentType = "application/json; charset=utf-8";

            var res = taskReq.GetResponse() as HttpWebResponse;
            var resStream = res.GetResponseStream();
            var sr = new StreamReader(resStream, Encoding.UTF8);

            var myTask = sr.ReadLine();
            Console.WriteLine(myTask);
            Console.ReadKey();
        }

        /// <summary>
        /// Выполнение задачи
        /// </summary>
        /// <param name="authToken"></param>
        public static void ExecuteTask(string authToken, string sessionToken)
        {
            HttpWebRequest taskReq = WebRequest.Create("http://localhost:2016/API/REST/Tasks/Complete") as HttpWebRequest;
            taskReq.Method = "POST";
            taskReq.Headers.Add("AuthToken", authToken);
            taskReq.Headers.Add("SessionToken", sessionToken);
            taskReq.Timeout = 10000;
            taskReq.ContentType = "application/json; charset=utf-8";
            /*
            var sentData = Encoding.UTF8.GetBytes(@"
<WebData xmlns=""http://schemas.datacontract.org/2004/07/EleWise.ELMA.Common.Models"">
    <Items>
        <WebDataItem>
            <Name>TaskId</Name>
            <Value>37</Value>
        </WebDataItem>
        <WebDataItem>
            <Data>
                <Items>
                    <WebDataItem>
                        <Name>Text</Name>
                        <Value>Text for comment</Value>
                    </WebDataItem>
                </Items>
            </Data>
        <Name>Comment</Name>
        </WebDataItem>
    </Items>
</WebData>");*/

            var request = @"
{
	""Items"":
	   [
		   {
				""Data"":null,
				""DataArray"":[],
				""Name"":""TaskId"",
				""Value"":""1""
			},
			{
				""Data"":
					{
						""Items"":
						[
							{
								""Data"":null,
								""DataArray"":[],
								""Name"":""Text"",
								""Value"":""Text for comment""
							}
						],
						""Value"":null
					},
				""DataArray"":[],
				""Name"":""Comment"",
				""Value"":null
			},
		],
	""Value"":null
}";

            var sentData = Encoding.UTF8.GetBytes(request);
            taskReq.ContentLength = sentData.Length;
            Stream sendStream = taskReq.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);

            var res = taskReq.GetResponse() as HttpWebResponse;
            var resStream = res.GetResponseStream();
            var sr = new StreamReader(resStream, Encoding.UTF8);
            Console.WriteLine(sr.ReadToEnd());
            Console.ReadKey();
        }

        public static void LoadTaskList(string authToken, string sessionToken)
        {
            var typeUid = "f532ef81-20e1-467d-89a4-940c57a609bc";
            var eqlQuery = "";
            var limit = "15";
            var offset = "0";
            var sort = "";
            var filterProviderUid = "";
            var filterProviderData = "";
            var filter = "";
            HttpWebRequest queryReq = WebRequest.Create(String.Format(@"http://localhost:2016/API/REST/Entity/Query?type={0}&q={1}&limit={2}&offset={3}&sort={4}&filterProviderUid={5}&filterProviderData={6}&filter={7}",
            typeUid, eqlQuery, limit, offset, sort, filterProviderUid, filterProviderData, filter)) as HttpWebRequest;
            queryReq.Method = "GET";
            queryReq.Headers.Add("AuthToken", authToken);
            queryReq.Headers.Add("SessionToken", sessionToken);
            queryReq.Timeout = 10000;
            queryReq.ContentType = "application/json; charset=utf-8";

            var res = queryReq.GetResponse() as HttpWebResponse;
            var resStream = res.GetResponseStream();
            var sr = new StreamReader(resStream, Encoding.UTF8);

            var queryResult = sr.ReadLine();
            Console.WriteLine(queryResult);
            Console.ReadKey();
        }
    }    
}
