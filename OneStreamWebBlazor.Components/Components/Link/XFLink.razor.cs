using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Components.Routing;
using OneStreamWebBlazor.Components.Common;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFLink : XFComponentBase, IDisposable
    {
        private string absoluteUri;
        private bool active = false;
        private string anchorTarget;
        protected bool PreventDefault { get; private set; }

        [Parameter] public LinkClasses LinkClassNames { get; set; }
        [Parameter] public string To { get; set; }
        [Parameter] public Match Match { get; set; }
        [Parameter] public Target Target { get; set; } = Target.None;
        [Parameter] public string Title { get; set; }
        [Parameter] public EventCallback Clicked { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            if(LinkClassNames == LinkClasses.ComboBoxButton)
            {
                builder.Append(ClassProvider.ComboBoxButton());
            }
            builder.Append("Active", active);
            base.BuildClasses(builder);
        }

        protected override void OnInitialized()
        {
            NavigationManager.LocationChanged += OnLocationChanged;
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            PreventDefault = false;

            if (Attributes?.ContainsKey("href") == true)
                To = $"{Attributes["href"]}";

            if (To != null && To.StartsWith("#"))
            {
                anchorTarget = To.Substring(1);
                PreventDefault = true;
            }

            absoluteUri = To == null ? string.Empty : NavigationManager.ToAbsoluteUri(To).AbsoluteUri;
            active = ShouldMatch(NavigationManager.Uri);

            base.OnParametersSet();
        }

        protected async Task OnClickHandler(MouseEventArgs e)
        {
            await Clicked.InvokeAsync(null);
        }

        private bool ShouldMatch(string currentUriAbsolute)
        {
            if (EqualsHrefExactlyOrIfTrailingSlashAdded(currentUriAbsolute))
            {
                return true;
            }

            if (Match == Match.Prefix && IsStrictlyPrefixWithSeparator(currentUriAbsolute, absoluteUri))
            {
                return true;
            }

            return false;
        }

        private bool EqualsHrefExactlyOrIfTrailingSlashAdded(string currentUriAbsolute)
        {
            if (string.Equals(currentUriAbsolute, absoluteUri, StringComparison.Ordinal))
            {
                return true;
            }

            if (currentUriAbsolute.Length == absoluteUri.Length - 1)
            {
                //if (absoluteUri[^1] == '/' && absoluteUri.StartsWith(currentUriAbsolute, StringComparison.Ordinal))
                if (absoluteUri[absoluteUri.Length - 1] == '/' && absoluteUri.StartsWith(currentUriAbsolute, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsStrictlyPrefixWithSeparator(string value, string prefix)
        {
            var prefixLength = prefix.Length;
            if (value.Length > prefixLength)
            {
                return value.StartsWith(prefix, StringComparison.Ordinal)
                    && (
                        // Only match when there's a separator character either at the end of the
                        // prefix or right after it.
                        // Example: "/abc" is treated as a prefix of "/abc/def" but not "/abcdef"
                        // Example: "/abc/" is treated as a prefix of "/abc/def" but not "/abcdef"
                        prefixLength == 0
                        || !char.IsLetterOrDigit(prefix[prefixLength - 1])
                        || !char.IsLetterOrDigit(value[prefixLength])
                    );
            }
            else
            {
                return false;
            }
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs args)
        {
            var shouldBeActiveNow = ShouldMatch(args.Location);

            if (shouldBeActiveNow != active)
            {
                active = shouldBeActiveNow;
                StateHasChanged();
            }
        }

        protected string TargetName
        {
            get
            {
                switch (Target)
                {
                    case Target.Blank:
                        return "_blank";
                    case Target.Parent:
                        return "_parent";
                    case Target.Top:
                        return "_top";
                    case Target.Self:
                        return "_self";
                    case Target.None:
                    default:
                        return null;
                }
            }
        }
    }

}