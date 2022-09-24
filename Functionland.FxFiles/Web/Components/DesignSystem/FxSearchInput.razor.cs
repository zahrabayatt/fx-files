﻿using System.Threading;
using System.Timers;

namespace Functionland.FxFiles.App.Components.DesignSystem
{
    public partial class FxSearchInput
    {

        private string? _inputText = string.Empty;
        private System.Timers.Timer? _timer;

        [Parameter, EditorRequired] public bool IsPartial { get; set; }
        [Parameter] public EventCallback<string?> OnSearch { get; set; }
        [Parameter] public double DebounceInterval { get; set; }

        private void HandleInput(ChangeEventArgs e)
        {
            var newValue = e.Value?.ToString();
            if (_inputText == newValue) return;

            _inputText = newValue;

            if (DebounceInterval == 0)
            {
                OnSearch.InvokeAsync(_inputText);
                return;
            }

            RestartTimer();
        }

        private void RestartTimer()
        {
            StopTimer();

            _timer = new System.Timers.Timer(DebounceInterval);
            _timer.Elapsed += TimerElapsed;
            _timer.Enabled = true;
            _timer.Start();
        }

        private void StopTimer()
        {
            if (_timer is null) return;

            _timer.Enabled = false;
            _timer.Elapsed -= TimerElapsed;
            _timer.Dispose();
            _timer = null;
        }

        private void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            StopTimer();
            OnSearch.InvokeAsync(_inputText);
        }
    }
}
