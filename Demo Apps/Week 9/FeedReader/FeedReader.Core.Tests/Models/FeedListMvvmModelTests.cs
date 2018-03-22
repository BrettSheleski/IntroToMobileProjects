using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedReader.Core.Tests.Models
{
    [TestClass]
    public class FeedListMvvmModelTests
    {
        [TestMethod]
        public async Task FeedListMvvmModel_InitializeAsync()
        {
            // Setup
            var model = new FeedReader.Core.Models.FeedListMvvmModel();

            // Act
            await model.InitializeAsync();

            // Verify
            Assert.IsTrue(model.Articles.Count > 0);
        }

    }
}
