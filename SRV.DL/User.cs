namespace SRV.DL
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserRoleCode { get; set; }
        public string Password { get; set; }=string.Empty;
        public RefUserRole RefUserRole { get; set; }
        public int ProgramId { get; set; }
        public Program Program { get; set; }
        public List<Student> Students { get; set; }

        //TODO: Yet to figure out how to limit only one Admin per department. Right now there is no such constraint. You can add any number of admins you want at program level.
    }
}
