﻿// <copyright file="UnityWikipediaTests.cs" company="Automate The Planet Ltd.">
// Copyright 2022 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>http://automatetheplanet.com/</site>
using System.Configuration;
using IoCContainerPageObjectPattern.Core;
using IoCContainerPageObjectPattern.WikipediaMainPage;
using Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Lifetime;
using Microsoft.Practices.Unity.Configuration;

namespace IoCContainerPageObjectPattern;

[TestClass]
public class UnityWikipediaTests
{
    private static readonly IUnityContainer PageFactory = new UnityContainer();

    [AssemblyInitialize]
    public static void MyTestInitialize(TestContext testContext)
    {
        var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "unity.config" };
        var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
        PageFactory.LoadConfiguration(unitySection);

        PageFactory.RegisterType<IWikipediaMainPage, WikipediaMainPage.WikipediaMainPage>(new ContainerControlledLifetimeManager());
    }

    [TestInitialize]
    public void SetupTest()
    {
        Driver.StartBrowser();
    }

    [TestCleanup]
    public void TeardownTest()
    {
        Driver.StopBrowser();
    }

    [TestMethod]
    public void TestWikiContentsToggle()
    {
        var wikiPage = new WikipediaMainPage.WikipediaMainPage();
        wikiPage.Navigate();
        wikiPage.Search("Quality assurance");
        wikiPage.Validate().ToogleLinkTextHide();
        wikiPage.Validate().ContentsListVisible();
        wikiPage.ToggleContents();
        wikiPage.Validate().ToogleLinkTextShow();
        wikiPage.Validate().ContentsListHidden();
    }

    [TestMethod]
    public void TestWikiContentsToggle_Unity()
    {
        ////var wikiPage = PageFactory.Get<IWikipediaMainPage>();
        var wikiPage = PageFactory.Resolve<IWikipediaMainPage>();
        wikiPage.Navigate();
        wikiPage.Search("Quality assurance");
        wikiPage.Validate().ToogleLinkTextHide();
        wikiPage.Validate().ContentsListVisible();
        wikiPage.ToggleContents();
        wikiPage.Validate().ToogleLinkTextShow();
        wikiPage.Validate().ContentsListHidden();
    }
}