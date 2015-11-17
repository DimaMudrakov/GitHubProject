using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CustomerDS
{
    public Array GetCustomers(int startIndex, int maxRows, string sortColumn)
    {

        using (var context = new CustomersEntities())
        {
            if (sortColumn == "User.Name")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Name
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Name DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Name descending
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if(sortColumn == "User.Email")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Email
                        select new { User, City })
                                .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Email DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Email descending
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Address")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Address
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Address DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Address descending
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "City.Name")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby City.Name
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "City.Name DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby City.Name descending
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Country")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Country
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Country DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Country descending
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }


            return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.ID
                        select new { User, City })
                           .Skip(startIndex).Take(maxRows).ToArray();
            

        }


    }
    public int GetCustomersCount()
    {
        using (var context = new CustomersEntities())
        {
            return context.User.Count();
        }
    }

}
