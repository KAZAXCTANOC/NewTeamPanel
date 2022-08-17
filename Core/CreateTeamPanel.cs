using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamPanelStart.Core.Intearfaces;

namespace TeamPanelStart.Core
{
    public class CreateTeamPanel : IAddRibbonPanel
    {
        //Путь до исполняемого класса
        //Заголовок
        // Панель
        //данные под заголовком
        //Картинка

        /// <summary>
        /// Добавляет в панель кнопки
        /// </summary>
        /// <param name="panel">Панель в которую добавят кнопку</param>
        /// <param name="PathToDirectory">Путь до папки с надстройкой</param>
        /// <param name="NameOfTheExecutableClass">Имя исполняемого класса</param>
        /// <param name="Header">Заголовк кнопки</param>
        /// <param name="toolTip">Подзаголовок</param>
        /// <param name="img">Изображение на кнопке</param>
        public void AddButtonBitmap(RibbonPanel panel, string PathToDirectory, string NameOfTheExecutableClass, string Header, string toolTip, Bitmap img)
        {
            var image = StaticBitmap2BitmapImage.Bitmap2BitmapImage(img);
            var buttonData = new PushButtonData(NameOfTheExecutableClass, Header, PathToDirectory, NameOfTheExecutableClass);
            var pushButton = panel.AddItem(buttonData) as PushButton;
            if (pushButton != null)
            {
                pushButton.ToolTip = toolTip;
                pushButton.LargeImage = image;
            }

        }
    }
}
