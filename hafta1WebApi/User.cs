using System.ComponentModel.DataAnnotations.Schema;

namespace hafta1WebApi
{
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
      
    }
}
