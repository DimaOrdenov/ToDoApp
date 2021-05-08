namespace ToDoApp.Definitions.Entities
{
    public class Issue : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }
    }
}
