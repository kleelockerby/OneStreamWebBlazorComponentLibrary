using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using OneStreamWebBlazor.Components.Common;
using OneStreamWebBlazor.Components.Utilities;

namespace OneStreamWebBlazor.Components.Components
{
    public abstract class XFInputBase<TValue> : XFComponentBase, IDisposable
    {
        [CascadingParameter] protected EditContext CascadedEditContext { get; set; }
        [Parameter] public TValue Value { get; set; }
        [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
        [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; }

        [Parameter] public TextBoxSize Size { get; set; } = TextBoxSize.None;
        [Parameter] public bool ReadOnly { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        private readonly EventHandler<ValidationStateChangedEventArgs> validationStateChangedHandler;

        protected EditContext EditContext { get; set; }
        protected FieldIdentifier FieldIdentifier { get; set; }

        protected virtual string FormatValueAsString(TValue value) => value?.ToString();
        protected abstract bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage);

        protected XFInputBase()
        {
            if (CascadedEditContext != null)
                validationStateChangedHandler = (sender, eventArgs) => StateHasChanged();
        }

        protected TValue CurrentValue
        {
            get => this.Value;
            set
            {
                if (!EqualityComparer<TValue>.Default.Equals(value, Value))
                {
                    Value = value;
                    _ = ValueChanged.InvokeAsync(value);
                    EditContext?.NotifyFieldChanged(FieldIdentifier);
                }
            }

        }

        protected string CurrentValueAsString
        {
            get => FormatValueAsString(CurrentValue);
            set
            {
                _ = ValueChanged.InvokeAsync(this.Value);
            }
        }

        protected async Task OnChangeAsync(ChangeEventArgs e)
        {
            string value = e?.Value?.ToString();
            bool empty = false;

            if (string.IsNullOrEmpty(value))
            {
                empty = true;
                CurrentValue = default;
            }

            if (!empty)
            {
                var result = TryParseValueFromString(value, out var parsedValue, out var validationErrorMessage);
                if (result == true)
                {
                    this.CurrentValue = parsedValue;
                    if (!EqualityComparer<TValue>.Default.Equals(CurrentValue, Value))
                    {
                        this.Value = CurrentValue;
                        _ = ValueChanged.InvokeAsync(this.Value);
                        CascadedEditContext?.NotifyFieldChanged(FieldIdentifier);
                    }

                }
            }
            await Task.CompletedTask;
        }

        void IDisposable.Dispose()
        {
            if (EditContext != null)
            {
                EditContext.OnValidationStateChanged -= validationStateChangedHandler;
            }

            Dispose(disposing: true);
        }
    }
}