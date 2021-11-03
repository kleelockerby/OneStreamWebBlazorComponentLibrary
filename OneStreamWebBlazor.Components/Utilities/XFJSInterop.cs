using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using OneStreamWebBlazor.Components.Components;

namespace OneStreamWebBlazor.Components.Utilities
{
    public class XFJSInterop : IDisposable
    {
        private int _openModals = 0;

        protected IJSRuntime JSRuntime { get; }
        public Func<string, Task> OnAnimationEndEvent { get; set; }
        public Func<string, string, Task> OnAddClassEvent { get; set; }

        public XFJSInterop(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }

        public ValueTask<bool> SetOffsetHeight(ElementReference el, bool show)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.collapsingElement", el, show);
        }

        public ValueTask<bool> ClearOffsetHeight(ElementReference el)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.collapsingElementEnd", el);
        }

        public ValueTask<bool> AddClass(ElementReference el, string Classname)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.addClass", el, Classname);
        }

        public ValueTask<bool> AddBodyClass(string Classname)
        {
            _openModals++;
            return JSRuntime.InvokeAsync<bool>("blazorStrap.addBodyClass", Classname);
        }
        public ValueTask<bool> RemoveBodyClass(string Classname)
        {
            _openModals--;
            return _openModals == 0 ? JSRuntime.InvokeAsync<bool>("blazorStrap.removeBodyClass", Classname) : new ValueTask<bool>(false);
        }

        public ValueTask<bool> ChangeBodyPaddingRight(string padding)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.changeBodyPaddingRight", padding);
        }

        private DotNetObjectReference<XFModal> _objRef;
        private bool _disposedValue;

        public ValueTask<string> ModalEscapeKey(XFModal modal)
        {
            _objRef = DotNetObjectReference.Create(modal);
            return JSRuntime.InvokeAsync<string>("blazorStrap.modelEscape", _objRef);
        }
        public ValueTask<bool> Log(string message)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.log", message);
        }

        public ValueTask<bool> Popper(string target, string popper, ElementReference arrow, string placement)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.popper", target, popper, arrow, placement);
        }

        public ValueTask<bool> Tooltip(string target, ElementReference tooltip, ElementReference arrow, string placement)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.tooltip", target, tooltip, arrow, placement);
        }

        public ValueTask<object> FocusElement(ElementReference el)
        {
            return JSRuntime.InvokeAsync<object>("blazorStrap.focusElement", el);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_objRef != null)
                    {
                        _objRef.Dispose();
                    }
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public class StringReturn
    {
        public string Result { get; set; }
    }
}
