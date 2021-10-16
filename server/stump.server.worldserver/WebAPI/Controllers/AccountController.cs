using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Http;
using MongoDB.Bson;
using NLog;
using Stump.Server.BaseServer.Logging;
using Stump.Server.BaseServer.Network;
using Stump.Server.WorldServer.Core.Network;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Accounts;

namespace Stump.Server.WorldServer.WebAPI.Controllers
{
    [Route("Account/{accountId:int}")]
    public class AccountController : ApiController
    {
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public IHttpActionResult Get(int accountId)
        {
            var account = World.Instance.GetConnectedAccount(accountId);

            if (account == null)
                return NotFound();

            return Json(account);
        }

        public IHttpActionResult Put(int accountId)
        {
            return StatusCode(HttpStatusCode.MethodNotAllowed);
        }

        public IHttpActionResult Post(int accountId, string value)
        {
            return StatusCode(HttpStatusCode.MethodNotAllowed);
        }

        public IHttpActionResult Delete(int accountId)
        {
            return StatusCode(HttpStatusCode.MethodNotAllowed);
        }
    }
}