namespace WeddingManager.Core.Data
{
    public class Service
    {
        public Service(int id, string description)
        {
            Id = id;

            Description = description;
        }

        public int Id { get; private set; }

        public string Description { get; private set; }
    }
}