using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : System.Web.UI.Page
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
        }

    }


    protected void btnAddNewCustomer_Click(object sender, EventArgs e)
    {
        var context = new CustomersEntities();

        User customer = new User();


        customer.Name = txtName.Text;
        customer.Email = txtEmail.Text;
        customer.Address = txtAddress.Text;
        customer.CityID =  int.Parse(ddlCity.SelectedValue);
        customer.Country = txtCountry.Text;

        User add =  context.User.Add(customer);

        context.SaveChanges();

    }


}
