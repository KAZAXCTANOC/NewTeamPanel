using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamPanelStart.Core;

namespace TeamPanelStart
{
    //AddButtonBitmap(
    //            "bim_apartment_info.Class1",
    //            " \nProfitbase",
    //            folder + "\\bim-apartment-info.dll",
    //            "bim_apartment_info.Class1",
    //            ribbonPanelBim,
    //            " Excel       ",
    //            Properties.Resources.Profitbase_8080); ////Profitbase_8080

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    class App : IExternalApplication
    {
        const string tabName = "BIM";
        const string panelBimName = "TeamPanel";
        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab(tabName);

            CreateTeamPanel createTeamPanel = new CreateTeamPanel();

            RibbonPanel ribbonPanelBim = application.CreateRibbonPanel(tabName, panelBimName);


            foreach (var needAddIn in Pathes.NeedAddIns)
            {
                switch (needAddIn)
                {
                    case "OKvsODB.dll":
                        {
                            createTeamPanel.AddButtonBitmap(
                                ribbonPanelBim, 
                                Pathes.PathToOKvsODB + needAddIn,
                                "OKvsODB.Command",
                                "Заполнение окон", 
                                @"*возможно это не заполенение окон",  
                                Properties.Resources.CP6); 
                            break;
                        }
                    case "CalcPrice.dll":
                        {
                            createTeamPanel.AddButtonBitmap(
                                ribbonPanelBim,
                                Pathes.PathToCalcPrice + needAddIn,
                                "CalcPrice.Class1",
                                "Импорт расценок",
                                @"",
                                Properties.Resources.CP6);
                            break;
                        }

                    case "FindApartment.dll":
                        {
                            createTeamPanel.AddButtonBitmap(
                                ribbonPanelBim,
                                Pathes.PathToFindApartment + needAddIn,
                                "FindApartment.Command",
                                "Квартирография",
                                @"Квартирография",
                                Properties.Resources.Квартирография_80х80);
                            break;
                        }

                    case "AreaOfVisibility.dll":
                        {
                            createTeamPanel.AddButtonBitmap(
                                ribbonPanelBim,
                                Pathes.PathToAreaOfVisibility + needAddIn,
                                "AreaOfVisibility.Command",
                                "Обрезка квартир",
                                @"Обрезка квартир",
                                Properties.Resources.CW);
                            break;
                        }

                    case "DecorationRoom.dll":
                        {
                            createTeamPanel.AddButtonBitmap(
                                ribbonPanelBim,
                                Pathes.PathToDecorationRoom + needAddIn,
                                "DecorationRoom.Command",
                                "Отделка помещений",
                                @"Отделка",
                                Properties.Resources.IP);
                            break;
                        }

                    case "MathCalcPrice.dll":
                        {
                            createTeamPanel.AddButtonBitmap(
                                ribbonPanelBim,
                                Pathes.PathToMathCalcPrice + needAddIn,
                                "MathCalcPrice.EntryPoint",
                                "Финансовый калькулятор",
                                @"Финансовый калькулятор",
                                Properties.Resources.Цены_80х80);
                            break;
                        }

                    case "bim-apartment-info.dll":
                        {
                            createTeamPanel.AddButtonBitmap(
                                ribbonPanelBim,
                                Pathes.PathToBim_apartment_info + needAddIn,
                                "bim_apartment_info.Class1",
                                "Экспорт в Profitbase",
                                @"Экспорт в Profitbase",
                                Properties.Resources.IP);
                            break;
                        }

                    case "BuildLegendWindows.dll":
                        {
                            createTeamPanel.AddButtonBitmap(
                                ribbonPanelBim,
                                Pathes.PathToBuildLegendWindows + needAddIn,
                                "BuildLegendWindows.Class1",
                                "Эскиз",
                                @"Эскиз",
                                Properties.Resources.IP);
                            break;
                        }
                }
            }

            try
            {
                TaskDialog.Show("Start", "Start");

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show(ex.ToString(), ex.ToString());
                return Result.Succeeded;
            }
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            try
            {
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show(ex.ToString(), ex.ToString());
                return Result.Succeeded;
            }
        }

    }
}
