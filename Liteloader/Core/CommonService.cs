using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liteloader.Core
{
    internal class CommonService(Base t)
    {
        private readonly Base that = t;

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="outputPath"></param>
        internal async Task DownloadFileAsync(string url, string outputPath)
        {
            try
            {
                using HttpClient client = new ();
                using HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                await using var fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None);
                await response.Content.CopyToAsync(fs);
            }
            catch (Exception ex)
            {
                that.CallFunc(() => { MessageBox.Show(ex.Message); });
            }
        }
    }
}
