﻿using Microsoft.Extensions.Logging;

namespace MauiCalc;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("LCD.ttf", "LCD");
                
                
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}