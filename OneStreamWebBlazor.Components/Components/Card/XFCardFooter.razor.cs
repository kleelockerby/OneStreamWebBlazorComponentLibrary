using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFCardFooter : XFComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.CardFooter());
            base.BuildClasses(builder);
        }
    }
}