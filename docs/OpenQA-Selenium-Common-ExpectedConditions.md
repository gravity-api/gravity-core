#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Common](./OpenQA-Selenium-Common.md 'OpenQA.Selenium.Common')
## ExpectedConditions Class
Supplies a set of common conditions that can be waited when using [OpenQA.Selenium.Support.UI.WebDriverWait](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Support.UI.WebDriverWait 'OpenQA.Selenium.Support.UI.WebDriverWait').  
```csharp
public static class ExpectedConditions
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExpectedConditions  
### Example
```csharp

                    IWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                    IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.Id("element_id")));
                
```  
### Methods
- [AlertIsPresent()](./OpenQA-Selenium-Common-ExpectedConditions-AlertIsPresent().md 'OpenQA.Selenium.Common.ExpectedConditions.AlertIsPresent()')
- [AttributeMatches(OpenQA.Selenium.By, string, string)](./OpenQA-Selenium-Common-ExpectedConditions-AttributeMatches(OpenQA-Selenium-By_string_string).md 'OpenQA.Selenium.Common.ExpectedConditions.AttributeMatches(OpenQA.Selenium.By, string, string)')
- [ElementExists(OpenQA.Selenium.By)](./OpenQA-Selenium-Common-ExpectedConditions-ElementExists(OpenQA-Selenium-By).md 'OpenQA.Selenium.Common.ExpectedConditions.ElementExists(OpenQA.Selenium.By)')
- [ElementIsSelected(OpenQA.Selenium.By)](./OpenQA-Selenium-Common-ExpectedConditions-ElementIsSelected(OpenQA-Selenium-By).md 'OpenQA.Selenium.Common.ExpectedConditions.ElementIsSelected(OpenQA.Selenium.By)')
- [ElementIsVisible(OpenQA.Selenium.By)](./OpenQA-Selenium-Common-ExpectedConditions-ElementIsVisible(OpenQA-Selenium-By).md 'OpenQA.Selenium.Common.ExpectedConditions.ElementIsVisible(OpenQA.Selenium.By)')
- [ElementToBeClickable(OpenQA.Selenium.By)](./OpenQA-Selenium-Common-ExpectedConditions-ElementToBeClickable(OpenQA-Selenium-By).md 'OpenQA.Selenium.Common.ExpectedConditions.ElementToBeClickable(OpenQA.Selenium.By)')
- [EnabilityOfAllElementsLocatedBy(OpenQA.Selenium.By)](./OpenQA-Selenium-Common-ExpectedConditions-EnabilityOfAllElementsLocatedBy(OpenQA-Selenium-By).md 'OpenQA.Selenium.Common.ExpectedConditions.EnabilityOfAllElementsLocatedBy(OpenQA.Selenium.By)')
- [FrameToBeAvailableAndSwitchToIt(OpenQA.Selenium.By)](./OpenQA-Selenium-Common-ExpectedConditions-FrameToBeAvailableAndSwitchToIt(OpenQA-Selenium-By).md 'OpenQA.Selenium.Common.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(OpenQA.Selenium.By)')
- [InvisibilityOfAllElementsLocatedBy(OpenQA.Selenium.By)](./OpenQA-Selenium-Common-ExpectedConditions-InvisibilityOfAllElementsLocatedBy(OpenQA-Selenium-By).md 'OpenQA.Selenium.Common.ExpectedConditions.InvisibilityOfAllElementsLocatedBy(OpenQA.Selenium.By)')
- [InvisibilityOfElementLocated(OpenQA.Selenium.By)](./OpenQA-Selenium-Common-ExpectedConditions-InvisibilityOfElementLocated(OpenQA-Selenium-By).md 'OpenQA.Selenium.Common.ExpectedConditions.InvisibilityOfElementLocated(OpenQA.Selenium.By)')
- [PageHasBeenLoaded()](./OpenQA-Selenium-Common-ExpectedConditions-PageHasBeenLoaded().md 'OpenQA.Selenium.Common.ExpectedConditions.PageHasBeenLoaded()')
- [PresenceOfAllElementsLocatedBy(OpenQA.Selenium.By)](./OpenQA-Selenium-Common-ExpectedConditions-PresenceOfAllElementsLocatedBy(OpenQA-Selenium-By).md 'OpenQA.Selenium.Common.ExpectedConditions.PresenceOfAllElementsLocatedBy(OpenQA.Selenium.By)')
- [SelectedOfAllElementsLocatedBy(OpenQA.Selenium.By)](./OpenQA-Selenium-Common-ExpectedConditions-SelectedOfAllElementsLocatedBy(OpenQA-Selenium-By).md 'OpenQA.Selenium.Common.ExpectedConditions.SelectedOfAllElementsLocatedBy(OpenQA.Selenium.By)')
- [TextMatches(OpenQA.Selenium.By, string)](./OpenQA-Selenium-Common-ExpectedConditions-TextMatches(OpenQA-Selenium-By_string).md 'OpenQA.Selenium.Common.ExpectedConditions.TextMatches(OpenQA.Selenium.By, string)')
- [UrlMatches(string)](./OpenQA-Selenium-Common-ExpectedConditions-UrlMatches(string).md 'OpenQA.Selenium.Common.ExpectedConditions.UrlMatches(string)')
- [VisibilityOfAllElementsLocatedBy(OpenQA.Selenium.By)](./OpenQA-Selenium-Common-ExpectedConditions-VisibilityOfAllElementsLocatedBy(OpenQA-Selenium-By).md 'OpenQA.Selenium.Common.ExpectedConditions.VisibilityOfAllElementsLocatedBy(OpenQA.Selenium.By)')
