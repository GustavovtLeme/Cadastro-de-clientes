using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NUnit.Framework;

namespace Cadastro_de_cliente.Driver
{
    class Drivers
    {

        public static IWebDriver driver = iniciaNavegador();
        public int cont = 0;
        private readonly string path = @"D:\Projeto\Cadastro de clientes - Teste\Cadastro de clientes - Teste\Evidencias\";

        public static IWebDriver iniciaNavegador()
        {
            Thread.Sleep(5000);
            ChromeOptions option = new ChromeOptions();
           // var path = "D:\\Projeto\\Cadastro de cliente\\Cadastro de cliente\\Drivers\\";
            var filePath = Directory.GetParent(Directory.GetCurrentDirectory()) + "\\Drivers";
            option.AddArguments("--start-maximized", "--ignore-certificate-errors", "--disable-popup-blocking", "--incognito");
            driver = new ChromeDriver(filePath, option);
            return driver;
        }


        public void screenshot()
        {
            
            string nome = NUnit.Framework.TestContext.CurrentContext.Test.Name;

            Directory.CreateDirectory(path);
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] ssBytes = ss.AsByteArray;
            ss.SaveAsFile((string.Format("{0}\\{1}{2}", path, (nome +" "+ cont), ".png")), ScreenshotImageFormat.Png);

            Thread.Sleep(2000);

            cont++;
        }
        public void encerraNavegador()
        {
            
            driver.Close();
            driver.Quit();
            Thread.Sleep(5000);
        }

        public void abrirPagina(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

    }
}
