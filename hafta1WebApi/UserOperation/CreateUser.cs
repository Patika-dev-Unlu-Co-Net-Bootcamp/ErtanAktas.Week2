using hafta1WebApi.DBOperations;
using System;
using System.Linq;

namespace hafta1WebApi.UserOperation
{
    public class CreateUser
    {
        public CreateUserModel Model { get; set; }
        private readonly UserDbContext _dbContext;

        public CreateUser(UserDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        
        public void Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.email == Model.email);

            if (user is not null)
            {
                throw new InvalidOperationException("User already in Records");

            }
            user = new User();

            user.email = Model.email;
            user.password = Model.password.Encryptor(); //Password şifrelenmiştir.

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            

        }

        public class CreateUserModel
        {
            public string email { get; set; }
            public string password { get; set; }
        }
    }
}
