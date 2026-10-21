using Stuple.Varables;


namespace Stuple.FileFormats
{
    /// <summary>
    /// json
    /// </summary>
    public class Json
    {
        /// <summary>
        /// Json 对象根
        /// </summary>
        public Dictionary<string, object> Root = new Dictionary<string, object>();

        /// <summary>
        /// 列印成可读字串符
        /// </summary>
        /// <returns>返回转化后的字串符</returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Json()
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Text">Json 文本数据</param>
        public Json(String Text)
        {
            this.Root = Read(Text);
        }

        /// <summary>
        /// 自定 Null 类在 Dictionary<string, object> 中, 作为 object 的初始值
        /// </summary>
        private class ValueNull
        {
            public ValueNull() { }

            /// <summary>
            /// Dictionary<string, object> 中默认初始值
            /// </summary>
            public static ValueNull Null = new ValueNull();
        }

        /// <summary>
        /// 自定异常类
        /// </summary>
        public class JsonException: Exception
        {
            //直接继承
            public JsonException(): base() { }
            public JsonException(string msg): base(msg) { }
        }

        /// <summary>
        /// 解析 Json 文本
        /// </summary>
        /// <param name="text">输入 Json 文本</param>
        /// <param name="decode">是否还原转义字符</param>
        /// <returns>object 字典(键值对)</returns>
        public static Dictionary<string, object> Read(string text, bool decode = true)
        {
            //不接受空值
            if (text == null)
            {
                throw new JsonException("[错误]: 这是空的 Json 对象! ");
            }
            text = text.Trim();
            if (text.Length < 1) 
            {
                throw new JsonException("[错误]: 这是空的 Json 对象! ");
            }
            if (text[0] != '{' || text[text.Length - 1] != '}')
            {
                throw new JsonException("[错误]: 这不是一个 Json 对象! ");
            }

            //初始化返回本体
            Dictionary<string, object> output = new Dictionary<string, object>();

            //一些桶
            List<Dictionary<string, object>> tmp_obj = new List<Dictionary<string, object>>(); //存放对象
            List<List<object>> tmp_array = new List<List<object>>(); //存放数组
            List<string> tmp_path = new List<string>(); //暂存路径, 免得封装数组时, 不知道父级是对象还是数组
            string tmp_str = null; //暂存文本
            //string tmp_value = null; //暂存除了文本以外的值

            //暫存狀態
            bool isstring = false; //寫入字符串模式
            //bool iskey = true; //是否寫入鍵名

            //去除双引号
            string RemoveQuotes(string input)
            {
                if (input.Length > 1 && input[0] == '"' && input[input.Length - 1] == '"')
                {
                    input = input.Substring(1, input.Length - 2);
                }
                return input;
            }

            //检查是不是合法字符串 (两边同时存在 " 或者同时不存在)
            void IsString(string input)
            {
                if (input.Length > 1 && ((input[0] == '"' && input[input.Length - 1] != '"') ||
                    (input[0] != '"' && input[input.Length - 1] == '"')))
                {
                    throw new JsonException("[错误]: Json 语法错误: 非法字符串: \r\n" + input);
                }
            }

            //在 WriteValue() 前, 先检查变数类型
            object CheckType(object input)
            {
                if (input == null) //若传递的是 null 的话, 也得是 "null", 不可能直接是 null
                {
                    throw new JsonException("[错误]: Json 语法错误: 不可传递空值! ");
                }
                else if (input is string) //文本
                {
                    string str = input as string;
                    if (str == "null") //返回空值
                    {
                        return null;
                    }
                    else
                    {
                        IsString(str);
                        //检查文本可转换的类型
                        string type = Conversion.GetType4String(str);
                        switch (type)
                        {
                            case "string": //返回文本
                                return RemoveQuotes(str); //去除双引号
                            case "bool": //返回布尔值
                                return bool.Parse(str);
                            case "int": //32位整数
                                return int.Parse(str);
                            case "long": //64位整数
                                return long.Parse(str);
                            case "decimal": //128位数数
                                return decimal.Parse(str);
                            case "biginteger": //biginteger 用不了, 先用 decimal 替代
                                return decimal.Parse(str);
                            case "float": //单精度浮点数
                                return float.Parse(str);
                            case "double": //双精度浮点数
                                return double.Parse(str);
                            default: //不知道是什么类型
                                throw new JsonException("[错误]: Json 语法错误: 未知类型的值: \r\n" + str);
                        }
                    }
                }
                else if (input is List<object>) //队列
                {
                    return input;
                }
                else if (input is Dictionary<string, object>) //对象
                {
                    return input;
                }
                else
                {
                    //一般情况不会运行到这里来
                    throw new JsonException("[错误]: Json 语法错误: 未知类型的值: \r\n" + input.ToString());
                }
            }

            //把值填上去, 返回成功状态, (输入文本, 强行指定写入对象)
            bool WriteValue(object input, string target = null)
            {
                if (tmp_path[tmp_path.Count - 1] == "obj" || target == "obj") //给对象
                {
                    if (input is Dictionary<string, object>) //如果输入的是对象
                    {
                        //查找父级存不存在
                        if (tmp_obj.Count < 1)
                        {
                            throw new JsonException("[错误]: Json 语法错误: 父级对象不存在. ");
                        }
                        else
                        {
                            var tmp_obj_keys = tmp_obj[tmp_obj.Count - 1].Keys;
                            if (tmp_obj_keys.Count == 0) // 这种情景: {{"name": "hanhan"}} //插入对象时, 没有提供键名
                            {
                                throw new JsonException("[错误]: Json 语法错误: 父级是空对象, 未提供键名. ");
                            }
                            var tmp_obj_key = tmp_obj_keys.Last();
                            tmp_obj[tmp_obj.Count - 1][tmp_obj_key] = input;
                        }
                    }
                    else //输入的不是对象
                    {
                        var tmp_obj_keys = tmp_obj[tmp_obj.Count - 1].Keys;
                        if (tmp_obj_keys.Count == 0) // 这种情景: {{"name": "hanhan"}} //插入对象时, 没有提供键名
                        {
                            throw new JsonException("[错误]: Json 语法错误: 父级是空对象, 未提供键名. ");
                        }
                        var tmp_obj_key = tmp_obj_keys.Last();
                        tmp_obj[tmp_obj.Count - 1][tmp_obj_key] = CheckType(input);
                    }
                }
                else //给队列
                {
                    tmp_array[tmp_array.Count - 1].Add( CheckType(input) );
                }
                return true;
            }

            //逐字解析
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (isstring == true) //判斷是否為寫入字符串模式
                {
                    //是否还原转义字符
                    if (c == '\\' && decode == true)
                    {
                        i++;
                        char cc = text[i];

                        //转义字符表, 来自 https://c.biancheng.net/view/50tbfbj.html
                        switch (cc)
                        {
                            case 'a':
                                tmp_str = tmp_str + "\a";
                                break;
                            case 'b':
                                tmp_str = tmp_str + "\b";
                                break;
                            case 'f':
                                tmp_str = tmp_str + "\f";
                                break;
                            case 'n':
                                tmp_str = tmp_str + "\n";
                                break;
                            case 'r':
                                tmp_str = tmp_str + "\r";
                                break;
                            case 't':
                                tmp_str = tmp_str + "\t";
                                break;
                            case 'v':
                                tmp_str = tmp_str + "\v";
                                break;
                            case '\\':
                                tmp_str = tmp_str + "\\";
                                break;
                            case '\'':
                                tmp_str = tmp_str + "\'";
                                break;
                            case '\"':
                                tmp_str = tmp_str + "\"";
                                break;
                            case '?':
                                tmp_str = tmp_str + "?";
                                break;
                            case '0':
                                tmp_str = tmp_str + "\0";
                                break;
                            case 'u': //Unicode 字符
                                if (i + 4 < text.Length)
                                {
                                    byte[] bytes;
                                    string u = text.Substring(i + 1, 4);
                                    if (Conversion.TryString2Bytes(u, out bytes) == true)
                                    {
                                        int hex = (int)Command.Sum4Bytes(bytes);
                                        //对于代理位解析, 参看一下连接, 感谢!
                                        //https://zhuanlan.zhihu.com/p/147339588
                                        //https://www.cnblogs.com/sailJs/p/18397567
                                        if (hex > 55295 && hex < 56320) // D800 到 DBFF //高代理位 //emoji 那些
                                        {
                                            if(i + 10 < text.Length && text[i + 5] == '\\' && text[i + 6] == 'u')
                                            {
                                                u = text.Substring(i + 7, 4);
                                                if (Conversion.TryString2Bytes(u, out bytes) == true)
                                                {
                                                    int HSCP = hex;
                                                    int LSCP = (int)Command.Sum4Bytes(bytes);
                                                    if (LSCP < 56320 || LSCP > 57343) //低代理位, 在 DC00 到 DFFF 
                                                    {
                                                        tmp_str = tmp_str + "\\u";
                                                    }
                                                    else
                                                    {
                                                        //HSCP = HSCP - (int)Command.Sum4Bytes(Command.String2Bytes("D800"));
                                                        HSCP = HSCP - 55296;
                                                        HSCP = HSCP * 1024;
                                                        //LSCP = LSCP - (int)Command.Sum4Bytes(Command.String2Bytes("DC00"));
                                                        LSCP = LSCP - 56320;
                                                        //hex = HSCP + LSCP + (int)Command.Sum4Bytes(Command.String2Bytes("010000"));
                                                        hex = HSCP + LSCP + 65536;
                                                        i = i + 10;
                                                        tmp_str = tmp_str + (string)char.ConvertFromUtf32(hex);
                                                    }
                                                }
                                                else
                                                {
                                                    tmp_str = tmp_str + "\\u";
                                                }
                                            }
                                            else
                                            {
                                                tmp_str = tmp_str + "\\u";
                                            }
                                        }

                                        else 
                                        {
                                            i = i + 4; //这里不因该是 i + 5, 因为下一次循环会 i++
                                            tmp_str = tmp_str + (string)char.ConvertFromUtf32(hex);
                                        }
                                    }
                                    else
                                    {
                                        tmp_str = tmp_str + "\\u";
                                    }
                                }
                                else
                                {
                                    tmp_str = tmp_str + "\\u";
                                }
                                break;
                        }
                    }
                    else //默认直接追加
                    { 
                        tmp_str = tmp_str + c; 
                    }

                    if (c == '"' && text[i - 1] != '\\') //判斷是不是 ", 截斷
                    {
                        isstring = false;
                    }
                }
                else // {}",[]:\
                {
                    switch (c)
                    {
                        case ' ': //在非字符串模式下, 跳过空白
                            break;
                        case '{': //对象起始
                            tmp_obj.Add(new Dictionary<string, object>());
                            tmp_path.Add("obj");
                            break;
                        case '}': //对象结束
                            //值还有内容就填上
                            if (tmp_str != null)
                            {
                                WriteValue(tmp_str);
                                tmp_str = null;
                            }

                            //一般来讲, tmp_obj.Count == 0 只有一个原因: 已经把 tmp_obj[0] 赋值给 output 了, 原本 tmp_obj 会清空.
                            if (tmp_obj.Count == 0) 
                            {
                                throw new JsonException("[错误]: Json 语法错误: 存在多余截止符: }");
                            }

                            //检查是否还有键值对仍处于初始状态
                            /*
                            var tmp_obj_keys = tmp_obj[tmp_obj.Count - 1].Keys;
                            if (tmp_obj_keys.Count > 0)
                            {
                                var tmp_obj_key = tmp_obj_keys.Last();
                                if (tmp_obj[tmp_obj.Count - 1][tmp_obj_key] is ValueNull) {
                                    throw new Exception("[错误]: Json 语法错误: 某个键值对仍存在初始值: \r\n" + tmp_obj_key);
                                }
                            }*/

                            if (tmp_obj.Count > 1) //直接把对象移到父对象
                            {
                                Dictionary<string, object> obj = tmp_obj[tmp_obj.Count - 1];
                                tmp_obj.RemoveAt(tmp_obj.Count - 1);
                                tmp_path.RemoveAt(tmp_path.Count - 1);
                                WriteValue(obj);
                            }
                            else //最后一个对象, 直接结尾
                            {
                                output = tmp_obj[0];
                                tmp_obj.RemoveAt(tmp_obj.Count - 1);
                                tmp_path.RemoveAt(tmp_path.Count - 1);
                                i = text.Length;
                            }
                            break;
                        case '[': //队列起始
                            tmp_array.Add(new List<object>());
                            tmp_path.Add("array");
                            break;
                        case ']': //队列结束
                            //如果 tmp_str 还有残留的话, 就写到队列里
                            if(tmp_str != null)
                            {
                                WriteValue(tmp_str);
                                tmp_str = null;
                            }
                            List<object> list = tmp_array[tmp_array.Count - 1];
                            tmp_path.RemoveAt(tmp_path.Count - 1);
                            tmp_array.RemoveAt(tmp_array.Count - 1);
                            WriteValue(list);
                            break;
                        case ',': //每各项的分隔符
                            //把值填上去
                            if (tmp_str != null) {
                                WriteValue(tmp_str);
                                tmp_str = null;
                            }
                            break;
                        case ':': //键值对分隔符
                            //写入键名
                            if (tmp_str == null)
                            {
                                throw new JsonException("[错误]: Json 语法错误: 未知键名. ");
                            }
                            IsString(tmp_str);
                            //检查是否为非法键名 (两边必须为 "" )
                            if (tmp_str.Length < 2 || (tmp_str.Length > 1 && tmp_str[0] != '"' && tmp_str[tmp_str.Length - 1] != '"'))
                            {
                                throw new JsonException("[错误]: Json 语法错误: 非法键名: \r\n" + tmp_str);
                            }
                            tmp_str = RemoveQuotes(tmp_str);
                            tmp_obj[tmp_obj.Count - 1].Add(tmp_str, ValueNull.Null);
                            tmp_str = null;
                            break;
                        case '"':
                            //不能同时存在两个字串符
                            if (tmp_str != null)
                            {
                                throw new JsonException("[错误]: Json 语法错误: 不能同时存在两个字串符. ");
                            }
                            isstring = true;
                            tmp_str = c.ToString();
                            break;
                        default:
                            if(tmp_str == null)
                            {
                                tmp_str = c.ToString();
                            }
                            else
                            {
                                tmp_str = tmp_str + c.ToString();
                            }
                            break;
                    }
                }
            }

