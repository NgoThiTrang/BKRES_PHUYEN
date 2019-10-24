using DoAn.Data.Model;
using System.Collections.Generic;

namespace DoAn.Common.Common
{
    public static class WarningProfileList
    {
        public static List<WarningProfile> Init()
        {
            return new List<WarningProfile>()
            {
                new WarningProfile(){Name = "PH", Up_Thres = 8.5, Low_Thres = 7.5,ProcessTimeOut = 1, WarningContent = "Canh bao PH"}, // k caanf truong PropertiesName nuwa dde moi namoke thoi
                new WarningProfile(){Name = "Temp", Up_Thres = 33, Low_Thres = 18,ProcessTimeOut = 1, WarningContent = "Canh bao Temp"},
                new WarningProfile(){Name = "Oxy", Up_Thres = 8, Low_Thres = 3.5,ProcessTimeOut = 1, WarningContent = "Canh bao Oxy"},
                new WarningProfile(){Name = "Salt", Up_Thres = 25, Low_Thres = 10,ProcessTimeOut = 1, WarningContent = "Canh bao Salt"},
                new WarningProfile(){Name = "H2S", Up_Thres = 0.05, Low_Thres = 0,ProcessTimeOut = 1, WarningContent = "Canh bao H2S"},
                new WarningProfile(){Name = "NH3", Up_Thres = 0.3, Low_Thres = 0.1,ProcessTimeOut = 1, WarningContent = "Canh bao NH3"},
                new WarningProfile(){Name = "NH4", Up_Thres = 0.2, Low_Thres = 0.01,ProcessTimeOut = 1, WarningContent = "Canh bao NH4"},
              
            };
        }
    }
}
