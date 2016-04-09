using System;
using Silanis.ESL.API;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class SigningService
    {
        private readonly UrlTemplate _template;
        private readonly RestClient _restClient;

        public SigningService(RestClient restClient, string baseUrl)
        {
            _template = new UrlTemplate( baseUrl );
            _restClient = restClient;
        }

        internal void SignDocument( PackageId packageId, API.Document document ) 
        {
            var path = _template.UrlFor( UrlTemplate.SIGN_DOCUMENT_PATH )
                .Replace("{packageId}", packageId.Id)
                .Build();

            try 
            {
                var json = Json.SerializeWithSettings(document);
                _restClient.Post( path, json );
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not sign document." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not sign document." + " Exception: " + e.Message, e);
            }
        }

        internal void SignDocuments( PackageId packageId, SignedDocuments documents ) 
        {
            var path = _template.UrlFor( UrlTemplate.SIGN_DOCUMENTS_PATH )
                .Replace("{packageId}", packageId.Id)
                .Build();

            try 
            {
                var json = Json.SerializeWithSettings(documents);
                _restClient.Post( path, json );
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not sign documents." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not sign documents." + " Exception: " + e.Message, e);
            }
        }

        internal void SignDocuments( PackageId packageId, SignedDocuments documents, string signerSessionId ) 
        {
            var path = _template.UrlFor( UrlTemplate.SIGN_DOCUMENTS_PATH )
                .Replace("{packageId}", packageId.Id)
                .Build();

            try 
            {
                var json = Json.SerializeWithSettings(documents);
                _restClient.Post( path, json, signerSessionId );
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not sign documents." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not sign documents." + " Exception: " + e.Message, e);
            }
        }
    }
}

