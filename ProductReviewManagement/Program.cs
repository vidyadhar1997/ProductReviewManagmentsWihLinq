using System;
using System.Collections.Generic;
using System.Data;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProductReview> list = new List<ProductReview>()
            {
            new ProductReview() { ProductId = 1, UserId = 1, Rating = 5.5, Review = "Good", isLike=true},
            new ProductReview() { ProductId = 1, UserId = 1, Rating = 5.5, Review = "Good", isLike=true},
            new ProductReview() { ProductId = 2, UserId = 2, Rating = 4.5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 3, UserId = 3, Rating = 6, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 4, UserId = 4, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 5, UserId = 5, Rating = 5, Review = "Nice", isLike=true },
            new ProductReview() { ProductId = 6, UserId = 6, Rating = 5, Review = "Nice", isLike=true },
            new ProductReview() { ProductId = 7, UserId = 7, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 8, UserId = 8, Rating = 7.5, Review = "Good", isLike=false},
            new ProductReview() { ProductId = 9, UserId = 9, Rating = 1.5, Review = "Good", isLike=false },
            new ProductReview() { ProductId = 10, UserId = 10, Rating = 6.5, Review = "Bad", isLike=false },
            new ProductReview() { ProductId = 11, UserId = 11, Rating = 5, Review = "Bad", isLike=false },
            new ProductReview() { ProductId = 12, UserId = 12, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 13, UserId = 13, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 14, UserId = 14, Rating = 5, Review = "Bad", isLike=true },
            new ProductReview() { ProductId = 15, UserId = 15, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 16, UserId = 16, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 17, UserId = 17, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 18, UserId = 18, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 19, UserId = 19, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 20, UserId = 20, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 21, UserId = 21, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 22, UserId = 22, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 23, UserId = 23, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 24, UserId = 24, Rating = 5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 25, UserId = 25, Rating = 5, Review = "Good", isLike=true }
            };
            Console.WriteLine("Rows in the table = ");
            foreach (var lists in list)
            {
                Console.WriteLine("Product id = " + lists.ProductId + "User id = " + lists.UserId + "Rating is = " + lists.Rating + " Review is = " + lists.Review + " isLike = " + lists.isLike);
            }
            Management management = new Management();
            management.topRecords(list);
            management.selectedRecords(list);
            management.retrieveCountOfRecords(list);
            management.retrieveProductdAndReview(list);
            management.skipTopFiveRecords(list);
            DataTable dataTable=management.createTable();
            foreach (var lists in list)
            {
                dataTable.Rows.Add(lists.ProductId, lists.UserId, lists.Rating, lists.Review,(bool)lists.isLike);
            }
            management.RetrieveRecordsWithIsLikeTrue(dataTable);
            management.findAvrageRating(list);
        }
    }
}
