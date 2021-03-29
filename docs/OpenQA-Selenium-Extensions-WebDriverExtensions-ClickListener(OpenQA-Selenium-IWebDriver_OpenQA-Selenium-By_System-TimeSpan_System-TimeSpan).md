#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.ClickListener(OpenQA.Selenium.IWebDriver, OpenQA.Selenium.By, System.TimeSpan, System.TimeSpan) Method
An [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') extension method that listens to elements using the provided [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
mechanism. When found, the listener will [OpenQA.Selenium.IWebElement.Click](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement.Click 'OpenQA.Selenium.IWebElement.Click') on all elements.  
```csharp
public static void ClickListener(this OpenQA.Selenium.IWebDriver driver, OpenQA.Selenium.By by, System.TimeSpan interval, System.TimeSpan timeout);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-ClickListener(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By_System-TimeSpan_System-TimeSpan)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-ClickListener(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By_System-TimeSpan_System-TimeSpan)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
The mechanism by which to find elements within a document.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-ClickListener(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By_System-TimeSpan_System-TimeSpan)-interval'></a>
`interval` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')  
The interval between search ticks. Using a low interval time can reduce performance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-ClickListener(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By_System-TimeSpan_System-TimeSpan)-timeout'></a>
`timeout` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')  
Timeout of this listener expiration.  
  
### Remarks
The listener will stop when the driver is disposed or when timeout reached.  
