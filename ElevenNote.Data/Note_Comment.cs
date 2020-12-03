using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note_Comment
    {
        [Key, Column(Order = 0)]
        public int NoteId { get; set; }
        public virtual Note Note { get; set; }
        [Key, Column(Order = 1)]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
