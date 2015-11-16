using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var context = new CustomersEntities();

            ddlCity.DataSource = context.City.ToList();
            ddlCity.DataValueField = "ID";
            ddlCity.DataTextField = "Name";
            ddlCity.DataBind();

            string ID = Request.QueryString["ID"];
            int UserID = int.Parse(ID);

            var user = context.User.Where(Name => Name.ID == UserID);


            foreach (User userData in user)
            {
                
                txtAddress.Text = userData.Address;
                txtCountry.Text = userData.Country;
                txtEmail.Text = userData.Email;
                txtName.Text = userData.Name;
                txtName.DataBind();

            }

        }
    }

    protected void btnEditCustomer_Click(object sender, EventArgs e)
    {

    }

}