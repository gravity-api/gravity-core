/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using OpenQA.Selenium.Mock;
using System;
using System.Linq;

#pragma warning disable S4144
namespace Gravity.Core.UnitTests
{
    [TestClass]
    public class WebDriverExtensionsTests
    {
        // members
        private static readonly TimeSpan timeout = TimeSpan.FromMilliseconds(10);

        #region *** Element: Selected  ***
        [DataTestMethod]
        [DataRow("positive")]
        public void GetSelectedElementPositive(string by)
        {
            // execute
            var onElement = new MockWebDriver().GetSelectedElement(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(onElement != default);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("none")]
        [DataRow("null")]
        [DataRow("stale")]
        [DataRow("{exception")]
        [DataRow("negative")]
        public void GetSelectedElementTimeout(string by)
        {
            // execute
            new MockWebDriver().GetSelectedElement(By.Name(by), timeout);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("positive")]
        public void GetSelectedElementsPositive(string by)
        {
            // execute
            var onElements = new MockWebDriver().GetSelectedElements(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(onElements.Count() == 2);
        }

        [DataTestMethod]
        [DataRow("none")]
        [DataRow("null")]
        [DataRow("stale")]
        [DataRow("{exception")]
        [DataRow("negative")]
        public void GetSelectedElementsTimeout(string by)
        {
            // execute
            var onElements = new MockWebDriver().GetSelectedElements(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(!onElements.Any());
        }
        #endregion        

        #region *** Element: Enabled   ***
        [DataTestMethod]
        [DataRow("positive")]
        public void GetEnabledElementPositive(string by)
        {
            // execute
            var onElement = new MockWebDriver().GetEnabledElement(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(onElement != default);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("none")]
        [DataRow("null")]
        [DataRow("stale")]
        [DataRow("{exception")]
        [DataRow("negative")]
        public void GetEnabledElementTimeout(string by)
        {
            // execute
            new MockWebDriver().GetEnabledElement(By.Name(by), timeout);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("positive")]
        public void GetEnabledElementsPositive(string by)
        {
            // execute
            var onElements = new MockWebDriver().GetEnabledElements(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(onElements.Count() == 2);
        }

        [DataTestMethod]
        [DataRow("none")]
        [DataRow("null")]
        [DataRow("stale")]
        [DataRow("{exception")]
        [DataRow("negative")]
        public void GetEnabledElementsTimeout(string by)
        {
            // execute
            var onElements = new MockWebDriver().GetEnabledElements(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(!onElements.Any());
        }
        #endregion

        #region *** Element: Exists    ***
        [DataTestMethod]
        [DataRow("positive")]
        [DataRow("negative")]
        public void GetElementPositive(string by)
        {
            // execute
            var onElement = new MockWebDriver().GetElement(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(onElement != default);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("none")]
        [DataRow("null")]
        [DataRow("stale")]
        [DataRow("{exception")]
        public void GetElementTimeout(string by)
        {
            // execute
            new MockWebDriver().GetElement(By.Name(by), timeout);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("positive")]
        [DataRow("negative")]
        public void GetElementsPositive(string by)
        {
            // execute
            var onElements = new MockWebDriver().GetElements(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(onElements.Any());
        }

        [DataTestMethod]
        [DataRow("none")]
        [DataRow("null")]
        [DataRow("stale")]
        [DataRow("{exception")]
        public void GetElementsTimeout(string by)
        {
            // execute
            var onElements = new MockWebDriver().GetElements(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(!onElements.Any());
        }
        #endregion

        #region *** Element: Displayed ***
        [DataTestMethod]
        [DataRow("positive")]
        public void GetDisplayedElementPositive(string by)
        {
            // execute
            var onElement = new MockWebDriver().GetDisplayedElement(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(onElement != default);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("none")]
        [DataRow("null")]
        [DataRow("stale")]
        [DataRow("{exception")]
        [DataRow("negative")]
        public void GetDisplayedElementTimeout(string by)
        {
            // execute
            new MockWebDriver().GetDisplayedElement(By.Name(by), timeout);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("positive")]
        public void GetDisplayedElementsPositive(string by)
        {
            // execute
            var onElements = new MockWebDriver().GetDisplayedElements(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(onElements.Count() == 2);
        }

        [DataTestMethod]
        [DataRow("none")]
        [DataRow("null")]
        [DataRow("stale")]
        [DataRow("{exception")]
        [DataRow("negative")]
        public void GetDisplayedElementsTimeout(string by)
        {
            // execute
            var onElements = new MockWebDriver().GetDisplayedElements(By.Name(by), timeout);

            // assertion
            Assert.IsTrue(!onElements.Any());
        }
        #endregion        
    }
}
#pragma warning restore
