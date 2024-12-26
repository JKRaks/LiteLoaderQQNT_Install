using LibGit2Sharp;
using Liteloader.Core.Output;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Liteloader.Core
{
    internal class PluginService(Plugin main)
    {
        private readonly Plugin that = main;

        internal void UpdateSource(PluginInfoOutput infoOutput)
        {
            try
            {
                List<PluginInfoOutput>? list = GetPluginInfos();
                if (list != null)
                {
                    PluginInfoOutput? item = list.FirstOrDefault(s => s.Id == infoOutput.Id);
                    if (item == null)
                    {
                        list.Add(infoOutput);
                    }
                    else
                    {
                        item = infoOutput;
                    }
                    SavePluginInfos(list);
                }
            }
            catch (Exception ex)
            {
                that.CallFunc(() => { MessageBox.Show(ex.Message); });
            }
        }

        internal List<PluginInfoOutput>? GetPluginInfos(bool readInfo = false)
        {
            List<PluginInfoOutput>? pluginInfoOutputs = null;
            try
            {
                string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Asset", "plugin.json");
                string json = File.ReadAllText(jsonPath);
                pluginInfoOutputs = JsonConvert.DeserializeObject<List<PluginInfoOutput>>(json);
            }
            catch (Exception ex)
            {
                that.CallFunc(() =>
                {
                    MessageBox.Show(ex.Message);
                });
            }
            return pluginInfoOutputs;
        }

        private void SavePluginInfos(List<PluginInfoOutput> pluginInfoOutputs)
        {
            try
            {
                string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Asset", "plugin.json");
                string json = JsonConvert.SerializeObject(pluginInfoOutputs);
                File.WriteAllText(jsonPath, json);
            }
            catch (Exception ex)
            {
                that.CallFunc(() =>
                {
                    MessageBox.Show(ex.Message);
                });
            }
        }

        internal void DelSource(string infoOutput)
        {
            try
            {
                List<PluginInfoOutput>? list = GetPluginInfos();
                if (list != null)
                {
                    list.RemoveAll(s => s.Id == infoOutput);
                    SavePluginInfos(list);
                }
            }
            catch (Exception ex)
            {
                that.CallFunc(() => { MessageBox.Show(ex.Message); });
            }
        }

        internal async Task UpdatePlugin(bool proxy)
        {
            try
            {
                string pluginDir = Path.Combine(UpdateService.Dir, "plugins");
                List<PluginInfoOutput>? pluginInfo = GetPluginInfos();
                if (pluginInfo != null)
                {
                    string cache = Path.Combine(UpdateService.Dir, "Cache");
                    foreach (var plugin in pluginInfo)
                    {
                        if (plugin.Branch == "master")
                        {
                            var itemDir = Path.Combine(pluginDir, plugin.Name);
                            if (!Directory.Exists(itemDir))
                            {
                                Directory.CreateDirectory(itemDir);
                            }
                            if (!Directory.Exists(Path.Combine(itemDir, ".git")))
                            {
                                string addr = proxy ? UpdateService.Proxy + "https://github.com/" + plugin.Repo + ".git" : "https://github.com/" + plugin.Repo + ".git";
                                Repository.Clone(addr, Path.Combine(pluginDir, itemDir));
                            }
                            else
                            {
                                using Repository repo = new(itemDir);
                                Remote remote = repo.Network.Remotes["origin"];
                                IEnumerable<string> refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                                Commands.Fetch(repo, remote.Name, refSpecs, null, "");
                                Branch originMaster = repo.Branches.Last();
                                repo.Reset(ResetMode.Hard, originMaster.Tip);
                            }
                        }
                        else
                        {
                            using HttpClient client = new();
                            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                            HttpResponseMessage version = await client.GetAsync($"https://api.github.com/repos/{plugin.Repo}/releases/latest");
                            if (version.Content == null)
                            {
                                throw new Exception("远端未响应");
                            }
                            string downloadUrl = string.Empty;
                            string fileName = string.Empty;
                            string versionJson = await version.Content.ReadAsStringAsync();
                            JObject jobj = JObject.Parse(versionJson);
                            if (jobj.TryGetValue("assets", out JToken? assets))
                            {
                                if (assets is JArray array)
                                {
                                    foreach (JToken item in array)
                                    {
                                        fileName = item["name"]?.ToString();
                                        downloadUrl = item["browser_download_url"]?.ToString();
                                        if (!string.IsNullOrEmpty(fileName))
                                        {
                                            break;
                                        }
                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(downloadUrl))
                            {
                                if (!Directory.Exists(cache))
                                {
                                    Directory.CreateDirectory(cache);
                                }
                                if (proxy)
                                {
                                    downloadUrl = UpdateService.Proxy + downloadUrl;
                                }
                                CommonService commonService = new(that);
                                string filePath = Path.Combine(cache, fileName);
                                await commonService.DownloadFileAsync(downloadUrl, filePath);
                                ZipFile.ExtractToDirectory(filePath, Path.Combine(UpdateService.Dir, "plugins", plugin.Name), true);
                            }
                            else
                            {
                                throw new Exception("未找到下载链接");
                            }
                        }
                    }
                    Directory.Delete(cache, true);
                }
                else
                {
                    throw new Exception("插件信息为空");
                }
            }
            catch (Exception ex)
            {
                that.CallFunc(() => { MessageBox.Show(ex.Message); });
            }
        }
    }
}
