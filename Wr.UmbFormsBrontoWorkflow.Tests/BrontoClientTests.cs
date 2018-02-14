using System.Collections.Generic;
using NUnit.Framework;
//using Wr.UmbFormsBrontoWorkflow.BrontoApi;
using Bronto.API;

namespace Wr.UmbFormsBrontoWorkflow.Tests
{
    [TestFixture]
    public class BrontoClientTests : BrontoTestBase
    {

        [Test]
        public void BrontoClient_LoadApiTokenTest_IsNotNullOrEmpty_ReturnsTrue()
        {
            // Arrange

            // Act
            var foundApiToken = ApiToken;

            // Assert
            Assert.IsNotNull(foundApiToken);
            Assert.IsTrue(!string.IsNullOrEmpty(foundApiToken));
        }

        [Test]
        public void BrontoClient_LoginTest_ValidApiToken_ReturnsSessionId()
        {
            // Arrange

            // Act
            var bronto = new LoginSession().; //BrontoSoapClient(ApiToken);

            // Assert
            Assert.IsNotNull(bronto);
            Assert.IsTrue(!string.IsNullOrEmpty(bronto._sessionId));
        }

        [Test]
        public void BrontoClient_GetListsTest_ReturnsLists()
        {
            // Arrange
            var bronto = new BrontoSoapClient(ApiToken);

            // Act
            var result = bronto.GetListsRaw();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void BrontoClient_GetListsTest_ResultIncKnownLists_ReturnsTrue()
        {
            // Arrange
            List<string> knownList =
                new List<string>()
                {
                    "New Sign-Ups",
                    "Other_Lists"
                };

            var bronto = new BrontoSoapClient(ApiToken);

            // Act
            var result = bronto.GetListsRaw();

            foreach (var item in result)
            {
                if (knownList.Contains(item.name))
                {
                    knownList.Remove(item.name);
                }
            }

            // Assert
            Assert.IsTrue(knownList.Count == 0);
        }

        [Test]
        public void BrontoClient_GetFieldsTest_ReturnsFields()
        {
            // Arrange
            var bronto = new BrontoSoapClient(ApiToken);

            // Act
            var result = bronto.GetFieldsRaw();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void BrontoClient_GetFieldsTest_ResultIncKnownCustomFields_ReturnsTrue()
        {
            // Arrange
            List<string> knownFields =
                new List<string>()
                {
                    "NL_Flag",
                    "Address1",
                    "Postcode",
                };

            var bronto = new BrontoSoapClient(ApiToken);

            // Act
            var result = bronto.GetFieldsRaw();

            foreach (var item in result)
            {
                if (knownFields.Contains(item.name))
                {
                    knownFields.Remove(item.name);
                }
            }

            // Assert
            Assert.IsTrue(knownFields.Count == 0);
        }

        /*[Test]
        public void Fail_Build_In_Development()
        {
            // Assert
            Assert.Fail();
        }*/
    }
}
