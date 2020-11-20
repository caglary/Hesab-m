using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
namespace Hesabım.Helper
{
    internal class Selenium
    {
        public  static IWebDriver driver;
        public Selenium()
        {
            driver = new ChromeDriver();
        }
        internal  void Halkbank(string kullaniciadi, string parola)
        {
            tryCatchBlock(() =>
            {
                driver.Url = "https://sube.halkbank.com.tr/InternetBankingHost/HostLogin?CustomerType=Retail";
                driver.FindElement(By.Id("PinLoginCustomerID")).SendKeys(kullaniciadi);
                driver.FindElement(By.Name("FirstLoginPassword")).SendKeys(parola);
                driver.FindElement(By.Id("submitbtn")).Click();
                driver.Manage().Window.Maximize();
            });
        }
        internal  void ZiraatBankasi(string kullaniciadi, string parola)
        {
            tryCatchBlock(() =>
            {
                driver.Navigate().GoToUrl("https://bireysel.ziraatbank.com.tr/Transactions/Login/FirstLogin.aspx?customertype=rtl");
                IWebElement UserName = driver.FindElement(By.Name("ctl00$c$RetailIdentityTextBox"));
                UserName.SendKeys(kullaniciadi);
                IWebElement Password = driver.FindElement(By.Name("ctl00$c$RetailPinTextBox"));
                Password.SendKeys(parola);
                IWebElement SubmitButton = driver.FindElement(By.Id("ctl00_c_RetailLoginButton"));
                SubmitButton.Click();
                driver.Manage().Window.Maximize();
            });
        }
        internal  static void QuitChromeDriver()
        {
            if (driver!=null)
            {
                driver.Quit();
            }
        }
        static void tryCatchBlock(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}