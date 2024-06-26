using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;

namespace PersonajeApi
{
    public class Character
{ 
  //Datos
     [JsonPropertyName("id")]
    public int Id { get; set; }

     [JsonPropertyName("firstName")]
    public string FirstName { get; set; }
      [JsonPropertyName("lastName")]
    public string LastName { get; set; }
     [JsonPropertyName("fullName")]
    public string FullName { get; set; }
     [JsonPropertyName("title")]
    public string Title { get; set; }

     [JsonPropertyName("family")]
    public string Family { get; set; }
    
        // Características
        private int Velocidad;
       private int Destreza;
       private int Fuerza;
       private int Nivel;
       private int Armadura;
       private int Salud;
        public int Fuerza1 { get => Fuerza; set => Fuerza = value; }
        public int Nivel1 { get => Nivel; set => Nivel = value; }
        public int Armadura1 { get => Armadura; set => Armadura = value; }
        public int Salud1 { get => Salud; set => Salud = value; }
        public int Destreza1 { get => Destreza; set => Destreza = value; }
        public int Velocidad1 { get => Velocidad; set => Velocidad = value; }

  
   
   
    }
}


