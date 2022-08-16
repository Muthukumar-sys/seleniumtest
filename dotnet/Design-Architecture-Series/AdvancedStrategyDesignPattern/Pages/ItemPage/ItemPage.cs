﻿// <copyright file="ItemPage.cs" company="Automate The Planet Ltd.">
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

namespace AdvancedStrategyDesignPattern.Pages.ItemPage;

public class ItemPage : Core.BasePageSingleton<ItemPage, ItemPageMap, ItemPageValidator>
{
    public ItemPage()
    {
    }

    public void ClickBuyNowButton()
    {
        Map.AddToCartButton.Click();
    }

    public override void Navigate(string part)
    {
        ///Selenium-Testing-Cookbook-Gundecha-Unmesh/dp/1849515743
        base.Navigate(string.Concat(@"http://www.amazon.com/", part));
    }
}