using Comm.Commons.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.App.Model.User;
using webapi.App.RequestModel.AppRecruiter;
using webapi.App.STLDashboardModel;

namespace webapi.App.Aggregates.Common.Dto
{
    public class STLSubscriberDto
    {
        public static IDictionary<string, object> GetPartyList(IDictionary<string,object> data, bool fullinfo = true)
        {
            dynamic o = Dynamic.Object;
            o.PL_ID = data["PL_ID"].Str();
            o.PL_NM = data["PL_NM"].Str();
            o.PL_ADD = data["PL_ADD"].Str();
            o.PL_TEL_NO = data["PL_TEL_NO"].Str();
            o.URL_STRMNG_NM = data["URL_STRMNG_NM"].Str();
            o.URL_STRMNG = data["URL_STRMNG"].Str();
            return o;
        }
        public static STLParty GetSTLParty(IDictionary<string,object> data)
        {
            STLParty o = new STLParty();
            o.PL_ID = data["PL_ID"].Str();
            return o;
        }
        public static IDictionary<string, object> GetGroup(IDictionary<string, object> data, bool fullinfo = true)
        {
            dynamic o = Dynamic.Object;
            o.PL_ID = data["PL_ID"].Str();
            o.PGRP_ID = data["PGRP_ID"].Str();
            o.PSN_CD = data["PSN_CD"].Str();
            o.PLTCL_NM = data["PLTCL_NM"].Str();
            return o;
        }
        public static IDictionary<string, object> GetMenuPage(IDictionary<string,object> data, string accttype)
        {
            string menubar = "|btnUserAccess|btnBranches|btnDrawSched|btnRemittances|btnusers|btnapk|btnForfeitScheduler|btnUserSettings|btnPowerApp|btnAccountCredits|btnTransferCredits|btnGameSettings|btnlivetrends|btngameresult|btnPostresult|btnLivestreaming|btnTextblasting|btnAnnouncement|btnWinners|btnResultConfirmation|btnCommissions|btnUserAccounts|btnWinningsRep|btnGameBetsRep|btnActivePlayer|btnMaxSales|btnSessionLogs|btnPlayerNoBet|btnInActiveUserAccount|btnTroubleReport|";
            dynamic o = Dynamic.Object;
            o.MenuPage = (accttype== "1" || accttype=="2") ? menubar : data["PGS"].Str();
            return o;
        }
        public static STLAccount STLUpdateMember(STLMembership data)
        {
            STLAccount o = new STLAccount();
            o.PL_ID = data.PLID;
            o.PGRP_ID = data.PGRPID;
            o.USR_ID = data.Userid;
            o.ACT_TYP = data.AccountType;

            o.FRST_NM = data.Firstname;
            o.LST_NM = data.Lastname;
            o.MDL_NM = data.Middlename;
            o.FLL_NM = $"{data.Lastname}, {data.Firstname} {data.Middlename}";
            o.NCK_NM = data.Nickname;

            o.MOB_NO = data.MobileNumber;
            o.EML_ADD = data.EmailAddress;
            o.HM_ADDR = data.HomeAddress;
            o.PRSNT_ADDR = data.PresentAddress;
            o.LOC_REG = data.Region;
            o.LOC_PROV = data.Province;
            o.LOC_MUN = data.Municipality;
            o.LOC_BRGY = data.Barangay;

            o.GNDR = data.Gender;
            o.MRTL_STAT = data.MaritalStatus;
            o.CTZNSHP = data.Citizenship;
            o.ImageUrl = data.ImageUrl;
            o.BRT_DT = data.BirthDate;
            o.BLD_TYP = data.BloodType;
            o.NATNLTY = data.Nationality;
            o.OCCPTN = data.Occupation;
            o.SKLLS = data.Skills;
            return o;
        }
    }
}
