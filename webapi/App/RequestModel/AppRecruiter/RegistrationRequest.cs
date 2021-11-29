using System;
using System.ComponentModel.DataAnnotations;
namespace webapi.App.RequestModel.AppRecruiter
{
    public class RegistrationRequest
    {
        public string RegisterID;
        public string Type;
        public string Role;
        public string GeneralCoordinator;
        public string Coordinator;

        public string Firstname;
        public string Middlename;
        public string Lastname;
        public string Fullname;

        public string BirthDate;
        public string Gender;
        public string BloodType;
        public string Nationality;
        public string Citizenship;
        public string MaritalStatus;

        public string MobileNumber;
        public string EmailAddress;
        public string Address;
        public string Occupation;
        public string Skills;

        public string Region;
        public string Province;
        public string Municipality;
        public string Barangay;

        //
        public string Img;
        public string ImageUrl;
    }
    public class STLMembership
    {
        public string PLID;
        public string PGRPID;
        public string Userid;

        public string Firstname;
        public string Lastname;
        public string Middlename;
        public string Nickname;

        public string BirthDate;
        public string Gender;
        public string BloodType;
        public string Nationality;
        public string Citizenship;
        public string MaritalStatus;

        public string MobileNumber;
        public string EmailAddress;
        public string HomeAddress;
        public string PresentAddress;
        public string Occupation;
        public string Skills;

        public string Region;
        public string Province;
        public string Municipality;
        public string Barangay;

        
        public string AccountType;
        public string Username;
        public string Userpassword;


        public string Img;
        public string ImageUrl;
    }
}