using System;
using System.Collections.Generic;
using System.Text;
using OneStreamWebBlazor.Components.Common;

namespace OneStreamWebBlazor.Components.Helpers
{
    public class StyleProvider
    {
        public string ListItemHeight(int height) => $"height: {height}px; line-height: {height - 2}px;";

        public string ListItemTemplate(bool show) => show == true ? "border-bottom: 1px solid #ccc;" : "";

        public string ModalShow() => "display: block; padding-right: 17px;";

        public string ModalBodyMaxHeight(int maxHeight) => $"max-height: {maxHeight}vh; overflow-y: auto;";

        public string ProgressBarValue(int value) => $"width: {value}%";

        public string ProgressBarSize(Size size) => null;

        public string Visibility(Visibility visibility) => visibility == Common.Visibility.Never ? "display: none;" : null;

        public virtual string RowGutter((int Horizontal, int Vertical) gutter)
        {
            var sb = new StringBuilder();

            if (gutter.Horizontal > 0)
                sb.Append($"margin-left: -{gutter.Horizontal / 2}px; margin-right: -{gutter.Horizontal / 2}px;");

            if (gutter.Vertical > 0)
                sb.Append($"margin-top: -{gutter.Vertical / 2}px");

            return sb.ToString();
        }

        public virtual string ColumnGutter((int Horizontal, int Vertical) gutter)
        {
            var sb = new StringBuilder();

            if (gutter.Horizontal > 0)
                sb.Append($"padding-left: {gutter.Horizontal / 2}px; padding-right: {gutter.Horizontal / 2}px;");

            if (gutter.Vertical > 0)
                sb.Append($"padding-top: {gutter.Vertical / 2}px; padding-bottom: {gutter.Vertical / 2}px");

            return sb.ToString();
        }
    }
}
