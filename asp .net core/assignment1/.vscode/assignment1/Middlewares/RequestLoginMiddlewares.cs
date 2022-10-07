using System.Diagnostics;

namespace assignment1.Middlewares
{
    public class RequestLoginMiddlewares
    {
        private readonly RequestDelegate _next;

        public RequestLoginMiddlewares(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var respond = context.Response;

            string requestInfo = "\tScheme: " + request.Scheme +
            "\r\tHost: " + request.Host +
            "\r\tPath: " + request.Path +
            "\r\tQuery String: " + request.QueryString +
            "\r\tBody: " + request.Body;

            Debug.Write(requestInfo);

            WriteFileStream("D:\\FILE_NAY_CHUA_JAV_VIDEO_4GB\\NashTech\\material\\week2day5\\assignment_1\\assignment1", "text.txt", requestInfo);

            await _next(context);
        }

        public static void WriteFileStream(string directoryPath, string fileName, string textContent)
        {
            using (var fileStream = new FileStream(Path.Combine(directoryPath, fileName), FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(textContent);
                }
            }
        }
    }
}
