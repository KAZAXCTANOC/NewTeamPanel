using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TeamPanelStart.Entites;

namespace TeamPanelStart.ServerConnection
{
    public static class ServerController
    {
        private static string GetUserName()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            string username = (string)collection.Cast<ManagementBaseObject>().First()["UserName"];
            return username;
        }
        public static void PostRequest(List<AddInDataForServer> addInDataForServer)
        {
            foreach (var item in addInDataForServer)
            {
                item.UserName = GetUserName();
            }

            var json = JsonConvert.SerializeObject(addInDataForServer);

            WebRequest request = WebRequest.Create($"{ServerAdress.IpAdress}/Files/SaveSendFilesData");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = json;
            // преобразуем данные в массив байтов
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/json";
            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;

            //записываем данные в поток запроса
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            request.GetResponseAsync();
            Console.WriteLine("Запрос выполнен...");
        }
    }
}
