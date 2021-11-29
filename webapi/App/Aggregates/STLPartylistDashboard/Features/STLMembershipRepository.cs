using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.App.Aggregates.Common;
using webapi.App.RequestModel.AppRecruiter;
using Comm.Commons.Extensions;
using webapi.Commons.AutoRegister;
using webapi.App.Model.User;
using webapi.App.Aggregates.Common.Dto;

namespace webapi.App.Aggregates.STLPartylistDashboard.Features
{
    [Service.ITransient(typeof(STLMembershipRepository))]
    public interface ISTLMembershipRepository
    {
        Task<(Results result, String message, STLSignInRequest signin, STLAccount account)> MembershipAsync(STLMembership membership, bool isUpdate=false);
    }
    public class STLMembershipRepository : ISTLMembershipRepository
    {
        public readonly IRepository _repo;
        public STLMembershipRepository(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<(Results result, string message, STLSignInRequest signin, STLAccount account)> MembershipAsync(STLMembership membership, bool isUpdate=false)
        {
            var results = _repo.DSpQueryMultiple("dbo.spfn_BDABDBCAACBB01", new Dictionary<string, object>()
            {
                {"parmplid",membership.PLID },
                {"parmpgrpid",membership.PGRPID },
                {"parmfnm",membership.Firstname },
                {"parmlnm",membership.Lastname },
                {"parmmnm",membership.Middlename },
                {"parmnnm",membership.Nickname },
                {"parmmobno",membership.MobileNumber },
                {"parmgender",membership.Gender },
                {"parmmstastus",membership.MaritalStatus },
                {"parmemladd",membership.EmailAddress },
                {"parmhmeadd",membership.HomeAddress },
                {"parmprsntadd",membership.PresentAddress },
                {"parmreg",membership.Region },
                {"parmprov",membership.Province },
                {"parmmun",membership.Municipality },
                {"parmbrgy",membership.Barangay },
                {"parmbdate",membership.BirthDate },
                {"parmctznshp",membership.Citizenship },
                {"parmbldType",membership.BloodType },
                {"parmntnlty",membership.Nationality },
                {"parmoccptn",membership.Occupation },
                {"parmsklls",membership.Skills },
                {"parmprfpic",membership.ImageUrl },
                {"parmImgUrl",membership.ImageUrl },
                {"parmusertype",membership.AccountType },

                {"parmusername",membership.Username },
                {"parmpassword",membership.Userpassword },
                {"parmusrid",(isUpdate?membership.Userid:"") },
            }).ReadSingleOrDefault();
            if (results != null)
            {
                var row = ((IDictionary<string, object>)results);
                string ResultCode = row["RESULT"].Str();
                if (ResultCode == "1")
                    if (isUpdate == false)
                    {
                        return (Results.Success, "Membership Successfull Save", new STLSignInRequest()
                        {
                            Username = row["USR_NM"].Str(),
                            Password = row["USR_PSSWRD"].Str(),
                            plid = row["PL_ID"].Str(),
                            groupid = row["PGRP_ID"].Str(),
                            psncd = row["PSN_CD"].Str()
                        },null);
                    }
                    else
                    {
                        return (Results.Success, "Member Account Successful save", null, STLSubscriberDto.STLUpdateMember(membership));
                    }
                    
                else if (ResultCode == "2")
                    return (Results.Failed, "Invalid Mobile Number",null, null);
                else if(ResultCode=="3")
                    return (Results.Failed, "Mobile Number already exist",null, null);
                else if (ResultCode == "4")
                    return (Results.Failed, "You are already Member of this Group",null, null);
                else if (ResultCode == "5")
                    return (Results.Failed, "Username already exist",null, null);
            }
            return (Results.Null, null,null, null);
        }
    }
}
