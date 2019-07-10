using Primer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Primer.Controllers
{
    public class PageSizeController : ApiController, ICustomController
    {
        private static string TargetUrl = "http://apress.com";

        //[HttpGet]
        //public async Task<long> GetPageSize()
        //{
        //    WebClient wc = new WebClient();
        //    Stopwatch sw = Stopwatch.StartNew();
        //    byte[] apressData = await wc.DownloadDataTaskAsync(TargetUrl);
        //    Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
        //    return apressData.LongLength;
        ////}

        //public async Task<long> GetPageSize(CancellationToken cToken)
        //{
        //    WebClient wc = new WebClient();
        //    Stopwatch sw = Stopwatch.StartNew();
        //    List<long> results = new List<long>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (!cToken.IsCancellationRequested)
        //        {
        //            Debug.WriteLine("Making Request: {0}", i);
        //            byte[] apressData = await wc.DownloadDataTaskAsync(TargetUrl);
        //            results.Add(apressData.LongLength);
        //        }
        //        else
        //        {
        //            Debug.WriteLine("Cancelled");
        //            return 0;
        //        }
        //    }
        //    Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
        //    return (long)results.Average();
        //}

        public async Task<long> GetPageSize(CancellationToken cToken)
        {
            WebClient wc = new WebClient();
            Stopwatch sw = Stopwatch.StartNew();
            byte[] apressData = await wc.DownloadDataTaskAsync(TargetUrl);
            Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
            return apressData.LongLength;
        }
        public Task PostUrl(string newUrl, CancellationToken cToken)
        {
            TargetUrl = newUrl;
            return Task.FromResult<object>(null);
        }
    }
}
