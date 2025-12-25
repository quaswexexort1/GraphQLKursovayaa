using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using ModernHttpClient;
using Newtonsoft.Json;

namespace GraphQLClientKursovayaa.DataAccess
{
    public class Mutation
    {
        private static GraphQLHttpClient? graphQLHttpClient;
        static Mutation()
        {
            var uri = new Uri("https://localhost:7271/graphql");
            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = uri,
                HttpMessageHandler = new NativeMessageHandler(),
            };
            graphQLHttpClient = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());
        }
        public static async Task<T> ExceuteMutationAsyn<T>(string graphQLQueryType, string completeQueryString)
        {
            var request = new GraphQLRequest
            {
                Query = completeQueryString
            };

            // если сервер отдаёт { "data": { "updateCase": { ... } } }
            // то T должен соответствовать СТРУКТУРЕ data
            var response = await graphQLHttpClient!.SendMutationAsync<T>(request);

            if (response == null)
                throw new Exception($"GraphQL: пустой ответ для '{graphQLQueryType}'.");

            if (response.Errors != null && response.Errors.Length > 0)
                throw new Exception($"GraphQL error: {response.Errors[0].Message}");

            if (response.Data == null)
                throw new Exception($"GraphQL: Data == null для '{graphQLQueryType}'.");

            return response.Data;
        }

    }
}