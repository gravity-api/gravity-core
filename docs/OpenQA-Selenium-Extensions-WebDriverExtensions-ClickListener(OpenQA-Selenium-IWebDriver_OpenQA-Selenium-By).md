#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.ClickListener(OpenQA.Selenium.IWebDriver, OpenQA.Selenium.By) Method
An [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') extension method that listens to elements using the provided [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
mechanism. When found, the listener will [OpenQA.Selenium.IWebElement.Click](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement.Click 'OpenQA.Selenium.IWebElement.Click') on all elements.  
```csharp
public static void ClickListener(this OpenQA.Selenium.IWebDriver d, OpenQA.Selenium.By by);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-ClickListener(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By)-d'></a>
`d` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-ClickListener(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
The mechanism by which to find elements within a document.  
  
### Remarks
The listener will stop when the driver is disposed or after 10min.  
