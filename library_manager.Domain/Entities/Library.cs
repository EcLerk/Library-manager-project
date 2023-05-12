using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Domain.Entities
{
    public class Library
    {
        private static Library instance;

        List<Book> books;
        List<Users.User> users;
        OrdersStorage ordersStorage;

        private Library() 
        {
            books = new List<Book>();
            users = new List<Users.User>();
            ordersStorage = new OrdersStorage();
        }

        public static Library getInstance()
        {
            if(instance == null)
                instance = new Library();

            return instance;
        }
    }
}
