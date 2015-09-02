namespace EC.Client.Core.ServiceAgents.Interfaces
{
    public interface ICoreClient
    {
        IFieldsService FieldsService{ get; }

        
        void Refresh();
    }
}
