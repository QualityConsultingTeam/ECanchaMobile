namespace EC.ServiceAgents
{
    using EC.DocumentResponse;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using Web;


    internal class FieldsService : BaseRequest, IFieldsService
    {
        public FieldsService(string urlPrefix, string securityToken)
            : base(urlPrefix, securityToken)
        {

        } 
        public async Task<List<Field>> GetFields()
        {
            string url = String.Format(CultureInfo.InvariantCulture
              , "{0}/api/canchas", _urlPrefix);

            return await base.GetAsync<List<Field>>(url);
        }

        public async Task<List<Field>> GetFields(FilterOptionModel filter)
        {
            string url = String.Format(CultureInfo.InvariantCulture
               , "{0}/api/canchas", _urlPrefix);

            return await base.PostAsync<FilterOptionModel,List<Field>>(url,filter);
        }

    }
}
