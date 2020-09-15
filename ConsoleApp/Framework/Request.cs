using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Request
    {
        /// <summary>
        /// Thành phần của lệnh truy vấn
        /// </summary>
        public string Route { get; private set; }
        /// <summary>
        /// Thành phần tham số truy vấn
        /// </summary>
        public Parameter Parameter { get; private set; }
        public Request(string request)
        {
            Analyze(request);
        }

        private void Analyze(string request)
        {
            //tìm xem trong chuỗi truy vấn có tham số hay không
            var firstIndex = request.IndexOf('?');
            if(firstIndex <0)
            {
                Route = request.ToLower().Trim();
            }
            else
            {
                if(firstIndex <=1)
                {
                    throw new Exception("Invalid request parameter");
                }
                var tokens = request.Split(new[] { '?'}, 2, StringSplitOptions.RemoveEmptyEntries);
                //route là thành phần của lệnh truy vấn
                Route = tokens[0].Trim().ToLower();
                var parameterPart = request.Substring(firstIndex + 1).Trim();
                Parameter = new Parameter(parameterPart);
            }
        }
    }
}
