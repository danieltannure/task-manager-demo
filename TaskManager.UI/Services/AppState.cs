using System;
using TaskManager.Shared;

namespace TaskManager.UI.Services;
public class AppState
{
    public bool IsAuthenticated { get; private set; } = false;
    public Usuario? UsuarioLogado { get; private set; }
    public bool IsAdmin => UsuarioLogado?.Id == 1;

    public event Action? OnChange;

    public void SetAuthentication(bool value)
    {
        IsAuthenticated = value;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();

    public void SetUsuario(Usuario usuario)
    {
        UsuarioLogado = usuario;
        IsAuthenticated = true;
    }

    public void LimparUsuario()
    {
        UsuarioLogado = null;
        IsAuthenticated = false;
    }
}
