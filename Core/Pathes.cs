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
        public const string Basepath = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins";
        public const string PathToDecorationRoomOneZero = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins\DecorationRoom20\";
        public const string PathToBatchPrintYay_2023 = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins\BatchPrintYay\"; 
        public const string PathToOKvsODB = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins\Filling windows\"; //+
        public const string PathToCalcPrice = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins\Import quotes\"; //+
        public const string PathToFindApartment = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins\apartment house\"; //+
        public const string PathToAreaOfVisibility = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins\Cropping flats\"; //+
        public const string PathToDecorationRoom = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins\Finishing\"; //+
        public const string PathToUploadToDWG = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins\Export to DWF\TestGovnaAndMochi\TestGovnaAndMochi\bin\Debug\";
        public const string PathToBim_apartment_info = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins\Export to Profitbase\";
        public const string PathToBuildLegendWindows = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins\Sketch\";
        public const string PathToMathCalcPrice = @"\\obmen\АПГ Проекты\Плагины для АПГ\List_of_plugins\financial calculator\MathCalcPriceForAPG\MathCalcPrice\bin\Debug\";
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
