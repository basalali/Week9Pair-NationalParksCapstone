using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Models;
using Capstone.Web.DAL;



[TestClass]
public class WeatherModelTests
{
    [TestMethod]
    public void ConvertToCelcius_Test()
    {

        Weather weather = new Weather();

        int farenheit = 75;

        int result = weather.ConverToCelcius(farenheit);

        Assert.AreEqual(23, result);

        //---------------------------

        farenheit = 32;

        result = weather.ConverToCelcius(farenheit);

        Assert.AreEqual(0, result);


        //-----------------------------

        farenheit = 0;

        result = weather.ConverToCelcius(farenheit);

        Assert.AreEqual(-17, result);

    }
}

