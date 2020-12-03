using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    public class Note_CommentController : ApiController
    {
        private Note_CommentService CreateNote_CommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var note_commentService = new Note_CommentService(userId);
            return note_commentService;
        }
        public IHttpActionResult Get()
        {
            Note_CommentService note_commentService = CreateNote_CommentService();
            var note_comments = note_commentService.GetNote_Comments();
            return Ok(note_comments);
        }
        public IHttpActionResult Post(Note_CommentItem note_comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNote_CommentService();

            if (!service.CreateComment(note_comment))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id, int id2)
        {
            Note_CommentService note_commentService = CreateNote_CommentService();
            var note_comment = note_commentService.GetNote_CommentById(id,id2);
            return Ok(note_comment);
        }

        public IHttpActionResult Put(Note_CommentItem note_comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateNote_CommentService();

            if (!service.UpdateNote_Comment(note_comment))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id, int id2)
        {
            var service = CreateNote_CommentService();

            if (!service.DeleteNote_Comment(id,id2))
                return InternalServerError();
            return Ok();
        }
    }
}
