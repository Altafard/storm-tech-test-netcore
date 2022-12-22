namespace Todo.Models.TodoItems
{
    public class UserSummaryViewmodel
    {
        public string UserName { get; }
        public string Email { get; }
        public string DisplayName { get; }

        public UserSummaryViewmodel(string userName, string email, string displayName)
        {
            UserName = userName;
            Email = email;
            DisplayName = displayName;
        }
    }
}