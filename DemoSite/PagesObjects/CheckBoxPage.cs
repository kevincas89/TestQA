using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static DemoSite.PagesObjects.TextBoxPage;

namespace DemoSite.PagesObjects
{
    public class CheckBoxPage
    {
        IPage _page;
        public readonly CheckBoxPageMap Map;

        public CheckBoxPage(IPage page)
        {
            this._page = page;
            Map = new CheckBoxPageMap(page);
        }

        public async Task DeployAndCheck()
        {
            await Map.ElementsBtn.ClickAsync();
            await Map.CheckBoxBtn.ClickAsync();
            await Map.HomeDeploy.ClickAsync();
            await Map.DesktopDeploy.ClickAsync();
            await Map.DocumentsDeploy.ClickAsync();
            await Map.DownloadsDeploy.ClickAsync();
            await Map.WorkSpaceDeploy.ClickAsync();
            await Map.OfficeDeploy.ClickAsync();
            //await Map.HomeCheckBox.CheckAsync();
            await Map.DesktopCheckBox.CheckAsync();
            await Map.DocumentsCheckBox.CheckAsync();
            await Map.DownloadsCheckBox.CheckAsync();
        }

        //method to select the checkbox or deselected
        public async Task ToggleCheckBox(ILocator checkBox)
        {
            bool isChecked = await checkBox.IsCheckedAsync();

            if (isChecked)
                await checkBox.UncheckAsync();
            else
                await checkBox.CheckAsync();
        }

        public class CheckBoxPageMap(IPage page)
        {
            //found text Elements
            public ILocator ElementsBtn => page.GetByText("Elements");
            //Click in CheckBox
            public ILocator CheckBoxBtn => page.GetByRole(AriaRole.Link, new() { Name = "Check Box" });
            //method to get the toggle button of the tree item
            private ILocator GetTreeItemToggle(string name) =>
              page.GetByRole(AriaRole.Treeitem, new() { Name = name })
                 .Locator(".rc-tree-switcher_close");
            //locators for the tree items
            public ILocator HomeDeploy => GetTreeItemToggle("Home");
            public ILocator DesktopDeploy => GetTreeItemToggle("Desktop");
            public ILocator DocumentsDeploy => GetTreeItemToggle("Documents");
            public ILocator DownloadsDeploy => GetTreeItemToggle("Downloads");
            public ILocator WorkSpaceDeploy => GetTreeItemToggle("WorkSpace");
            public ILocator OfficeDeploy => GetTreeItemToggle("Office");

            //Method to get the checkbox locator for a given tree item
            // Checkboxes
            private ILocator GetTreeItemCheckBox(string name) =>
                page.GetByRole(AriaRole.Treeitem, new() { Name = name })
                    .Locator(".rc-tree-checkbox");

            public ILocator HomeCheckBox => GetTreeItemCheckBox("Home");
            public ILocator DesktopCheckBox => GetTreeItemCheckBox("Desktop");
            public ILocator DocumentsCheckBox => GetTreeItemCheckBox("Documents");
            public ILocator DownloadsCheckBox => GetTreeItemCheckBox("Downloads");

        }
    }
}
