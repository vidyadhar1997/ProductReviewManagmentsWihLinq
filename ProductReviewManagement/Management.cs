using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagement
{
    public class Management
    {
        private readonly DataTable dataTable = new DataTable();

        /// <summary>
        /// Displays the specified record data.
        /// </summary>
        /// <param name="recordData">The record data.</param>
        public void display(List<ProductReview> recordData)
        {
            foreach (var list in recordData)
            {
                Console.WriteLine("Product id = " + list.ProductId + "User id = " + list.UserId + "Rating is = " + list.Rating + " Review is = " + list.Review + " isLike = " + list.isLike);
            }
        }

        /// <summary>
        /// Retrieve Top 3 records from list.
        /// </summary>
        /// <param name="listProductReviews">The list product reviews.</param>
        public void topRecords(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews orderby productReview.Rating descending select productReview).Take(3).ToList();
            Console.WriteLine("\n Top 3 records = ");
            display(recordData);
        }

        /// <summary>
        /// Selecteds the record with rating grater than 3 and with product id =1,3,9.
        /// </summary>
        /// <param name="listProductReviews">The list product reviews.</param>
        public void selectedRecords(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews where (productReview.ProductId == 1 || productReview.ProductId == 4 || productReview.ProductId == 9) && productReview.Rating > 3 select productReview).ToList();
            Console.WriteLine("\n Rating grater than 3 with product id 1,4,9 = ");
            display(recordData);
        }

        /// <summary>
        /// Retrieves the count of record with  the help of group by id.
        /// </summary>
        /// <param name="listProductReviews">The list product reviews.</param>
        public void retrieveCountOfRecords(List<ProductReview> listProductReviews)
        {
            var recordData = listProductReviews.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            Console.WriteLine("\n Product id and count = ");
            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductId + " = " + list.Count);
            }
        }

        /// <summary>
        /// Retrieves the productd and review.
        /// </summary>
        /// <param name="listProductReviews">The list product reviews.</param>
        public void retrieveProductdAndReview(List<ProductReview> listProductReviews)
        {
            var recordData = listProductReviews.Select(x => new { ProductId = x.ProductId, Review = x.Review });
            Console.WriteLine("\n Product id and review = ");
            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductId + "----------" + list.Review);
            }
        }

        /// <summary>
        /// Skips the top five records.
        /// </summary>
        /// <param name="listProductReviews">The list product reviews.</param>
        public void skipTopFiveRecords(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews select productReview).Skip(5).ToList();
            Console.WriteLine("\n Records from list after skipp top 5 lines = ");
            display(recordData);
        }

        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <param name="listProductReviews">The list product reviews.</param>
        /// <returns></returns>
        public DataTable createTable()
        {
            dataTable.Columns.Add("ProductId", typeof(int));
            dataTable.Columns.Add("UserId",typeof(int));
            dataTable.Columns.Add("Rating",typeof(double));
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike",typeof(bool));
            return dataTable;
        }

        /// <summary>
        ///  Retrieve Records with is value true
        /// </summary>
        /// <param name="table"></param>
        public void RetrieveRecordsWithIsLikeTrue(DataTable table)
        {
            var recordData = from productReview in table.AsEnumerable() where (productReview.Field<bool>("isLike") == true) select productReview;
            Console.WriteLine("Records with is like true = ");
            foreach (var lists in recordData)
            {
                Console.WriteLine("Product id = " + lists.Field<int>("ProductId") + "User id = " + lists.Field<int>("UserId") + "Rating is = " + lists.Field<double>("Rating") + " Review is = " + lists.Field<string>("Review") + " isLike = " + lists.Field<bool>("isLike"));
            }
        }
    }
}