using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}