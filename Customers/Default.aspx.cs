using System;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected void btnAddNewCustomerDefault_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddNewCustomer.aspx");
    }

    protected void btnDeleteSelectedCustomer_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvCustomers.Rows)
        {
            CheckBox chkDeleteCustomer = (CheckBox)row.FindControl("chkDeleteCustomer");

            if (chkDeleteCustomer.Checked)
            {
                var lblId = row.FindControl("lblID") as Label ;
                int ID = int.Parse(lblId.Text);

                var context = new CustomersEntities();

                var employer = new User { ID = ID };
                context.User.Attach(employer);
                context.User.Remove(employer);
                context.SaveChanges();
               
            }

        }
        Response.Redirect("Default.aspx");
    }
}

 
