using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPanelStart.Core
{
    public static class Pathes
    {
        #region base path txt file with need add'ins
        private static string PathToFileWithNeedAddIns { get { return @"C:\TeamPanel\NeedAddIns.txt"; } }
        #endregion

        #region pathes to dll files
        public const string PathToOKvsODB = @"\\obmen\01_BIM\List_of_plugins\Заполнение окон\"; //+
        public const string PathToCalcPrice = @"\\obmen\01_BIM\List_of_plugins\Импорт расценок\"; //+
        public const string PathToFindApartment = @"\\obmen\01_BIM\List_of_plugins\Квартирография\"; //+
        public const string PathToAreaOfVisibility = @"\\obmen\01_BIM\List_of_plugins\Обрезка квартир\"; //+
        public const string PathToDecorationRoom = @"\\obmen\01_BIM\List_of_plugins\Отделка\"; //+
        public const string PathToUploadToDWG = @"\\obmen\01_BIM\List_of_plugins\Экспорт в DWF\TestGovnaAndMochi\TestGovnaAndMochi\bin\Debug\";
        public const string PathToBim_apartment_info = @"\\obmen\01_BIM\List_of_plugins\Экспорт в Profitbase\";
        public const string PathToBuildLegendWindows = @"\\obmen\01_BIM\List_of_plugins\Эскиз\";
        public const string PathToMathCalcPrice = @"\\obmen\01_BIM\List_of_plugins\Финансовый калькулятор\MathCalcPriceForAPG\MathCalcPrice\bin\Debug\";
        #endregion

        public static List<string> NeedAddIns 
        { 
            get 
            {
                string textFromFile = "";
                using (FileStream fstream = File.OpenRead(PathToFileWithNeedAddIns))
                {
                    // выделяем массив для считывания данных из файла
                    byte[] buffer = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(buffer, 0, buffer.Length);
                    // декодируем байты в строку
                    textFromFile = Encoding.Default.GetString(buffer);
                } 
                return textFromFile.Split(';').ToList();
            } 
        }
    }
}
