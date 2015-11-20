﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

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

        if (CheckValidEmail(txtEmail.Text) == true) {

           lblInformLabel.Text = "";
           var context = new CustomersEntities();

            User customer = new User();


            customer.Name = txtName.Text;
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;
            customer.CityID = int.Parse(ddlCity.SelectedValue);
            customer.Country = txtCountry.Text;

            User add = context.User.Add(customer);

            context.SaveChanges();
            ClearInputs();
            lblInformLabel.Text = "Customer Add";
            lblInformLabel.ForeColor = System.Drawing.Color.FromArgb(22, 139, 224);

        }
        else if(CheckValidEmail(txtEmail.Text) == false)
        {
            lblInformLabel.Text = "Not valid email";
            lblInformLabel.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

    }
    protected bool CheckValidEmail (string Email)
    {
        string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        Match match = Regex.Match(Email.Trim(), pattern, RegexOptions.IgnoreCase);

        if (match.Success)
            return true;
        else
            return false;
    }
    private void ClearInputs()
    {
        txtName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtAddress.Text = string.Empty;
        ddlCity.SelectedIndex = 0 ;
        txtCountry.Text = string.Empty;

    }


}
