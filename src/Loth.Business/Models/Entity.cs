namespace AppLothMVC.Models
{
    //Entidade abstrata pq deve ser herdada e não instanciada 
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
