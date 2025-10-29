using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Helpers
{
    public static class ToastHelper
    {
        public static async Task GetToastAsync(string Text, ToastDuration toastDuration, int size)
        {
            CancellationTokenSource cancellationToken = new();

            var toast = Toast.Make(Text, toastDuration, size);

            await toast.Show(cancellationToken.Token);
        } 
    }
}