            //检查有没有多余对象
            if (tmp_obj.Count > 1)
            {
                throw new JsonException("[错误]: 存在多余的 Json 对象! ");
            }

            //如果循环结束之后, isstring 还为 true 的话, 那说明字符串没有设置截止符
            if (isstring == true)
            {
                throw new JsonException("[错误]: Json 语法错误: 字符串溢出: \r\n" + tmp_str);
            }

            return output;
        }

        /// <summary>
        /// 打印 Json 文本
        /// </summary>
        /// <param name="json">Json 对象</param>
        /// <returns>string: 打印信息</returns>
        public static string Print(Dictionary<string, object> json)
        {
            List<string> output = new List<string>();
            List<int> treeindex = new List<int>(); //记录每个条目在根内的深度
            int num1 = 0; //空格计数
            int num2 = 0; //条目计数
            if (json.Count == 0)
            {
                return "空的 Json 对象";
            }

            //记下每个条目在根内的深度
            string updatatreeindex(string text)
            {
                treeindex.Add(num1);
                num2++;
                return text;
            }

            //循环解析
            void loop(object json2)
            {
                num1++;
                //先变量检查再循环
                if (json2 is Dictionary<string, object>) //这里解析对象
                {
                    Dictionary<string, object> json3 = json2 as Dictionary<string, object>;
                    foreach (var t in json3)
                    {
                        //判断类型
                        if (t.Value == null) //null
                        {
                            output.Add(updatatreeindex("\"" + t.Key + "\":" + "null"));
                        }
                        else if (t.Value is string) //文本
                        {
                            output.Add(updatatreeindex("\"" + t.Key + "\":\"" + t.Value + "\""));
                        }
                        else if (t.Value is Dictionary<string, object>) //对象
                        {
                            Dictionary<string, object> obj = t.Value as Dictionary<string, object>;
                            if (obj.Count == 0)
                            {
                                output.Add(updatatreeindex("\"" + t.Key + "\":{}"));
                            }
                            else
                            {
                                output.Add(updatatreeindex("\"" + t.Key + "\":{..}"));
                                loop(obj);
                            }
                        }
                        else if (t.Value is List<object>) //数组
                        {
                            List<object> list = t.Value as List<object>;
                            if (list.Count == 0)
                            {
                                output.Add(updatatreeindex("\"" + t.Key + "\":[]"));
                            }
                            else
                            {
                                output.Add(updatatreeindex("\"" + t.Key + "\":[..]"));
                                loop(list);
                            }
                        }
                        else //要麽數字, 要麽布爾值
                        {
                            output.Add(updatatreeindex("\"" + t.Key + "\":" + t.Value.ToString()));
                        }
                    }
                }
                else //这里解析数组
                {
                    List<object> json3 = json2 as List<object>;
                    foreach (var t in json3)
                    {
                        //判断类型
                        if (t == null) //null
                        {
                            output.Add(updatatreeindex("null"));
                        }
                        else if (t is string) //文本
                        {
                            output.Add(updatatreeindex("\"" + t.ToString() + "\""));
                        }
                        else if (t is Dictionary<string, object>) //对象
                        {
                            //数组里碰到数组, 那么父节点显示为 {}
                            Dictionary<string, object> obj = t as Dictionary<string, object>;
                            if (obj.Count == 0)
                            {
                                output.Add(updatatreeindex("{}"));
                            }
                            else
                            {
                                output.Add(updatatreeindex("{..}"));
                                loop(obj);
                            }
                        }
                        else if (t is List<object>) //数组
                        {
                            //数组里碰到数组, 那么父节点显示为 []
                            List<object> list = t as List<object>;
                            if (list.Count == 0)
                            {
                                output.Add(updatatreeindex("[]"));
                            }
                            else {
                                output.Add(updatatreeindex("[..]"));
                                loop(list);
                            }
                        }
                        else //要麽數字, 要麽布爾值
                        {
                            output.Add(updatatreeindex(t.ToString()));
                        }
                    }
                }
                num1--;
            }
            output.Add("Json 对象, 一共: ");
            loop(json); //启动
            output[0] = "Json 对象, 一共: " + num2 + " 个条目";

            //格式化
            List<bool> tmp4 = new List<bool>(); //這個用於規定哪個可以標 "│"
            bool treeend = true; //└
            for (int t = output.Count - 1; t > 0; t--)
            {
                string tmp1 = output[t].TrimStart(); //去除空格
                int tmp2 = treeindex[t - 1]; //这个条目所在根的深度
                string tmp3 = ""; //树干, 就是 |└
                //更新 tmp4 
                if (tmp4.Count <  tmp2) //小了
                {
                    treeend = true;
                    if (tmp4.Count > 0) { //在新增前, 标记最后一个为 true
                        tmp4[tmp4.Count - 1] = true;
                    }
                    int tmp5 = tmp2 - tmp4.Count;
                    for (int tt = 0; tt < tmp5; tt++)
                    {
                        tmp4.Add(false);
                    }
                }
                else if (tmp4.Count > tmp2) //大了
                {
                    treeend = true;
                    int tmp5 = tmp4.Count - tmp2;
                    for (int tt = 0; tt < tmp5; tt++) //删除多余的
                    {
                        tmp4.RemoveAt(tmp4.Count - 1);
                    }
                    if (tmp4.Count > 0)
                    {
                        if (tmp4[tmp4.Count - 1] == true) //在同一列上只出现一次└
                        {
                            treeend = false;
                        }
                        else
                        {
                            tmp4[tmp4.Count - 1] = true;
                        }
                    }
                }

                //開始添加樹幹
                for(int tt = 0; tt < tmp4.Count; tt++)
                {
                    bool tmp5 = tmp4[tt]; //決定要不要添加 "|"
                    if (tt + 1 != tmp4.Count) { //不在尾部
                        if (tmp5 == true)
                        {
                            tmp3 = tmp3 + "｜";
                        }
                        else
                        {
                            tmp3 = tmp3 + "  ";
                        }
                    }
                    else //在尾部
                    {
                        if (treeend == true)
                        {
                            tmp3 = tmp3 + "└";
                            treeend = false;
                        }
                        else
                        {
                            tmp3 = tmp3 + "├";
                        }
                    }
                }

                output[t] = tmp3 + tmp1;
            }

            return string.Join("\r\n",output);
        }

