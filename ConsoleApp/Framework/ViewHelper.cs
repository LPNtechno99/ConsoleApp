using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    /// <summary>
    /// Sử dụng ExtensionMethod cho kiểu dữ liệu string
    /// </summary>
    public static class ViewHelper
    {
        /// <summary>
        /// Xuát thông tin ra console với màu sắc (Write có màu)
        /// </summary>
        /// <param name="message">thông tin cần xuất</param>
        /// <param name="color">màu chữ</param>
        /// <param name="resetColor">trả lại màu mặc định hay không</param>
        public static void Write(this object message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor)
                Console.ResetColor();
        }
        public static void WriteLine(this object message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Write(message, color, resetColor);
            Console.WriteLine();
        }
        /// <summary>
        /// Biến đổi value thành kiểu T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T To<T>(this string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        /// <summary>
        /// Biến đổi value thành kiểu T qua tham số out
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool To<T>(this string value, out T result)
        {
            var ok = false;
            result = default(T);
            try
            {
                result = value.To<T>();
                ok = true;
            }
            catch(Exception)
            {

            }
            return ok;
        }
        
        /// <summary>
        /// In ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static string Read(this string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}: ", labelColor, false);
            Console.ForegroundColor = valueColor;
            string value = Console.ReadLine();
            Console.ResetColor();
            return value;
        }
        /// <summary>
        /// Đọc một chuỗi và chuyển về kiểu cơ sở T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="label"></param>
        /// <param name="labelColor"></param>
        /// <param name="valueColor"></param>
        /// <returns></returns>
        public static T Read<T>(this string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            var ok = false;
            T result = default(T);
            while(true)
            {
                var str = Read(label, labelColor, valueColor);
                try
                {
                    result = str.To<T>();
                    ok = true;
                }
                catch(Exception)
                {

                }
                if (ok) break;
            }
            return result;
        }
        /// <summary>
        /// Cập nhật giá trị kiểu string. Nếu ấn enter mà không nhập dữ liệu sẽ trả lại giá trị cũ
        /// </summary>
        /// <param name="label"></param>
        /// <param name="oldValue"></param>
        /// <param name="labelColor"></param>
        /// <param name="valueColor"></param>
        /// <returns></returns>
        public static string Update(this string label, string oldValue, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}: ",labelColor);
            WriteLine(oldValue, ConsoleColor.Yellow);
            Write(" >> ", ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string newValue = Console.ReadLine();
            return string.IsNullOrEmpty(newValue.Trim()) ? oldValue : newValue;
        }

        /// <summary>
        /// Cập nhật giá trị có kiểu cơ bản T bất kỳ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="label"></param>
        /// <param name="oldValue"></param>
        /// <param name="labelColor"></param>
        /// <param name="valueColor"></param>
        /// <returns></returns>
        public static T Update<T>(this string label, T oldValue, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}: ", labelColor);
            WriteLine($"{oldValue}", ConsoleColor.Yellow);
            Write(" >> ", ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str)) return oldValue;
            if (str.To<T>(out T i)) return i; //sử dụng phương thức mở rộng ToInt
            return oldValue;
        }
    }
}
