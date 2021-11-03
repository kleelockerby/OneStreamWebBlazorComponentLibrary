using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneStreamWebBlazor.Components.Common;


namespace OneStreamWebBlazor.Components.Helpers
{
    public class ClassProvider
    {
        public bool UseCustomInputStyles { get; set; } = true;

        public string Button() => "btn";
        public string ButtonColor(Color color) => $"{Button()}-{ToColor(color)}";
        public string ButtonOutline(Color color) => color != Color.None ? $"{Button()}-outline-{ToColor(color)}" : $"{Button()}-outline";
        public string ButtonBlock() => $"{Button()}-block";
        public string ButtonActive() => "active";
        public string ButtonLoading() => null;

        public string ButtonsAddons() => "btn-group";
        public string ButtonsToolbar() => "btn-toolbar";
        public string ButtonsVertical() => "btn-group-vertical";
        public string CloseButton() => "close";

        public string ComboBox() => "xf-combo";
        public string ComboBoxWrapper() => "xf-combo-wrapper";
        public string ComboBoxButton() => "xf-button";
        public string ListBox() => "xf-scrollbox";
        public string ListBoxContent() => "xf-listbox";
        //public string ListBoxItem() => "xf-listitem";
        public string ListBoxItem(bool selected) => selected == false ? "xf-listitem" : "xf-listitem selected";

        public string Dropdown() => "dropdown";
        public string DropdownGroup() => "btn-group";
        public string DropdownShow() => Show();
        public string DropdownRight() => null;
        public string DropdownItem() => "dropdown-item";
        public string DropdownItemActive() => Active();
        public string DropdownDivider() => "dropdown-divider";
        public string DropdownMenu() => "dropdown-menu";
        public string DropdownMenuVisible(bool visible) => visible ? Show() : null;
        public string DropdownMenuRight() => "dropdown-menu-right";
        public string DropdownToggle() => "btn dropdown-toggle";
        public string DropdownToggleColor(Color color) => $"{Button()}-{ToColor(color)}";
        public string DropdownToggleOutline(Color color) => color != Color.None ? $"{Button()}-outline-{ToColor(color)}" : $"{Button()}-outline";
        public string DropdownToggleSplit() => "dropdown-toggle-split";

        public string TextEdit() => "form-control";
        public string TextEditSize(TextBoxSize size) => $"{TextEdit()}-{ToTextBoxSize(size)}";
        public string TextEditColor(Color color) => $"text-{ToColor(color)}";
        public string TextEditValidation(ValidationStatus validationStatus) => ToValidationStatus(validationStatus);

        public string TextArea() => "form-control";
        public string TextAreaSize(TextBoxSize size) => $"{TextArea()}-{ToTextBoxSize(size)}";
        public string TextAreaValidation(ValidationStatus validationStatus) => ToValidationStatus(validationStatus);

        public string DateEdit() => "form-control";
        public string DateEditSize(TextBoxSize size) => $"{DateEdit()}-{ToTextBoxSize(size)}";
        public string DateEditValidation(ValidationStatus validationStatus) => ToValidationStatus(validationStatus);

        public string Select() => UseCustomInputStyles ? "custom-select" : "form-control";
        public string SelectSize(TextBoxSize size) => $"{Select()}-{ToTextBoxSize(size)}";
        public string SelectValidation(ValidationStatus validationStatus) => ToValidationStatus(validationStatus);

        public string TimeEdit() => "form-control";
        public string TimeEditSize(Size size) => $"{TimeEdit()}-{ToSize(size)}";
        public string TimeEditValidation(ValidationStatus validationStatus) => ToValidationStatus(validationStatus);

        public string ColorEdit() => "form-control";

        public string Check() => UseCustomInputStyles ? "custom-control-input" : "form-check-input";
        public string CheckInline() => UseCustomInputStyles ? "custom-control-inline" : "form-check-inline";
        public string CheckCursor(Cursor cursor) => $"{Check()}-{ToCursor(cursor)}";
        public string CheckValidation(ValidationStatus validationStatus) => ToValidationStatus(validationStatus);

