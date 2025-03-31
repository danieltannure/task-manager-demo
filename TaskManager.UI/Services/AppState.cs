using System;

namespace TaskManager.UI.Services;
public class AppState
{
    public bool IsAuthenticated { get; private set; } = false;

    public event Action? OnChange;

    public void SetAuthentication(bool value)
    {
        IsAuthenticated = value;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
