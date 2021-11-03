using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Common;
using OneStreamWebBlazor.Components.Helpers;
using OneStreamWebBlazor.Components.Utilities;

namespace OneStreamWebBlazor.Components.Components
{
    public class XFComponentBase : ComponentBase, IDisposable
    {
        private string customClass;
        private string customStyle;
        private string elementId;

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }

        //[Inject] protected ClassProvider ClassProvider { get; set; }
        private Visibility visibility = Visibility.Default;
        private Queue<Func<Task>> executeAfterRendereQueue;
        protected ClassBuilder ClassBuilder { get; private set; }
        protected StyleBuilder StyleBuilder { get; private set; }
        protected string ClassNames => ClassBuilder.Class;
        protected string StyleNames => StyleBuilder.Styles;
        protected ClassProvider ClassProvider { get; } = new ClassProvider();
        protected StyleProvider StyleProvider { get; } = new StyleProvider();

        public ElementReference ElementRef { get; set; }

        [Parameter]
        public string Class
        {
            get => customClass;
            set => customClass = value;
        }

        [Parameter]
        public string Style
        {
            get => customStyle;
            set => customStyle = value;
        }

        [Parameter]
        public Visibility Visibility
        {
            get => visibility;
            set => visibility = value;
        }

        protected virtual Task OnFirstAfterRenderAsync() => Task.CompletedTask;

        public string ElementId
        {
            get
            {
                if (elementId == null) { elementId = IDGenerator.Instance.Generate; }
                return elementId;
            }
            private set { elementId = value; }
        }

        protected bool Disposed { get; private set; }

        protected XFComponentBase()
        {
            ClassBuilder = new ClassBuilder(BuildClasses);
            StyleBuilder = new StyleBuilder(BuildStyles);
        }

        protected virtual void BuildClasses(ClassBuilder builder)
        {
            if (Class != null)
            {
                builder.Append(Class);
            }

        }

        protected virtual void BuildStyles(StyleBuilder builder)
        {
            if (Style != null)
            {
                builder.Append(Style);
            }

        }

        protected void ExecuteAfterRender(Func<Task> action)
        {
            if (executeAfterRendereQueue == null)
                executeAfterRendereQueue = new Queue<Func<Task>>();

            executeAfterRendereQueue.Enqueue(action);
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            return base.SetParametersAsync(parameters);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                Disposed = true;
            }
        }
    }
}





/*
public ElementReference ElementRef
{
    get { return GetCustomElementRef != null ? GetCustomElementRef() : elementRef; }
    protected set => elementRef = value;
}

private Func<ElementReference> GetCustomElementRef { get; set; }




*/