        public string RadioGroup(bool buttons) => buttons ? "btn-group btn-group-toggle" : null;
        public string RadioGroupInline() => null;

        public string RadioGroupControl() => "custom-control";
        public string RadioGroup() => "custom-radio";
       // public string Radio() =>  UseCustomInputStyles ? "custom-control-input" : "form-check-input";
        public string RadioInline(bool isInline) => isInline ? null :  UseCustomInputStyles ? "custom-control-inline" : "form-check-inline";
        public string Radio(bool button) => button ? null : UseCustomInputStyles ? "custom-control-input" : "form-check-input";
        //public string RadioInline() => UseCustomInputStyles ? "custom-control-inline" : "form-check-inline";

        public string LabelCursor(Cursor cursor) => UseCustomInputStyles ? $"custom-control-label-{ToCursor(cursor)}" : $"form-check-label-{ToCursor(cursor)}";

        public string Tabs() => "nav nav-tabs";
        public string TabsCards() => "card-header-tabs";
        public string TabsPills() => "nav-pills";
        public string TabsFullWidth() => "nav-fill";
        public string TabsJustified() => "nav-justified";
        public string TabsVertical() => "flex-column";
        public string TabItem() => "nav-item";
        public string TabItemActive(bool active) => null;
        public string TabItemDisabled(bool disabled) => null;
        public string TabLink() => "nav-link";
        public string TabLinkActive(bool active) => active ? $"{Active()} {Show()}" : null;
        public string TabLinkDisabled(bool disabled) => disabled ? "disabled" : null;
        public string TabsContent() => "nav-item-content";
        public string TabPanel() => "nav-item-panel";
        public string TabPanelActive(bool active) => active ? $"{Active()} {Show()}" : null;

        public string Nav() => "nav";
        public string NavItem() => "nav-item";
        public string NavLink() => "nav-link";
        public string NavTabs() => "nav-tabs";
        public string NavCards() => "nav-cards";
        public string NavPills() => "nav-pills";
        public string NavFill(NavFillType fillType) => fillType == NavFillType.Justified ? "nav-justified" : "nav-fill";
        public string NavVertical() => "flex-column";

        public string Show() => "show";
        public string Fade() => "fade";
        public string Active() => "active";
        public string Disabled() => "disabled";
        public string Collapsed() => "collapsed";

        public string ListGroup() => "list-group";
        public string ListGroupFlush() => "list-group-flush";
        public string ListGroupItem() => "list-group-item";
        public string ListGroupItemActive() => Active();
        public string ListGroupItemDisabled() => Disabled();

        public string Container() => "container";
        public string ContainerFluid() => "container-fluid";

        public string Bar() => "navbar";
        public string BarBackground(Background background) => BackgroundColor(background);
        public string BarAlignment(Alignment alignment) => FlexAlignment(alignment);
        public string BarBreakpoint(Breakpoint breakpoint) => $"navbar-expand-{ToBreakpoint(breakpoint)}";
        public string BarItem() => "nav-item";
        public string BarItemActive() => Active();
        public string BarItemDisabled() => Disabled();
        public string BarItemHasDropdown() => "dropdown";
        public string BarItemHasDropdownShow() => Show();
        public string BarLink() => "nav-link";
        public string BarLinkDisabled() => Disabled();
        public string BarCollapse() => "navbar-collapse";
        
        public string BarBrand() => "navbar-brand";
        public string BarToggler() => "navbar-toggler";
        public string BarTogglerCollapsed(bool isShow) => isShow ? null : "collapsed";
        public string BarMenu() => "collapse navbar-collapse";
        public string BarMenuShow() => Show();
        public string BarStart() => "navbar-nav mr-auto";
        public string BarEnd() => "navbar-nav";

        //public string BarHasDropdown() => "dropdown";

        public string BarDropdown() => null;
        public string BarDropdownShow() => null;
        public string BarDropdownToggle() => "nav-link dropdown-toggle";
        public string BarDropdownItem() => "dropdown-item";
        public string BarTogglerIcon() => "navbar-toggler-icon";
        public string BarDropdownMenu() => "dropdown-menu";
        public string BarDropdownMenuVisible(bool visible) => visible ? Show() : null;
        public string BarDropdownMenuRight() => "dropdown-menu-right";