        /// <summary>
        /// 按照路径在 Json 对象中获取值
        /// </summary>
        /// <param name="json">Json 对象</param>
        /// <param name="path">查找路径</param>
        /// <returns>object: 返回取值结果</returns>
        public static object GetValue(Dictionary<string, object> json, object[] path)
        {
            if (json == null)
            {
                throw new JsonException("[错误]: Json 取值错误: Json 对象不存在. ");
            }
            if (path.Length < 1)
            {
                throw new JsonException("[错误]: Json 取值错误: 输入路径不能为空. ");
            }
            Dictionary<string, object> obj = json;
            List<object> array = null;

            //循环遍历
            for (int i = 0; i < path.Length; i++)
            {
                object keys = path[i];
                if (keys is string) //文本, 键名
                {
                    string key = (string)keys;
                    if (obj == null) //对象找不到就报错
                    {
                        throw new JsonException("[错误]: Json 取值错误: 找不到对象, 待查询的键名是: \"" + key + "\" 深度: " + i.ToString());
                    }
                    object value;
                    if (obj.TryGetValue(key, out value) == false) //值找不到就报错
                    {
                        throw new JsonException("[错误]: Json 取值错误: 找不到该值, 其键名是: \"" + key + "\" 深度: " + i.ToString());
                    }

                    if (i == path.Length - 1) //检索到路径的最后一个 key, 就返回数据 (遍历到 path 的最后一个值)
                    {
                        return value;
                    }
                    else //继续给下一个循环
                    {
                        if (value is Dictionary<string, object>)
                        {
                            obj = (Dictionary<string, object>)value;
                            array = null;
                        }
                        else if(value is List<object>)
                        {
                            obj = null;
                            array = (List<object>)value;
                        }
                        else //既不是对象也不是队列, 那无法继续遍历下去了, 直接报错
                        {
                            throw new JsonException("[错误]: Json 取值错误: 检索到非对象\\队列, 提前终止, 其键名是: \"" + key + 
                                "\" 深度: " + i.ToString());
                        }
                    }
                }
                else if(keys is int) //整数, 索引
                {
                    int index = (int)keys;
                    if (array == null) //队列找不到就报错
                    {
                        throw new JsonException("[错误]: Json 取值错误: 找不到队列, 待查询的索引是: " + index.ToString() + " 深度: " + i.ToString());
                    }
                    if (index > array.Count - 1) //超过索引就报错
                    {
                        throw new JsonException("[错误]: Json 取值错误: 索引值超出范围, 其索引是: " + index.ToString() + " 深度: " + i.ToString());
                    }
                    object value = array[index];

                    if (i == path.Length - 1) //检索到路径的最后一个 key, 就返回数据 (遍历到 path 的最后一个值)
                    {
                        return value;
                    }
                    else //继续给下一个循环
                    {
                        if (value is Dictionary<string, object>)
                        {
                            obj = (Dictionary<string, object>)value;
                            array = null;
                        }
                        else if (value is List<object>)
                        {
                            obj = null;
                            array = (List<object>)value;
                        }
                        else //既不是对象也不是队列, 那无法继续遍历下去了, 直接报错
                        {
                            throw new JsonException("[错误]: Json 取值错误: 检索到非对象\\队列, 提前终止, 其索引是: " + index.ToString() +
                                " 深度: " + i.ToString());
                        }
                    }
                }
                else //输入的不是键名或索引就报错
                {
                    throw new JsonException("[错误]: Json 取值错误: 输入路径有误, 非键名\\索引, 深度: " + i.ToString());
                }
            }
            throw new JsonException("[错误]: Json 取值错误: 未知错误. ");
        }

