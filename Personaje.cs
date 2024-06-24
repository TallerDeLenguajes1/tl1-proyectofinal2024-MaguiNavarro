using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;

namespace PersonajeApi
{
    public class Character
{ 
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

 
}
}


