using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TestAutomationForm;

[TestFixture]
public class Tests
{
    private IWebDriver driver;
    private string testFirst = "Jackson";
    private string testLast = "Leone";
    private string testEmail = "jackson.leone.usa@gmail.com";
    private string testPhone = "(404) 988-3168";
    private string testState = "Georgia";
    private string testCity = "Atlanta";


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void TestFormSubmission()
    {
        driver.Url = "https://www.cognitoforms.com/CognitoForms/testautomation?v2";
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        IWebElement firstField = driver.FindElement(By.Id("cog-input-auto-0"));
        firstField.SendKeys(testFirst);
        firstField.SendKeys("\t");

        IWebElement lastField = driver.FindElement(By.Id("cog-input-auto-1"));
        lastField.SendKeys(testLast);
        lastField.SendKeys("\t");

        IWebElement emailField = driver.FindElement(By.Id("cog-1"));
        emailField.SendKeys(testEmail);
        emailField.SendKeys("\t");

        IWebElement phoneField = driver.FindElement(By.Id("cog-2"));
        phoneField.SendKeys(testPhone);
        phoneField.SendKeys("\t");

        IWebElement stateField = driver.FindElement(By.Id("cog-3"));
        stateField.SendKeys(testState);
        stateField.SendKeys("\t");

        IWebElement cityField = driver.FindElement(By.Id("cog-4"));
        cityField.SendKeys(testCity);
        cityField.SendKeys("\t");

        Thread.Sleep(500);
        IWebElement submitButton = driver.FindElement(By.ClassName("cog-button--submit"));
        submitButton.Click();


        Thread.Sleep(3000);
        IWebElement submittedName = driver.FindElement(By.CssSelector(
            "body > div.😉.cog-cognito.cog-form.cog-83.is-success.cog-cognito--styled.cog-form--light-background.cog-form--show-all-pages.cog-form--confirmation-has-entry-details.cog-form--opaque-background > div > div > div > div.cog-page.cog-wrapper.cog-transition-ltr > div:nth-child(1) > fieldset > div.cog-name > div"));
        string nameString = submittedName.Text;
        Assert.AreEqual(nameString, testFirst + " " + testLast);

        IWebElement submittedEmail = driver.FindElement(By.CssSelector(
            "body > div.😉.cog-cognito.cog-form.cog-83.is-success.cog-cognito--styled.cog-form--light-background.cog-form--show-all-pages.cog-form--confirmation-has-entry-details.cog-form--opaque-background > div > div > div > div.cog-page.cog-wrapper.cog-transition-ltr > div:nth-child(2) > div.cog-field.cog-field--3.cog-col.cog-col--12.cog-email > div.cog-input.is-read-only"));
        string emailString = submittedEmail.Text;
        Assert.AreEqual(emailString, testEmail);

        IWebElement submittedPhone = driver.FindElement(By.CssSelector(
            "body > div.😉.cog-cognito.cog-form.cog-83.is-success.cog-cognito--styled.cog-form--light-background.cog-form--show-all-pages.cog-form--confirmation-has-entry-details.cog-form--opaque-background > div > div > div > div.cog-page.cog-wrapper.cog-transition-ltr > div:nth-child(2) > div.cog-field.cog-field--4.cog-col.cog-col--12.cog-phone.cog-phone--us > div.cog-input.is-read-only"));
        string phoneString = submittedPhone.Text;
        Assert.AreEqual(phoneString, testPhone);

        IWebElement submittedState = driver.FindElement(By.CssSelector(
            "body > div.😉.cog-cognito.cog-form.cog-83.is-success.cog-cognito--styled.cog-form--light-background.cog-form--show-all-pages.cog-form--confirmation-has-entry-details.cog-form--opaque-background > div > div > div > div.cog-page.cog-wrapper.cog-transition-ltr > div:nth-child(3) > div.cog-field.cog-field--6.cog-col.cog-col--12.cog-choice.cog-choice--dropdown > div.cog-choice.cog-lookup > div"));
        string stateString = submittedState.Text;
        Assert.AreEqual(stateString, testState);

        IWebElement submittedCity = driver.FindElement(By.CssSelector(
            "body > div.😉.cog-cognito.cog-form.cog-83.is-success.cog-cognito--styled.cog-form--light-background.cog-form--show-all-pages.cog-form--confirmation-has-entry-details.cog-form--opaque-background > div > div > div > div.cog-page.cog-wrapper.cog-transition-ltr > div:nth-child(3) > div.cog-field.cog-field--5.cog-col.cog-col--12.cog-lookup.cog-lookup--dropdown > div.cog-choice.cog-lookup > div > div"));
        string cityString = submittedCity.Text;
        Assert.AreEqual(cityString, testCity);
    }

    [TearDown]
    public void Close()
    {
        driver.Close();
    }
}
