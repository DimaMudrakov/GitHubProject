﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class EditCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var context = new CustomersEntities();

            string ID = Request.QueryString["ID"];
            int UserID = int.Parse(ID);


            ddlCity.DataSource = context.City.ToList();
            ddlCity.DataValueField = "ID";
            ddlCity.DataTextField = "Name";
            ddlCity.DataBind();


            var user = context.User.Where(Name => Name.ID == UserID);


            foreach (User userData in user)
            {

                txtAddress.Text = userData.Address;
                txtCountry.Text = userData.Country;
                txtEmail.Text = userData.Email;
                txtName.Text = userData.Name;

                var cityID = userData.CityID;
                string idCity = cityID.ToString();

                ddlCity.SelectedValue = idCity;

                txtName.DataBind();

            }

        }
    }

    protected void btnEditCustomer_Click(object sender, EventArgs e)
    {
        string ID = Request.QueryString["ID"];
        int UserID = int.Parse(ID);

        if (CheckValidEmail(txtEmail.Text) == true)
        {
            var context = new CustomersEntities();

            var customer = new User();

            customer.Name = txtName.Text;
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;
            customer.CityID = int.Parse(ddlCity.SelectedValue);
            customer.Country = txtCountry.Text;
            customer.ID = UserID;

            context.User.Attach(customer);
            var entry = context.Entry(customer);
            entry.Property(u => u.Name).IsModified = true;
            entry.Property(u => u.Email).IsModified = true;
            entry.Property(u => u.Address).IsModified = true;
            entry.Property(u => u.CityID).IsModified = true;
            entry.Property(u => u.Country).IsModified = true;
            entry.Property(u => u.ID).IsModified = false;

            context.SaveChanges();

        }
        else if (CheckValidEmail(txtEmail.Text) == false)
        {
            Response.Redirect("EditCustomer.aspx?ID=" + ID);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }




    }
    protected bool CheckValidEmail(string Email)
    {
        string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        Match match = Regex.Match(Email.Trim(), pattern, RegexOptions.IgnoreCase);

        if (match.Success)
            return true;
        else
            return false;
    }

}