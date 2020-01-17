/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenQA.Selenium.Extensions
{
    /// <summary>
    /// A collection of <see cref="IWebElement" /> extensions.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Provides a mechanism for building advanced interactions with the browser.
        /// </summary>
        /// <param name="element">This <see cref="IWebElement" /> instance.</param>
        /// <returns>A self-reference to this <see cref="Interactions.Actions" />.</returns>
        public static Actions Actions(this IWebElement element)
        {
            return GetActionsFromElement(element).MoveToElement(element);
        }

        /// <summary>
        /// Clicks and holds the mouse button down on the specified element.
        /// </summary>
        /// <param name="element">The element on which to click and hold.</param>
        /// <returns>A self-reference to this <see cref="Interactions.Actions" />.</returns>
        public static Actions ClickAndHold(this IWebElement element)
        {
            // create new actions instance
            var actions = GetActionsFromElement(element);

            // execute action
            actions.ClickAndHold(element).Build().Perform();

            // keep the fluent
            return actions;
        }

        /// <summary>
        /// Provides a convenience method for manipulating selections of options in an HTML
        /// select element.
        /// </summary>
        /// <param name="element">The web element from which to create <see cref="SelectElement" />.</param>
        /// <returns>New instance of <see cref="SelectElement" />.</returns>
        /// <exception cref="UnexpectedTagNameException">Thrown when the element wrapped is not a <select> element.</exception>
        public static SelectElement AsComboBox(this IWebElement element)
        {
            return new SelectElement(element);
        }

        /// <summary>
        /// Right-click the mouse at the last known mouse coordinates.
        /// </summary>
        /// <param name="element">The element on which to click.</param>
        /// <returns>A self-reference to this <see cref="Interactions.Actions" />.</returns>
        public static Actions ContextClick(this IWebElement element)
        {
            // create new actions instance
            var actions = GetActionsFromElement(element);

            // execute action
            actions.MoveToElement(element).ContextClick().Build().Perform();

            // keep the fluent
            return actions;
        }

        /// <summary>
        /// Double-clicks the mouse on the specified element.
        /// </summary>
        /// <param name="element">The element on which to double-click.</param>
        /// <returns>A self-reference to this <see cref="Actions" />.</returns>
        public static Actions DoubleClick(this IWebElement element)
        {
            // create new actions instance
            var actions = GetActionsFromElement(element);

            // execute action
            actions.MoveToElement(element).DoubleClick().Build().Perform();

            // keep the fluent
            return actions;
        }

        #region *** Download Resource ***
        /// <summary>
        /// Download a resource based on the given <see cref="IWebElement" />.
        /// </summary>
        /// <param name="element">The element to use when downloading a resource.</param>
        /// <param name="path">The path on which the resource will be saved.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        public static IWebElement DownloadResource(this IWebElement element, string path)
        {
            return DoDownloadResource(element, path, "");
        }

        /// <summary>
        /// Download a resource based on the given <see cref="IWebElement" />.
        /// </summary>
        /// <param name="element">The element to use when downloading a resource.</param>
        /// <param name="path">The path on which the resource will be saved.</param>
        /// <param name="attribute">The element attribute from which to extract resource URL (if needed).</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        public static IWebElement DownloadResource(this IWebElement element, string path, string attribute)
        {
            return DoDownloadResource(element, path, attribute);
        }

        // execute action routine
        private static IWebElement DoDownloadResource(this IWebElement element, string path, string attribute)
        {
            // get resource address
            var resource = (string.IsNullOrEmpty(attribute))
                ? element.Text
                : element.GetAttribute(attribute);

            // download resource
            using (var client = new HttpClient())
            {
                // get response for the current resource
                var httpResponseMessage = client.GetAsync(resource).GetAwaiter().GetResult();

                // exit condition
                if (!httpResponseMessage.IsSuccessStatusCode) return element;

                // create directories path
                Directory.CreateDirectory(path);

                // get absolute file name
                var fileName = Regex.Match(resource, @"[^/\\&\?]+\.\w{3,4}(?=([\?&].*$|$))").Value;
                path = (path.LastIndexOf(@"\") == path.Length - 1)
                    ? path + fileName
                    : path + $@"\{fileName}";

                // write the file
                File.WriteAllBytes(path, httpResponseMessage.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult());
            }

            // keep the fluent
            return element;
        }
        #endregion

        #region *** Utilities         ***
        // gets and actions instance from IWebElement
        private static Actions GetActionsFromElement(IWebElement element)
        {
            // extract the driver to which the current element belongs to
            var driver = ((IWrapsDriver)element).WrappedDriver;

            // create new actions instance
            return new Actions(driver);
        }
        #endregion
    }
}