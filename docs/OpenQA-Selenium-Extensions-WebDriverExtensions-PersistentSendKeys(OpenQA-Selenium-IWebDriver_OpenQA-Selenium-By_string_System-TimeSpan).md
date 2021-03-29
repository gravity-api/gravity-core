#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.PersistentSendKeys(OpenQA.Selenium.IWebDriver, OpenQA.Selenium.By, string, System.TimeSpan) Method
Persistently attempts to find and send keys to the given element, until successful  
or until no exceptions has been thrown.  
```csharp
public static OpenQA.Selenium.IWebDriver PersistentSendKeys(this OpenQA.Selenium.IWebDriver driver, OpenQA.Selenium.By by, string text, System.TimeSpan timeout);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-PersistentSendKeys(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By_string_System-TimeSpan)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-PersistentSendKeys(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By_string_System-TimeSpan)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
The locating mechanism to use.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-PersistentSendKeys(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By_string_System-TimeSpan)-text'></a>
`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The keys to send.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-PersistentSendKeys(OpenQA-Selenium-IWebDriver_OpenQA-Selenium-By_string_System-TimeSpan)-timeout'></a>
`timeout` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')  
The timeout value indicating how long to wait for the condition.  
  
#### Returns
[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
A self-reference to this [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver').  
### Remarks
If not provided, the default timeout is 10 seconds.  
