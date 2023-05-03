using IMALOpening;
using Microsoft.AspNetCore.Mvc;

namespace IMALOpening.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CIMALCIFCreate : Controller
    {
        DLL_Code dllCode = new DLL_Code();

        [HttpPost("CIMALCIFCreate")]
 
        public ActionResult<string> Create([FromBody] SIMALCIF x)
        {
            string cifType = x.cifType;
            string idType = x.idType;
            string idNumber = x.idNumber;
            string Country_of_issuance = x.Country_of_issuance;
            string dateOFbirth = x.dateOFbirth;
            string idExpiryDate = x.idExpiryDate;
            string maritalStatus = x.maritalStatus;
            string gender = x.gender;
            string language = x.language;
            string shortName = x.shortName;
            string longName = x.longName;
            string shortNameArabic = x.shortNameArabic;
            string longNameArabic = x.longNameArabic;
            string nationality = x.nationality;
            string country = x.country;
            string firstName = x.firstName;
            string secondName = x.secondName;
            string thirdName = x.thirdName;
            string lastName = x.lastName;
            string firstNameArabic = x.firstNameArabic;
            string secondNameArabic = x.secondNameArabic;
            string thirdNameArabic = x.thirdNameArabic;
            string lastNameArabic = x.lastNameArabic;
            string block = x.block;
            string blockenglish = x.blockenglish;
            string mobile = x.mobile;
            string area = x.area;
            string addressCountry = x.addressCountry;
            string modeOfStatementDelivery = x.modeOfStatementDelivery;
            string statement = x.statement;
            string economicSector = x.economicSector;
            string legalStatus = x.legalStatus;
            string ranking = x.ranking;
            string occupation = x.occupation;
            string division = x.division;
            string department = x.department;
            string username = x.username;
            string password = x.password;
            string ChannelName = x.ChannelName;
            string CorpCIF = x.CorpCIF;
            string cifBranch = x.CIFBranch;


   string response = dllCode.CreateCIF(cifType, idType, idNumber, Country_of_issuance, dateOFbirth, idExpiryDate, maritalStatus, gender, language, shortName, longName, shortNameArabic, longNameArabic, nationality, country, firstName, secondName
                , thirdName, lastName, firstNameArabic, secondNameArabic, thirdNameArabic, lastNameArabic, block, blockenglish, mobile, area, addressCountry, modeOfStatementDelivery, statement, economicSector, legalStatus, ranking, occupation, division
                , department, username, password, ChannelName,CorpCIF,cifBranch);

         
            return response;
        }
    }
}
