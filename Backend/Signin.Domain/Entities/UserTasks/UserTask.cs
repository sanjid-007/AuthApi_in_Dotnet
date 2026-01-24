using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace Signin.Domain.Entities.UserTasks
{
    public class UserTask
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Priority { get; set; }

        public UserTaskStatus Status { get; set; }


    }
    public enum UserTaskStatus
    {
        Todo = 1,
        InProgress = 2,
        Complete = 3

    }
}
