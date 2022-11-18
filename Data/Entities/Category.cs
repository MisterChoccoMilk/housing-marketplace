using marketplace.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace marketplace.Data.Entities
{
    public class Category : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string UserId { get; set; }
        public MarketplaceRestUser User { get; set; }       
    }
}
