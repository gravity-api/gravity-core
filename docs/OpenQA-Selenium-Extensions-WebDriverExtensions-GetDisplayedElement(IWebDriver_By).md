#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.GetDisplayedElement(IWebDriver, By) Method
Finds the first visible [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') using the given method.  
```csharp
public static IWebElement GetDisplayedElement(this IWebDriver driver, By by);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-GetDisplayedElement(IWebDriver_By)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-GetDisplayedElement(IWebDriver_By)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
The locating mechanism to use.  
  
#### Returns
[OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')  
The first visible matching [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') on the current context.  
#### Exceptions
[OpenQA.Selenium.WebDriverTimeoutException](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.WebDriverTimeoutException 'OpenQA.Selenium.WebDriverTimeoutException')  
Thrown when element was not found or not displayed.  
### Remarks
If not provided, the default timeout is 10 seconds.  
