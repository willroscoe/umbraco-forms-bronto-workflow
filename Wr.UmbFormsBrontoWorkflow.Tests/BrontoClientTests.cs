using System;
using System.Collections.Generic;
using NUnit.Framework;
using Wr.UmbFormsBrontoWorkflow.BrontoApi;

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
            var bronto = new BrontoSoapClient(ApiToken);

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
            var result = bronto.GetLists();

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
            var result = bronto.GetLists();

            foreach (var item in result)
            {
                Console.WriteLine("List found: " + item.name);
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
            var result = bronto.GetFields();

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
            var result = bronto.GetFields();

            foreach (var item in result)
            {
                Console.WriteLine("Field found: " + item.name);
                if (knownFields.Contains(item.name))
                {
                    knownFields.Remove(item.name);
                }
            }

            // Assert
            Assert.IsTrue(knownFields.Count == 0);
        }

        [Test]
        public void BrontoClient_AddContactTest_NoContact_ReturnsFailed()
        {
            Assert.Fail();
        }
    }
}
