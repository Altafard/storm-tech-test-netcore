namespace Todo.Services.Gravatar
{
    public class GravatarProfile
    {
        public GravatarEntry[] Entry { get; set; }

        public class GravatarEntry
        {
            public string DisplayName { get; set; }
        }
    }
}