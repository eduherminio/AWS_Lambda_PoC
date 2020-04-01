using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace TestLambda
{
    public static class Functions
    {
        /// <summary>
        /// A simple function that takes a string, does a ToUpper of the input
        /// and appends some random info from https://openlibrary.org
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<string> ToUpperPlusBookRecommendation(string input, ILambdaContext context)
        {
            var sb = new StringBuilder(input?.ToUpperInvariant());
            sb.Append("   ");

            var client = new HttpClient();
            var result = await client.GetAsync("https://openlibrary.org/api/books?bibkeys=OLID:OL5917940M");
            sb.Append(await result.Content.ReadAsStringAsync());

            return sb.ToString();
        }
    }
}