        public string Accordion() => "accordion";
        
        public string Collapse() => "card";
        public string CollapseActive(bool active) => null;
        public string CollapseHeader() => "card-header";
        public string CollapseBody() => "collapse";
        public string CollapseBodyActive(bool active) => active ? Show() : null;
        public string CollapseBodyContent() => "card-body";

        public string CardGroup() => "card-group";
        
        public string Card() => "xf-card";
        public string CardHeader() => "xf-header";
        public string CardHeaderText() => "xf-header-text";
        public string CardHeaderTextBorder(bool showBorder) => "xf-header-border";

        public string CardBody() => "xf-body";
        public string CardFooter() => "xf-footer";
        

        public string CardWhiteText() => "text-white";
        public string CardBackground(Background background) => BackgroundColor(background);
        public string CardActions() => "card-actions";
       
        public string CardImage() => "card-img-top";
        public string CardTitle(bool insideHeader) => "card-title";
        public string CardTitleSize(bool insideHeader, int? size) => null;
        public string CardSubtitle(bool insideHeader) => "card-subtitle";
        public string CardSubtitleSize(bool insideHeader, int size) => null;
        public string CardText() => "card-text";
        public string CardLink() => "card-link";

        public string Alert() => "alert";
        public string AlertColor(Color color) => $"{Alert()}-{ToColor(color)}";
        public string AlertDismisable() => "alert-dismissible";
        public string AlertFade() => Fade();
        public string AlertShow() => Show();
        public string AlertHasMessage() => null;
        public string AlertHasDescription() => null;
        public string AlertMessage() => null;
        public string AlertDescription() => null;

        public string Modal() => "modal";
        public string ModalFade() => Fade();
        public string ModalVisible(bool visible) => visible ? Show() : null;
        public string ModalBackdrop() => "modal-backdrop";
        public string ModalBackdropFade() => Fade();
        public string ModalBackdropVisible(bool visible) => visible ? Show() : null;
        public string ModalContent(bool dialog) => "modal-content";
        public string ModalContentSize(ModalSize modalSize) => $"modal-{ToModalSize(modalSize)}";
        public string ModalContentCentered() => "modal-dialog-centered";
        public string ModalBody() => "modal-body";
        public string ModalHeader() => "modal-header";
        public string ModalFooter() => "modal-footer";
        public string ModalTitle() => "modal-title";

        public string Pagination() => "pagination";
        public string PaginationSize(Size size) => $"{Pagination()}-{ToSize(size)}";
        public string PaginationItem() => "page-item";
        public string PaginationItemActive() => Active();
        public string PaginationItemDisabled() => Disabled();
        public string PaginationLink() => "page-link";
        public string PaginationLinkActive() => null;
        public string PaginationLinkDisabled() => null;

        public string Progress() => "progress";
        public string ProgressSize(Size size) => $"progress-{ToSize(size)}";
        public string ProgressBar() => "progress-bar";
        public string ProgressBarColor(Background background) => BackgroundColor(background);
        public string ProgressBarStriped() => "progress-bar-striped";
        public string ProgressBarAnimated() => "progress-bar-animated";
        public string ProgressBarWidth(int width) => $"w-{width}";

        public string Chart() => null;

        public string BackgroundColor(Background color) => $"bg-{ToBackground(color)}";

        public string Title() => null;
        public string TitleSize(int size) => $"h{size}";

        public string Table() => "table";
        public string TableFullWidth() => null;
        public string TableStriped() => "table-striped";
        public string TableHoverable() => "table-hover";
        public string TableBordered() => "table-bordered";
        public string TableNarrow() => "table-sm";
        public string TableBorderless() => "table-borderless";
        public string TableHeader() => null;
        public string TableHeaderCell() => null;
        public string TableFooter() => null;
        public string TableBody() => null;
        public string TableRow() => null;
        public string TableRowColor(Color color) => $"table-{ToColor(color)}";
        public string TableRowBackground(Background background) => BackgroundColor(background);
        public string TableRowTextColor(TextColor textColor) => $"text-{ToTextColor(textColor)}";
        public string TableRowHoverCursor() => "table-row-selectable";
        public string TableRowIsSelected() => "selected";
        public string TableRowHeader() => null;
        public string TableRowCell() => null;
        public string TableRowCellColor(Color color) => $"table-{ToColor(color)}";
        public string TableRowCellBackground(Background background) => BackgroundColor(background);
        public string TableRowCellTextColor(TextColor textColor) => $"text-{ToTextColor(textColor)}";
        public string TableRowCellTextAlignment(TextAlignment textAlignment) => $"text-{ToTextAlignment(textAlignment)}";

