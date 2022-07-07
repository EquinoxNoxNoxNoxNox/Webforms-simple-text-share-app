using Notebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Notebook
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// دکمه رجیستر
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var DbAccess = new DataAccess();
                DbAccess.Users.Add(new M_User()
                {
                    Password = txtPassword.Text,
                    Username = txtUsername.Text
                });
                DbAccess.SaveChanges();
                Response.Redirect("./Login.aspx");
            }
        }
    }
}