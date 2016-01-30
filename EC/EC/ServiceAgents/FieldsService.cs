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
			try{
            string url = String.Format(CultureInfo.InvariantCulture
              , "{0}/api/canchas", _urlPrefix);

				return await base.GetAsync<List<Field>>(url);
			}
			catch(Exception ex) 
			{
				return new List<Field> ();
			}
        }

        public async Task<List<Field>> GetFields(FilterOptionModel filter)
        {
			try{
            string url = String.Format(CultureInfo.InvariantCulture
               , "{0}/api/canchas", _urlPrefix);

            return await base.PostAsync<FilterOptionModel,List<Field>>(url,filter);
			}
			catch(Exception ex) {
				return new List<Field> ();
			}
        }

        public async Task<List<Field>> GetFields(string keywords, string lat, string lon)
        {
			try
			{
				
            string url = String.Format(CultureInfo.InvariantCulture
              , "{0}/api/canchas?keywords={1}", _urlPrefix, keywords);

				return await base.GetAsync<List<Field>>(url);
			}
			catch(Exception ex) 
			{
				return new List<Field> ();
			}
        }
    }
}
