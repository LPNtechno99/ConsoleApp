using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    /* đây không phải lệnh sử dụng namespace
     * mà là tạo biệt danh cho một kiểu dữ liệu
     * ở đây đang tạo một biệt danh cho kiểu Dictionary<string, ControllerAction>
     * trong cả file này có thể sử dụng tên kiểu RoutingTable
     * thay cho Dictionary<string, ControllerAction>
     */
    using RoutingTable = Dictionary<string, ControllerAction>;
    /// <summary>
    /// Delegate này đại diện cho tất cả các phương thức có:
    /// - kiểu trả về là void
    /// - danh sách tham số vào là (Parameter)
    /// </summary>
    /// <param name="parameter"></param>
    public delegate void ControllerAction(Parameter parameter = null);
    /// <summary>
    /// Lớp này cho phép ánh xạ truy vấn với phương thức
    /// </summary>
    public class Router
    {
        private static Router _instance;
        private Router()
        {
            _routingTable = new RoutingTable();
            _helpTable = new Dictionary<string, string>();
        }
        //  để ý: constructor là private
        // người sử dụng class thông qua property này để truy xuất các phương thức của class
        // chỉ khi nào _instance == null mới tạo object. Một khi đã tạo object, _instance sẽ không có giá trị null nữa
        // vì là biến static, _instance một khi được khởi tạo sẽ tồn tại suốt chương trình
        public static Router Instance => _instance ?? (_instance = new Router());
        // lưu ý: ở đây đang sử dụng alias của Dictionary<string, ControllerAction> cho ngắn gọn
        private readonly RoutingTable _routingTable;
        private readonly Dictionary<string, string> _helpTable;

        public string GetRoutes()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var k in _routingTable.Keys)
                sb.AppendFormat("{0}, ", k);
            return sb.ToString().TrimEnd(',', ' ');
        }

        public string GetHelps(string key)
        {
            if (_helpTable.ContainsKey(key))
                return _helpTable[key];
            else
                return "Document not ready yet";
        }

        /// <summary>
        /// Đăng ký một route mới, mỗi route ánh xạ một chuỗi truy vấn với một phương thức
        /// </summary>
        /// <param name="route"></param>
        /// <param name="action"></param>
        /// <param name="help"></param>
        public void Register(string route, ControllerAction action, string help = "")
        {
            // nếu _routingTable đã chứa route này thì bỏ qua
            if(!_routingTable.ContainsKey(route))
            {
                _routingTable[route] = action;
                _helpTable[route] = help;
            }
        }
        /// <summary>
        /// Phân tích truy vấn và gọi phương thức tương ứng với chuỗi truy vấn
        /// <para><h>chuối truy vấn bao gồm hai phần: route và parameter, phân tách bởi ký tự ?</h></para>
        /// </summary>
        /// <param name="request">chuỗi truy vấn, bao gồm hai phần: 
        ///  route, parameter; phân tách bởi ký tự ?</param>
        public void Forward(string request)
        {
            var req = new Request(request);
            if (!_routingTable.ContainsKey(req.Route))
                throw new Exception("Command not found");
            if (req.Parameter == null)
                _routingTable[req.Route]?.Invoke();
            else
                _routingTable[req.Route]?.Invoke(req.Parameter);
        }
    }
}
