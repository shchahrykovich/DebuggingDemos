using Nancy;

namespace NancyMemoryLeak
{
    public class ExampleNancyModule : NancyModule
    {
        public ExampleNancyModule()
        {
            Get["/v1/feeds"] = parameters =>
            {
                var feeds = new string[] { "foo", "bar" };
                return Response.AsJson(feeds);
            };
        }
    }
}
