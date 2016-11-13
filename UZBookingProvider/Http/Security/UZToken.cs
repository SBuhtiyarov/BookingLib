using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UZBookingProvider
{
    public class UZToken: IToken
    {
        #region Fields: Private

        private string _value;
        private readonly string _pattern = @"gaq.push....trackPageview...;(.*?).function .. .var";

        public string Value {
            get {
                return _value;
            }
        }

        #endregion

        #region Methods: Private

        private int ParseInt(string a, int b) {
            return System.Convert.ToInt32(a, b);
        }

        private string FromCharCode(int value) {
            var character = (char)value;
            return character.ToString();
        }

        private string DecodeJj(string jsCode) {
            var result = string.Empty;
            var cleanCode = Regex.Replace(jsCode, @"/^\s+|\s+$/g", "").Replace(" ", string.Empty).Replace("\n", "").Replace("\r", "");
            int startpos;
            int endpos;
            string gv;
            int gvl;
            if (cleanCode.IndexOf("\"'\\\"+'+\",") == 0) {
                startpos = cleanCode.IndexOf("$$+\"\\\"\"+") + 8;
                endpos = cleanCode.IndexOf("\"\\\"\")())()");
                gv = cleanCode.Substring((cleanCode.IndexOf("\"'\\\"+'+\",") + 9), cleanCode.IndexOf("=~[]"));
                gvl = cleanCode.Length;
            } else {
                var endIndex = cleanCode.IndexOf("=");
                if (endIndex < 0) {
                    return string.Empty;
                }
                gv = cleanCode.Substring(0, endIndex);
                gvl = gv.Length;
                startpos = cleanCode.IndexOf("\"\\\"\"+") + 5;
                endpos = cleanCode.IndexOf("\"\\\"\")())()");
            }
            if (startpos == endpos) {
                throw new InvalidOperationException();
            }
            var data = cleanCode.Substring(startpos, endpos - startpos);
            var b = new string[] { "___+", "__$+", "_$_+", "_$$+", "$__+", "$_$+", "$$_+", "$$$+", "$___+", "$__$+", "$_$_+", "$_$$+", "$$__+", "$$_$+", "$$$_+", "$$$$+" };
            var str_l = "(![]+\"\")[" + gv + "._$_]+";
            var str_o = gv + "._$+";
            var str_t = gv + ".__+";
            var str_u = gv + "._+";
            var str_hex = gv + ".";
            string str_s = "\"";
            var gvsig = gv + ".";
            var str_quote = "\\\\\\\"";
            var str_slash = "\\\\\\\\";
            var str_lower = "\\\\\"+";
            var str_upper = "\\\\\"+" + gv + "._+";
            var str_end = "\"+";
            while (data != "") {
                if (0 == data.IndexOf(str_l)) {
                    data = data.Substring(str_l.Length);
                    result += "l";
                    continue;
                } else if (0 == data.IndexOf(str_o)) {
                    data = data.Substring(str_o.Length);
                    result += "o";
                    continue;
                } else if (0 == data.IndexOf(str_t)) {
                    data = data.Substring(str_t.Length);
                    result += "t";
                    continue;
                } else if (0 == data.IndexOf(str_u)) {
                    data = data.Substring(str_u.Length);
                    result += ("u");
                    continue;
                }
                if (0 == data.IndexOf(str_hex)) {
                    data = data.Substring(str_hex.Length);
                    var i = 0;
                    for (i = 0; i < b.Length; i++) {
                        if (0 == data.IndexOf(b[i])) {
                            data = data.Substring((b[i]).Length);
                            result += i.ToString("X");
                            break;
                        }
                    }
                    continue;
                }
                if (0 == data.IndexOf(str_s)) {
                    data = data.Substring(str_s.Length);
                    if (0 == data.IndexOf(str_upper))
                    {
                        data = data.Substring(str_upper.Length);
                        var ch_str = "";
                        for (var j = 0; j < 2; j++)
                        {				
                            if (0 == data.IndexOf(gvsig)) {
                                data = data.Substring(gvsig.Length); 
                                for (var k = 0; k < b.Length; k++)	
                                {
                                    if (0 == data.IndexOf(b[k])) {
                                        data = data.Substring(b[k].Length);
                                        ch_str += k.ToString("X") + "";
                                        break;
                                    }
                                }
                            } else {
                                break; 
                            }
                        }
                        result += FromCharCode(ParseInt(ch_str, 16));
                        continue;
                    } else if (0 == data.IndexOf(str_lower)) {
                        data = data.Substring(str_lower.Length);
                        var ch_str = "";
                        var ch_lotux = "";
                        var temp = "";
                        var b_checkR1 = 0;
                        for (var j = 0; j < 3; j++){
                            if (j > 1)
                            {
                                if (0 == data.IndexOf(str_l)) {
                                    data = data.Substring(str_l.Length);
                                    ch_lotux = "l";
                                    break;
                                } else if (0 == data.IndexOf(str_o)) {
                                    data = data.Substring(str_o.Length);
                                    ch_lotux = "o";
                                    break;
                                } else if (0 == data.IndexOf(str_t)) {
                                    data = data.Substring(str_t.Length);
                                    ch_lotux = "t";
                                    break;
                                } else if (0 == data.IndexOf(str_u)) {
                                    data = data.Substring(str_u.Length);
                                    ch_lotux = "u";
                                    break;
                                }
                            }						
                            if (0 == data.IndexOf(gvsig)) {
                                temp = data.Substring(gvsig.Length);
                                for (var k = 0; k < 8; k++) {
                                    if (0 == temp.IndexOf(b[k])) {
                                        if (ParseInt(ch_str + k + "", 8) > 128) {
                                            b_checkR1 = 1;
                                            break;
                                        }
                                        ch_str += k + "";
                                        data = data.Substring(gvsig.Length);
                                        data = data.Substring(b[k].Length);
                                        break;
                                    }
                                }
                                if (1 == b_checkR1) {
                                    if (0 == data.IndexOf(str_hex)) {
                                        data = data.Substring(str_hex.Length);
                                        var i = 0;
                                        for (i = 0; i < b.Length; i++) {
                                            if (0 == data.IndexOf(b[i])) {
                                                data = data.Substring((b[i]).Length);
                                                ch_lotux = i.ToString("X");
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                            } else {
                                break; 
                            }
                        }
                        result += FromCharCode(ParseInt(ch_str, 8)) + ch_lotux;
                        continue; 
                    } else {
                        var match = 0;
                        string n;
                        while (true) {
                            n = FromCharCode(data[0]);
                            if (0 == data.IndexOf(str_quote)) {
                                data = data.Substring(str_quote.Length);
                                result += "\"";
                                match += 1;
                                continue;
                            } else if (0 == data.IndexOf(str_slash)) {
                                data = data.Substring(str_slash.Length);
                                result += "\\";
                                match += 1;
                                continue;
                            } else if (0 == data.IndexOf(str_end)) {
                                if (match == 0) {
                                    return string.Empty;
                                }
                                data = data.Substring(str_end.Length);
                                break;
                            } else if (0 == data.IndexOf(str_upper)) {
                                if (match == 0) {
                                    return string.Empty;
                                }

                                data = data.Substring(str_upper.Length);

                                var ch_str = "";
                                var ch_lotux = "";
                                for (var j = 0; j < 10; j++) {
                                    if (j > 1) {
                                        if (0 == data.IndexOf(str_l)) {
                                            data = data.Substring(str_l.Length);
                                            ch_lotux = "l";
                                            break;
                                        } else if (0 == data.IndexOf(str_o)) {
                                            data = data.Substring(str_o.Length);
                                            ch_lotux = "o";
                                            break;
                                        } else if (0 == data.IndexOf(str_t)) {
                                            data = data.Substring(str_t.Length);
                                            ch_lotux = "t";
                                            break;
                                        } else if (0 == data.IndexOf(str_u)) {
                                            data = data.Substring(str_u.Length);
                                            ch_lotux = "u";
                                            break;
                                        }
                                    }			
                                    if (0 == data.IndexOf(gvsig)) {
                                        data = data.Substring(gvsig.Length);

                                        for (var k = 0; k < b.Length; k++) {
                                            if (0 == data.IndexOf(b[k])) {
                                                data = data.Substring(b[k].Length);
                                                ch_str += k.ToString("X") + "";
                                                break;
                                            }
                                        }
                                    } else {
                                        break;
                                    }
                                }
                                result += FromCharCode(ParseInt(ch_str, 16));
                                break;
                            } else if (0 == data.IndexOf(str_lower)) {
                                if (match == 0) {
                                    return string.Empty;
                                }
                                data = data.Substring(str_lower.Length);
                                var ch_str = "";
                                var ch_lotux = "";
                                var temp = "";
                                var b_checkR1 = 0;
                                for (var j = 0; j < 3; j++) {
                                    if (j > 1) {
                                        if (0 == data.IndexOf(str_l)) {
                                            data = data.Substring(str_l.Length);
                                            ch_lotux = "l";
                                            break;
                                        } else if (0 == data.IndexOf(str_o)) {
                                            data = data.Substring(str_o.Length);
                                            ch_lotux = "o";
                                            break;
                                        } else if (0 == data.IndexOf(str_t)) {
                                            data = data.Substring(str_t.Length);
                                            ch_lotux = "t";
                                            break;
                                        } else if (0 == data.IndexOf(str_u)) {
                                            data = data.Substring(str_u.Length);
                                            ch_lotux = "u";
                                            break;
                                        }
                                    }						
                                    if (0 == data.IndexOf(gvsig)) {
                                        temp = data.Substring(gvsig.Length);
                                        for (var k = 0; k < 8; k++) {
                                            if (0 == temp.IndexOf(b[k])) {
                                                if (ParseInt(ch_str + k + "", 8) > 128) {
                                                    b_checkR1 = 1;
                                                    break;
                                                }
                                                ch_str += k + "";
                                                data = data.Substring(gvsig.Length);
                                                data = data.Substring(b[k].Length);
                                                break;
                                            }
                                        }

                                        if (1 == b_checkR1) {
                                            if (0 == data.IndexOf(str_hex)) {
                                                data = data.Substring(str_hex.Length);
                                                var i = 0;
                                                for (i = 0; i < b.Length; i++) {
                                                    if (0 == data.IndexOf(b[i])) {
                                                        data = data.Substring((b[i]).Length);
                                                        ch_lotux = i.ToString("X");
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    } else {
                                        break;
                                    }
                                }
                                result += FromCharCode(ParseInt(ch_str, 8)) + ch_lotux;
                                break;
                            } else {
                                result += data[0].ToString();
                                data = data.Substring(1);
                                match += 1;
                            }
                        }
                        continue;
                    }
                }
                break;
            }
            return result;
        }
        
        #endregion

        #region Methods: Public

        public void DecodeToken(string encodeString) {
            var regex = new Regex(_pattern);
            var match = regex.Match(encodeString);
            var encodeSubString = match.Groups[1].Value;
            var decodeSubString = DecodeJj(encodeSubString);
            _value = decodeSubString.Split('\"')[3].Split('\"')[0].ToLower();
        }

        #endregion
    }
}
