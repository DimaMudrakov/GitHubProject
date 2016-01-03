using System;
using System.Linq;

public class CustomerDS
{
    public Array GetCustomers(int startIndex, int maxRows, string sortColumn, string nameSearchString, string citySearchString)
    {
        int thisStartIndex = startIndex;
        int thisMaxRows = maxRows;
        string thisSortColumn = sortColumn;
        string thisSearchString = nameSearchString;
        string thisSearchStringCity = citySearchString;

        using (var context = new CustomersEntities())
        {
            if (!String.IsNullOrWhiteSpace(citySearchString) && !String.IsNullOrWhiteSpace(nameSearchString))
            {
                return searchByNameAndByCity(thisStartIndex, thisMaxRows, thisSortColumn, thisSearchStringCity, thisSearchString);
            }
            else if (!String.IsNullOrWhiteSpace(nameSearchString))
            {
              return searchByName(thisStartIndex, thisMaxRows, thisSortColumn, thisSearchString);
              
            }
            else if (!String.IsNullOrWhiteSpace(citySearchString))
            {
                return searchByCity(thisStartIndex, thisMaxRows, thisSortColumn, thisSearchStringCity);
            }

        else if (sortColumn == "User.Name")
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
        else if (sortColumn == "User.Email")
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
    public int GetCustomersCount(string nameSearchString, string citySearchString)
    {
        using (var context = new CustomersEntities())
        {
            if (!String.IsNullOrWhiteSpace(nameSearchString) && !String.IsNullOrWhiteSpace(citySearchString))
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                        select new { User.City })
                           .Count();
            }
            else if (!String.IsNullOrWhiteSpace(nameSearchString))
            {
                return (from User in context.User
                        where User.Name.Contains(nameSearchString)
                        select User)
                           .Count();
            }
            else if (!String.IsNullOrWhiteSpace(citySearchString))
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        where City.Name.Contains(citySearchString)
                        select new { User.City })
                           .Count();
            }

            return context.User.Count();
        }
    }

    public Array searchByName(int startIndex, int maxRows, string sortColumn, string nameSearchString)
    {
        using (var context = new CustomersEntities())
        {
              if (sortColumn == "User.Name")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Name
                        where User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Name DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Name descending
                        where User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Email")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Email
                        where User.Name.Contains(nameSearchString)
                        select new { User, City })
                                .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Email DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Email descending
                        where User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Address")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Address
                        where User.Name.Contains(nameSearchString)
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Address DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Address descending
                        where User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "City.Name")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby City.Name
                        where User.Name.Contains(nameSearchString)
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "City.Name DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby City.Name descending
                        where User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Country")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Country
                        where User.Name.Contains(nameSearchString)
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Country DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Country descending
                        where User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }


            return (from User in context.User
                    join City in context.City
                   on User.CityID equals City.ID
                    orderby User.ID
                    where User.Name.Contains(nameSearchString)
                    select new { User, City })
                       .Skip(startIndex).Take(maxRows).ToArray();
        }
            
    }

    public Array searchByCity(int startIndex, int maxRows, string sortColumn, string citySearchString)
    {
        using (var context = new CustomersEntities())
        {
            if (sortColumn == "User.Name")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Name
                        where City.Name.Contains(citySearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Name DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Name descending
                        where City.Name.Contains(citySearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Email")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Email
                        where City.Name.Contains(citySearchString)
                        select new { User, City })
                                .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Email DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Email descending
                        where City.Name.Contains(citySearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Address")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Address
                        where City.Name.Contains(citySearchString)
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Address DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Address descending
                        where City.Name.Contains(citySearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "City.Name")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby City.Name
                        where City.Name.Contains(citySearchString)
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "City.Name DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby City.Name descending
                        where City.Name.Contains(citySearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Country")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Country
                        where City.Name.Contains(citySearchString)
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Country DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Country descending
                        where City.Name.Contains(citySearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }


            return (from User in context.User
                    join City in context.City
                    on User.CityID equals City.ID
                    orderby User.ID
                    where City.Name.Contains(citySearchString)
                    select new { User, City })
                       .Skip(startIndex).Take(maxRows).ToArray();
        }

    }

    public Array searchByNameAndByCity(int startIndex, int maxRows, string sortColumn, string citySearchString, string nameSearchString)
    {
        using (var context = new CustomersEntities())
        {
            if (sortColumn == "User.Name")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Name
                        where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Name DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Name descending
                        where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Email")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Email
                        where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                        select new { User, City })
                                .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Email DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Email descending
                        where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Address")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Address
                        where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Address DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Address descending
                        where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "City.Name")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby City.Name
                        where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "City.Name DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby City.Name descending
                        where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Country")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Country
                        where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                        select new { User, City })
                                  .Skip(startIndex).Take(maxRows).ToArray();
            }
            else if (sortColumn == "User.Country DESC")
            {
                return (from User in context.User
                        join City in context.City
                        on User.CityID equals City.ID
                        orderby User.Country descending
                        where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                        select new { User, City })
                        .Skip(startIndex).Take(maxRows).ToArray();
            }


            return (from User in context.User
                    join City in context.City
                    on User.CityID equals City.ID
                    orderby User.ID
                    where City.Name.Contains(citySearchString) && User.Name.Contains(nameSearchString)
                    select new { User, City })
                       .Skip(startIndex).Take(maxRows).ToArray();
        }
    }
}
