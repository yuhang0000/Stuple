namespace Stuple.Commands
{
    /// <summary>
    /// 实用工具集
    /// </summary>
    public static class ToolKit
    {
        //type:0    2026-8-17 15:42:46
        //type:1    2026/8/17 15:42:46
        //type:2    2026-8-17
        //type:3    2026/8/17
        //type:4    15:42:46
        //type:5    2026年8月17日 15:42:46
        //type:6    2026年8月17日 星期天 15:42:46
        /// <summary>
        /// 修饰时间格式
        /// </summary>
        /// <returns>string: 返回修饰好的时间文本</returns>
        public static string FixDateTime(DateTime? date = null, int type = 0)
        {
            DateTime _date;
            string output = "";
            if(date == null)
            {
                _date = DateTime.Now;
            }
            else
            {
                _date = (DateTime)date;
            }

            String hour = _date.Hour.ToString().PadLeft(2, '0');
            String min = _date.Minute.ToString().PadLeft(2, '0');
            String sec = _date.Second.ToString().PadLeft(2, '0');
            String year = _date.Year.ToString();
            String mouth = _date.Month.ToString();
            String day = _date.Day.ToString();
            DayOfWeek week = _date.DayOfWeek;

            switch (type)
            {
                case 0:
                    output = year + "-" + mouth + "-" + day + " " + hour + ":" + min + ":" + sec;
                    break;
                case 1:
                    output = year + "/" + mouth + "/" + day + " " + hour + ":" + min + ":" + sec;
                    break;
                case 2:
                    output = year + "-" + mouth + "-" + day;
                    break;
                case 3:
                    output = year + "/" + mouth + "/" + day;
                    break;
                case 4:
                    output = hour + ":" + min + ":" + sec;
                    break;
                case 5:
                    output = year + "年" + mouth + "月" + day + "日 " + hour + ":" + min + ":" + sec;
                    break;
                case 6:
                    string xinqi = "";
                    switch ((int)week)
                    {
                        case 1:
                            xinqi = "星期一";
                            break;
                        case 2:
                            xinqi = "星期二";
                            break;
                        case 3:
                            xinqi = "星期三";
                            break;
                        case 4:
                            xinqi = "星期四";
                            break;
                        case 5:
                            xinqi = "星期五";
                            break;
                        case 6:
                            xinqi = "星期六";
                            break;
                        case 0:
                            xinqi = "星期天";
                            break;
                    }
                    output = year + "年" + mouth + "月" + day + "日 " + xinqi + " " + hour + ":" + min + ":" + sec;
                    break;
                default:
                    output = _date.ToString();
                    break;
            }

            return output;
        }

        /// <summary>
        /// 数字简写, 例如: 23333 简写成 2.33万
        /// </summary>
        /// <param name="input">输入数字</param>
        /// <param name="digits">保留几位小数点</param>
        /// <returns>string: 返回文本</returns>
        public static string NumAbbr(object input, int digits = 2)
        {
            long num = -1;
            double num2 = -1;
            string output = "";

            //变数类型检查
            if (input is long)
            {
                num = (long)input ;
            }
            else if (input is int)
            {
                num = (int)input;
            }
            else if (input is string)
            {
                if (long.TryParse((string)input, out num) == false)
                {
                    throw new Exception("[错误]: 数字简写: 输入数值不可用. ");
                }
            }
            else
            {
                throw new Exception("[错误]: 数字简写: 输入数值不可用. ");
            }

            if (num > 99999999 || num < -99999999) //亿
            {
                num2 = num / 100000000.0;
                num2 = Math.Round(num2, digits);
                output = num2.ToString() + "亿";
            }
            else if (num > 9999 || num < -9999) //万
            {
                num2 = num / 10000.0;
                num2 = Math.Round(num2, digits);
                output = num2.ToString() + "万";
            }
            else
            {
                output = num.ToString();
            }

            return output;
        }

        /// <summary>
        /// 数字扩写
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <returns>long: 返回数字</returns>
        public static long NumUnAbbr(string text)
        {
            if (text == null)
            {
                throw new Exception("[错误]: NumUnAbbr: 不许传递空对象!");
            }
            text = text.Trim().ToLower();
            if (text.Length == 0)
            {
                throw new Exception("[错误]: NumUnAbbr: 这不是一个合法的数字简写!");
            }
            string danwei = text.Last().ToString(); //要么 亿, 要么 万, k, m, b ,t
            long num = 0;
            if (long.TryParse(danwei, out num) == true) //最后一个字符是数字的话
            {
                if (long.TryParse(text, out num) == true) //直接返回
                {
                    return num;
                }
                else //但整体不是数字
                {
                    throw new Exception("[错误]: NumUnAbbr: 这不是一个合法的数字简写!");
                }
            }
            if (text.Length == 1) //可能会遇到 "万" 这种情况
            {
                throw new Exception("[错误]: NumUnAbbr: 这不是一个合法的数字简写!");
            }

            //继续
            double double1;
            if (double.TryParse(text.Substring(0, text.Length - 1), out double1) == false) //这种情况: 2点33万
            {
                throw new Exception("[错误]: NumUnAbbr: 这不是一个合法的数字简写!");
            }
            //然后扩写
            switch (danwei)
            {
                case "万":
                    num = (long)Math.Round(double1 * 10000);
                    break;
                case "亿":
                    num = (long)Math.Round(double1 * 100000000);
                    break;
                case "k":
                    num = (long)Math.Round(double1 * 1000);
                    break;
                case "m":
                    num = (long)Math.Round(double1 * 1000000);
                    break;
                case "b":
                    num = (long)Math.Round(double1 * 1000000000);
                    break;
                case "t":
                    num = (long)Math.Round(double1 * 1000000000000);
                    break;
                default:
                    throw new Exception("[错误]: NumUnAbbr: 这不是一个合法的数字简写, 没见过的单位: " + danwei);
            }

            return num;
        }

        /// <summary>
        /// 时间戳转日期
        /// </summary>
        /// <param name="Timestamp">时间戳</param>
        /// <returns>DateTime: 日期对象</returns>
        public static DateTime TimeStamp2Date(long Timestamp)
        {
            DateTime dt = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970,1,1));
            return dt.AddSeconds(Timestamp);
        }

        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <param name="target">给定时间对象, 缺省时取当前时间</param>
        /// <returns>long: 时间戳</returns>
        public static long GetTimeStamp(DateTime? target = null)
        {
            DateTime now;
            if (target == null)
            {
                now = DateTime.Now;
            }
            else
            {
                now = (DateTime)target;
            }
            DateTime old = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970,1,1));
            long timestamp = (long)(now - old).TotalSeconds;

            return timestamp;
        }

        /// <summary>
        /// 从 Url 中获取请求网域的拓展名
        /// </summary>
        /// <param name="uri">输入文本或者 Uri 对象</param>
        /// <returns>string: 返回拓展名</returns>
        public static string GetExt4Url(Object uri)
        {
            if (uri != null)
            {
                string url;
                if (uri is string)
                {
                    url = (string)uri;
                }
                else if(uri is Uri)
                {
                    Uri uri2 = (Uri)uri;
                    url = uri2.ToString();
                }
                else
                {
                    return null;
                }

                string[] urls = url.Split('/');
                if (urls.Length > 1)
                {
                    url = urls.Last();
                    //去除?和#
                    if (url.IndexOf("?") != -1)
                    {
                        url = url.Substring(0, url.IndexOf("?"));
                    }
                    if (url.IndexOf("#") != -1)
                    {
                        url = url.Substring(0, url.IndexOf("#"));
                    }
                    //检查有没有 "."
                    int index = url.LastIndexOf(".");
                    if (index == -1 && url.Length == 0)
                    {
                        return null;
                    }
                    return url.Substring(index + 1, url.Length - index - 1).ToLower();
                }
            }
            return null;
        }

        /// <summary>
        /// 从 Url 中获取请求参数 (键值对)
        /// </summary>
        /// <param name="uri">输入文本或者 Uri 对象</param>
        /// <returns>dictionary: 返回载荷</returns>
        public static Dictionary<string, string> GetDict4Url(Object uri)
        {
            if (uri != null)
            {
                string url;
                if (uri is string)
                {
                    url = (string)uri;
                }
                else if (uri is Uri)
                {
                    Uri uri2 = (Uri)uri;
                    url = uri2.ToString();
                }
                else
                {
                    return null;
                }
                int index = url.LastIndexOf("?");
                if (index == -1)
                {
                    return null;
                }
                //创建字典
                Dictionary<string, string> dict = new Dictionary<string, string>();
                string[] array = url.Substring(index + 1).Split('&');
                foreach (string str in array)
                {
                    string key;
                    string value = null;
                    int i = str.IndexOf("=");
                    if (i == -1) //只有键名
                    {
                        key = str;
                    }
                    else //键值对
                    {
                        key = str.Substring(0, i);
                        value = str.Substring(i + 1);
                        if (key.Length == 0) //像 ?=debug& 这种工况
                        {
                            key = value;
                            value = null;
                        }
                    }

                    //追加字典
                    if (dict.ContainsKey(key) == true) //是否出现重复键名
                    {
                        //TODO: 暂且直接覆盖
                        dict[key] = value;
                    }
                    else
                    {
                        dict.Add(key, value);
                    }

                }

                return dict;
            }

            return null;
        }
    }

}

