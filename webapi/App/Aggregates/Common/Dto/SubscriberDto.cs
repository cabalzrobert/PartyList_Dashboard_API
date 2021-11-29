using System;
using System.Collections.Generic;
using webapi.App.Model.User;
using Comm.Commons.Extensions;
using System.Linq;

namespace webapi.App.Aggregates.Common
{
    public class SubscriberDto
    {
        public static IDictionary<string, object> AccountBalance(STLAccount account, IDictionary<string, object> data){
            dynamic o = Dynamic.Object;
            o.Balance = data["ACT_BAL"].Str().ToDecimalDouble();
            o.CreditBalance = data["ACT_CRDT_BAL"].Str().ToDecimalDouble();
            //if(!account.IsPlayer){
            //    var combal = data["ACT_COM_BAL"].Str().ToDecimalDouble();
            //    o.CommissionBalance = combal;
            //}
            var winbal = data["ACT_WIN_BAL"].Str().ToDecimalDouble();
            if(winbal>0) o.WinningBalance = winbal;
            return o;
        }

        public static IEnumerable<dynamic> SearchSubscribers(STLAccount account, IEnumerable<dynamic> list, int limit = 50){
            if(list==null) return null;
            var items = SearchSubscribers(account, list);
            var count = items.Count();
            if(count>=limit){
                var o = items.Last();
                var filter = (o.NextFilter = Dynamic.Object);
                items = items.Take(count-1).Concat(new[]{ o });
                filter.BaseFilter = o.AccountID;
            }
            return items;
        }

        public static IEnumerable<dynamic> SearchSubscribers(STLAccount account, IEnumerable<dynamic> list){
            if(list==null) return null;
            return list.Select(e=> SearchSubscriber(account, e));
        }

        public static IDictionary<string, object> SearchSubscriber(STLAccount account,  IDictionary<string, object> data){
            dynamic o = Dynamic.Object;
            //o.SubscriberID =  data["CUST_ID"].Str();
            o.AccountID =  data["ACT_ID"].Str();
            o.MobileNumber = data["MOB_NO"].Str();
            o.DisplayName =  data["NCK_NM"].Str();
            o.ImageUrl =  data["IMG_URL"].Str();
            o.Firstname = data["FRST_NM"].Str().ToUpper();
            o.Lastname = data["LST_NM"].Str().ToUpper();
            o.Fullname = data["FLL_NM"].Str().ToUpper();
            o.CreditBalance = data["ACT_CRDT_BAL"].Str().ToDecimalDouble();
            o.CommissionBalance = data["ACT_COM_BAL"].Str().ToDecimalDouble();
            //
            string usertype = data["USR_TYP"].Str();
            o.IsPlayer = (usertype.Equals("5"));
            //if(account.IsGeneralCoordinator){
            //    o.IsCoordinator = (usertype.Equals("4"));
            //    o.IsGeneralCoordinator = (usertype.Equals("3"));
            //}
            o.IsBlocked = (data["S_BLCK"].Str().Equals("1"));
            return o;
        }


        public static IEnumerable<dynamic> SearchSubscribers(IEnumerable<dynamic> list, int limit = 50){
            if(list==null) return null;
            var items = SearchSubscribers(list);
            var count = items.Count();
            if(count>=limit){
                var o = items.Last();
                var filter = (o.NextFilter = Dynamic.Object);
                items = items.Take(count-1).Concat(new[]{ o });
                filter.BaseFilter = o.AccountID;
            }
            return items;
        }

        public static IEnumerable<dynamic> SearchSubscribers(IEnumerable<dynamic> list){
            if(list==null) return null;
            return list.Select(e=> SearchSubscriber(e));
        }

