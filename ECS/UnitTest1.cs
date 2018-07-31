using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ECS
{
    [TestClass]
    public class UnitTest1
    {


        private readonly IWebDriver driver;
        

   




        [TestMethod]
        public void TestMethod1()
        {

          

            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:3000/");

       


            try
            {
                IWebElement renderChallenge = driver.FindElement(By.CssSelector("[data-test-id=render-challenge]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", renderChallenge);
                renderChallenge.Click();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


            /// Result - Row1
            List<int> nameOne=  returnfun(driver, 1);
            string resultOne = calc(nameOne).ToString();
            IWebElement submitOne = driver.FindElement(By.CssSelector("[data-test-id='submit-1']"));
            submitOne.SendKeys(resultOne);


            ///Result - Row2
            List<int> nameTwo = returnfun(driver, 2);
            string resultTwo = calc(nameTwo).ToString();
            IWebElement submitTwo = driver.FindElement(By.CssSelector("[data-test-id='submit-2']"));
            submitTwo.SendKeys(resultTwo);


            ///Result - Row3
            List<int> nameThree = returnfun(driver, 3);
            string resulthree = calc(nameThree).ToString();
            IWebElement submitThree = driver.FindElement(By.CssSelector("[data-test-id='submit-3']"));
            submitThree.SendKeys(resulthree);


            //EnterName 
            IWebElement submitName = driver.FindElement(By.CssSelector("[data-test-id='submit-4']"));
            submitName.SendKeys("Andy Mondal");



            IWebElement FinalSubmit = driver.FindElement(By.XPath(" //*[@id='challenge']/div/div/div[2]/div/div[2]/button"));
            FinalSubmit.Click();

            QuiteBrowser(driver);

        }






        private List<int> returnfun(IWebDriver driver, int rowId)
        {
            //var table = driver.FindElement(By.TagName("table"));
            var table = driver.FindElement(By.XPath("//*[@id='challenge']/div/div/div[1]/div/div[2]/table/tbody/tr["+rowId+"]"));
            var   value = table.Text;
            var arr = value.Split(' ');

            List<string> strlist=  new List<string>(arr);
            List<int> inlist = strlist.ConvertAll(int.Parse);

            return inlist;        
            
        }



        private int calc(List<int> A)
        {
            if (A == null || A.Count == 0)
                return -1;

            if (A.Count == 1)
                return 0;

            var upperBoundSum = GetTotal(A);
            var lowerBoundSum = 0;
            for (var i = 0; i < A.Count; i++)
            {
                lowerBoundSum += (i - 1) >= 0 ? A[i - 1] : 0;
                upperBoundSum -= A[i];
                if (lowerBoundSum == upperBoundSum)
                    return i;
            }
            return -1;
        }

        private static int GetTotal(List<int> ints)
        {
            var sum = 0;
            for (var i = 0; i < ints.Count; i++)
                sum += ints[i];
            return sum;
            
        }

        
        private void QuiteBrowser(IWebDriver driver)
        {
            driver.Quit();
        }

    }





}

