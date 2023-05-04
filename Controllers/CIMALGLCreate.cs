using Microsoft.AspNetCore.Mvc;

namespace IMALOpening.Controllers
{
 
    public class CIMALGLCreate : Controller
    {
        DLL_Code dllCode = new DLL_Code();

        [HttpPost("CIMALGLCreate")]
        public ActionResult<string> Create([FromBody] SIMALGL x)
        {
            string username = x.username;
            string password = x.password;
            string currency = x.currency;
            string accGL = x.accGl;
            string cif = x.cifNo;
            string branch = x.branchCode;
            string channelName = x.ChannelName;
            return (dllCode.GLCreation(cif,currency, accGL, branch,username,password,channelName));
        }
    }
}
