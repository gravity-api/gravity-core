#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.ClickListener(IWebDriver, By, System.TimeSpan) Method
An [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') extension method that listens to elements using the provided [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
mechanism. When found, the listener will [OpenQA.Selenium.IWebElement.Click](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement.Click 'OpenQA.Selenium.IWebElement.Click') on all elements.  
```csharp
public static void ClickListener(this IWebDriver driver, By by, System.TimeSpan interval);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-ClickListener(IWebDriver_By_System-TimeSpan)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-ClickListener(IWebDriver_By_System-TimeSpan)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
The mechanism by which to find elements within a document.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-ClickListener(IWebDriver_By_System-TimeSpan)-interval'></a>
`interval` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')  
The interval between search ticks. Using a low interval time can reduce performance.  
  
### Remarks
The listener will stop when the driver is disposed or after 10min.  
