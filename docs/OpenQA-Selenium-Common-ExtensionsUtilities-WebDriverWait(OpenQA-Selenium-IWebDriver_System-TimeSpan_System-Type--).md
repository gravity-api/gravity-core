#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Common](./OpenQA-Selenium-Common.md 'OpenQA.Selenium.Common').[ExtensionsUtilities](./OpenQA-Selenium-Common-ExtensionsUtilities.md 'OpenQA.Selenium.Common.ExtensionsUtilities')
## ExtensionsUtilities.WebDriverWait(OpenQA.Selenium.IWebDriver, System.TimeSpan, System.Type[]) Method
Gets an instance of [OpenQA.Selenium.Support.UI.IWait&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Support.UI.IWait-1 'OpenQA.Selenium.Support.UI.IWait`1') with default ignore list  
of [OpenQA.Selenium.StaleElementReferenceException](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.StaleElementReferenceException 'OpenQA.Selenium.StaleElementReferenceException') and [OpenQA.Selenium.NoSuchElementException](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.NoSuchElementException 'OpenQA.Selenium.NoSuchElementException')  
```csharp
public static OpenQA.Selenium.Support.UI.IWait<OpenQA.Selenium.IWebDriver> WebDriverWait(OpenQA.Selenium.IWebDriver driver, System.TimeSpan timeout, params System.Type[] exceptionTypes);
```
#### Parameters
<a name='OpenQA-Selenium-Common-ExtensionsUtilities-WebDriverWait(OpenQA-Selenium-IWebDriver_System-TimeSpan_System-Type--)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
The WebDriver instance used to wait.  
  
<a name='OpenQA-Selenium-Common-ExtensionsUtilities-WebDriverWait(OpenQA-Selenium-IWebDriver_System-TimeSpan_System-Type--)-timeout'></a>
`timeout` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')  
The timeout value indicating how long to wait for the condition.  
  
<a name='OpenQA-Selenium-Common-ExtensionsUtilities-WebDriverWait(OpenQA-Selenium-IWebDriver_System-TimeSpan_System-Type--)-exceptionTypes'></a>
`exceptionTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The types of exceptions to ignore.  
  
#### Returns
[OpenQA.Selenium.Support.UI.IWait&lt;](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Support.UI.IWait-1 'OpenQA.Selenium.Support.UI.IWait`1')[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Support.UI.IWait-1 'OpenQA.Selenium.Support.UI.IWait`1')  
[OpenQA.Selenium.Support.UI.IWait&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Support.UI.IWait-1 'OpenQA.Selenium.Support.UI.IWait`1') implementation which provides the ability to wait for an arbitrary condition during test execution.  
