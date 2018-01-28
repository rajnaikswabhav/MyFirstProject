using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Welcome_API.Models;

namespace Welcome_API.Controllers
{
    [RoutePrefix("api/v1/Swabhav/Welcome")]
    public class WelcomeController : ApiController
    {
        [Route("GetMessage")]
        public IHttpActionResult GetMessage()
        {
            return Ok(new { Text = "Hello World" });
        }

        [Route("GetMessageById/{messageId}")]
        public IHttpActionResult GetMessageById(string messageId)
        {
            return Ok(new { Text = "Fetching Message with Id " + messageId });
        }

        [Route("PostWithDTO")]
        public IHttpActionResult PostWithDTO(MessageDTO dto)
        {
            var value = "Posted by Id "+id+" Data:" + dto.Id + "--" + dto.Text; 
            return Ok(value);
        }

        [Route("PutAMessage")]
        public IHttpActionResult PutMessage()
        {
            return Ok("Put Invoked");
        }


    }
}
