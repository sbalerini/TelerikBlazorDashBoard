﻿using BlazorOE01.Resources;
using Telerik.Blazor.Services;

namespace BlazorOE01.Services
{
    public class SampleResxLocalizer : ITelerikStringLocalizer
    {
        // This indexer is required
        public string this[string key]
        {
            get
            {
                return TelerikMessages.ResourceManager.GetString(key, TelerikMessages.Culture) ?? key;
            }
        }
    }
}
