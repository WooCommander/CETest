﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CAEntity
{
    // Enable-Migrations // включаем миграцию
    // add-migration 'addMigration' //название появится в солюшине ехплорере
    // update-database // обновляем базу согласно миграции

    class UserContext : DbContext
    {
        public UserContext()
            : base("DbConnection") // conectionstring api.config
        { }

        public DbSet<User> Users { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                User user1 = new User { Name = "Tom", Age = 33, DateR=DateTime.Today };
                User user2 = new User { Name = "Sam", Age = 26, DateR = DateTime.Today };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Users;
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                }
            }
            Console.Read();
        }
    }
}
