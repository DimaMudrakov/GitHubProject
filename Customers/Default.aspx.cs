using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    public void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnAddNewCustomer_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddNewCustomer.aspx");
    }
}

 
