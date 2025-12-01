using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace newhhhh
{
    public partial class MainForm : Form
    {
        private List<string> dnsList = new List<string>();
        private Dictionary<string, long> dnsSpeedResults = new Dictionary<string, long>();
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
                lblStatus.Text = "جاري تحميل قائمة DNS من الإنترنت...";
                Application.DoEvents();

                string jsonData;
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                    client.Encoding = System.Text.Encoding.UTF8;
                    jsonData = client.DownloadString(DnsListUrl);
                }

                if (!string.IsNullOrEmpty(jsonData))
                {
                    dnsList = JsonConvert.DeserializeObject<List<string>>(jsonData);
                    
                    if (dnsList != null && dnsList.Count > 0)
                    {
                        lblStatus.Text = $"تم تحميل {dnsList.Count} DNS";
                        
                        // تحديث ListBox لعرض القائمة مباشرة
                        listBoxResults.Items.Clear();
                        listBoxResults.Items.Add($"=== تم تحميل {dnsList.Count} DNS ===");
                        
                        foreach (var dns in dnsList.Take(10)) // عرض أول 10 عناصر
                        {
                            listBoxResults.Items.Add(dns);
                        }
                        
                        if (dnsList.Count > 10)
                        {
                            listBoxResults.Items.Add($"... و {dnsList.Count - 10} أكثر");
                        }
                        
                        MessageBox.Show($"تم تحميل {dnsList.Count} DNS من الإنترنت ✅", "تحديث القائمة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblStatus.Text = "القائمة فارغة - استخدام الافتراضي";
                        LoadDefaultDnsList();
                    }
                }
                else
                {
                    lblStatus.Text = "لا توجد بيانات - استخدام الافتراضي";
                    LoadDefaultDnsList();
                }
            }
            catch (WebException webEx)
            {
                lblStatus.Text = "خطأ في الاتصال - استخدام الافتراضي";
                MessageBox.Show($"خطأ في الاتصال بالإنترنت:\n{webEx.Message}\n\nجاري استخدام القائمة الافتراضية...", "خطأ اتصال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadDefaultDnsList();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "خطأ في التحميل - استخدام الافتراضي";
                MessageBox.Show($"حدث خطأ أثناء تحميل قائمة DNS:\n{ex.Message}\n\nجاري استخدام القائمة الافتراضية...", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadDefaultDnsList();
            }
        }

        // قائمة DNS افتراضية في حالة فشل التحميل
        private void LoadDefaultDnsList()
        {
            dnsList = new List<string>
            {
                "8.8.8.8",          // Google DNS
                "8.8.4.4",          // Google DNS
                "1.1.1.1",          // Cloudflare DNS
                "1.0.0.1",          // Cloudflare DNS
                "208.67.222.222",   // OpenDNS
                "208.67.220.220",   // OpenDNS
                "9.9.9.9",          // Quad9 DNS
                "149.112.112.112",  // Quad9 DNS
                "64.6.64.6",        // Verisign DNS
                "64.6.65.6"         // Verisign DNS
            };
            
            // تحديث ListBox لعرض القائمة الافتراضية
            listBoxResults.Items.Clear();
            listBoxResults.Items.Add($"=== تم تحميل {dnsList.Count} DNS افتراضية ===");
            
            foreach (var dns in dnsList)
            {
                listBoxResults.Items.Add(dns);
            }
            
            lblStatus.Text = $"تم تحميل {dnsList.Count} DNS افتراضية";
            MessageBox.Show($"تم تحميل {dnsList.Count} DNS افتراضية ✅", "القائمة الافتراضية", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // زر لاختبار DNS
        private void btnTestDns_Click(object sender, EventArgs e)
        {
            if (dnsList == null || dnsList.Count == 0)
            {
                MessageBox.Show("قائمة DNS فارغة! جاري تحميل القائمة الافتراضية...", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadDefaultDnsList();
                return;
            }

            listBoxResults.Items.Clear();
            listBoxResults.Items.Add("=== بدء اختبار سرعة DNS ===");

            int successful = 0;
            dnsSpeedResults.Clear();
            
            foreach (var dns in dnsList)
            {
                lblStatus.Text = $"جاري اختبار: {dns}";
                Application.DoEvents();
                
                long pingTime = TestDnsSpeed(dns);
                if (pingTime > 0)
                {
                    dnsSpeedResults[dns] = pingTime;
                    string status = $"✅ {pingTime} ms";
                    listBoxResults.Items.Add($"{dns} => {status}");
                    successful++;
                }
                else
                {
                    string status = "❌ غير متاح";
                    listBoxResults.Items.Add($"{dns} => {status}");
                }
                
                // إعطاء وقت للواجهة للتحديث
                System.Threading.Thread.Sleep(100);
            }

            lblStatus.Text = $"تم الانتهاء - {successful} من {dnsList.Count} ناجح";
            MessageBox.Show($"تم اختبار {dnsList.Count} DNS\n{successful} تعمل بشكل صحيح", "نتيجة الاختبار", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // اختبار سرعة DNS وإرجاع وقت الاستجابة
        private long TestDnsSpeed(string dns)
        {
            try
            {
                var ping = new System.Net.NetworkInformation.Ping();
                var reply = ping.Send(dns, 3000); // 3 ثواني Timeout
                
                if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    return reply.RoundtripTime;
                }
                return -1;
            }
            catch
            {
                return -1;
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
                if (listBoxResults.Items.Count == 0)
                {
                    MessageBox.Show("لا توجد نتائج لحفظها!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string filePath = Path.Combine(Application.StartupPath, "results.txt");
                File.WriteAllLines(filePath, GetListBoxItems());
                MessageBox.Show($"تم حفظ النتائج في:\n{filePath}", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"تعذر حفظ النتائج:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // زر لاختيار أفضل DNS
        private void btnBestDns_Click(object sender, EventArgs e)
        {
            if (dnsSpeedResults.Count == 0)
            {
                MessageBox.Show("لم يتم إجراء أي اختبارات بعد! يرجى اختبار DNS أولاً.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ترتيب الـ DNS حسب السرعة (من الأسرع إلى الأبطأ)
            var sortedDns = dnsSpeedResults
                .Where(x => x.Value > 0)
                .OrderBy(x => x.Value)
                .ToList();

            if (sortedDns.Count == 0)
            {
                MessageBox.Show("لا توجد نتائج ناجحة لاختيار أفضل DNS!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listBoxResults.Items.Clear();
            listBoxResults.Items.Add("=== أفضل DNS حسب السرعة ===");

            int rank = 1;
            foreach (var dns in sortedDns.Take(10)) // عرض أفضل 10 فقط
            {
                listBoxResults.Items.Add($"{rank}. {dns.Key} - {dns.Value} ms");
                rank++;
            }

            // عرض أفضل DNS في MessageBox
            var bestDns = sortedDns.First();
            string bestDnsInfo = $"أفضل DNS:\n{bestDns.Key}\nالسرعة: {bestDns.Value} ms\n\n";
            bestDnsInfo += $"أفضل 3 DNS:\n";
            
            for (int i = 0; i < Math.Min(3, sortedDns.Count); i++)
            {
                bestDnsInfo += $"{i + 1}. {sortedDns[i].Key} - {sortedDns[i].Value} ms\n";
            }

            MessageBox.Show(bestDnsInfo, "أفضل DNS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblStatus.Text = $"أفضل DNS: {bestDns.Key} - {bestDns.Value} ms";
        }

        private IEnumerable<string> GetListBoxItems()
        {
            foreach (var item in listBoxResults.Items)
                yield return item.ToString();
        }
    }
}
