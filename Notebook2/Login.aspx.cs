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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // پیام کاربر در سیستم پیدا نشد
            txtUserNotFound.Visible = false;
        }
        /// <summary>
        /// دکمه ی لوگین
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var DbAccess = new DataAccess();
                M_User targetUser = DbAccess.Users.Where(x => x.Username == txtUsername.Text && x.Password == txtPassword.Text).FirstOrDefault();
                if (targetUser != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(txtUsername.Text.ToLower(), false);
                    //FormsAuthentication.SetAuthCookie(txtUsername.Text.ToLower(), true);
                }
                else
                {
                    txtUserNotFound.Visible = true;
                }
            }
        }
    }
}