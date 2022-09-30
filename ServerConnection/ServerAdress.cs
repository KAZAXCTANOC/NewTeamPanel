using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPanelStart.ServerConnection
{
    public static class ServerAdress
    {
        public static string IpAdress 
        { 
            get 
            {
                string textFromFile = "";
                using (FileStream fstream = File.OpenRead(@"\\obmen\01_BIM\List_of_plugins\Ip адресс сервера для тим панели\ip.txt"))
                {
                    // выделяем массив для считывания данных из файла
                    byte[] buffer = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(buffer, 0, buffer.Length);
                    // декодируем байты в строку
                    textFromFile = Encoding.Default.GetString(buffer);
                }
                return textFromFile; 
            } 
        }
    }
}
