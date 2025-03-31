using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TaskManager.Shared;

namespace TaskManager.UI.Services;
public class AuthService
{
    private readonly HttpClient _http;
    public bool IsAuthenticated { get; private set; }
    public Usuario? UsuarioAtual { get; private set; }

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var loginRequest = new LoginRequest { Username = username, Password = password };
        var response = await _http.PostAsJsonAsync("api/auth/login", loginRequest);

        Console.WriteLine($"Resposta do login: {response.StatusCode}");

        if (response.IsSuccessStatusCode)
        {
            UsuarioAtual = await response.Content.ReadFromJsonAsync<Usuario>();
            IsAuthenticated = true;
            return true;
        }

        IsAuthenticated = false;
        return false;
    }

    public async Task<List<Tarefa>> GetTarefasAsync()
    {
        // Alteração da URL para corresponder à API
        var response = await _http.GetFromJsonAsync<List<Tarefa>>("https://localhost:7067/api/tarefas");
        return response ?? new List<Tarefa>();
    }
}
