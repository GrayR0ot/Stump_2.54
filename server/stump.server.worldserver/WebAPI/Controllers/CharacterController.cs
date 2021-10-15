using System.Net;
using System.Web.Http;
using Stump.Server.WorldServer.Game;

namespace Stump.Server.WorldServer.WebAPI.Controllers
{
    [CustomAuthorize]
    [Route("Character/{characterId:int}")]
    public class CharacterController : ApiController
    {
        public IHttpActionResult Get(int characterId)
        {
            var character = World.Instance.GetCharacter(characterId);

            if (character == null)
                return NotFound();

            return Json(character.Record);
        }

        public IHttpActionResult Put(int characterId)
        {
            return StatusCode(HttpStatusCode.MethodNotAllowed);
        }

        public IHttpActionResult Post(int characterId, string value)
        {
            return StatusCode(HttpStatusCode.MethodNotAllowed);
        }

        public IHttpActionResult Delete(int characterId)
        {
            return StatusCode(HttpStatusCode.MethodNotAllowed);
        }
    }
}