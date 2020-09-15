using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    /// <summary>
    /// Lưu các cặp key-value người dùng nhập;
    /// Chuỗi tham số cần viết ở dạng key-value;
    /// Nếu có nhiều tham số thì viết tách nhau bằng kí tự &;
    /// </summary>
    public class Parameter
    {
        private readonly Dictionary<string, string> _pairs = new Dictionary<string, string>();
        /// <summary>
        /// Nạp chồng phép toán indexing[]; cho phép truy xuất giá trị theo kiểu biến[key] = value;
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Giá trị tương ứng</returns>
        public string this[string key] //để nạp chồng indexing phải viết hai phương thức get, set
        {
            get
            {
                if (_pairs.ContainsKey(key))
                    return _pairs[key];
                else return null;
            } //phương thức get trả lại giá trị từ dictionary

            set => _pairs[key] = value; //phương thức set gán giá trị cho dictionary
        }

        /// <summary>
        /// Kiểm tra xem một khóa có  trong danh sách tham số không
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return _pairs.ContainsKey(key);
        }
        /// <summary>
        /// Nhận chuỗi ký tự và phân tích, chuyển thành cặp khóa-giá trị
        /// </summary>
        /// <param name="parameter">chuỗi kí tự theo quy tắc khóa_1 = giá_trị_1 & khóa_2 = giá_trị_2</param>
        public Parameter(string parameter)
        {
            //cắt chuỗi theo mốc là ký tự &
            //kết quả của phép toán này là một mảng, mỗi phần tử là một chuỗi có dạng khóa = giá trị
            var pairs = parameter.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var pair in pairs)
            {
                var p = pair.Split('='); // cắt mỗi phần tử lấy mốc là kí tự =
                if(p.Length == 2)
                {
                    var key = p[0].Trim(); // phần tử thứ nhất là khóa
                    var value = p[1].Trim(); // phần tử thứ hai là giá trị
                    this[key] = value; //lưu cặp khóa-giá trị này lại sử dụng phép toán indexing

                    //cũng có thể viết theo kiểu khác, trực tiếp sử dụng biến _pairs
                    // _pairs[key] = value
                }
            }
        }
    }
}
