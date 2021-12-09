using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CompraAlterandoEnderecoDeEntrega(){

            IWebDriver driver = new ChromeDriver(@"C:\Users\AP 102\Documents\chromedriver_win32");

            driver.Navigate().GoToUrl("http://automationpractice.com");
            String tituloEsperado = "My Store";
            String tituloRecebido = driver.Title;
            Assert.AreEqual(tituloRecebido, tituloEsperado);

            driver.FindElement(By.XPath("//a[@title='Faded Short Sleeve T-shirts']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.Id("add_to_cart")).Click();

            driver.SwitchTo().ActiveElement();

            driver.FindElement(By.XPath("//a[@title='Proceed to checkout']")).Click();

            driver.FindElement(By.XPath("//div[@id='center_column']/p[2]/a/span")).Click();

            var telaEmail = driver.FindElement(By.Id("login_form"));
            Assert.IsTrue(telaEmail.Displayed);

            IWebElement email = (IWebElement)driver.FindElement(By.Id("email"));
            email.SendKeys("candidato@justa.com.vc");
            Assert.AreEqual(email.GetAttribute("value"), "candidato@justa.com.vc");

            IWebElement senha = (IWebElement)driver.FindElement(By.Id("passwd"));
            senha.SendKeys("tamojusto");
            Assert.AreEqual(senha.GetAttribute("value"), "tamojusto");

            driver.FindElement(By.Id("SubmitLogin")).Click();

            IWebElement alterarEndereco = (IWebElement)driver.FindElement(By.Id("address_delivery"));

            Assert.IsTrue(alterarEndereco.Text.ToLower().Contains("YOUR DELIVERY ADDRESS".ToLower()));

            alterarEndereco.FindElement(By.XPath("//a[@title='Update']")).Click();

            IWebElement endereco1 = (IWebElement)driver.FindElement(By.Id("address1"));

            endereco1.Clear();
            endereco1.SendKeys("Avenida Agamenon Magalhães");
            Assert.AreEqual(endereco1.GetAttribute("value"), "Avenida Agamenon Magalhães");

            IWebElement endereco2 = (IWebElement)driver.FindElement(By.Id("address2"));

            endereco2.Clear();
            endereco2.SendKeys("548");
            Assert.AreEqual(endereco2.GetAttribute("value"), "548");

            IWebElement cidade = (IWebElement)driver.FindElement(By.Id("city"));

            cidade.Clear();
            cidade.SendKeys("Caruaru");
            Assert.AreEqual(cidade.GetAttribute("value"), "Caruaru");

            IWebElement estado = (IWebElement)driver.FindElement(By.Id("id_state"));
            new SelectElement(estado).SelectByText("Arkansas");

            driver.FindElement(By.Id("postcode")).Clear();
            driver.FindElement(By.Id("postcode")).SendKeys("55012");
            driver.FindElement(By.Id("submitAddress")).Click();
            driver.FindElement(By.Name("processAddress")).Click();
            driver.FindElement(By.Id("uniform-cgv")).Click();


            Assert.IsTrue(driver.FindElement(By.Id("cgv")).Selected);

            driver.FindElement(By.Name("processCarrier")).Click();

            driver.FindElement(By.XPath("//a[@title='Pay by bank wire']")).Click();
            WebElement finalizar = (WebElement)driver.FindElement(By.XPath("//*[@id='cart_navigation']/button"));
            finalizar.Click();

            IWebElement pedidoFinalizado = (IWebElement)driver.FindElement(By.XPath("//*[@id='center_column']/div/p/strong"));
            Assert.IsTrue(pedidoFinalizado.Text.ToLower().Contains("Your order on My Store is complete.".ToLower()));

            driver.Quit();

        }

        [TestMethod]

        public void CompraAlterandoEnderecoCobranca(){

            IWebDriver driver = new ChromeDriver(@"C:\Users\AP 102\Documents\chromedriver_win32");

            driver.Navigate().GoToUrl("http://automationpractice.com");
            String tituloEsperado = "My Store";
            String tituloRecebido = driver.Title;
            Assert.AreEqual(tituloRecebido, tituloEsperado);

            driver.FindElement(By.XPath("//a[@title='Faded Short Sleeve T-shirts']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.Id("add_to_cart")).Click();

            driver.SwitchTo().ActiveElement();

            driver.FindElement(By.XPath("//a[@title='Proceed to checkout']")).Click();

            driver.FindElement(By.XPath("//div[@id='center_column']/p[2]/a/span")).Click();

            IWebElement email1 = (IWebElement)driver.FindElement(By.Id("email"));
            email1.SendKeys("candidato@justa.com.vc");
            Assert.AreEqual(email1.GetAttribute("value"), "candidato@justa.com.vc");

            IWebElement senha = (IWebElement)driver.FindElement(By.Id("passwd"));
            senha.SendKeys("tamojusto");
            Assert.AreEqual(senha.GetAttribute("value"), "tamojusto");
            driver.FindElement(By.Id("SubmitLogin")).Click();

            WebElement alterarEndereco = (WebElement)driver.FindElement(By.Id("address_invoice"));

            alterarEndereco.FindElement(By.XPath("//a[@title='Update']")).Click();

            IWebElement endereco1 = (IWebElement)driver.FindElement(By.Id("address1"));

            endereco1.Clear();
            endereco1.SendKeys("Avenida Agamenon Magalhães");
            Assert.AreEqual(endereco1.GetAttribute("value"), "Avenida Agamenon Magalhães");

            IWebElement endereco2 = (IWebElement)driver.FindElement(By.Id("address2"));

            endereco2.Clear();
            endereco2.SendKeys("548");
            Assert.AreEqual(endereco2.GetAttribute("value"), "548");

            IWebElement cidade = (IWebElement)driver.FindElement(By.Id("city"));

            cidade.Clear();
            cidade.SendKeys("Caruaru");
            Assert.AreEqual(cidade.GetAttribute("value"), "Caruaru");

            WebElement estado = (WebElement)driver.FindElement(By.Id("id_state"));
            new SelectElement(estado).SelectByText("Arkansas");

            driver.FindElement(By.Id("postcode")).Clear();
            driver.FindElement(By.Id("postcode")).SendKeys("55012");
            driver.FindElement(By.Id("submitAddress")).Click();
            driver.FindElement(By.Name("processAddress")).Click();
            driver.FindElement(By.Id("uniform-cgv")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("cgv")).Selected);

            driver.FindElement(By.Name("processCarrier")).Click();

            driver.FindElement(By.XPath("//a[@title='Pay by bank wire']")).Click();
            WebElement finalizar = (WebElement)driver.FindElement(By.XPath("//*[@id='cart_navigation']/button"));
            finalizar.Click();

            IWebElement pedidoFinalizado = (IWebElement)driver.FindElement(By.XPath("//*[@id='center_column']/div/p/strong"));
            Assert.IsTrue(pedidoFinalizado.Text.ToLower().Contains("Your order on My Store is complete.".ToLower()));

            driver.Quit();

        }

        [TestMethod]

        public void CompraComCheque() {

            IWebDriver driver = new ChromeDriver(@"C:\Users\AP 102\Documents\chromedriver_win32");

            driver.Navigate().GoToUrl("http://automationpractice.com");
            String tituloEsperado = "My Store";
            String tituloRecebido = driver.Title;
            Assert.AreEqual(tituloRecebido, tituloEsperado);

            driver.FindElement(By.XPath("//a[@title='Faded Short Sleeve T-shirts']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.Id("add_to_cart")).Click();

            driver.SwitchTo().ActiveElement();

            driver.FindElement(By.XPath("//a[@title='Proceed to checkout']")).Click();

            driver.FindElement(By.XPath("//div[@id='center_column']/p[2]/a/span")).Click();


            IWebElement email = (IWebElement)driver.FindElement(By.Id("email"));
            email.SendKeys("candidato@justa.com.vc");
            Assert.AreEqual(email.GetAttribute("value"), "candidato@justa.com.vc");

            IWebElement senha = (IWebElement)driver.FindElement(By.Id("passwd"));
            senha.SendKeys("tamojusto");
            Assert.AreEqual(senha.GetAttribute("value"), "tamojusto");

            driver.FindElement(By.Id("SubmitLogin")).Click();

            driver.FindElement(By.Name("processAddress")).Click();
            driver.FindElement(By.Id("uniform-cgv")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("cgv")).Selected);

            driver.FindElement(By.Name("processCarrier")).Click();

            driver.FindElement(By.XPath("//a[@title='Pay by check.']")).Click();
            WebElement finalizar = (WebElement)driver.FindElement(By.XPath("//*[@id='cart_navigation']/button"));
            finalizar.Click();

            IWebElement pedidoFinalizado = (IWebElement)driver.FindElement(By.XPath("//*[@id='center_column']/p[1]"));
            Assert.IsTrue(pedidoFinalizado.Text.ToLower().Contains("Your order on My Store is complete.".ToLower()));

            driver.Quit();

        }

    }


}

