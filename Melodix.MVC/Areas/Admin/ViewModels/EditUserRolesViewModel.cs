namespace Melodix.MVC.Areas.Admin.ViewModels
{
    public class EditUserRolesViewModel
    {

        public string UserId { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new();
        public List<string> SelectedRoles { get; set; } = new();

    }
}
