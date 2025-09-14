namespace VoxTics.Models.ViewModels.Actor
{
    public class ActorVM
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        private string? _fullName;
        public string FullName
        {
            get => _fullName ?? $"{FirstName} {LastName}".Trim();
            set => _fullName = value;
        }

        public string? Bio { get; set; }         
        public string? ImageUrl { get; set; }     // ProfileImage renamed to match entity
        public DateTime? DateOfBirth { get; set; }

        public int? Age => DateOfBirth.HasValue ?
                          DateTime.Today.Year - DateOfBirth.Value.Year -
                          (DateOfBirth.Value.Date > DateTime.Today.AddYears(-(DateTime.Today.Year - DateOfBirth.Value.Year)) ? 1 : 0)
                          : null;

        public string? CharacterName { get; set; }
        public bool IsLeadRole { get; set; }
    }
}
