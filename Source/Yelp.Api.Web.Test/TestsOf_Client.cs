using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yelp.Api.Web.Models;

namespace Yelp.Api.Web.Test
{
    [TestClass]
    public class TestsOf_Client
    {
        #region Variables

        private const string _YelpAppId = "6WfLJ5rmFrGOsNS7cKo5Mg";
        private const string _YelpAppSecret = "a2npPM9U0YbBDbSwUxYXVTpUFj2JLWA1N4HykT6FfHHDgPmshRaGYHAKValxWf5X";

        private readonly Client _client;

        #endregion

        #region Constructors

        public TestsOf_Client()
        {
            _client = new Client(_YelpAppId, _YelpAppSecret);
        }

        #endregion

        #region Methods

        [TestMethod]
        public void TestSearch()
        {
            var response = _client.SearchBusinessesAllAsync("cupcakes", 37.786882, -122.399972).Result;

            Assert.AreNotSame(null, response);
            Assert.AreSame(null, response?.Error, $"Response error returned {response?.Error?.Code} - {response?.Error?.Description}");
        }

        [TestMethod]
        public void TestSearchDelivery()
        {
            var response = _client.SearchBusinessesWithDeliveryAsync("mex", 37.786882, -122.399972).Result;

            Assert.AreNotSame(null, response);
            Assert.AreSame(null, response?.Error, $"Response error returned {response?.Error?.Code} - {response?.Error?.Description}");
        }

        [TestMethod]
        public void TestAutocomplete()
        {
            var response = _client.AutocompleteAsync("hot dogs", 37.786882, -122.399972).Result;

            Assert.IsTrue(response.Categories.Length > 0);
            Assert.AreNotSame(null, response);
            Assert.AreSame(null, response?.Error, $"Response error returned {response?.Error?.Code} - {response?.Error?.Description}");
        }

        [TestMethod]
        public void TestGetBusiness()
        {
            var response = _client.GetBusinessAsync("north-india-restaurant-san-francisco").Result;

            Assert.AreNotSame(null, response);
            Assert.AreSame(null, response?.Error, $"Response error returned {response?.Error?.Code} - {response?.Error?.Description}");
        }

        [TestMethod]
        public void TestGetBusinessAsyncInParallel()
        {
            List<string> businessIds = new List<string> { "north-india-restaurant-san-francisco" };

            var response = _client.GetBusinessAsyncInParallel(businessIds).Result;

            Assert.AreNotSame(null, response);
            Assert.AreSame(null, response?.FirstOrDefault().Error, $"Response error returned {response?.FirstOrDefault().Error?.Code} - {response?.FirstOrDefault().Error?.Description}");
        }

        [TestMethod]
        public void TestGetReviews()
        {
            var response = _client.GetReviewsAsync("north-india-restaurant-san-francisco").Result;

            Assert.AreNotSame(null, response);
            Assert.AreSame(null, response?.Error, $"Response error returned {response?.Error?.Code} - {response?.Error?.Description}");
        }

        [TestMethod]
        public void TestGetModelChanges()
        {
            var m = new SearchRequest();
            m.Term = "Hello world";
            m.Price = "$";

            var dic = m.GetChangedProperties();

            Assert.AreEqual(dic.Count, 2);
            Assert.IsTrue(dic.ContainsKey("term"));
            Assert.IsTrue(dic.ContainsKey("price"));
        }

        #endregion

        #region GraphQL Methods *REQUIRES APP TO BE IN BETA*

        [TestMethod]
        public void TestGetGraphQlAsync()
        {
            List<string> businessIds = new List<string> { "north-india-restaurant-san-francisco" };

            var response = _client.GetGraphQlAsync(businessIds).Result;

            Assert.AreNotSame(null, response);
            Assert.AreSame(null, response?.FirstOrDefault().Error, $"Response error returned {response?.FirstOrDefault().Error?.Code} - {response?.FirstOrDefault().Error?.Description}");
        }

        [TestMethod]
        public void TestGetGraphQlInChunksAsync()
        {
            List<string> businessIds = new List<string> { "north-india-restaurant-san-francisco" };

            var response = _client.GetGraphQlInChunksAsync(businessIds).Result;

            Assert.AreNotSame(null, response);
            Assert.AreSame(null, response?.FirstOrDefault().Error, $"Response error returned {response?.FirstOrDefault().Error?.Code} - {response?.FirstOrDefault().Error?.Description}");
        }

        [TestMethod]
        public void TestGetGraphQlAsyncInParallel()
        {
            List<string> businessIds = new List<string> { "north-india-restaurant-san-francisco" };

            var response = _client.GetGraphQlAsyncInParallel(businessIds);

            Assert.AreNotSame(null, response);
            Assert.AreSame(null, response?.FirstOrDefault().Result.FirstOrDefault().Error,
                $"Response error returned {response?.FirstOrDefault().Result.FirstOrDefault().Error?.Code} - {response?.FirstOrDefault().Result.FirstOrDefault().Error?.Description}");
        }

        [TestMethod]
        public void TestProcessResultsOfGetGraphQlAsyncInParallel()
        {
            List<string> businessIds = new List<string> {"north-india-restaurant-san-francisco"};
            var response = _client.GetGraphQlAsyncInParallel(businessIds);

            var results = _client.ProcessResultsOfGetGraphQlAsyncInParallel(response);

            Assert.AreNotSame(null, results);
            Assert.AreSame(null, results?.FirstOrDefault().Error, $"Response error returned {results?.FirstOrDefault().Error?.Code} - {results?.FirstOrDefault().Error?.Description}");
        }

        #endregion
    }
}
