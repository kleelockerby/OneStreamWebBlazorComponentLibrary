using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFCardHeader : XFComponentBase
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public bool ShowBorder { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected ClassBuilder HeaderClassBuilder { get; private set; }
        protected string HeaderClassNames => HeaderClassBuilder.Class;

        public XFCardHeader()
        {
            HeaderClassBuilder = new ClassBuilder(BuildHeaderClasses);
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.CardHeader());
            base.BuildClasses(builder);
        }

        private void BuildHeaderClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.CardHeaderText());
            builder.Append(ClassProvider.CardHeaderTextBorder(this.ShowBorder));
        }
    }
}