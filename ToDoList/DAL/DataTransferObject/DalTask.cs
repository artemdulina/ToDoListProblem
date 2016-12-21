namespace DAL.DataTransferObject
{
    public class DalTask : IEntity
    {
        public int Id { get; set; }

        public bool IsCompleted { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }
    }
}
