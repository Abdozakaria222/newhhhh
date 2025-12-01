using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNSOptimizer
{
    public partial class MainForm : Form
    {
        private List<DnsTester> dnsList;

        public MainForm()
        {
            InitializeComponent();
            LoadDnsList();
        }

        private async void LoadDnsList(bool forceUpdate = false)
        {
            string cachePath = Path.Combine(Application.StartupPath, "dns_cache.json");
            string url = "https://raw.githubusercontent.com/Abdozakaria222/DNSList/main/dns.json";

            if (forceUpdate || !File.Exists(cachePath))
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.Timeout = TimeSpan.FromSeconds(5);
                        string json = await client.GetStringAsync(url);
                        File.WriteAllText(cachePath, json);
                    }
                }
                catch
                {
                    MessageBox.Show("تعذر تحديث قائمة DNS من الإنترنت. سيتم استخدام القائمة القديمة.", "تحذير");
                }
            }

            try
            {
                string jsonData = File.ReadAllText(cachePath);
                dnsList = JsonSerializer.Deserialize<List<DnsTester>>(jsonData);
            }
            catch
            {
                dnsList = new List<DnsTester>
                {
                    new DnsTester { Name = "Google", Address = "8.8.8.8" },
                    new DnsTester { Name = "Cloudflare", Address = "1.1.1.1" }
                };
            }

            gridResults.DataSource = dnsList.Select(x => new
            {
                x.Name,
                x.Address,
                Response = "لم يتم الفحص بعد"
            }).ToList();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            progressBar.Value = 0;
            progressBar.Maximum = dnsList.Count;

            foreach (var dns in dnsList)
            {
                await dns.TestAsync();
                progressBar.Value++;
                gridResults.DataSource = dnsList.Select(x => new
                {
                    x.Name,
                    x.Address,
                    Response = x.ResponseTime == 9999 ? "فشل الاتصال" : $"{x.ResponseTime} ms"
                }).OrderBy(x => x.Response).ToList();
                gridResults.Refresh();
            }

            btnStart.Enabled = true;
        }

        private void btnApplyBest_Click(object sender, EventArgs e)
        {
            var best = dnsList.OrderBy(x => x.ResponseTime).FirstOrDefault();
            if (best == null || best.ResponseTime == 9999)
            {
                MessageBox.Show("لا يوجد DNS سريع لتطبيقه.");
                return;
            }

            try
            {
                Process.Start("netsh", $"interface ip set dns name=\"Ethernet\" static {best.Address}");
                MessageBox.Show($"تم تطبيق DNS الأسرع: {best.Name} ({best.Address})", "تم");
            }
            catch
            {
                MessageBox.Show("يجب تشغيل البرنامج كمسؤول لتطبيق DNS.");
            }
        }

        private async void btnUpdateList_Click(object sender, EventArgs e)
        {
            btnUpdateList.Enabled = false;
            await Task.Delay(200);
            LoadDnsList(forceUpdate: true);
            MessageBox.Show("تم تحديث قائمة DNS من الإنترنت.", "تم");
            btnUpdateList.Enabled = true;
        }
    }
}
