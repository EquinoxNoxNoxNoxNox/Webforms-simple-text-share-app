using Notebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Notebook2
{
    public partial class Profile : System.Web.UI.Page
    {
        public IQueryable<M_Note> GetNotes()
        {
            DataAccess db = new DataAccess();
            var query = db.Notes.Where(x=>x.UserId == 1);
            return query;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("default.aspx");
            }
        }
        /// <summary>
        /// دکمه خارج شدن از اکانت
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/login.aspx");
        }
    }
}