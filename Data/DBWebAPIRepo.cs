using System.Linq;
using Assignment2.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class DBWebAPIRepo : IWebAPIRepo
{
    private readonly WebAPIDBContext _dbContext;

    public DBWebAPIRepo(WebAPIDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool UserExistOrNot(Users user)
    {
        if (_dbContext.Users.FirstOrDefault(e => e.UserName == user.UserName) != null)
            return true;
        else
            return false;
    }

    public Users AddUser(Users user)
    {
        EntityEntry<Users> e = _dbContext.Users.Add(user);
        Users u = e.Entity;
        _dbContext.SaveChanges();
        return u;
    }

    public bool ValidLogin(string userName, string password)
    {
        Users u = _dbContext.Users.FirstOrDefault
            (e => e.UserName == userName && e.Password == password);
        if (u == null)
            return false;
        else
            return true;
    }

    public Orders AddOrder(Orders order)
    {
        EntityEntry<Orders> e = _dbContext.Orders.Add(order);
        Orders o = e.Entity;
        _dbContext.SaveChanges();
        return o;
    }

    public Orders GetOrder(int id)
    {
        Orders o = _dbContext.Orders.FirstOrDefault(e => e.Id == id);
        return o;
    }
}