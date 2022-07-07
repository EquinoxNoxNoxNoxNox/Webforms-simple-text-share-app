using Notebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Notebook
{
    public partial class _default : System.Web.UI.Page
    {
        private List<M_NoteLike> Likes = new DataAccess().NoteLike.ToList();
        /// <summary>
        /// گرفتن تعداد لایک ها
        /// </summary>
        /// <param name="NoteId">شناسه ی نوشته</param>
        /// <returns></returns>
        public int GetLikeCounts(int NoteId)
        {
            return Likes.Where(x => x.PostId == NoteId).Count();
        }
        /// <summary>
        /// آیا توسط کاربر کنونی لایک شده است
        /// </summary>
        public bool GetIsLiked(int NoteId)
        {
            if (User.Identity.IsAuthenticated)
            {
                string UserName = User.Identity.Name;
                DataAccess db = new DataAccess();
                int UserId = db.Users.Where(x => x.Username == UserName).FirstOrDefault().Id;
                var UserLikes = Likes.Where(x => x.UserId == UserId);
                for (int i = 0; i < UserLikes.Count(); i++)
                {
                    if (UserLikes.ToList()[i].PostId == NoteId)
                        return true;
                }
            }
            return false;
        }
        public void toggleVoid(int NoteId)
        {
            if (User.Identity.IsAuthenticated)
            {
                string UserName = User.Identity.Name;
                DataAccess db = new DataAccess();
                int q = db.NoteLike.Where(x => x.PostId == NoteId).Count();
                if (q > 0)
                {
                    db.NoteLike.Remove(db.NoteLike.Where(x => x.PostId == NoteId).FirstOrDefault());
                    db.SaveChanges();
                }
                else
                {
                    int UserId = db.Users.Where(x => x.Username.ToLower() == UserName.ToLower()).FirstOrDefault().Id;
                    db.NoteLike.Add(new M_NoteLike()
                    {
                        UserId = UserId,
                        PostId = NoteId
                    });
                    db.SaveChanges();
                }
                Response.Redirect("/");
            }

        }
        public IQueryable<M_Note> GetNotes()
        {
            DataAccess db = new DataAccess();
            var query = db.Notes.OrderByDescending(x => x.CreateDate);
            return query;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLikeButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}