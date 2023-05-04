using Microsoft.AspNetCore.Mvc;

namespace IMALOpening.Controllers
{
   
    public class CIMALVALIDATE : Controller
    {
        DLL_Code dllCode = new DLL_Code();

        [HttpPost("CIMALVALIDATE")]
        public ActionResult<string> Create([FromBody] SIMALVALIDATE x)
        {
            string username = x.username;
            string password = x.password;
            string cif = x.CIF;
            string channelName = x.ChannelName;
            return (dllCode.CIFVALIDATE(cif,username,channelName,password));
        }
    }
}
