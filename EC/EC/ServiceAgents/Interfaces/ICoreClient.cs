namespace EC.ServiceAgents.Interfaces
{
    public interface ICoreClient
    {
        IFieldsService FieldsService{ get; }

        IAccountService AccountService { get; }
        
        void Refresh();
    }
}
