namespace Entitiy.Models
{
    public class BaseEntity
    {

        public Guid ID { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public Boolean IsActive { get; set; }


        public BaseEntity()
        {
            
            ID = Guid.NewGuid();
            CreatedTime = DateTime.Now;
            IsActive = true;


        }
    }



}
