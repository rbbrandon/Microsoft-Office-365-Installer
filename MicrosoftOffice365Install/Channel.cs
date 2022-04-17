using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOffice365Install
{
    public static class Channel
    {
        public static string MonthlyEnterprise = "MonthlyEnterprise";
        public static string Volume = "PerpetualVL2019";

        public static string InsiderFast                 = "InsiderFast";
        public static string BetaChannel                 = "BetaChannel"; // = InsiderFast

        public static string Monthly                     = "Monthly";
        public static string Current                     = "Current"; // = Monthly

        public static string MonthlyTargeted             = "Insiders";
        public static string CurrentPreview              = "CurrentPreview"; // = MonthlyTargeted

        public static string SemiAnnual                  = "Broad";
        public static string SemiAnnualEnterprise        = "SemiAnnual"; // = SemiAnnual

        public static string SemiAnnualTargeted          = "Targeted";
        public static string SemiAnnualEnterprisePreview = "SemiAnnualPreview"; // = SemiAnnualTargeted

        

        private const StringComparison _IgnoreCase = StringComparison.OrdinalIgnoreCase;

        public static string GetGUID(string channelId)
        {
            string guid = null;

            if (channelId.Equals(Monthly, _IgnoreCase) || channelId.Equals(Current, _IgnoreCase))
                guid = "492350f6-3a01-4f97-b9c0-c7c6ddf67d60";
            else if (channelId.Equals(MonthlyTargeted, _IgnoreCase) || channelId.Equals(CurrentPreview, _IgnoreCase))
                guid = "64256afe-f5d9-4f86-8936-8840a6a4f5be";
            else if (channelId.Equals(SemiAnnual, _IgnoreCase) || channelId.Equals(SemiAnnualEnterprise, _IgnoreCase))
                guid = "7ffbc6bf-bc32-4f92-8982-f9dd17fd3114";
            else if (channelId.Equals(SemiAnnualTargeted, _IgnoreCase) || channelId.Equals(SemiAnnualEnterprisePreview, _IgnoreCase))
                guid = "b8f9b850-328d-4355-9145-c59439a0c4cf";
            else if (channelId.Equals(Volume, _IgnoreCase))
                guid = "f2e724c1-748f-4b47-8fb8-8e0d210e9208";
            else if (channelId.Equals(MonthlyEnterprise, _IgnoreCase))
                guid = "55336b82-a18d-4dd6-b5f6-9e5095c314a6";
            else if (channelId.Equals(InsiderFast, _IgnoreCase) || channelId.Equals(BetaChannel, _IgnoreCase))
                guid = "5440fd1f-7ecb-4221-8110-145efaa6372f";

            return guid;
        }

        public static string GetFriendlyChannelName(string channelId)
        {
            string channelName = null;

            if (channelId.Equals(Monthly, _IgnoreCase) || channelId.Equals(Current, _IgnoreCase))
                channelName = "Current";
            else if (channelId.Equals(MonthlyTargeted, _IgnoreCase) || channelId.Equals(CurrentPreview, _IgnoreCase))
                channelName = "Current (Preview)";
            else if (channelId.Equals(SemiAnnual, _IgnoreCase) || channelId.Equals(SemiAnnualEnterprise, _IgnoreCase))
                channelName = "Semi-Annual Enterprise";
            else if (channelId.Equals(SemiAnnualTargeted, _IgnoreCase) || channelId.Equals(SemiAnnualEnterprisePreview, _IgnoreCase))
                channelName = "Semi-Annual Enterprise (Preview)";
            else if (channelId.Equals(Volume, _IgnoreCase))
                channelName = "Volume";
            else if (channelId.Equals(MonthlyEnterprise, _IgnoreCase))
                channelName = "Monthly Enterprise";
            else if (channelId.Equals(InsiderFast, _IgnoreCase) || channelId.Equals(BetaChannel, _IgnoreCase))
                channelName = "Beta";

            return channelName;
        }

        public static string GetChannelID(string channelName)
        {
            string channelId = null;

            if (channelName.Equals(Monthly, _IgnoreCase) || channelName.Equals(Current, _IgnoreCase))
                channelId = Current;
            else if(channelName.Equals(MonthlyTargeted, _IgnoreCase) || channelName.Equals(CurrentPreview, _IgnoreCase))
                channelId = CurrentPreview;
            else if(channelName.Equals(SemiAnnual, _IgnoreCase) || channelName.Equals(SemiAnnualEnterprise, _IgnoreCase))
                channelId = SemiAnnualEnterprise;
            else if(channelName.Equals(SemiAnnualTargeted, _IgnoreCase) || channelName.Equals(SemiAnnualEnterprisePreview, _IgnoreCase))
                channelId = SemiAnnualEnterprisePreview;
            else if(channelName.Equals(Volume, _IgnoreCase))
                channelId = Volume;
            else if (channelName.Equals(MonthlyEnterprise, _IgnoreCase))
                channelId = MonthlyEnterprise;
            else if (channelName.Equals(InsiderFast, _IgnoreCase) || channelName.Equals(BetaChannel, _IgnoreCase))
                channelId = BetaChannel;

            return channelId;
        }
    }
}
