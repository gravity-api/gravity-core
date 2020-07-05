#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Common](./OpenQA-Selenium-Common.md 'OpenQA.Selenium.Common')
## ExpectedConditions Class
Supplies a set of common conditions that can be waited when using [OpenQA.Selenium.Support.UI.WebDriverWait](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Support.UI.WebDriverWait 'OpenQA.Selenium.Support.UI.WebDriverWait').  
```csharp
public static class ExpectedConditions
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExpectedConditions  
### Example
```

                    IWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                    IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.Id("element_id")));
                
```  
### Methods
- [AlertIsPresent()](./OpenQA-Selenium-Common-ExpectedConditions-AlertIsPresent().md 'OpenQA.Selenium.Common.ExpectedConditions.AlertIsPresent()')
- [AttributeMatches(By, string, string)](./OpenQA-Selenium-Common-ExpectedConditions-AttributeMatches(By_string_string).md 'OpenQA.Selenium.Common.ExpectedConditions.AttributeMatches(By, string, string)')
- [ElementExists(By)](./OpenQA-Selenium-Common-ExpectedConditions-ElementExists(By).md 'OpenQA.Selenium.Common.ExpectedConditions.ElementExists(By)')
- [ElementIsSelected(By)](./OpenQA-Selenium-Common-ExpectedConditions-ElementIsSelected(By).md 'OpenQA.Selenium.Common.ExpectedConditions.ElementIsSelected(By)')
- [ElementIsVisible(By)](./OpenQA-Selenium-Common-ExpectedConditions-ElementIsVisible(By).md 'OpenQA.Selenium.Common.ExpectedConditions.ElementIsVisible(By)')
- [ElementToBeClickable(By)](./OpenQA-Selenium-Common-ExpectedConditions-ElementToBeClickable(By).md 'OpenQA.Selenium.Common.ExpectedConditions.ElementToBeClickable(By)')
- [EnabilityOfAllElementsLocatedBy(By)](./OpenQA-Selenium-Common-ExpectedConditions-EnabilityOfAllElementsLocatedBy(By).md 'OpenQA.Selenium.Common.ExpectedConditions.EnabilityOfAllElementsLocatedBy(By)')
- [FrameToBeAvailableAndSwitchToIt(By)](./OpenQA-Selenium-Common-ExpectedConditions-FrameToBeAvailableAndSwitchToIt(By).md 'OpenQA.Selenium.Common.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By)')
- [InvisibilityOfAllElementsLocatedBy(By)](./OpenQA-Selenium-Common-ExpectedConditions-InvisibilityOfAllElementsLocatedBy(By).md 'OpenQA.Selenium.Common.ExpectedConditions.InvisibilityOfAllElementsLocatedBy(By)')
- [InvisibilityOfElementLocated(By)](./OpenQA-Selenium-Common-ExpectedConditions-InvisibilityOfElementLocated(By).md 'OpenQA.Selenium.Common.ExpectedConditions.InvisibilityOfElementLocated(By)')
- [PageHasBeenLoaded()](./OpenQA-Selenium-Common-ExpectedConditions-PageHasBeenLoaded().md 'OpenQA.Selenium.Common.ExpectedConditions.PageHasBeenLoaded()')
- [PresenceOfAllElementsLocatedBy(By)](./OpenQA-Selenium-Common-ExpectedConditions-PresenceOfAllElementsLocatedBy(By).md 'OpenQA.Selenium.Common.ExpectedConditions.PresenceOfAllElementsLocatedBy(By)')
- [SelectedOfAllElementsLocatedBy(By)](./OpenQA-Selenium-Common-ExpectedConditions-SelectedOfAllElementsLocatedBy(By).md 'OpenQA.Selenium.Common.ExpectedConditions.SelectedOfAllElementsLocatedBy(By)')
- [TextMatches(By, string)](./OpenQA-Selenium-Common-ExpectedConditions-TextMatches(By_string).md 'OpenQA.Selenium.Common.ExpectedConditions.TextMatches(By, string)')
- [UrlMatches(string)](./OpenQA-Selenium-Common-ExpectedConditions-UrlMatches(string).md 'OpenQA.Selenium.Common.ExpectedConditions.UrlMatches(string)')
- [VisibilityOfAllElementsLocatedBy(By)](./OpenQA-Selenium-Common-ExpectedConditions-VisibilityOfAllElementsLocatedBy(By).md 'OpenQA.Selenium.Common.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By)')