        public static IDictionary<string, object> SearchSubscriber(IDictionary<string, object> data){
            dynamic o = Dynamic.Object;
            //o.SubscriberID =  data["CUST_ID"].Str();
            o.AccountID =  data["ACT_ID"].Str();
            o.MobileNumber = data["MOB_NO"].Str().Replace("+639","09");
            //o.DisplayName =  data["NCK_NM"].Str();
            o.Fullname = data["FLL_NM"].Str().ToUpper();
            o.ImageUrl =  data["IMG_URL"].Str();
            /*o.Firstname = data["FRST_NM"].Str().ToUpper();
            o.Lastname = data["LST_NM"].Str().ToUpper();
            o.Fullname = data["FLL_NM"].Str().ToUpper();
            o.CreditBalance = data["ACT_CRDT_BAL"].Str().ToDecimalDouble();
            o.CommissionBalance = data["ACT_COM_BAL"].Str().ToDecimalDouble();
            //
            string usertype = data["USR_TYP"].Str();
            o.IsPlayer = (usertype.Equals("5"));
            if(account.IsGeneralCoordinator){
                o.IsCoordinator = (usertype.Equals("4"));
                o.IsGeneralCoordinator = (usertype.Equals("3"));
            }
            o.IsPlayer = (usertype.Equals("5"));
            o.IsCoordinator = (usertype.Equals("4"));
            o.IsGeneralCoordinator = (usertype.Equals("3"));
            o.IsBlocked = (data["S_BLCK"].Str().Equals("1"));*/
            return o;
        }


        
        public static IEnumerable<dynamic> SearchRegisters(IEnumerable<dynamic> list, int limit = 50){
            if(list==null) return null;
            var items = SearchRegisters(list);
            var count = items.Count();
            if(count>=limit){
                var o = items.Last();
                var filter = (o.NextFilter = Dynamic.Object);
                items = items.Take(count-1).Concat(new[]{ o });
                filter.BaseFilter = o.RegisterID;
            }
            return items;
        }

        public static IEnumerable<dynamic> SearchRegisters(IEnumerable<dynamic> list){
            if(list==null) return null;
            return list.Select(e=> SearchRegister(e));
        }

        public static IDictionary<string, object> SearchRegister(IDictionary<string, object> data){
            dynamic o = Dynamic.Object;
            //o.SubscriberID =  data["CUST_ID"].Str();
            o.RegisterID =  data["RGS_ID"].Str();
            o.MobileNumber = data["MOB_NO"].Str().Replace("+639","09");
            //o.DisplayName =  data["NCK_NM"].Str();
            o.ImageUrl =  data["IMG_URL"].Str();
            //
            o.Type =  (int)data["USR_TYP"].Str().ToDecimalDouble();
            o.Role =  (int)data["GRP_CD"].Str().ToDecimalDouble();
            //o.RoleName =  data["NCK_NM"].Str();
            //
            o.Fullname =  data["FLL_NM"].Str();
            o.Lastname =  data["LST_NM"].Str();
            o.Middlename =  data["MDL_NM"].Str();
            o.Firstname =  data["FRST_NM"].Str();

            o.BirthDate =  data["BRT_DT"].Str();
            o.Gender =  data["GNDR"].Str();
            o.BloodType =  data["BLD_TYP"].Str();
            o.Nationality =  data["NATNLTY"].Str();
            o.MaritalStatus =  data["MRTL_STAT"].Str();

            //o.MobileNumber =  data["MOB_NO"].Str();
            o.EmailAddress =  data["EML_ADD"].Str();
            o.Address =  data["PRSNT_ADDR"].Str();
            o.Occupation =  data["OCCPTN"].Str();
            o.Skills =  data["SKLLS"].Str();
            o.GeneralCoordinator =  data["REF_ACT_ID"].Str();
            o.Coordinator =  data["REF_ACT_ID2"].Str();
            o.GeneralCoordinatorName =  data["REF_ACT_NM"].Str();
            o.CoordinatorName =  data["REF_ACT_NM2"].Str();

            o.Region =  data["LOC_REG"].Str();
            o.Province =  data["LOC_PROV"].Str();
            o.Municipality =  data["LOC_MUN"].Str();
            o.Barangay =  data["LOC_BRGY"].Str();

            return o;
        }
    }

}