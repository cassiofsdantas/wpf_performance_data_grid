﻿using Microsoft.AspNetCore.Components;

namespace WPF_BLAZOR.Views
{
    public partial class Counter : ComponentBase
    {
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }
    }
}
