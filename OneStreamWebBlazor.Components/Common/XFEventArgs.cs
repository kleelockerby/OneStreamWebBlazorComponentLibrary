using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using OneStreamWebBlazor.Components.Components;

namespace OneStreamWebBlazor.Components.Common
{
    public class ModalStateEventArgs : EventArgs
    {
        public ModalStateEventArgs(bool visible)
        {
            Visible = visible;
        }
        public bool Visible { get; }
    }

    public class ModalClosingEventArgs : CancelEventArgs
    {
        public ModalClosingEventArgs(bool cancel, CloseReason closeReason) : base(cancel)
        {
            CloseReason = closeReason;
        }
        public CloseReason CloseReason { get; }
    }

    public class AlertStateEventArgs : EventArgs
    {
        public AlertStateEventArgs(bool visible)
        {
            Visible = visible;
        }
        public bool Visible { get; }
    }

    public class DropdownStateEventArgs : EventArgs
    {
        public DropdownStateEventArgs(bool visible)
        {
            Visible = visible;
        }
        public bool Visible { get; }
    }

    public class RadioCheckedChangedEventArgs<TValue> : EventArgs
    {
        public RadioCheckedChangedEventArgs(TValue value)
        {
            Value = value;
        }
        public TValue Value { get; }
    }

}

