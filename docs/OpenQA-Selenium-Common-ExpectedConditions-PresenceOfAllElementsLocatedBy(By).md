#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Common](./OpenQA-Selenium-Common.md 'OpenQA.Selenium.Common').[ExpectedConditions](./OpenQA-Selenium-Common-ExpectedConditions.md 'OpenQA.Selenium.Common.ExpectedConditions')
## ExpectedConditions.PresenceOfAllElementsLocatedBy(By) Method
An expectation for checking that all elements present on the web page that  
match the locator.  
```csharp
public static System.Func<IWebDriver,System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>> PresenceOfAllElementsLocatedBy(By by);
```
#### Parameters
<a name='OpenQA-Selenium-Common-ExpectedConditions-PresenceOfAllElementsLocatedBy(By)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
The locator used to find the element.  
  
#### Returns
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Collections.ObjectModel.ReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ReadOnlyCollection-1 'System.Collections.ObjectModel.ReadOnlyCollection`1')[OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ReadOnlyCollection-1 'System.Collections.ObjectModel.ReadOnlyCollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
The list of [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') once it is located.  
