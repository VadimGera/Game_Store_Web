using System.Collections;

namespace GameStore.Models
{
    public class StudioDev
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Game>? Games { get; set; }
    }
}
