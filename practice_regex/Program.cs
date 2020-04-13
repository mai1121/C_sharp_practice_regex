using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace practice_regex
{
    class Program
    {
        static void Main(string[] args)
        {

            var dic = new Dictionary<string,string>{};

            var tel_num = "電話番号は、03-1111-1111です。携帯番号は、090-3333-4444です。";
            var post_num = "郵便番号は、111-3333です";
            var old = "年齢は、34歳です";
     


            var rgx_telnum = new Regex(@"[0-9]{2,4}-[0-9]{2,4}-[0-9]{4}");
            var match_telnum = rgx_telnum.Matches(tel_num);

            var rgx_post_num = new Regex(@"[0-9]{3}-[0-9]{4}");
            var match_postnum = rgx_post_num.Match(post_num);


            var rgx_old = new Regex(@"[0-9]{1,3}歳");
            var match_old = rgx_old.Match(old);

            var i = 0;
            foreach(Match m in match_telnum)
            {
                if (m.Success)
                {
                    dic.Add($"電話番号{i}", $"{m.Value}");
                    Console.WriteLine(dic[$"電話番号{i}"]);
                    i++;
                }
            }

            if (match_postnum.Success)
            {
                dic.Add("郵便番号",$"{match_postnum.Value}");
                Console.WriteLine(dic["郵便番号"]);
            }

            if (match_old.Success)
            {
                dic.Add("年齢",$"{match_old.Value}");
                Console.WriteLine(dic["年齢"]);
            }

            foreach (var key in dic.Keys)
            {
                Console.WriteLine($"{key}:{dic[key]}");

            }
        }
    }
}
