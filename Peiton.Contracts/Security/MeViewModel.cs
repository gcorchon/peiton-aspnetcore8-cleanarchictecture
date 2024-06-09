namespace Peiton.Contracts.Security
{
    public class MeViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }    
        public required IEnumerable<int> Permissions { get; set; }
    }
}
