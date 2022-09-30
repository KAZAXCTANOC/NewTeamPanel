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
using TeamPanelStart.Entites;
using TeamPanelStart.ServerConnection;

namespace TeamPanelStart
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    class App : IExternalApplication
    {
        const string tabName = "ТИМ Панель";
        const string panelBimName = "TeamPanel";
        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                application.CreateRibbonTab(tabName);

                CreateTeamPanel createTeamPanel = new CreateTeamPanel();

                RibbonPanel ribbonPanelBim = application.CreateRibbonPanel(tabName, panelBimName);

                List<AddInDataForServer> addInDataForServers = new List<AddInDataForServer>();

                foreach (var needAddIn in Pathes.NeedAddIns)
                {
                    switch (needAddIn)
                    {
                        case "DecorationRoomOneZero.dll":
                            {
                                try
                                {
                                    createTeamPanel.AddButtonBitmap(
                                        ribbonPanelBim,
                                        Pathes.PathToDecorationRoomOneZero + needAddIn,
                                        "DecorationRoomOneZero.App",
                                        "Стяжка",
                                        @"Стяжка помещений",
                                        Properties.Resources.CP6);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });
                                    break;
                                }
                                catch (Exception e)
                                {
                                    TaskDialog.Show("ошибка", $"При зазрузке палина 'OKvsODB.dll' произошла ошибка: \n{e.Message}");
                                    break;
                                }
                            }

                        case "BatchPrintYay_2023.dll": 
                            {
                                try
                                {
                                    createTeamPanel.AddButtonBitmap(
                                        ribbonPanelBim, 
                                        Pathes.PathToBatchPrintYay_2023 + needAddIn,
                                        "BatchPrintYay.CommandBatchPrint",
                                        "Пакетная печать", 
                                        @" ",  
                                        Properties.Resources.CP6);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });

                                    createTeamPanel.AddButtonBitmap(
                                        ribbonPanelBim,
                                        Pathes.PathToBatchPrintYay_2023 + needAddIn,
                                        "BatchPrintYay.CommandRefreshSchedules",
                                        "Пакетная печать",
                                        @" ",
                                        Properties.Resources.CP6);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });
                                    break;
                                }
                                catch (Exception e)
                                {
                                    TaskDialog.Show("ошибка", $"При зазрузке палина 'BatchPrintYay_2023' произошла ошибка: \n{e.Message}");
                                    break;
                                }
                            }
                        case "OKvsODB.dll":
                            {
                                try
                                {
                                    createTeamPanel.AddButtonBitmap(
                                        ribbonPanelBim, 
                                        Pathes.PathToOKvsODB + needAddIn,
                                        "OKvsODB.Command",
                                        "Заполнение окон", 
                                        @"*возможно это не заполенение окон",  
                                        Properties.Resources.CP6);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });
                                    break;
                                }
                                catch (Exception e)
                                {
                                    TaskDialog.Show("ошибка", $"При зазрузке палина 'OKvsODB.dll' произошла ошибка: \n{e.Message}");
                                    break;
                                }
                            }
                        case "CalcPrice.dll":
                            {
                                try
                                {
                                    createTeamPanel.AddButtonBitmap(
                                        ribbonPanelBim,
                                        Pathes.PathToCalcPrice + needAddIn,
                                        "CalcPrice.Class1",
                                        "Импорт расценок",
                                        @"",
                                        Properties.Resources.CP6);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });
                                    break;
                                }
                                catch (Exception e)
                                {
                                    TaskDialog.Show("ошибка", $"При зазрузке палина 'CalcPrice.dll' произошла ошибка: \n{e.Message}");
                                    break;
                                }
                            }

                        case "FindApartment.dll":
                            {
                                try
                                {
                                    createTeamPanel.AddButtonBitmap(
                                    ribbonPanelBim,
                                    Pathes.PathToFindApartment + needAddIn,
                                    "FindApartment.Command",
                                    "Квартирография",
                                    @"Квартирография",
                                    Properties.Resources.Квартирография_80х80);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });
                                    break;
                                }
                                catch (Exception e)
                                {
                                    TaskDialog.Show("ошибка", $"При зазрузке палина 'FindApartment.dll' произошла ошибка: \n{e.Message}");
                                    break;
                                }
                                
                            }

                        case "AreaOfVisibility.dll":
                            {
                                try
                                {
                                    createTeamPanel.AddButtonBitmap(
                                        ribbonPanelBim,
                                        Pathes.PathToAreaOfVisibility + needAddIn,
                                        "AreaOfVisibility.Command",
                                        "Обрезка квартир",
                                        @"Обрезка квартир",
                                        Properties.Resources.CW);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });
                                    break;
                                }
                                catch (Exception e)
                                {
                                    TaskDialog.Show("ошибка", $"При зазрузке палина 'AreaOfVisibility.dll' произошла ошибка: \n{e.Message}");
                                    break;
                                }


                            }

                        case "DecorationRoom.dll":
                            {
                                try
                                {
                                    createTeamPanel.AddButtonBitmap(
                                        ribbonPanelBim,
                                        Pathes.PathToDecorationRoom + needAddIn,
                                        "DecorationRoom.Command",
                                        "Отделка помещений",
                                        @"Отделка",
                                        Properties.Resources.IP);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });
                                    break;
                                }
                                catch (Exception e)
                                {
                                    TaskDialog.Show("ошибка", $"При зазрузке палина 'DecorationRoom.dll' произошла ошибка: \n{e.Message}");
                                    break;
                                }

                            }

                        case "MathCalcPrice.dll":
                            {
                                try
                                {
                                    createTeamPanel.AddButtonBitmap(
                                        ribbonPanelBim,
                                        Pathes.PathToMathCalcPrice + needAddIn,
                                        "MathCalcPrice.EntryPoint",
                                        "Финансовый калькулятор",
                                        @"Финансовый калькулятор",
                                        Properties.Resources.Цены_80х80);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });
                                    break;
                                }
                                catch (Exception e)
                                {
                                    TaskDialog.Show("ошибка", $"При зазрузке палина 'MathCalcPrice.dll' произошла ошибка: \n{e.Message}");
                                    break;
                                }

                            }

                        case "bim-apartment-info.dll":
                            {
                                try
                                {
                                    createTeamPanel.AddButtonBitmap(
                                        ribbonPanelBim,
                                        Pathes.PathToBim_apartment_info + needAddIn,
                                        "bim_apartment_info.Class1",
                                        "Экспорт в Profitbase",
                                        @"Экспорт в Profitbase",
                                        Properties.Resources.IP);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });
                                    break;
                                }
                                catch (Exception e)
                                {
                                    TaskDialog.Show("ошибка", $"При зазрузке палина 'bim-apartment-info.dll' произошла ошибка: \n{e.Message}");
                                    break;
                                }

                            }

                        case "BuildLegendWindows.dll":
                            {
                                try
                                {
                                    createTeamPanel.AddButtonBitmap(
                                        ribbonPanelBim,
                                        Pathes.PathToBuildLegendWindows + needAddIn,
                                        "BuildLegendWindows.Class1",
                                        "Эскиз",
                                        @"Эскиз",
                                        Properties.Resources.IP);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });
                                    break;
                                }
                                catch (Exception e)
                                {
                                    TaskDialog.Show("ошибка", $"При зазрузке палина 'BuildLegendWindows.dll' произошла ошибка: \n{e.Message}");
                                    break;
                                }

                            }

                        case "TestGovnaAndMochi.dll":
                            {
                                try
                                {
                                    createTeamPanel.AddButtonBitmap(
                                        ribbonPanelBim,
                                        Pathes.PathToUploadToDWG + needAddIn,
                                        "TestGovnaAndMochi.App",
                                        "Экспорт в DWF",
                                        @"Экспорт в DWF",
                                        Properties.Resources.IP);
                                    addInDataForServers.Add(new AddInDataForServer { PluginName = needAddIn, RevitVersion = "2019" });
                                    break;
                                }
                                catch (Exception e)
                                {
                                    TaskDialog.Show("ошибка", $"При зазрузке палина 'Выгрузка в DWF' произошла ошибка: \n{e.Message}");
                                    break;
                                }
                            }
                    }
                }

                if (addInDataForServers.Count != 0)
                {
                    try
                    {
                        ServerController.PostRequest(addInDataForServers);
                    }
                    catch (Exception e)
                    {

                    }
                }

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
