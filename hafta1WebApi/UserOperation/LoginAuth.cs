using hafta1WebApi.DBOperations;
using System.Linq;

namespace hafta1WebApi.UserOperation
{
    public class LoginAuth
    {   
        public LoginUserModel Model { get; set; }
        private readonly UserDbContext _dbContext;

        public LoginAuth(UserDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        //Modelden gelen veriler ile db kayıtları eşlenip sonuç geri dödürülmüştür.
        public string Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.email == Model.email && x.password == Model.password.Encryptor());
            if(user == null)
            {
                return "Kullanıcı Bulunamamıştır.";
            }
            return "Başarılı bir şekilde giriş yaptınız";
           
        }
        //Kullanıcıdan gerekli alanları almak için böyle bir Model tasarlanmıştır.

        public class LoginUserModel
        {
            public string email { get; set; }
            public string password { get; set; }
        }
    }
}
