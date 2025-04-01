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

    public async Task<Usuario?> LoginAsync(string username, string password)
    {
        var loginRequest = new LoginRequest { Username = username, Password = password };
        var response = await _http.PostAsJsonAsync("api/auth/login", loginRequest);

        Console.WriteLine($"Resposta do login: {response.StatusCode}");

        if (response.IsSuccessStatusCode)
        {
            var usuario = await response.Content.ReadFromJsonAsync<Usuario>();
            IsAuthenticated = true;
            UsuarioAtual = usuario;
            return usuario;
        }

        IsAuthenticated = false;
        UsuarioAtual = null;
        return null;
    }
    public async Task<bool> CriarTarefaAsync(Tarefa novaTarefa)
    {
        var tarefaDto = new
        {
            novaTarefa.Titulo,
            novaTarefa.Descricao,
            novaTarefa.DataEntrega,
            novaTarefa.Dificuldade,
            novaTarefa.ResponsavelId,
            Concluida = false // sempre começa como falso
        };

        var response = await _http.PostAsJsonAsync("api/tarefas", tarefaDto);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<Usuario>> GetUsuariosAsync()
    {
        var response = await _http.GetFromJsonAsync<List<Usuario>>("api/auth/usuarios");
        return response ?? new List<Usuario>();
    }

    public async Task<List<Tarefa>> GetTarefasAsync(int idUsuario)
    {
        var response = await _http.GetFromJsonAsync<List<Tarefa>>($"api/tarefas?idUsuario={idUsuario}");
        return response ?? new List<Tarefa>();
    }
    public async Task<bool> UpdateTarefaAsync(Tarefa tarefa)
    {
        var tarefaDto = new
        {
            tarefa.Id,
            tarefa.Titulo,
            tarefa.Descricao,
            tarefa.DataEntrega,
            tarefa.Dificuldade,
            tarefa.Concluida,
            tarefa.ResponsavelId
        };

        var response = await _http.PutAsJsonAsync($"api/tarefas/{tarefa.Id}", tarefaDto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteTarefaAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/tarefas/{id}");
        return response.IsSuccessStatusCode;
    }

}
