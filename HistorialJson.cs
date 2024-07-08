using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Historial
{
    public static class HistorialJson
    {
        public static void GuardarDatos(object datos, string nombreArchivo)
        {
            string json = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(nombreArchivo, json);
        }

        public static T LeerDatos<T>(string nombreArchivo)
        {
            string json = File.ReadAllText(nombreArchivo);
            return JsonSerializer.Deserialize<T>(json);
        }


    public static bool Existe(string nombreArchivo)
    {
        // Verificar si el archivo existe y tiene datos
        return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
    }
    }
}