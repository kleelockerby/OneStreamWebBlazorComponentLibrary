using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace OneStreamWebBlazor.Components.Services
{
    public class XFJsRunner
    {
        private readonly IJSRuntime jsRuntime;
        private const string XF_NAMESPACE = "oneStreamWebBlazor";

        public XFJsRunner(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task ShowModal(ElementReference elemRef)
        {
            await jsRuntime.InvokeVoidAsync($"{XF_NAMESPACE}.showModal", elemRef);
        }

        public async Task HideModal(ElementReference elemRef)
        {
            await jsRuntime.InvokeVoidAsync($"{XF_NAMESPACE}.hideModal", elemRef);
        }
    }
}
