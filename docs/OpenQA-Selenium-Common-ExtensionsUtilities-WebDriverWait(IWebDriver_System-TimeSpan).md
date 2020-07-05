#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Common](./OpenQA-Selenium-Common.md 'OpenQA.Selenium.Common').[ExtensionsUtilities](./OpenQA-Selenium-Common-ExtensionsUtilities.md 'OpenQA.Selenium.Common.ExtensionsUtilities')
## ExtensionsUtilities.WebDriverWait(IWebDriver, System.TimeSpan) Method
Gets an instance of [OpenQA.Selenium.Support.UI.IWait&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Support.UI.IWait-1 'OpenQA.Selenium.Support.UI.IWait`1') with default ignore list  
of [OpenQA.Selenium.StaleElementReferenceException](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.StaleElementReferenceException 'OpenQA.Selenium.StaleElementReferenceException') and [OpenQA.Selenium.NoSuchElementException](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.NoSuchElementException 'OpenQA.Selenium.NoSuchElementException')  
```csharp
public static IWait<IWebDriver> WebDriverWait(IWebDriver driver, System.TimeSpan timeout);
```
#### Parameters
<a name='OpenQA-Selenium-Common-ExtensionsUtilities-WebDriverWait(IWebDriver_System-TimeSpan)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
The WebDriver instance used to wait.  
  
<a name='OpenQA-Selenium-Common-ExtensionsUtilities-WebDriverWait(IWebDriver_System-TimeSpan)-timeout'></a>
`timeout` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')  
The timeout value indicating how long to wait for the condition.  
  
#### Returns
[OpenQA.Selenium.Support.UI.IWait](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Support.UI.IWait 'OpenQA.Selenium.Support.UI.IWait')  
[OpenQA.Selenium.Support.UI.IWait&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Support.UI.IWait-1 'OpenQA.Selenium.Support.UI.IWait`1') implementation which provides the ability to wait for an arbitrary condition during test execution.  
