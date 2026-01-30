using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ElorMAUI.Components.Model;
using Microsoft.Maui.Storage;

namespace ElorMAUI.Services
{
    public class IkastetxeService
    {
        public List<Centro> Centros { get; private set; } = new List<Centro>();

        public async Task LoadCentrosAsync()
        {
            if (Centros != null && Centros.Any())
                return; // Ya cargados

            try
            {
                var path = Path.Combine(FileSystem.AppDataDirectory, "ikastetxeak.json");
                if (File.Exists(path))
                {
                    var jsonFromFile = await File.ReadAllTextAsync(path);
                    if (!string.IsNullOrWhiteSpace(jsonFromFile) && jsonFromFile.TrimStart().StartsWith("["))
                    {
                        Centros = System.Text.Json.JsonSerializer.Deserialize<List<Centro>>(jsonFromFile) ?? new List<Centro>();
                        return;
                    }
                }
                else 
                { 
                    using var stream = await FileSystem.OpenAppPackageFileAsync("ikastetxeak.json");
                    using var reader = new StreamReader(stream);
                    var json = await reader.ReadToEndAsync();

                    if (!string.IsNullOrWhiteSpace(json) && json.TrimStart().StartsWith("["))
                    {
                        Centros = System.Text.Json.JsonSerializer.Deserialize<List<Centro>>(json) ?? new List<Centro>();
                    }
                    else
                    {
                        Centros = new List<Centro>();
                    }
                }
            }
            catch
            {
                Centros = new List<Centro>();
            }
        }

        public async Task GuardarCentros() 
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, "ikastetxeak.json");
            var json = JsonSerializer.Serialize(Centros, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(path, json);
        }

        public async Task GuardarCentro(Centro centro) 
        {
            if (!centro.CCEN.HasValue)
            {
                centro.CCEN = (Centros.Max(c => c.CCEN) ?? 0) + 1;
                Centros.Add(centro);
            }
            else 
            { 
                var index = Centros.FindIndex(c => c.CCEN == centro.CCEN);
                if (index >= 0)
                {
                    Centros[index] = centro;
                }
            }
            await GuardarCentros();
        }

        public async void EliminarCentro(int ccen)
        {
            var centro = Centros.FirstOrDefault(c => c.CCEN == ccen);
            if (centro != null)
            {
                Centros.Remove(centro);
                await GuardarCentros();
            }
        }

    }
}
