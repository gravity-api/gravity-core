#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Common](./OpenQA-Selenium-Common.md 'OpenQA.Selenium.Common').[ExpectedConditions](./OpenQA-Selenium-Common-ExpectedConditions.md 'OpenQA.Selenium.Common.ExpectedConditions')
## ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By) Method
An expectation for checking whether the given frame is available to switch to.  
If the frame is available it switches the given driver to the specified frame.  
```csharp
public static System.Func<IWebDriver,IWebDriver> FrameToBeAvailableAndSwitchToIt(By by);
```
#### Parameters
<a name='OpenQA-Selenium-Common-ExpectedConditions-FrameToBeAvailableAndSwitchToIt(By)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
Locator for the Frame  
  
#### Returns
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
An [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') to manipulate the browser  
