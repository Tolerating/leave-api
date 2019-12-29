using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace leaveAPI.Content
{
    public class JwtTool
    {
        public static string Key { get; set; } = "hello world";
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string EncodeJwt(Dictionary<string, object> payload, string key = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                key = Key;
            }
            try
            {
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                return encoder.Encode(payload, key);
            }
            catch (TokenExpiredException)
            {
                throw;
            }

        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Dictionary<string, object> DecodeJwt(string token, string key = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                key = Key;
            }
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                var json = decoder.Decode(token: token, key, verify: true);//token为之前生成的字符串
                //需要安装Newtonsoft.json
                var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

                return result;
            }
            catch (TokenExpiredException)
            {
                throw;
            }
        }
    }
}