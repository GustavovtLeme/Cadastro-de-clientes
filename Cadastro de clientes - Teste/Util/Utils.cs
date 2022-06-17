using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Cadastro_de_cliente.Driver;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_cliente.Util
{
    class Utils : Drivers

    {
        public IWebElement element;

        public WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        
        //preenche um elemento visivel na tela
        public bool Preencher_elemento(string xpath, string valor, int timeout)
        {
            int cont = 0;
            do
            {
                try
                {
                    element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                    if (!element.Displayed)
                    {
                        return false;
                    }
                    else
                    {
                        element.Clear();
                        element.SendKeys(valor);
                        Console.WriteLine("Elemento preenchido com sucesso");
                        return true;
                    }
                }
                catch (Exception e)
                {
                    cont++;
                    Console.WriteLine("Excessão encontrada: " + e);
                    Console.WriteLine("Tentativa " + cont);

                }
                
            }while (cont < timeout);
            return false;
        }
        //Envia o comando Enter para o elemento selecionado
        public void precionarTecla(string xpath)
        {
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            element.SendKeys(Keys.Enter);
        }
        //Clica em um elemento visivel na tela
        public bool clicar_Elemento(string xpath, int timeout)
        {
            int cont = 0;
            do
            {
                try
                {
                    element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                    if (!element.Displayed)
                    {
                        return false;
                    }
                    else
                    {
                        element.Click();
                        Console.WriteLine("Elemento clicado com sucesso");
                        return true;
                    }
                }
                catch (Exception e)
                {
                    cont++;
                    Console.WriteLine("Excessão encontrada: " + e);
                    Console.WriteLine("Tentativa " + cont);

                }
            }while (cont < timeout);
            return false;
        }
        //Armazena texto da tela
        public string ArmazenaTexto(string xpath, int timeout)
        {
            int cont = 0;
            do
            {
                try
                {
                    element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                    if (!element.Displayed)
                    {
                        return null;

                    }
                    else
                    {
                        string texto = element.Text;
                        return texto;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Excessão encotrada:" + e);
                    Console.WriteLine("Tentativa " + cont);
                    cont++;
                }
            } while (cont < timeout);
            return null;
        }

        public string itemvalidacao(string texto)
        {
            string item = texto.Split(new string[] { "\n" }, StringSplitOptions.None).Last();
            return item;
        }

        public bool validarTexto(string original, string xpath, int timeout)
        {
            string texto = driver.FindElement(By.XPath(xpath)).Text;
            int cont = 0;
            do
            {
                try
                {
                    if (String.Equals(original.ToUpper(), texto.ToUpper()))
                    {
                        Console.WriteLine("Texto corresponde");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Texto não corresponde");
                        return false;
                    }
                }
                catch (Exception e)
                {
                    cont++;
                    Console.WriteLine("Exceção encontrada: " + e);
                    Console.WriteLine("Tentativa " + cont);
                }
            } while (cont < timeout);
            return false;
        }
    

        public bool validarFluxo(string item1, string item2, int timeout)
        {
            int cont = 0;
            do
            {
                try
                {
                    if (String.Equals(item1.ToUpper(), item2.ToUpper()))
                    {
                        Console.WriteLine("Processo valido");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Processo invalido");
                        return false;

                    }
                }
                catch (Exception e)
                {
                    cont++;
                    Console.WriteLine("Exceção encontrada: " + e);
                    Console.WriteLine("Tentativa " + cont);
                }
            }while(cont < timeout);
            return false;
        }

        public bool selecionarOpcao(string xpath, string valor, int timeout)
        {
            int cont = 0;
            do
            {
                try
                {
                    element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                    if (!element.Displayed)
                    {
                        return false;
                    }
                    else
                    {
                        var dropdown = driver.FindElement(By.XPath(xpath));
                        var selectElement = new SelectElement(dropdown);

                        selectElement.SelectByText(valor);
                        return true;
                    }
                }
                catch (Exception e)
                {
                    cont++;
                    Console.WriteLine("Excessão encontrada: " + e);
                    Console.WriteLine("Tentativa " + cont);

                }
            }while (cont < timeout);
            return false;
            
        }

    }
}
