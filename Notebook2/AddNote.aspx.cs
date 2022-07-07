using Notebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Notebook
{
    public partial class AddNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/login.aspx");
            }
        }
        /// <summary>
        /// دکمه ثبت نوشته
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DataAccess db = new DataAccess();
                string UserName = User.Identity.Name;
                var _temp = db.Users.Where(x => x.Username.ToLower() == UserName.ToLower()).Count();
                List<M_User> uu = db.Users.ToList();
                int UserId = uu.LastOrDefault().Id;
                if (_temp > 0)
                {
                    UserId = db.Users.Where(x => x.Username == UserName).FirstOrDefault().Id;
                }
                M_Note noteParam = new M_Note()
                {
                    Content = txtContent.Text,
                    Title = txtTitle.Text,
                    UserId = UserId
                };
                db.Notes.Add(noteParam);
                db.SaveChanges();
                Response.Redirect("/default.aspx");
            }
        }
    }
}