using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneStreamWebBlazor.Components.Common
{
    public enum ButtonType
    {
        Button,
        Submit,
        Reset,
    }

    public enum SearchFilterMode
    {
        StartsWith,
        Contains
    }

    public enum FilterCaseSensitivity
    {
        CaseSensitive,
        CaseInsensitive
    }

    public enum Color
    {
        None,
        Primary,
        Secondary,
        Success,
        Danger,
        Warning,
        Info,
        Light,
        Dark,
        Link,
    }

    public enum TextColor
    {
        None,
        Primary,
        Secondary,
        Success,
        Danger,
        Warning,
        Info,
        Light,
        Dark,
        Body,
        Muted,
        White,
        Black50,
        White50,
    }


    public enum TextChangeMode
    {
        Change,
        Input
    }

    public enum Background
    {
        None,
        Primary,
        Secondary,
        Success,
        Danger,
        Warning,
        Info,
        Light,
        Dark,
        White,
        Transparent,
    }

    public enum Size
    {
        None,
        ExtraSmall,
        Small,
        Medium,
        Large,
        ExtraLarge,
    }

    public enum TextBoxSize
    {
        None,
        Small,
        Large
    }

    public enum Breakpoint
    {
        None,
        Mobile,
        Tablet,
        Desktop,
        Widescreen,
        FullHD,
    }

    public enum ColumnWidth
    {
        None,
        Is1,
        Is2,
        Is3,
        Is4,
        Is5,
        Is6,
        Is7,
        Is8,
        Is9,
        Is10,
        Is11,
        Is12,
        Full,
        Half,
        Third,
        Quarter,
        Auto,
    }

    public enum Direction
    {
        None,
        Down,
        Up,
        Right,
        Left,
    }

    public enum Side
    {
        None,
        Top,
        Bottom,
        Left,
        Right,
        X,
        Y,
        All,
    }

    public enum Float
    {
        None,
        Left,
        Right,
    }

    public enum Placement
    {
        Top,
        Bottom,
        Left,
        Right,
    }

    public enum Spacing
    {
        None,
        Margin,
        Padding,
    }

    public enum SpacingSize
    {
        Is0,
        Is1,
        Is2,
        Is3,
        Is4,
        Is5,
        IsAuto,
    }

    public enum TextRole
    {
        Text,
        Email,
        Password,
        Url,
    }

    public enum TextInputMode
    {
        None,
        Text,
        Tel,
        Url,
        Email,
        Numeric,
        Decimal,
        Search,
    }

    public enum NavFillType
    {
        None,
        Default,
        Justified,
    }

    public enum Visibility
    {
        Default,
        Always,
        Never,
    }

    public enum Alignment
    {
        None,
        Start,
        Center,
        End,
    }

    public enum TextAlignment
    {
        None,
        Left,
        Center,
        Right,
        Justified
    }

    public enum TextTransform
    {
        None,
        Lowercase,
        Uppercase,
        Capitalize,
    }

    public enum TextWeight
    {
        None,
        Normal,
        Bold,
        Light,
    }

    public enum Match
    {
        Prefix,
        All,
    }

    public enum Target
    {
        None,
        Self,
        Blank,
        Parent,
        Top,
    }

    public enum AddonType
    {
        Body,
        Start,
        End,
    }

    public enum ControlRole
    {
        None,
        Check,
        Radio,
        Switch,
        File,
        Text,
    }

    public enum ModalSize
    {
        None,
        Default,
        Small,
        Large,
        ExtraLarge,
    }

    public enum ButtonsRole
    {
        Addons,
        Toolbar,
    }

    public enum Orientation
    {
        Horizontal,
        Vertical,
    }

    public enum JustifyContent
    {
        None,
        Start,
        End,
        Center,
        Between,
        Around,
    }

    public enum Screenreader
    {
        Always,
        Only,
        OnlyFocusable,
    }

    public enum HeadingSize
    {
        Is1,
        Is2,
        Is3,
        Is4,
        Is5,
        Is6,
    }

    public enum DisplayHeadingSize
    {
        Is1,
        Is2,
        Is3,
        Is4,
    }

    public enum ValidationStatus
    {
        None,
        Success,
        Error,
    }

    public enum ValidationMode
    {
        Auto,
        Manual,
    }

    public enum ButtonSize
    {
        None,
        Small,
        Large,
    }

    public enum ButtonsSize
    {
        None,
        Small,
        Large,
    }

    public enum Cursor
    {
        Default,
        Pointer,
    }

    public enum IconName
    {
        New,
        Edit,
        Save,
        Cancel,
        Delete,
        Clear,
        Search,
        ClearSearch,
        Phone,
        Smartphone,
        Mail,
        Person,
        Lock,
        MoreHorizontal,
        MoreVertical,
        ExpandMore,
        ExpandLess,
        SliderHorizontal,
        SliderVertical,
        Dashboard,
        Tint,
        Palette,
        SortUp,
        SortDown,
    }

    public enum IconStyle
    {
        Solid = 0,
        Regular = 1,
        Light = 2,
        DuoTone = 4,
    }

    public enum FormatType
    {
        None = 0,
        Numeric = 1,
        DateTime = 2,
        Custom = 3,
    }

    public enum MaskType
    {
        None,
        Numeric = 1,
        DateTime = 2,
        RegEx = 3,
    }

    public enum MouseButton
    {
        Left = 0,
        Middle = 1,
        Right = 2,
    }

    public enum SortDirection
    {
        None = 0,
        Ascending = 1,
        Descending = 2,
    }

    public enum FigureSize
    {
        None = 0,
        Is16x16 = 1,
        Is24x24 = 2,
        Is32x32 = 3,
        Is48x48 = 4,
        Is64x64 = 5,
        Is96x96 = 6,
        Is128x128 = 7,
        Is256x256 = 8,
        Is512x512 = 9,
    }

    public enum CharacterCasing
    {
        Normal = 0,
        Upper = 1,
        Lower = 2,
        Title = 3,
    }

    public enum LabelType
    {
        None,
        Check,
        Radio,
        Switch,
        File,
    }

    public enum CloseReason
    {
        None,
        UserClosing,
        FocusLostClosing,
        EscapeClosing,
    }

    public enum DividerType
    {
        Solid,
        Dashed,
        Dotted,
        TextContent,
    }

    public enum TabPosition
    {
        Top,
        Bottom,
        Left,
        Right,
    }

    public enum BreadcrumbMode
    {
        None,
        Auto,
    }

    public enum ListBoxDirection
    {
        Down,
        Up
    }

    public enum LinkClasses
    {
        ComboBoxButton,
        SidebarButton,
        SidebarFlyoutButton,
        TabButton
    }
}
