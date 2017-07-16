using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yelp.Api.Web.Test
{
    [TestClass]
    public class TestsOf_ClientBase
    {
        #region Variables

        private const string _YelpAppId = "6WfLJ5rmFrGOsNS7cKo5Mg";
        private const string _YelpAppSecret = "a2npPM9U0YbBDbSwUxYXVTpUFj2JLWA1N4HykT6FfHHDgPmshRaGYHAKValxWf5X";

        private readonly Client _client;

        #endregion

        #region Constructors

        public TestsOf_ClientBase()
        {
            _client = new Client(_YelpAppId, _YelpAppSecret);
        }

        #endregion

        [TestMethod]
        public void GetAsync()
        {
            // TODO: Write a test that makes sure null coordinates don't crash
            // TODO: Write a test that makes sure null cordinates are set to NaN
        }

        [TestMethod]
        public void PostAsync()
        {
            // TODO: Write a test that makes sure null coordinates don't crash
            // TODO: Write a test that makes sure null cordinates are set to NaN
        }
    }
}