        public string Breadcrumb() => "breadcrumb";
        public string BreadcrumbItem() => "breadcrumb-item";
        public string BreadcrumbItemActive() => Active();
        public string BreadcrumbLink() => null;

        public string Row() => "row";
        public string Col() => "col";

        public string Col(ColumnWidth columnWidth, Breakpoint breakpoint, bool offset)
        {
            var baseClass = offset ? "offset" : Col();

            if (breakpoint != Breakpoint.None)
            {
                if (columnWidth == ColumnWidth.None)
                    return $"{baseClass}-{ToBreakpoint(breakpoint)}";

                return $"{baseClass}-{ToBreakpoint(breakpoint)}-{ToColumnWidth(columnWidth)}";
            }

            //if ( columnWidth == ColumnWidth.Auto )
            //    return $"{baseClass}";

            return $"{baseClass}-{ToColumnWidth(columnWidth)}";
        }
        public string Col(ColumnWidth columnWidth, IEnumerable<(Breakpoint breakpoint, bool offset)> rules) => string.Join(" ", rules.Select(r => Col(columnWidth, r.breakpoint, r.offset)));

        #region Enums

        public virtual string ToTextAlignment(TextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case TextAlignment.Left:
                    return "left";
                case TextAlignment.Center:
                    return "center";
                case TextAlignment.Right:
                    return "right";
                case TextAlignment.Justified:
                    return "justify";
                default:
                    return null;
            }
        }

        public string ButtonSize(ButtonSize buttonSize)
        {
            switch (buttonSize)
            {
                case Common.ButtonSize.Small:
                    return "btn-sm";
                case Common.ButtonSize.Large:
                    return "btn-lg";
                default:
                    return null;
            }
        }

