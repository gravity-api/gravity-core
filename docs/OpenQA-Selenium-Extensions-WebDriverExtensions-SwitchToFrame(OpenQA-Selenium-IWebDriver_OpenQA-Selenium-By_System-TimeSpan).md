#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.SwitchToFrame(OpenQA.Selenium.IWebDriver, OpenQA.Selenium.By, System.TimeSpan) Method
If the frame is available it switches the given driver to the specified frame.  
```csharp
public static OpenQA.Selenium.IWebDriver SwitchToFrame(this OpenQA.Selenium.IWebDriver driver, OpenQA.Selenium.By by, System.TimeSpan timeout);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-SwitchToFrame(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By_System-TimeSpan)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-SwitchToFrame(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By_System-TimeSpan)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
A mechanism by which to find elements within a document.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-SwitchToFrame(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By_System-TimeSpan)-timeout'></a>
`timeout` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')  
The timeout value indicating how long to wait for the condition.  
  
#### Returns
[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
A self-reference to this [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver').  
### Remarks
If not provided, the default timeout is 10 seconds.  
