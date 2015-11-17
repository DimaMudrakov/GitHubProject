using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CustomerDS
{
    public Array GetCustomers(int startIndex, int maxRows)
    {
        using (var context = new CustomersEntities())
        {
          return  (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.ID
                        select  new {User, City } )
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
