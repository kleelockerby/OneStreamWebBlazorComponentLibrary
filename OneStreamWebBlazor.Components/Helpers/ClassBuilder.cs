using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OneStreamWebBlazor.Components.Helpers
{
    public class ClassBuilder
    {
        private string classNames;
        private const char Delimiter = ' ';
        private readonly Action<ClassBuilder> buildClasses;
        private StringBuilder builder = new StringBuilder();

        public string Class
        {
            get
            {
                builder = new StringBuilder();
                buildClasses(this);
                classNames = builder.ToString()?.TrimEnd();
                return classNames;
            }
        }

        public ClassBuilder(Action<ClassBuilder> buildClasses)
        {
            this.buildClasses = buildClasses;
        }

        public void Append(string value)
        {
            if (value == null)
                return;

            builder.Append(value).Append(Delimiter);
        }

        public void Append(string value, bool condition)
        {
            if (condition && value != null)
                builder.Append(value).Append(Delimiter);
        }

        public void Append(IEnumerable<string> values)
        {
            builder.Append(string.Join(Delimiter.ToString(), values)).Append(Delimiter);
        }
    }
}
