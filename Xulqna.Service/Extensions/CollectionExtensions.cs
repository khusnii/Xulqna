using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xulqna.Domain.Configuration;
using Xulqna.Service.Helpers;

namespace Xulqna.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source , PaginationParams @params)
        {
            var metaData = new PaginationMetaData(source.Count(), @params);
            var json = JsonConvert.SerializeObject(metaData);

            if (HttpContextHelper.ResponseHeader.Keys.Contains("X-Pagination"))
                HttpContextHelper.ResponseHeader.Keys.Remove("X-Pagination");

            HttpContextHelper.Context.Response.Headers.Add("X-Pagination", json);

            return @params.PageIndex >= 0 && @params.PageSize > 0 ?
                source.Skip(@params.PageSize * (@params.PageIndex -1)).Take(@params.PageSize) : source;
        }
    }
}
