namespace Dotnext.Application.Services.Interfaces
{
    public class ObjectAccessLevel
    {
        public string UserId { get; set; }

        public int ObjectId { get; set; }

        public ObjectType ObjectType { get; set; }

        public AccessLevel AccessLevel { get; set; }
    }
}
