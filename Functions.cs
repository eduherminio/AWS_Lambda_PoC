using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

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
        public static async Task<string> EchoPlusBookRecommendation(string input, ILambdaContext context)
        {
            var sb = new StringBuilder(input?.ToUpperInvariant());
            sb.Append("   ");

            var client = new HttpClient();
            var result = await client.GetAsync("https://openlibrary.org/api/books?bibkeys=OLID:OL629052W");
            sb.Append(await result.Content.ReadAsStringAsync());

            return sb.ToString();
        }
    }
}
