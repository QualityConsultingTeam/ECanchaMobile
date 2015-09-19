namespace EC.ServiceAgents.Interfaces
{
    public interface ICoreClient
    {
        IFieldsService FieldsService{ get; }

        
        void Refresh();
    }
}
