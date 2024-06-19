using Microsoft.JSInterop;
using System.Text.Json;

namespace ToDoList.App
{
    public class LocalStorageAccessor : IAsyncDisposable
    {
        // Tots els metodes asincrons tornen una Task
        public async Task<T> GetValueAsync<T>(string key)
        {
            await WaitForReference();
            var jsonResult = await _accesorJsRef.Value.InvokeAsync<string>("get", key);
            var result = JsonSerializer.Deserialize<T>(jsonResult);
            return result;
        }

        public async Task SetValueAsync<T>(string key, T value)
        {
            await WaitForReference();
            string jsonValue = JsonSerializer.Serialize(value);
            await _accesorJsRef.Value.InvokeVoidAsync("set", key, jsonValue);
        }

         public async Task RemoveValueAsync(string key)
        {
            await WaitForReference();
            await _accesorJsRef.Value.InvokeVoidAsync("remove",key);
        }

         public async Task ClearAsync()
        {
            await WaitForReference();
            await _accesorJsRef.Value.InvokeVoidAsync("clear");
        }

        // Els Lazy serveixen per allibera carrega, en el moment que es necessiti ho creara
        private Lazy<IJSObjectReference> _accesorJsRef = new();
        private readonly IJSRuntime _jsRuntime;

        public LocalStorageAccessor(IJSRuntime jsRuntime) 
        {
            _jsRuntime = jsRuntime;
        }

        // Un async és un métode que s'executa però no sabem quan retornara el valor, s'executa en un altre fil
        private async Task WaitForReference() {
            if (!_accesorJsRef.IsValueCreated)
            {
                _accesorJsRef = new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import","/js/LocalStorageAccessor.js"));
            }
        }
        
        // DisposeAsync és per dir-li al garbage collector que abans de borrar una instancia faci el que posem al body del metode
        public async ValueTask DisposeAsync()
        {
            if (_accesorJsRef.IsValueCreated)
            {
                await _accesorJsRef.Value.DisposeAsync();
            }

        }
    }
}