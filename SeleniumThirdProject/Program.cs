using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SeleniumThirdProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string para, bugun,kayıt;
            int i = 1;
            Console.WriteLine("************************ KRIPTO PARA SORGULAMA PROGRAMIDIR ************************");
            Console.Write("Program Kac Kez Kayit Alsin: ");
            kayıt = Console.ReadLine();
            int kayıt1 = Convert.ToInt32(kayıt);
            Console.Write("Lutfen Sorgulamak İstediginiz Para Birimini Giriniz: ");
            para = Console.ReadLine();
            while (i<=kayıt1)
            {
                IWebDriver driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.google.com");
                IWebElement element = driver.FindElement(By.Name("q"));
                element.SendKeys(para + " BiNANCE");
                element.Submit();
                driver.FindElement(By.XPath("//*[@id='rso']/div[1]/div[1]/div/div[1]/a/h3")).Click();
                Task.Delay(3000);
                driver.FindElement(By.CssSelector("body > div.css-1u2nk9f > div.css-4nl6qi > div.css-4rbxuz > svg > path")).Click();
                DateTime tarih = DateTime.Now;
                bugun = (tarih.ToString("f"));
                string kripto = driver.FindElement(By.CssSelector("#__APP > div > div > div.css-vduvd8 > div > div.css-15vandh > div > div.left.css-4cffwv > div > div.css-11y6cix > div > div.css-t7ggbb > div")).Text.Trim().ToString();
                string deger = driver.FindElement(By.CssSelector("#__APP > div > div > div.css-vduvd8 > div > div.css-15vandh > div > div.left.css-4cffwv > div > div.css-8t380c > div.showPrice.css-32cz3z")).Text.Trim().ToString();
                Console.Write(deger);
                string tldeger = driver.FindElement(By.CssSelector("#__APP > div > div > div.css-vduvd8 > div > div.css-15vandh > div > div.left.css-4cffwv > div > div.css-8t380c > div.subPrice.css-4lmq3e")).Text.Trim().ToString();
                Console.Write(tldeger);
                string degisim = driver.FindElement(By.CssSelector("#__APP > div > div > div.css-vduvd8 > div > div.css-15vandh > div > div.css-qk7wjx > div > div > div:nth-child(1) > div.css-dq9fy2")).Text.Trim().ToString();
                Console.Write(degisim);
                string satirlar;
                satirlar = ("***************************************************************\n" + "Günü ve Saati: " + bugun + "\nPara Birimi: " + kripto + "\nParanın Degeri: " + deger + "\nTL Bazında Değeri: " + tldeger + "\n24 Saatlik Değişim Oranı: " + degisim +  "\n***************************************************************");
                using (System.IO.StreamWriter dosya = new System.IO.StreamWriter(@"C:\Users\kerem\OneDrive\Belgeler\visual studio 2015\Projects\SeleniumThirdProject\SeleniumThirdProject\Kayit.txt", true))
                dosya.WriteLine(satirlar);
                string dosya1 = @"C:\Users\kerem\OneDrive\Belgeler\visual studio 2015\Projects\SeleniumThirdProject\SeleniumThirdProject\Kayit.txt";
                driver.Quit();
                i++;
            }
            Console.ReadKey();
            Process.Start(@"C:\Users\kerem\OneDrive\Belgeler\visual studio 2015\Projects\SeleniumThirdProject\SeleniumThirdProject\Kayit.txt");
            // Kerem Aksoy'dan. @Thekeremaksoy, Github: KeremAksoy11
        }
    }
}
