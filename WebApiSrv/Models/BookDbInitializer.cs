using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApiSrv.Models
{
    public class BookDbInitializer:DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { BookName = "Война и мир", Author = "Л. Толстой", Year = 1863 });
            db.Books.Add(new Book { BookName = "Отцы и дети", Author = "И. Тургенев", Year = 1862 });
            db.Books.Add(new Book { BookName = "Чайка", Author = "А. Чехов", Year = 1896 });

            base.Seed(db);
        }
    }
}