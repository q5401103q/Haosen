using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haosen.Common.Json
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2019/8/15 14:35:32
    /// 描述：用于将序列化时处理默认日期格式
    /// </summary>
    public class CustomJsonSerializer
    {
        public static JsonSerializer serializer = null;
        public static JsonSerializerSettings setting = null;

        /// <summary>
        /// 自定义序列化时间
        /// </summary>
        /// <returns></returns>
        public static JsonSerializer GetSerializer()
        {
            if (serializer == null)
            {
                if (setting == null)
                {
                    setting = new JsonSerializerSettings();
                    setting.Converters.Add(new IsoDateTimeConverter
                    {
                        //这里指定序列化的格式
                        DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
                    });
                }
                serializer = JsonSerializer.Create(setting);
            }
            return serializer;
        }
    }
}
