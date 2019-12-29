using leaveAPI.Content;
using leaveAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace leaveAPI.Filters
{
    public class TokenCheckAttribute : Attribute, IAuthorizationFilter
    {
        public bool AllowMultiple { get; }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            IEnumerable<string> headers;
            if (actionContext.Request.Headers.TryGetValues(name: "token", out headers))
            {
                //如果获取到了headers里的token
                var loginName = JwtTool.DecodeJwt(token: headers.First())["Name"].ToString();
                var userId = JwtTool.DecodeJwt(token: headers.First())["ID"];
                (actionContext.ControllerContext.Controller as ApiController).User = new ApplicationUser(loginName, Convert.ToInt32(userId));
                return await continuation();
            }
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent("未登录");
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}