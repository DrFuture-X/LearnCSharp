using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ThreadBasic
{
    class DownloadTool
    {
        public string URL { get; set; }
        public string Message { get; set; }

        public DownloadTool(string url, string message)
        {
            this.URL = url;
            this.Message = message;
        }

        public void Download()
        {
            Console.WriteLine("从" + URL + "下载中。。。");
        }
    }
}
