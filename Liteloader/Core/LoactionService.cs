using LibGit2Sharp;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liteloader.Core
{
    internal class LoactionService(Main t)
    {
        private readonly Main that = t;

        public async void Inject(string filepath, string version)
        {
            try
            {

                Init();
                FileInfo fi = new(filepath);
                string? path = fi.Directory?.FullName;
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception("未找到文件路径");
                }
                string target;

                if (!string.IsNullOrEmpty(version) && Directory.Exists(Path.Combine(path, "versions")))
                {
                    target = Path.Combine(path, "versions", version, "resources", "app");
                    if (!Directory.Exists(target))
                    {
                        throw new Exception("版本号似乎有误");
                    }
                }
                else
                {
                    target = Path.Combine(path, "resources", "app");
                }

                if (!Directory.Exists(target))
                {
                    throw new Exception("未找到启动文件夹");
                }
                using (FileStream launcherJs = File.Open(Path.Combine(target, "app_launcher", "ntloader.js"), FileMode.OpenOrCreate))
                {
                    string launcherText = $"require(String.raw`{UpdateService.Dir}`)";
                    using StreamWriter writer = new(launcherJs);
                    writer.Write(launcherText);
                }

                string json = File.ReadAllText(Path.Combine(target, "package.json"));
                JObject jobj = JObject.Parse(json);
                jobj["main"] = "./app_launcher/ntloader.js";
                json = jobj.ToString();
                File.WriteAllText(Path.Combine(target, "package.json"), json);

                File.Copy(Path.Combine(UpdateService.Patch, "dbghelp.dll"), Path.Combine(path, "dbghelp.dll"), true);
            }
            catch (Exception ex)
            {
                that.CallFunc(() => { MessageBox.Show(ex.Message); });
            }
        }

        private void Init()
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                processes = processes.Where(p => p.ProcessName.Contains("QQ")).ToArray();
                foreach (var item in processes)
                {
                    item.Kill();
                }
            }
            catch (Exception ex)
            {
                that.CallFunc(() => { MessageBox.Show(ex.Message); });
            }
        }

        public string? GetQVersion()
        {
            string ver = "";
            try
            {
                RegistryKey? key = Registry.CurrentUser.OpenSubKey("Software\\Tencent\\QQNT");
                ver = key?.GetValue("version")?.ToString() ?? "";
                if (!ver.Contains('-'))
                {
                    if (ver.Count(c => c == '.') == 3)
                    {
                        int lastDotIndex = ver.LastIndexOf('.');
                        ver = string.Concat(ver.AsSpan(0, lastDotIndex), "-", ver.AsSpan(lastDotIndex + 1));
                    }
                }
            }
            catch (Exception ex)
            {
                that.CallFunc(() => { MessageBox.Show(ex.Message); });
            }
            return ver;
        }

        internal void Reset()
        {
            try
            {
                Directory.Delete(UpdateService.Dir, true);
            }
            catch (Exception ex)
            {
                that.CallFunc(() => { MessageBox.Show(ex.Message); });
            }
        }
    }
}
