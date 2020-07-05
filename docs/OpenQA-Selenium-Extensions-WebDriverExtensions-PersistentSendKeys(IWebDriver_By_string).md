#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.PersistentSendKeys(IWebDriver, By, string) Method
Persistently attempts to find and send keys to the given element, until successful  
or until no exceptions has been thrown.  
```csharp
public static IWebDriver PersistentSendKeys(this IWebDriver driver, By by, string text);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-PersistentSendKeys(IWebDriver_By_string)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-PersistentSendKeys(IWebDriver_By_string)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
The locating mechanism to use.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-PersistentSendKeys(IWebDriver_By_string)-text'></a>
`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The keys to send.  
  
#### Returns
[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
A self-reference to this [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver').  
### Remarks
If not provided, the default timeout is 10 seconds.  
