using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Coffees.Any())
            {
                context.AddRange
                (
                    new Coffee
                    {
                        Name = "Apple Pie",
                        Price = 12.95M,
                        ShortDescription = "Our famous Coffee!",
                        LongDescription = "Hot Cuppuccino Coffee.  This the world's number one coffee that has a remarkable taste and it keeps you happy and enegetic",
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg",
                        ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg"
                    });

                context.SaveChanges();            }
        }
    }
}
