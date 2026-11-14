using Stuple.Varables;

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
        //type:7    2026年8月17日 星期天
        //type:8    星期天
        /// <summary>
        /// 修饰时间格式
        /// </summary>
        /// <param name="date">指定时间. 为空时, 取当前时间. </param>
        /// <param name="type">指定要修饰的时间格式</param>
        /// <returns>string: 返回修饰好的时间文本</returns>
        public static string FixDateTime(DateTime? date = null, FixDataTimeType type = FixDataTimeType.Default)
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
            String weekstr = "";

            switch ((int)type)
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
                    switch ((int)week)
                    {
                        case 1:
                            weekstr = "星期一";
                            break;
                        case 2:
                            weekstr = "星期二";
                            break;
                        case 3:
                            weekstr = "星期三";
                            break;
                        case 4:
                            weekstr = "星期四";
                            break;
                        case 5:
                            weekstr = "星期五";
                            break;
                        case 6:
                            weekstr = "星期六";
                            break;
                        case 0:
                            weekstr = "星期天";
                            break;
                    }
                    output = year + "年" + mouth + "月" + day + "日 " + weekstr + " " + hour + ":" + min + ":" + sec;
                    break;
                case 7:
                    switch ((int)week)
                    {
                        case 1:
                            weekstr = "星期一";
                            break;
                        case 2:
                            weekstr = "星期二";
                            break;
                        case 3:
                            weekstr = "星期三";
                            break;
                        case 4:
                            weekstr = "星期四";
                            break;
                        case 5:
                            weekstr = "星期五";
                            break;
                        case 6:
                            weekstr = "星期六";
                            break;
                        case 0:
                            weekstr = "星期天";
                            break;
                    }
                    output = year + "年" + mouth + "月" + day + "日 " + weekstr;
                    break;
                case 8:
                    switch ((int)week)
                    {
                        case 1:
                            weekstr = "星期一";
                            break;
                        case 2:
                            weekstr = "星期二";
                            break;
                        case 3:
                            weekstr = "星期三";
                            break;
                        case 4:
                            weekstr = "星期四";
                            break;
                        case 5:
                            weekstr = "星期五";
                            break;
                        case 6:
                            weekstr = "星期六";
                            break;
                        case 0:
                            weekstr = "星期天";
                            break;
                    }
                    output = weekstr;
                    break;
                default:
                    output = _date.ToString();
                    break;
            }

            return output;
        }

        /// <summary>
        /// 指定 FixDateTime() 使用的时间格式
        /// </summary>
        public enum FixDataTimeType
        {
            /// <summary>
            /// 默认, 等同于 <c>DateTime.ToString(); </c>
            /// </summary>
            Default = -1,
            /// <summary>
            /// 标准日期和时间格式, 用减号分隔, 如下: 
            /// <para>
            /// <c>2026-8-17 15:42:46</c>
            /// </para>
            /// </summary>
            DashWithDate = 0,
            /// <summary>
            /// 标准日期和时间格式, 用斜杠分隔, 如下: 
            /// <para>
            /// <c>2026/8/17 15:42:46</c>
            /// </para>
            /// </summary>
            SlashWithDate = 1,
            /// <summary>
            /// 标准日期格式, 但是没有时间, 用减号分隔, 如下: 
            /// <para>
            /// <c>2026-8-17</c>
            /// </para>
            /// </summary>
            DashDateOnly = 2,
            /// <summary>
            /// 标准日期格式, 但是没有时间, 用斜杠分隔, 如下: 
            /// <para>
            /// <c>2026/8/17</c>
            /// </para>
            /// </summary>
            SlashDateOnly = 3,
            /// <summary>
            /// 就只有时间, 如下: 
            /// <para>
            /// <c>15:42:46</c>
            /// </para>
            /// </summary>
            TimeOnly = 4,
            /// <summary>
            /// 标准日期格式, 用年月日分隔, 如下: 
            /// <para>
            /// <c>2026年8月17日 15:42:46</c>
            /// </para>
            /// </summary>
            ChineseData = 5,
            /// <summary>
            /// 标准日期格式, 多了个星期几, 用年月日分隔, 如下: 
            /// <para>
            /// <c>2026年8月17日 星期天 15:42:46</c>
            /// </para>
            /// </summary>
            ChineseDateWithWeek = 6,
            /// <summary>
            /// 标准日期格式, 但是没有时间, 并且多了个星期几, 用年月日分隔, 如下: 
            /// <para>
            /// <c>2026年8月17日 星期天</c>
            /// </para>
            /// </summary>
            ChineseDateWeekNotTime = 7,
            /// <summary>
            /// 就只有星期几, 如下: 
            /// <para>
            /// <c>星期天</c>
            /// </para>
            /// </summary>
            WeekOnly = 8,
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
                    throw new ArgumentException("输入数值不可用, 无法将文本转换成整数. ");
                }
            }
            else
            {
                throw new ArgumentException("输入格数据格式无效, 无法进行整数转换. ");
            }

            if (num > 999999999999 || num < -999999999999) //万亿
            {
                num2 = num / 1000000000000.0;
                num2 = Math.Round(num2, digits);
                output = num2.ToString() + "万亿";
            }
            else if (num > 99999999 || num < -99999999) //亿
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
        /// 整数扩写
        /// </summary>
        /// <param name="text">输入文本, 例如 <c>"1234万"</c>. <br/><br/>支援这些单位: <c>亿, 万, 千, K, M, B, T, Q</c></param>
        /// <returns>long: 返回已扩写的整数</returns>
        public static long NumUnAbbr(string text)
        {
            string numtype;
            long result = 0;

            if (text == null)
            {
                throw new ArgumentNullException("输入参数不能为 null. ");
            }
            text = text.Trim().ToLower();
            if (text.Length == 0)
            {
                throw new ArgumentException("输入参数不能为空. ");
            }
            string unit = text.Last().ToString(); //要么 亿, 要么 万, 千, k, m, b ,t, q
            if (Conversion.GetNumType(unit) == "int") //最后一个字符是数字的话
            {
                string type = Conversion.GetNumType(text);
                if (type == "int" || type == "long" ) //直接返回
                {
                    return long.Parse(text);
                }
                else if (type == "float" || type == "double" )
                {
                    return (long)Math.Round(double.Parse(text), 0);
                }
                else //但整体不是数字
                {
                    throw new ArgumentException("无法将输出的参数转换为整数. ");
                }
            }
            if (text.Length == 1) //可能会遇到 "万" 这种情况
            {
                throw new ArgumentException("无法将输出的参数转换为整数. ");
            }

            //获取数字类型
            numtype = Conversion.GetNumType(text.Substring(0, text.Length - 1));
            if (numtype == "int" || numtype == "long") //整数
            {
                long num = long.Parse(text.Substring(0, text.Length - 1));
                //然后扩写
                switch (unit)
                {
                    case "万":
                        result = NumUnAbbr(num, NumUnAbbrUnit.Wan);
                        break;
                    case "亿":
                        result = NumUnAbbr(num, NumUnAbbrUnit.Yi);
                        break;
                    case "千":
                    case "k":
                        result = NumUnAbbr(num, NumUnAbbrUnit.K);
                        break;
                    case "m":
                        result = NumUnAbbr(num, NumUnAbbrUnit.M);
                        break;
                    case "b":
                        result = NumUnAbbr(num, NumUnAbbrUnit.B);
                        break;
                    case "t":
                        result = NumUnAbbr(num, NumUnAbbrUnit.T);
                        break;
                    case "q":
                        result = NumUnAbbr(num, NumUnAbbrUnit.Q);
                        break;
                    default:
                        throw new ArgumentException("未识别单位: " + unit);
                }
            }
            else if (numtype == "float" || numtype == "double") //浮点
            {
                double num = double.Parse(text.Substring(0, text.Length - 1));
                //然后扩写
                switch (unit)
                {
                    case "万":
                        result = NumUnAbbr(num, NumUnAbbrUnit.Wan);
                        break;
                    case "亿":
                        result = NumUnAbbr(num, NumUnAbbrUnit.Yi);
                        break;
                    case "千":
                    case "k":
                        result = NumUnAbbr(num, NumUnAbbrUnit.K);
                        break;
                    case "m":
                        result = NumUnAbbr(num, NumUnAbbrUnit.M);
                        break;
                    case "b":
                        result = NumUnAbbr(num, NumUnAbbrUnit.B);
                        break;
                    case "t":
                        result = NumUnAbbr(num, NumUnAbbrUnit.T);
                        break;
                    case "q":
                        result = NumUnAbbr(num, NumUnAbbrUnit.Q);
                        break;
                    default:
                        throw new ArgumentException("未识别单位: " + unit);
                }
            }
            else
            {
                throw new ArgumentException("无法将输出的参数转换为整数. ");
            }

            return result;
        }
        /// <summary>
        /// 整数扩写
        /// </summary>
        /// <param name="input">要扩写的整数</param>
        /// <param name="unit">指定单位</param>
        /// <returns>long: 返回已扩写的整数</returns>
        public static long NumUnAbbr(long input, NumUnAbbrUnit unit = NumUnAbbrUnit.None)
        {
            long result = 0;
            switch ((int)unit)
            {
                default:
                case 0: //默认, 什么也不动
                    result = input;
                    break;
                case 1: //亿
                    result = checked(input * 100_000_000); //checked() 敢溢出直接爆
                    break;
                case 2: //万
                    result = checked(input * 10_000);
                    break;
                case 3: //千
                    result = checked(input * 1_000);
                    break;
                case 4: //百万
                    result = checked(input * 1_000_000);
                    break;
                case 5: //十亿
                    result = checked(input * 1_000_000_000);
                    break;
                case 6: //万亿
                    result = checked(input * 1_000_000_000_000);
                    break;
                case 7: //千万亿
                    result = checked(input * 1_000_000_000_000_000);
                    break;
            }

            return result;
        }
        /// <summary>
        /// 整数扩写
        /// </summary>
        /// <param name="input">要扩写的整数</param>
        /// <param name="unit">指定单位</param>
        /// <returns>long: 返回已扩写的整数</returns>
        public static long NumUnAbbr(double input, NumUnAbbrUnit unit = NumUnAbbrUnit.None)
        {
            long result = 0;
            switch ((int)unit)
            {
                default:
                case 0: //默认, 什么也不动
                    result = (long)input;
                    break;
                case 1: //亿
                    result = (long)checked(input * 100_000_000.0); //checked() 敢溢出直接爆
                    break;
                case 2: //万
                    result = (long)checked(input * 10_000.0);
                    break;
                case 3: //千
                    result = (long)checked(input * 1_000.0);
                    break;
                case 4: //百万
                    result = (long)checked(input * 1_000_000.0);
                    break;
                case 5: //十亿
                    result = (long)checked(input * 1_000_000_000.0);
                    break;
                case 6: //万亿
                    result = (long)checked(input * 1_000_000_000_000.0);
                    break;
                case 7: //千万亿
                    result = (long)checked(input * 1_000_000_000_000_000.0);
                    break;
            }

            return result;
        }

        /// <summary>
        /// 指定 NumUnAbbr() 使用的单位
        /// </summary>
        public enum NumUnAbbrUnit
        {
            /// <summary>
            /// 无
            /// </summary>
            None = 0, 
            /// <summary>
            /// 亿 = 100 000 000 = 10^8
            /// </summary>
            Yi = 1,
            /// <summary>
            /// 亿 = 100 000 000 = 10^8
            /// </summary>
            OneHundredMillion = 1,
            /// <summary>
            /// 万 = 10 000 = 10^4
            /// </summary>
            Wan = 2,
            /// <summary>
            /// 万 = 10 000 = 10^4
            /// </summary>
            TenThousand = 2,
            /// <summary>
            /// 千 = 1 000 = 10^3
            /// </summary>
            Qian = 3,
            /// <summary>
            ///  千 = 1 000 = 10^3
            /// </summary>
            K = 3,
            /// <summary>
            /// 千 = 1 000 = 10^3
            /// </summary>
            Thousand = 3,
            /// <summary>
            /// 百万 = 1 000 000 = 10^6
            /// </summary>
            M = 4,
            /// <summary>
            /// 百万 = 1 000 000 = 10^6
            /// </summary>
            Million = 4,
            /// <summary>
            /// 十亿 = 1 000 000 000 = 10^9
            /// </summary>
            B = 5,
            /// <summary>
            /// 十亿 = 1 000 000 000 = 10^9
            /// </summary>
            Billion = 5,
            /// <summary>
            /// 万亿 = 1 000 000 000 000 = 10^12
            /// </summary>
            T = 6,
            /// <summary>
            /// 万亿 = 1 000 000 000 000 = 10^12
            /// </summary>
            Trillion = 6,
            /// <summary>
            /// 千万亿 = 1 000 000 000 000 = 10^15
            /// </summary>
            Q = 7,
            /// <summary>
            /// 千万亿 = 1 000 000 000 000 = 10^15
            /// </summary>
            Quadrillion = 7
        }

        /// <summary>
        /// 时间戳转日期
        /// <para>
        /// 在 .NET8 环境中, 应该使用 <c>DateTimeOffset.FromUnixTimeSeconds(Timestamp).LocalDateTime;</c>
        /// </para>
        /// </summary>
        /// <param name="Timestamp">时间戳</param>
        /// <returns>DateTime: 日期对象</returns>
        public static DateTime TimeStamp2Date(long Timestamp)
        {
            // .NET8 不适用
            //DateTime dt = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970,1,1));
            DateTime dt;
            if(Timestamp > -62135596800 && Timestamp < 253402300799)
            {
                dt = DateTimeOffset.FromUnixTimeSeconds(Timestamp).LocalDateTime;
            }
            else
            {
                dt = DateTimeOffset.FromUnixTimeMilliseconds(Timestamp).LocalDateTime;
            }
            return dt;
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
            //.NET8 不适用
            //DateTime old = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970,1,1));
            //long timestamp = (long)(now - old).TotalSeconds;
            long timestamp = ((DateTimeOffset)now).ToUnixTimeSeconds();

            return timestamp;
        }

        /// <summary>
        /// 获取当前时间戳, 精确到毫秒
        /// </summary>
        /// <param name="target">给定时间对象, 缺省时取当前时间</param>
        /// <returns>long: 时间戳</returns>
        public static long GetTimeStampMs(DateTime? target = null)
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
            long timestamp = ((DateTimeOffset)now).ToUnixTimeMilliseconds();

            return timestamp;
        }

        /// <summary>
        /// 从 Url 中获取请求网域的拓展名
        /// </summary>
        /// <param name="uri">输入文本或者 Uri 对象</param>
        /// <returns>string: 返回拓展名</returns>
        public static string? GetExt4Url(Object uri)
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
        public static Dictionary<string, string?>? GetDict4Url(Object uri)
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
                Dictionary<string, string?> dict = new Dictionary<string, string?>();
                string[] array = url.Substring(index + 1).Split('&');
                foreach (string str in array)
                {
                    //跳过空白
                    if (str.Length == 0)
                    {
                        continue;
                    }

                    string key;
                    string? value = null;
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

        /// <summary>
        /// 打印这种
        /// <code>
        /// {"key":"text}
        ///        ^~~~~
        /// </code>
        /// 的字符指示器
        /// </summary>
        /// <param name="text">要处理的文本</param>
        /// <param name="scopestart">(~) 作用范围起始位置</param>
        /// <param name="scopelength">(~) 作用范围长度</param>
        /// <param name="pointerstart">(^) 指针范围起始位置</param>
        /// <param name="pointerlength">(^) 指针范围长度</param>
        /// <returns>string: 返回已修饰的文本</returns>
        public static string ShowCaretPointer(string text, int scopestart, int scopelength, int pointerstart, int pointerlength)
        {
            string output = "";

            if(scopestart < 0)
            {
                scopestart = 0;
            }
            if(pointerstart < 0)
            {
                pointerstart = 0;
            }
            for(int i = 0; i < scopestart; i++)
            {
                output = output + " ";
            }
            for(int i = scopestart; i < scopelength; i++)
            {
                output = output + "~";
            }
            for(int i = pointerstart - output.Length; i < pointerstart; i++)
            {
                output = output + " ";
            }
            for(int i = pointerstart; i < pointerlength; i++)
            {
                output = output + "^";
            }

            return output;
        }
    }

}

