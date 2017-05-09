using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XrmAPIProvider.Model
{
    internal class APICallConstants
    {
        /// <summary>
        /// KVPs for the header element
        /// </summary>
        internal class HttpRequestHeaders
        {
            internal const string BASE_ADDRESS_POSTFIX = "/api/data/v8.1/";
            internal const int TIME_OUT = 2;
            internal const string BEARER = "Bearer";
            internal const string ODATA_MAX_VERSION = "OData-MaxVersion";
            internal const string ODATA_VERSION = "OData-Version";
            internal const string ODATA_VERSION_VALUE = "4.0";
            internal const string JSON_RESPONSE_TYPE = "application/json";
            internal const string DEFAULT_AUTHORITY_URI = "https://login.windows.net/common";
        }

        internal class XrmSDKMessageName
        {
            internal const string WHO_AM_I = "WhoAmI"; //indeed :\

        }
            
    }
}
