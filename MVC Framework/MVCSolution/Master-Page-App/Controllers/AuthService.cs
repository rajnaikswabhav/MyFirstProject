using Master_Page_App.Models.ViewModel;

namespace Master_Page_App.Controllers
{
    public class AuthService
    {
        public bool CheckUser(UserVM vm)
        {
            if(vm.Username.Equals("admin") && vm.Password.Equals("admin"))
            {
                return true;
            }
            return false;
        }
    }
}