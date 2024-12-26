using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace Liteloader.Core
{
    internal class UpdateService(Main t)
    {
        private readonly Main that = t;

        const string Repo = "https://github.com/LiteLoaderQQNT/LiteLoaderQQNT.git";
        public const string Proxy = "https://ghp.miaostay.com/";

        public static string Dir => Directory.GetCurrentDirectory() + "\\Liteloader";
        public static string Patch => Path.Combine(Dir, "Patch");

        /// <summary>
        /// 更新框架
        /// </summary>
        /// <param name="proxy"></param>
        public async void UpdateFramework(bool proxy)
        {
            try
            {
                if (!Directory.Exists(Dir))
                {
                    Directory.CreateDirectory(Dir);
                }
                if (!Directory.Exists(Dir + "\\.git"))
                {
                    string addr = proxy ? Proxy + Repo : Repo;
                    Repository.Clone(addr, Dir);
                }
                else
                {
                    using Repository repo = new(Dir);
                    Remote remote = repo.Network.Remotes["origin"];
                    IEnumerable<string> refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                    Commands.Fetch(repo, remote.Name, refSpecs, null, "");
                    Branch originMaster = repo.Branches.Last();
                    repo.Reset(ResetMode.Hard, originMaster.Tip);
                }
                await UpdatePatch(proxy);
            }
            catch (Exception ex)
            {
                that.CallFunc(() => { MessageBox.Show(ex.Message); });
            }
        }

        /// <summary>
        /// 更新补丁
        /// </summary>
        /// <param name="proxy"></param>
        /// <returns></returns>
        private async Task<string> UpdatePatch(bool proxy)
        {
            string dbg = Path.Combine(Patch, "dbghelp.dll");
            try
            {
                using HttpClient client = new();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                var version = await client.GetAsync("https://api.github.com/repos/LiteLoaderQQNT/QQNTFileVerifyPatch/releases/latest");
                if (version.Content == null)
                {
                    throw new Exception("远端未响应");
                }
                string downloadUrl = string.Empty;
                string versionJson = await version.Content.ReadAsStringAsync();
                JObject jobj = JObject.Parse(versionJson);
                if (jobj.TryGetValue("assets", out JToken? assets))
                {
                    if (assets is JArray array)
                    {
                        foreach (JToken item in array)
                        {
                            if (item["name"]?.ToString().Contains("x64") ?? false)
                            {
                                downloadUrl = item["browser_download_url"]?.ToString() ?? "";
                                if (!string.IsNullOrEmpty(downloadUrl))
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(downloadUrl))
                {
                    if (!Directory.Exists(Patch))
                    {
                        Directory.CreateDirectory(Patch);
                    }
                    File.Delete(dbg);
                    if (proxy)
                    {
                        downloadUrl = Proxy + downloadUrl;
                    }
                    CommonService commonService = new(that);
                    commonService.DownloadFileAsync(downloadUrl, dbg);
                }
                else
                {
                    throw new Exception("未找到下载链接");
                }
            }
            catch (Exception ex)
            {
                that.CallFunc(() => { MessageBox.Show(ex.Message); });
            }
            return dbg;
        }

    }
}
