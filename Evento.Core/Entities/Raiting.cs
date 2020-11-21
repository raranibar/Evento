namespace Evento.Core.Entities
{
    public partial class Raiting : BaseEntity
    {
        public int Rating { get; set; }
        public int IdEmprendedor { get; set; }
        public virtual Emprendedor IdEmprendedorNavigation { get; set; }
    }
}