        public string DropdownDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return "dropup";
                case Direction.Right:
                    return "dropright";
                case Direction.Left:
                    return "dropleft";
                case Direction.Down:
                case Direction.None:
                default:
                    return null;
            }
        }

        public string DropdownToggleSize(ButtonSize buttonSize)
        {
            switch (buttonSize)
            {
                case Common.ButtonSize.Small:
                    return "btn-sm";
                case Common.ButtonSize.Large:
                    return "btn-lg";
                default:
                    return null;
            }
        }

        public string ToSize(Size size)
        {
            switch (size)
            {
                case Size.ExtraSmall:
                    return "xs";
                case Size.Small:
                    return "sm";
                case Size.Medium:
                    return "md";
                case Size.Large:
                    return "lg";
                case Size.ExtraLarge:
                    return "xl";
                default:
                    return null;
            }
        }

        public string ButtonsSize(ButtonsSize buttonsSize)
        {
            switch (buttonsSize)
            {
                case Common.ButtonsSize.Small:
                    return "btn-group-sm";
                case Common.ButtonsSize.Large:
                    return "btn-group-lg";
                default:
                    return null;
            }
        }

        public virtual string ToColumnWidth(ColumnWidth columnWidth)
        {
            switch (columnWidth)
            {
                case ColumnWidth.Is1:
                    return "1";
                case ColumnWidth.Is2:
                    return "2";
                case ColumnWidth.Is3:
                case ColumnWidth.Quarter:
                    return "3";
                case ColumnWidth.Is4:
                case ColumnWidth.Third:
                    return "4";
                case ColumnWidth.Is5:
                    return "5";
                case ColumnWidth.Is6:
                case ColumnWidth.Half:
                    return "6";
                case ColumnWidth.Is7:
                    return "7";
                case ColumnWidth.Is8:
                    return "8";
                case ColumnWidth.Is9:
                    return "9";
                case ColumnWidth.Is10:
                    return "10";
                case ColumnWidth.Is11:
                    return "11";
                case ColumnWidth.Is12:
                case ColumnWidth.Full:
                    return "12";
                case ColumnWidth.Auto:
                    return "auto";
                default:
                    return null;
            }
        }

        public string ToTextBoxSize(TextBoxSize size)
        {
            switch (size)
            {
                case TextBoxSize.Small:
                    return "sm";
                case TextBoxSize.Large:
                    return "lg";
                default:
                    return null;
            }
        }

        public string ToColor(Color color)
        {
            switch (color)
            {
                case Color.Primary:
                    return "primary";
                case Color.Secondary:
                    return "secondary";
                case Color.Success:
                    return "success";
                case Color.Danger:
                    return "danger";
                case Color.Warning:
                    return "warning";
                case Color.Info:
                    return "info";
                case Color.Light:
                    return "light";
                case Color.Dark:
                    return "dark";
                case Color.Link:
                    return "link";
                default:
                    return null;
            }
        }

        public string ToTextColor(TextColor textColor)
        {
            switch (textColor)
            {
                case Common.TextColor.Primary:
                    return "primary";
                case Common.TextColor.Secondary:
                    return "secondary";
                case Common.TextColor.Success:
                    return "success";
                case Common.TextColor.Danger:
                    return "danger";
                case Common.TextColor.Warning:
                    return "warning";
                case Common.TextColor.Info:
                    return "info";
                case Common.TextColor.Light:
                    return "light";
                case Common.TextColor.Dark:
                    return "dark";
                case Common.TextColor.Body:
                    return "body";
                case Common.TextColor.Muted:
                    return "muted";
                case Common.TextColor.White:
                    return "white";
                case Common.TextColor.Black50:
                    return "black-50";
                case Common.TextColor.White50:
                    return "white-50";
                default:
                    return null;
            }
        }

        public string ToValidationStatus(ValidationStatus validationStatus)
        {
            switch (validationStatus)
            {
                case ValidationStatus.Success:
                    return "is-valid";
                case ValidationStatus.Error:
                    return "is-invalid";
                default:
                    return null;
            }
        }

        public string ToCursor(Cursor cursor)
        {
            switch (cursor)
            {
                case Cursor.Pointer:
                    return "pointer";
                default:
                    return null;
            }
        }

        public virtual string ToBackground(Background color)
        {
            switch (color)
            {
                case Background.Primary:
                    return "primary";
                case Background.Secondary:
                    return "secondary";
                case Background.Success:
                    return "success";
                case Background.Danger:
                    return "danger";
                case Background.Warning:
                    return "warning";
                case Background.Info:
                    return "info";
                case Background.Light:
                    return "light";
                case Background.Dark:
                    return "dark";
                case Background.White:
                    return "white";
                case Background.Transparent:
                    return "transparent";
                default:
                    return null;
            }
        }

        public virtual string ToAlignment(Alignment alignment)
        {
            switch (alignment)
            {
                case Alignment.Start:
                    return "start";
                case Alignment.Center:
                    return "center";
                case Alignment.End:
                    return "end";
                default:
                    return null;
            }
        }

        public virtual string ToModalSize(ModalSize modalSize)
        {
            switch (modalSize)
            {
                case ModalSize.Small:
                    return "sm";
                case ModalSize.Large:
                    return "lg";
                case ModalSize.ExtraLarge:
                    return "xl";
                case ModalSize.Default:
                default:
                    return null;
            }
        }

        public virtual string ToBreakpoint(Breakpoint breakpoint)
        {
            switch (breakpoint)
            {
                case Breakpoint.Mobile:
                    return "xs";
                case Breakpoint.Tablet:
                    return "sm";
                case Breakpoint.Desktop:
                    return "md";
                case Breakpoint.Widescreen:
                    return "lg";
                case Breakpoint.FullHD:
                    return "xl";
                default:
                    return null;
            }
        }

        public string FlexAlignment(Alignment alignment) => $"justify-content-{ToAlignment(alignment)}";

        #endregion
    }
}
