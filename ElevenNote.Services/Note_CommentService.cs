using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class Note_CommentService
    {

        private readonly Guid _userId;
        public Note_CommentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateComment(Note_CommentItem model)
        {
            var entity =
                new Note_Comment()
                {
                    CommentId = model.CommentId,
                    NoteId = model.NoteId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Note_Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<Note_CommentItem> GetNote_Comments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Note_Comments
                        .Select(
                        e =>
                            new Note_CommentItem
                            {
                                CommentId = e.CommentId,
                                NoteId = e.NoteId
                            });
                return query.ToArray();
            }
        }
        public Note_CommentItem GetNote_CommentById(int id, int id2)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Note_Comments
                    .Single(e => e.NoteId == id && e.CommentId == id2);
                return
                    new Note_CommentItem
                    {
                        NoteId = entity.NoteId,
                        CommentId = entity.CommentId
                    };
            }
        }
        public bool UpdateNote_Comment(Note_CommentItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Note_Comments
                    .Single(e => e.NoteId == model.NoteId && e.CommentId == model.CommentId);

                entity.CommentId = model.CommentId;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote_Comment(int commentId,int id2)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                   .Note_Comments
                   .Single(e => e.NoteId == commentId && e.CommentId == id2);
                ctx.Note_Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