        /// <summary>
        /// 按照路径在 Json 对象中获取值
        /// </summary>
        /// <param name="json">Json 对象</param>
        /// <param name="path">查找路径</param>
        /// <param name="output">赋值返回结果的变数</param>
        /// <returns>bool: 如果成功获取, 则返回 true, 反之 false </returns>
        public static bool TryGetValue(Dictionary<string, object> json, object[] path, out object output)
        {
            if (json == null || path.Length < 1)
            {
                output = null;
                return false;
            }
            Dictionary<string, object> obj = json;
            List<object> array = null;

            //循环遍历
            for (int i = 0; i < path.Length; i++)
            {
                object keys = path[i];
                if (keys is string) //文本, 键名
                {
                    string key = (string)keys;
                    if (obj == null) //对象找不到就报错
                    {
                        output = null;
                        return false;
                    }
                    object value;
                    if (obj.TryGetValue(key, out value) == false) //值找不到就报错
                    {
                        output = null;
                        return false;
                    }

                    if (i == path.Length - 1) //检索到路径的最后一个 key, 就返回数据 (遍历到 path 的最后一个值)
                    {
                        output = value;
                        return true;
                    }
                    else //继续给下一个循环
                    {
                        if (value is Dictionary<string, object>)
                        {
                            obj = (Dictionary<string, object>)value;
                            array = null;
                        }
                        else if(value is List<object>)
                        {
                            obj = null;
                            array = (List<object>)value;
                        }
                        else //既不是对象也不是队列, 那无法继续遍历下去了, 直接报错
                        {
                            output = null;
                            return false;
                        }
                    }
                }
                else if(keys is int) //整数, 索引
                {
                    int index = (int)keys;
                    if (array == null) //队列找不到就报错
                    {
                        output = null;
                        return false;
                    }
                    if (index > array.Count - 1) //超过索引就报错
                    {
                        output = null;
                        return false;
                    }
                    object value = array[index];

                    if (i == path.Length - 1) //检索到路径的最后一个 key, 就返回数据 (遍历到 path 的最后一个值)
                    {
                        output = value;
                        return true;
                    }
                    else //继续给下一个循环
                    {
                        if (value is Dictionary<string, object>)
                        {
                            obj = (Dictionary<string, object>)value;
                            array = null;
                        }
                        else if (value is List<object>)
                        {
                            obj = null;
                            array = (List<object>)value;
                        }
                        else //既不是对象也不是队列, 那无法继续遍历下去了, 直接报错
                        {
                            output = null;
                            return false;
                        }
                    }
                }
                else //输入的不是键名或索引就报错
                {
                    output = null;
                    return false;
                }
            }

            output = null;
            return false;
        }
    }
}

