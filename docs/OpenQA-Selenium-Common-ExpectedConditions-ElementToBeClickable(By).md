#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Common](./OpenQA-Selenium-Common.md 'OpenQA.Selenium.Common').[ExpectedConditions](./OpenQA-Selenium-Common-ExpectedConditions.md 'OpenQA.Selenium.Common.ExpectedConditions')
## ExpectedConditions.ElementToBeClickable(By) Method
An expectation for checking if an element is visible and enabled such that you can click it.  
```csharp
public static System.Func<IWebDriver,IWebElement> ElementToBeClickable(By by);
```
#### Parameters
<a name='OpenQA-Selenium-Common-ExpectedConditions-ElementToBeClickable(By)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
The locator used to find the element.  
  
#### Returns
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
The [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') once it is located and click-able (visible and enabled).  
