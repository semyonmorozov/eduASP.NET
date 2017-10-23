using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HW1
{
    public class MyMW
    {
        private readonly RequestDelegate _next;

        public MyMW(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.WriteAsync("\t\tThis text from MW class. \n");
            Stopwatch st = new Stopwatch();
            st.Start();
            await _next(context);
            st.Stop();
            context.Response.WriteAsync("\t\tDelay calculated in MW class: " + st.Elapsed.ToString() + "\n");
        }
    }
    public static class MyMWExtensions
    {
        public static IApplicationBuilder UseMyMW(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMW>();
        }
    }
}
