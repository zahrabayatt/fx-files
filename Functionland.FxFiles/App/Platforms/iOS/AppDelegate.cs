﻿using Foundation;

namespace Functionland.FxFiles.App.Platforms.iOS;

[Register(nameof(AppDelegate))]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiAppBuilder().Build();
}