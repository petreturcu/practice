namespace Samples.Tests
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using NUnit.Framework;

    using Assert = NUnit.Framework.Assert;

    [TestFixture]
    public class HttpClientUsageTests
    {
        [Test]
        [Ignore("This test is for demonstration purposes only, and is not a unit test.")]
        public async Task GetStringAsync_WhenPutInAUsing_IsConsiderablySlowerThanReusing()
        {
            // Arrange
            double timeWithUsing, timeWithReusable;
            Uri endpoint = new Uri("https://google.co.uk");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Act
            for (int i = 0; i < 100; i++)
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(endpoint);
                }
            }

            timeWithUsing = sw.Elapsed.TotalSeconds;

            sw.Restart();
            // Arrange
            using (HttpClient client = new HttpClient())
            {
                // Act
                for (int i = 0; i < 100; i++)
                {
                    var response = await client.GetStringAsync(endpoint);
                }
            }
            timeWithReusable = sw.Elapsed.TotalSeconds;

            // Assert
            Assert.That(timeWithUsing, Is.GreaterThan(timeWithReusable * 1.5));
        }

    }
}