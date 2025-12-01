using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace newhhhh
{
    public partial class MainForm : Form
    {
        private List<string> dnsList = new List<string>();
        private const string DnsListUrl = "https://raw.githubusercontent.com/Abdozakaria222/newhhhh/main/DNSList/dnslist.json";

        public MainForm()
        {
            InitializeComponent();
            LoadDnsList();
        }

        // تحميل قائمة DNS من الإنترنت أو من ملف محلي
        private void LoadDnsList()
        {
            try
            {
                string jsonData;

                // تحميل من الإنترنت (تحديث تلقائي)
                using (WebClient client = new WebClient())
                {
                    jsonData = client.DownloadString(DnsListUrl);
                }

                dnsList = JsonConvert.DeserializeObject<List<string>>(jsonData);
                MessageBox.Show($"تم تحميل {dnsList.Count} DNS من الإنترنت ✅", "تحديث القائمة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل قائمة DNS:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // زر لاختبار DNS
        private void btnTestDns_Click(object sender, EventArgs e)
        {
            if (dnsList.Count == 0)
            {
                MessageBox.Show("قائمة DNS فارغة!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var dns in dnsList)
            {
                bool result = TestDnsSpeed(dns);
                listBoxResults.Items.Add($"{dns} => {(result ? "✅ سريع" : "❌ بطيء")}");
                Application.DoEvents();
            }
        }

        // اختبار سرعة DNS بسيط عن طريق ping
        private bool TestDnsSpeed(string dns)
        {
            try
            {
                var ping = new System.Net.NetworkInformation.Ping();
                var reply = ping.Send(dns, 1000); // 1 ثانية Timeout
                return reply.Status == System.Net.NetworkInformation.IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }

        // زر لتحديث القائمة يدويًا
        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            LoadDnsList();
        }

        // حفظ النتائج إلى ملف
        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, "results.txt");
                File.WriteAllLines(filePath, GetListBoxItems());
                MessageBox.Show($"تم حفظ النتائج في:\n{filePath}", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"تعذر حفظ النتائج:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IEnumerable<string> GetListBoxItems()
        {
            foreach (var item in listBoxResults.Items)
                yield return item.ToString();
        }
    }
}
