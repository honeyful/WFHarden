using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Threading;
using NetFwTypeLib;

namespace WFH
{
    public partial class MainFrame : Form
    {
        private volatile bool _stop = false;

        public MainFrame()
        {
            InitializeComponent();
        }

        private void fwHarden()
        {
            CheckForIllegalCrossThreadCalls = false;
            btnReset.Enabled = false;
            btnHarden.Text = "Stop";

            fwReset();

            List<string> fileList = GetFilesRecursive("C:\\");
            progressBar.Maximum = fileList.Count;

            foreach (var file in fileList)
            {
                if (_stop) break;
                if (checkSignature(file))
                {
                    allowRule(file);
                    txtLog.AppendText($"[+]{file}" + Environment.NewLine);
                }
                else
                {
                    blockRule(file);
                    txtLog.AppendText($"[-]{file}" + Environment.NewLine);
                }
                progressBar.Value += 1;
            }

            fwInitRule();

            btnReset.Enabled = true;
            btnHarden.Text = "Harden";
            progressBar.Value = 0;
            MessageBox.Show("Done.");
            
        }

        private void allowRule(string fileName)
        {
            INetFwRule fwRule = (INetFwRule)Activator.CreateInstance(
                 Type.GetTypeFromProgID("HNetCfg.FWRule"));
            fwRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            fwRule.Enabled = true;
            fwRule.InterfaceTypes = "All";
            fwRule.Name = fileName;
            fwRule.ApplicationName = fileName;
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            fwRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            fwPolicy.Rules.Add(fwRule);
        }

        private void blockRule(string fileName)
        {
            INetFwRule fwRule = (INetFwRule)Activator.CreateInstance(
                Type.GetTypeFromProgID("HNetCfg.FWRule"));
            fwRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            fwRule.Enabled = true;
            fwRule.InterfaceTypes = "All";
            fwRule.Name = fileName;
            fwRule.ApplicationName = fileName;
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            fwRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            fwPolicy.Rules.Add(fwRule);
        }

        private void fwReset()
        {
            Type netFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 mgr = (INetFwPolicy2)Activator.CreateInstance(netFwPolicy2Type);
            mgr.RestoreLocalFirewallDefaults();
        }

        private void fwInitRule()
        {
            Type netFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 mgr = (INetFwPolicy2)Activator.CreateInstance(netFwPolicy2Type);

            mgr.set_BlockAllInboundTraffic(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN, chkBlockAllInbound.Checked ? true : false);
            mgr.set_DefaultInboundAction(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN, NET_FW_ACTION_.NET_FW_ACTION_BLOCK);
            mgr.set_DefaultOutboundAction(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN, !chkBlockOutbound.Checked ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK);

            mgr.set_BlockAllInboundTraffic(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE, chkBlockAllInbound.Checked ? true : false);
            mgr.set_DefaultInboundAction(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE, NET_FW_ACTION_.NET_FW_ACTION_BLOCK);
            mgr.set_DefaultOutboundAction(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE, !chkBlockOutbound.Checked ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK);

            mgr.set_BlockAllInboundTraffic(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC, chkBlockAllInbound.Checked ? true : false);
            mgr.set_DefaultInboundAction(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC, NET_FW_ACTION_.NET_FW_ACTION_BLOCK);
            mgr.set_DefaultOutboundAction(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC, !chkBlockOutbound.Checked ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK);
        }

        private bool checkSignature(string fileName)
        {
            var certChain = new X509Chain();
            var cert = default(X509Certificate2);
            bool isChainValid = false;
            try
            {
                var signer = X509Certificate.CreateFromSignedFile(fileName);
                cert = new X509Certificate2(signer);
            }
            catch
            {
                return isChainValid;
            }

            certChain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
            certChain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
            certChain.ChainPolicy.UrlRetrieval‎Timeout = new TimeSpan(0, 1, 0);
            certChain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
            isChainValid = certChain.Build(cert);

            return isChainValid;
        }


        private List<string> GetFilesRecursive(string initial)
        {
            List<string> result = new List<string>();

            Stack<string> stack = new Stack<string>();

            stack.Push(initial);

            while ((stack.Count > 0))
            {
                string dir = stack.Pop();
                try
                {
                    result.AddRange(Directory.GetFiles(dir, "*.exe"));

                    string directoryName = null;
                    foreach (string directoryName_loopVariable in Directory.GetDirectories(dir))
                    {
                        directoryName = directoryName_loopVariable;
                        stack.Push(directoryName);
                    }

                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            fwReset();
            MessageBox.Show("Reset");
        }

        private void btnHarden_Click(object sender, EventArgs e)
        {
            if(btnHarden.Text == "Harden")
            {
                _stop = false;
                new Thread(fwHarden).Start();
            }
            else
            {
                _stop = true;
            }
        }
    }
}
