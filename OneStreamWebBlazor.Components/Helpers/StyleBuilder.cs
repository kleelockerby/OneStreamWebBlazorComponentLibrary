using System;
using System.Collections;
using System.Text;

namespace OneStreamWebBlazor.Components.Helpers
{
    public class StyleBuilder
    {
        private string styles;
        private const char Delimiter = ' ';
        private readonly Action<StyleBuilder> buildStyles;
        private StringBuilder builder = new StringBuilder();

        public string Styles
        {
            get
            {
                builder = new StringBuilder();
                buildStyles(this);
                styles = builder.ToString();
                return styles;
            }
        }

        public StyleBuilder(Action<StyleBuilder> buildStyles)
        {
            this.buildStyles = buildStyles;
        }

        public void Append(string value)
        {
            if (value != null)
                builder.Append(value).Append(Delimiter);
        }

        public void Append(string value, bool condition)
        {
            if (condition)
                builder.Append(value).Append(Delimiter);
        }
    }
}
