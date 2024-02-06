namespace Redis.Business.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreateAt {get; set;}
    }
}