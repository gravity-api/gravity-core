#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.GetEnabledElements(IWebDriver, By, System.TimeSpan) Method
Finds all enabled [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') within the current context using the given mechanism.  
```csharp
public static System.Collections.Generic.IEnumerable<IWebElement> GetEnabledElements(this IWebDriver driver, By by, System.TimeSpan timeout);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-GetEnabledElements(IWebDriver_By_System-TimeSpan)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-GetEnabledElements(IWebDriver_By_System-TimeSpan)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
The locating mechanism to use.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-GetEnabledElements(IWebDriver_By_System-TimeSpan)-timeout'></a>
`timeout` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')  
The timeout value indicating how long to wait for the condition.  
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The first visible matching [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') on the current context.  
#### Exceptions
[OpenQA.Selenium.WebDriverTimeoutException](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.WebDriverTimeoutException 'OpenQA.Selenium.WebDriverTimeoutException')  
Thrown when element was not found or not clickable.  
### Remarks
If not provided, the default timeout is 10 seconds.  
