using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo
{
    public class Variable
    {
        public static string ToInput(string text)
        {
            if (isEmpty(text))
            {
                Exception e = new Exception("Xuất hiện dữ liệu trống");
                throw e;
            }
            return text;
        }

        public static string ToPhone(string text)
        {
            if (isEmpty(text))
            {
                Exception e = new Exception("Xuất hiện dữ liệu trống");
                throw e;
            }
            if (!isNumber(text))
            {
                Exception e = new Exception("So dien thoai khong hop le");
                throw e;
            }
            return text;
        }
        public static string ToEmail(string text)
        {
            if (isEmpty(text))
            {
                Exception e = new Exception("Ký tự trống");
                throw e;
            }
            if (!isEmail(text))
            {
                Exception e = new Exception("Email khong hop le");
                throw e;
            }
            return text;
        }

        public static bool isEmail(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (c == '@')
                    count++;
            }
            return count == 1;
        }

        public static bool isNumber(string text)
        {
            foreach (char c in text)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool isEmpty(string text)
        {
            if (text == "")
                return true;
            return false;
        }
    }
}
