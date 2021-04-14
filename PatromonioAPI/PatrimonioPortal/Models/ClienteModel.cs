namespace PatrimonioPortal.Models
{
    public class ClienteModel : BaseModel
    {
        public string Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Documento { get; set; }
        public bool Ativo { get; set; }
    }
}
