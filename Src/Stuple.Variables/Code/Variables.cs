namespace Stuple.Varables
{
    /// <summary>
    /// 指令集
    /// </summary>
    public static class Command
    {
        /// <summary>
        /// 求 byte[] 的总和, 十进制
        /// </summary>
        /// <param name="input">输入 byte[] 变数</param>
        /// <returns>long: 返回总和</returns>
        public static long Sum4Bytes(byte[] input)
        {
            long num = 0;
            for (int i = input.Length - 1; i > -1; i--) //求总和
            {
                int n = input.Length - 1 - i;
                num = num + ((long)input[i] * (long)Math.Pow(256, n));
            }
            return num;
        }

    }

    /// <summary>
    /// 变数转换
    /// </summary>
    public static class Conversion
    {
        /// <summary>
        /// 给出可以转换的数字类型
        /// </summary>
        /// <param name="input">输入文本</param>
        /// <returns>string: 返回可以转换的变数类型: null, string, int, long, float, double, decimal, biginteger</returns>
        public static string GetNumType(string input)
        {
            //忽略 Null
            if (input == null)
            {
                return "null";
            }
            else if (input.Length == 0)
            {
                return "string";
            }

            string type = "string";
            char[] nums = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            bool kexuejishufa = false; //是不是科学计数发
            for (int i = 0; i < input.Length; i++) //遍历文本
            {
                char t = input[i];
                if (i == 0 && (t == '-' || t == '+')) //是不是正负数
                {
                    continue;
                }
                bool yes = false;
                foreach (char tt in nums) //诶个看看单个字是不是数字
                {
                    if (tt == t)
                    {
                        yes = true;
                        break;
                    }
                }
                if (t == 'e' || t == 'E') //科学计数发
                {
                    if (kexuejishufa == true) //不可能有两个E
                    {
                        return "string";
                    }
                    else
                    {
                        yes = true;
                        type = "float";
                        kexuejishufa = true;
                    }
                }
                else if (t == '-' || t == '+') //正负数的前面是不是 'E'
                {
                    if (input[i - 1] == 'E' || input[i - 1] == 'e')
                    {
                        yes = true;
                    }
                }
                else if (t == '.' && type != "float") //小数点
                {
                    yes = true;
                    type = "float";
                }
                if (yes == false) //都不是那只能是文本
                {
                    return "string";
                }
            }
            //都跑到这里来的,说明是数字
            if (type != "float")
            {
                type = "int";
            }
            //然后判断大小
            if (type == "int") //这是整数
            {
                int int1 = 0;
                long long1 = 0;
                decimal decimal1 = 0;
                if (int.TryParse(input, out int1) == true) //32位整數
                {
                    return "int";
                }
                else if (long.TryParse(input, out long1) == true) //64位整數
                {
                    return "long";
                }
                else if (decimal.TryParse(input, out decimal1) == true) //128位數字
                {
                    return "decimal";
                }
                else //超級無敵大
                {
                    return "biginteger";
                }
            }
            else //这是浮点数
            {
                double double1 = 0;
                //去除符号
                if (input[0] == '-')
                {
                    input = input.Substring(1);
                }
                //科学计数法展开
                if (kexuejishufa == true)
                {
                    int E = input.IndexOf("E", StringComparison.InvariantCultureIgnoreCase);
                    //检查 E 旁边有没有数字
                    if (E == 0 || E == input.Length - 1) // 1e
                    {
                        return "string";
                    }
                    else if (E == input.Length - 2 && (input[input.Length - 1] == '-' || input[input.Length - 1] == '+')) //1e+
                    {
                        return "string";
                    }
                    //获取 E 后边的数
                    E = int.Parse(input.Substring(E + 1, input.Length - 1 - E));
                    input = input.Substring(0, input.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));
                    int potindex = input.IndexOf(".");
                    input = input.Replace(".", "");
                    if (E < 0) //加小数点
                    {
                        int newpot = E + potindex;
                        int length = input.Length;
                        if (length > newpot)
                        {
                            for (int t = 0; t < newpot * -1 + 1; t++)
                            {
                                input = "0" + input;
                            }
                        }
                    }
                    else //减小数点
                    {
                        int newpot = E + potindex;
                        int length = input.Length;
                        if (newpot > length)
                        {
                            for (int t = 0; t < newpot - length; t++)
                            {
                                input = input + "0";
                            }
                        }
                        //好像没必要再把小数点填回去, 后面只比对有多少位有效数字
                    }
                    //ConsoleLog(input);
                }

                input = input.Replace(".", "");
                //继续比对
                if (input.Length > 16 && kexuejishufa == false) //高精度浮点
                {
                    return "decimal";
                }
                else
                {
                    if (double1 > float.MaxValue) //双精度浮点
                    {
                        return "double";
                    }
                    else if (input.Length > 8)
                    {
                        return "double";
                    }
                    else //单精度浮点
                    {
                        return "float";
                    }
                }
            }
        }

        /// <summary>
        /// 判断输入文本可以转换的类型
        /// </summary>
        /// <param name="input">输入文本</param>
        /// <returns>string: 返回可以转换的类型: null, bool, string, int, long, float, double, decimal, biginteger, 不确定的时候返回 -1</returns>
        public static string GetType4String(string input)
        {
            if (input == null)
            {
                return "null";
            }
            if (input is string)
            {
                if (string.Equals(input, "false", StringComparison.InvariantCultureIgnoreCase) == true ||
                    string.Equals(input, "true", StringComparison.InvariantCultureIgnoreCase) == true) //布尔值
                {
                    return "bool";
                }
                else
                {
                    return GetNumType((string)input);
                }
            }
            return "-1";
        }

        /// <summary>
        /// 字串符转 byte[]
        /// </summary>
        /// <param name="input">输入文本</param>
        /// <param name="bytes">输入 byte[] 变数用于赋值转换结果</param>
        /// <returns>bool: 如果成功转换, 则返回 true, 反之 false </returns>
        /// <remarks>
        /// 即,将 <c>"AB CD EF"</c> 之类的字符串转换成 位元数组
        /// </remarks>
        public static bool TryString2Bytes(string input, out byte[]? bytes)
        {
            if (input == null)
            {
                bytes = null;
                return false;
            }

            input = input.ToLower();
            List<byte> list = new List<byte>();
            string strings = "0123456789abcdef";
            bool sec = false; //第二位

            //循环遍历
            for (int i = 0; i < input.Length; i++)
            {
                //跳过空格
                if (input[i] == ' ')
                {
                    continue;
                }
                bool ishex = false; //这个是给下边循环用的状态位, 如果下边循环满足条件的话, 他会为 true

                //遍历 HEX 字符表
                for (int ii = 0; ii < strings.Length; ii++)
                {
                    if (input[i] == strings[ii])
                    {
                        ishex = true;
                        //一个位元组打印成字串符, 长度为2, 那么这里, 当取第一位,直接 * 16 并追加到新位元数组
                        if (sec == false)
                        {
                            sec = true;
                            list.Add((byte)(ii * 16));
                        }
                        //直接加入到位元数组最后一位
                        else
                        {
                            sec = false;
                            list[list.Count - 1] = (byte)(list[list.Count - 1] + ii);
                        }
                        break;
                    }
                }

                //如果该 char 不属于在 HEX 字符集里, 就说明, 不是一个有效的 HEX 文本
                if(ishex == false)
                {
                    bytes = null;
                    return false;
                }
            }
            
            bytes = list.ToArray();
            return true;
        }

        /// <summary>
        /// 字串符转 byte[]
        /// </summary>
        /// <param name="input">输入文本</param>
        /// <returns>byte[]: 返回 byte[] </returns>
        /// <remarks>
        /// 即,将 <c>"AB CD EF"</c> 之类的字符串转换成 位元数组
        /// </remarks>
        public static byte[]? String2Bytes(string input)
        {
            if (input == null)
            {
                return null;
            }
            input = input.ToLower();
            List<byte> list = new List<byte>();
            string strings = "0123456789abcdef";
            bool sec = false;

            //循环遍历
            for (int i = 0; i < input.Length; i++ )
            {
                //跳过空格
                if (input[i] == ' ')
                {
                    continue;
                }
                bool ishex = false; //这个是给下边循环用的状态位, 如果下边循环满足条件的话, 他会为 true

                //遍历循环
                for(int ii = 0; ii < strings.Length;ii++)
                {
                    if (strings[ii] == input[i])
                    {
                        ishex = true;
                        if (sec == false)
                        {
                            sec = true;
                            list.Add((byte)(ii * 16));
                        }
                        else
                        {
                            sec = false;
                            list[list.Count - 1] = (byte)(list[list.Count - 1] + ii);
                        }
                        break;
                    }
                }

                if(ishex == false)
                {
                    throw new Exception("待会写");
                }

            }
            return list.ToArray();
        }
    }
}