using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Mango.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetRequestIp(this HttpContext httpContext)
        {
            string ip = null;

            ip = httpContext?.Request?.Host.Host;
            
            if (string.IsNullOrWhiteSpace(ip))
            {
                // todo support new "Forwarded" header (2014) https://en.wikipedia.org/wiki/X-Forwarded-For

                // X-Forwarded-For (csv list):  Using the First entry in the list seems to work
                // for 99% of cases however it has been suggested that a better (although tedious)
                // approach might be to read each IP from right to left and use the first public IP.
                // http://stackoverflow.com/a/43554000/538763
                ip = GetHeaderValueAs<string>("X-Forwarded-For", httpContext).SplitCsv().FirstOrDefault();
            }

            // RemoteIpAddress is always null in DNX RC1 Update1 (bug).
            if (string.IsNullOrWhiteSpace(ip) && httpContext?.Connection?.RemoteIpAddress != null)
            {
                ip = httpContext.Connection.RemoteIpAddress.ToString();
            }

            if (string.IsNullOrWhiteSpace(ip))
            {
                ip = GetHeaderValueAs<string>("REMOTE_ADDR", httpContext);
            }
            
            if (string.IsNullOrWhiteSpace(ip))
            {
                throw new Exception("Unable to determine caller's IP.");
            }

            return ip;
        }

        private static T GetHeaderValueAs<T>(string headerName, HttpContext httpContext)
        {
            var values = new StringValues();

            if (!(httpContext?.Request?.Headers?.TryGetValue(headerName, out values) ?? false))
            {
                return default(T);
            }
            
            var rawValues = values.ToString();   // writes out as Csv when there are multiple.

            if (!string.IsNullOrWhiteSpace(rawValues))
            {
                return (T) Convert.ChangeType(values.ToString(), typeof(T));
            }

            return default(T);
        }

        private static List<string> SplitCsv(this string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
            {
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();
            }

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable<string>()
                .Select(s => s.Trim())
                .ToList();
        }
    }
}