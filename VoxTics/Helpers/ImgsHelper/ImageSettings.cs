namespace VoxTics.Helpers.ImgsHelper
{
    public class ImageSettings
    {
        // relative to wwwroot, no leading slash
        public string UploadsFolderMovies { get; set; } = "uploads/movies";
        public string UploadsFolderActors { get; set; } = "uploads/actors";
        public string UploadsFolderUsers { get; set; } = "uploads/users";
        public string UploadsFolderCinemas { get; set; } = "uploads/cinemas";

        public string DefaultMovieImage { get; set; } = "images/defaults/placeholder.png";
        public string DefaultActorImage { get; set; } = "images/defaults/avater.png";
        public string DefaultUserImage { get; set; } = "images/defaults/avater.png";
        public string DefaultCinemaImage { get; set; } = "images/defaults/placeholder.png";

        public long MaxFileSize { get; set; } = 5 * 1024 * 1024;
        public string[] AllowedExtensions { get; set; } = new[] { ".JPG", ".JPEG", ".PNG", ".GIF", ".BMP", ".WEBP", ".SVG" };
    }
}
