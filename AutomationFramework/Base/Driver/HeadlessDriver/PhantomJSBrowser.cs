﻿using System;
using OpenQA.Selenium.PhantomJS;
using AutomationFrameWork.Driver.Interface;
namespace AutomationFrameWork.Driver
{
    class PhantomJSBrowser : IDrivers
    {
        public PhantomJSBrowser() { }
        public object Driver { get; set; }
        public object DesiredCapabilities
        {
            get
            {
                PhantomJSOptions options = new PhantomJSOptions();
                return options;
            }
        }

        public object DriverServices
        {
            get
            {
                PhantomJSDriverService services = PhantomJSDriverService.CreateDefaultService();
                services.HideCommandPromptWindow = true;
                services.IgnoreSslErrors = true;
                services.LoadImages = true;               
                services.SuppressInitialDiagnosticInformation = false;
                return services;
            }
        }

        public void StartDriver(DriverConfiguration configuration)
        {
            configuration.DriverServices = configuration.DriverServices ?? DriverServices;
            configuration.DesiredCapabilities = configuration.DesiredCapabilities ?? DesiredCapabilities;
            Driver= new PhantomJSDriver((PhantomJSDriverService)configuration.DriverServices, (PhantomJSOptions)configuration.DesiredCapabilities, TimeSpan.FromSeconds(configuration.CommandTimeout));
        }       
    }
}
