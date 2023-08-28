using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walter.Core.DTO_s.Post
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FullText { get; set; } = string.Empty;
        public string PublishDate { get; set; } = string.Empty;
        private string? _imagePath;
        public string? ImagePath
        {
            get => _imagePath;
            set => _imagePath = value ?? defaultPath;
        }
        const string defaultPath = "Default.png";
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public IFormFileCollection File { get; set; }
        public string Slug => Title?
            .Replace("а", "a")
            .Replace("б", "b")
            .Replace("в", "v")
            .Replace("г", "g")
            .Replace("д", "d")
            .Replace("е", "e")
            .Replace("є", "e")
            .Replace("ё", "e")
            .Replace("ж", "j")
            .Replace("з", "z")
            .Replace("и", "i")
            .Replace("ї", "yi")
            .Replace("й", "i")
            .Replace("к", "k")
            .Replace("л", "l")
            .Replace("м", "m")
            .Replace("н", "n")
            .Replace("о", "o")
            .Replace("п", "p")
            .Replace("р", "r")
            .Replace("с", "s")
            .Replace("т", "t")
            .Replace("у", "u")
            .Replace("ф", "f")
            .Replace("х", "h")
            .Replace("ц", "c")
            .Replace("ч", "ch")
            .Replace("ш", "sh")
            .Replace("щ", "shch")
            .Replace("ы", "y")
            .Replace("э", "e")
            .Replace("ю", "u")
            .Replace("я", "ya")
            .Replace(":", "-")
            .Replace(" ", "-").ToLower().ToString() + ".html";
    }
}
