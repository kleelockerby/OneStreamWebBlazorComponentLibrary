using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneStream.Shared.Common;

namespace OneStreamWebBlazor.Client.State
{
    public class StateManager
    {
        private SessionInfo sessionInfo = new SessionInfo();
        public event EventHandler StateChanged;

        public SessionInfo GetSessionInfo()
        {
            return this.sessionInfo;
        }

        public void SetSessionInfo(SessionInfo sessionInfoToSet)
        {
            this.sessionInfo = sessionInfoToSet;
            StateHasChanged();
        }

        public void ResetSessionInfo()
        {
            this.sessionInfo = new SessionInfo();
            StateHasChanged();
        }

        private void StateHasChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
