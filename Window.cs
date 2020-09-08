// Decompiled with JetBrains decompiler
// Type: Enhance.Window
// Assembly: Enhance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC90F2AF-9765-4FB8-9E9D-C598AA50E670
// Assembly location: C:\Users\Vand\AppData\Roaming\Skype\My Skype Received Files\Enhance.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Enhance
{
  public class Window : Form, IDisposable
  {
    private IContainer components = (IContainer) null;
    private EventHandler<TriggerEventArgs> SettingsUpdated;
    private EventHandler Closed;
    private GroupBox ClientGB;
    private Button ConnectBTN;
    private Label StatusLB;
    private Label ClassLB;
    private Label NameLB;
    private GroupBox SettingsGB;
    private CheckBox ChargeCB;
    private CheckBox BuffCB;
    private CheckBox SelfCB;
    private CheckBox AttackCB;
        private LinkLabel linkLabel1;
        private Label label1;
        private TextBox DelayTB;

    public Window()
    {
      this.InitializeComponent();
    }

        private void ConnectBTN_Click(object sender, EventArgs e)
        {
            Manager manager = (Manager)null;
            try
            {
                for (int index = 0; index < Process.GetProcessesByName("elementclient").Length; ++index)
                {
                    manager = new Manager(index);
                    if (manager.Connected)
                    {
                        this.SetupManager(manager);
                        manager.Connect();
                        this.ConnectBTN.Visible = false;
                        this.NameLB.Visible = true;
                        break;
                    }
                }
            }
            catch
            {
               int num = (int)MessageBox.Show("Failed to attach. Open client, Login and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); 
            }            
        }

    private void SetupManager(Manager manager)
    {
      manager.OnConnect += new EventHandler<ClientEventArgs>(this.OnConnect);
      this.SettingsUpdated += manager.OnSettingsChanged;
      this.Closed += new EventHandler(manager.OnClose);
    }

    private void OnConnect(object sender, ClientEventArgs e)
    {
      this.NameLB.Text = e.Name;
      this.ClassLB.Text = e.Class;
      this.StatusLB.Text = "Connected";
      this.StatusLB.ForeColor = Color.Chartreuse;
    }

    private void OnChangeStatus(object sender, EventArgs e)
    {
      if (this.StatusLB.ForeColor == Color.Red)
      {
        this.StatusLB.Text = "Connected";
        this.StatusLB.ForeColor = Color.Chartreuse;
      }
      else
      {
        this.StatusLB.Text = "Disconnected.";
        this.StatusLB.ForeColor = Color.Red;
      }
    }

    private void AttackCB_CheckedChanged(object sender, EventArgs e)
    {
      this.SettingsUpdated(sender, new TriggerEventArgs(16 | (((CheckBox) sender).Checked ? 1 : 0)));
    }

    private void SelfCB_CheckedChanged(object sender, EventArgs e)
    {
      this.SettingsUpdated(sender, new TriggerEventArgs(32 | (((CheckBox) sender).Checked ? 1 : 0)));
    }

    private void BuffCB_CheckedChanged(object sender, EventArgs e)
    {
      this.SettingsUpdated(sender, new TriggerEventArgs(48 | (((CheckBox) sender).Checked ? 1 : 0)));
    }

    private void ChargeCB_CheckedChanged(object sender, EventArgs e)
    {
      this.SettingsUpdated(sender, new TriggerEventArgs(64 | (((CheckBox) sender).Checked ? 1 : 0)));
    }

    public new void Dispose()
    {
      if (this.Closed == null)
        return;
      this.Closed((object) this, new EventArgs());
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.ClientGB = new System.Windows.Forms.GroupBox();
            this.ConnectBTN = new System.Windows.Forms.Button();
            this.StatusLB = new System.Windows.Forms.Label();
            this.ClassLB = new System.Windows.Forms.Label();
            this.NameLB = new System.Windows.Forms.Label();
            this.SettingsGB = new System.Windows.Forms.GroupBox();
            this.ChargeCB = new System.Windows.Forms.CheckBox();
            this.BuffCB = new System.Windows.Forms.CheckBox();
            this.SelfCB = new System.Windows.Forms.CheckBox();
            this.AttackCB = new System.Windows.Forms.CheckBox();
            this.DelayTB = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.ClientGB.SuspendLayout();
            this.SettingsGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientGB
            // 
            this.ClientGB.BackColor = System.Drawing.Color.Transparent;
            this.ClientGB.Controls.Add(this.ConnectBTN);
            this.ClientGB.Controls.Add(this.StatusLB);
            this.ClientGB.Controls.Add(this.ClassLB);
            this.ClientGB.Controls.Add(this.NameLB);
            this.ClientGB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientGB.Location = new System.Drawing.Point(12, 12);
            this.ClientGB.Name = "ClientGB";
            this.ClientGB.Size = new System.Drawing.Size(431, 76);
            this.ClientGB.TabIndex = 0;
            this.ClientGB.TabStop = false;
            this.ClientGB.Text = "Client";
            // 
            // ConnectBTN
            // 
            this.ConnectBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ConnectBTN.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ConnectBTN.Location = new System.Drawing.Point(26, 22);
            this.ConnectBTN.Name = "ConnectBTN";
            this.ConnectBTN.Size = new System.Drawing.Size(384, 35);
            this.ConnectBTN.TabIndex = 3;
            this.ConnectBTN.Text = "CONNECT";
            this.ConnectBTN.UseVisualStyleBackColor = true;
            this.ConnectBTN.Click += new System.EventHandler(this.ConnectBTN_Click);
            // 
            // StatusLB
            // 
            this.StatusLB.AutoSize = true;
            this.StatusLB.Location = new System.Drawing.Point(7, 50);
            this.StatusLB.Name = "StatusLB";
            this.StatusLB.Size = new System.Drawing.Size(0, 13);
            this.StatusLB.TabIndex = 2;
            this.StatusLB.Visible = false;
            // 
            // ClassLB
            // 
            this.ClassLB.AutoSize = true;
            this.ClassLB.Location = new System.Drawing.Point(7, 34);
            this.ClassLB.Name = "ClassLB";
            this.ClassLB.Size = new System.Drawing.Size(0, 13);
            this.ClassLB.TabIndex = 1;
            this.ClassLB.Visible = false;
            // 
            // NameLB
            // 
            this.NameLB.AutoSize = true;
            this.NameLB.Location = new System.Drawing.Point(6, 18);
            this.NameLB.Name = "NameLB";
            this.NameLB.Size = new System.Drawing.Size(0, 13);
            this.NameLB.TabIndex = 0;
            this.NameLB.Visible = false;
            // 
            // SettingsGB
            // 
            this.SettingsGB.BackColor = System.Drawing.Color.Transparent;
            this.SettingsGB.Controls.Add(this.ChargeCB);
            this.SettingsGB.Controls.Add(this.BuffCB);
            this.SettingsGB.Controls.Add(this.SelfCB);
            this.SettingsGB.Controls.Add(this.AttackCB);
            this.SettingsGB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SettingsGB.Location = new System.Drawing.Point(12, 94);
            this.SettingsGB.Name = "SettingsGB";
            this.SettingsGB.Size = new System.Drawing.Size(431, 54);
            this.SettingsGB.TabIndex = 1;
            this.SettingsGB.TabStop = false;
            this.SettingsGB.Text = "Settings";
            // 
            // ChargeCB
            // 
            this.ChargeCB.AutoSize = true;
            this.ChargeCB.Checked = true;
            this.ChargeCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChargeCB.Location = new System.Drawing.Point(259, 21);
            this.ChargeCB.Name = "ChargeCB";
            this.ChargeCB.Size = new System.Drawing.Size(151, 17);
            this.ChargeCB.TabIndex = 3;
            this.ChargeCB.Text = "Auto-complete charging";
            this.ChargeCB.UseVisualStyleBackColor = true;
            this.ChargeCB.CheckedChanged += new System.EventHandler(this.ChargeCB_CheckedChanged);
            // 
            // BuffCB
            // 
            this.BuffCB.AutoSize = true;
            this.BuffCB.Checked = true;
            this.BuffCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BuffCB.Location = new System.Drawing.Point(177, 21);
            this.BuffCB.Name = "BuffCB";
            this.BuffCB.Size = new System.Drawing.Size(76, 17);
            this.BuffCB.TabIndex = 2;
            this.BuffCB.Text = "Buff skills";
            this.BuffCB.UseVisualStyleBackColor = true;
            this.BuffCB.CheckedChanged += new System.EventHandler(this.BuffCB_CheckedChanged);
            // 
            // SelfCB
            // 
            this.SelfCB.AutoSize = true;
            this.SelfCB.Checked = true;
            this.SelfCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelfCB.Location = new System.Drawing.Point(98, 21);
            this.SelfCB.Name = "SelfCB";
            this.SelfCB.Size = new System.Drawing.Size(73, 17);
            this.SelfCB.TabIndex = 1;
            this.SelfCB.Text = "Self skills";
            this.SelfCB.UseVisualStyleBackColor = true;
            this.SelfCB.CheckedChanged += new System.EventHandler(this.SelfCB_CheckedChanged);
            // 
            // AttackCB
            // 
            this.AttackCB.AutoSize = true;
            this.AttackCB.Checked = true;
            this.AttackCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AttackCB.Location = new System.Drawing.Point(6, 21);
            this.AttackCB.Name = "AttackCB";
            this.AttackCB.Size = new System.Drawing.Size(86, 17);
            this.AttackCB.TabIndex = 0;
            this.AttackCB.Text = "Attack skills";
            this.AttackCB.UseVisualStyleBackColor = true;
            this.AttackCB.CheckedChanged += new System.EventHandler(this.AttackCB_CheckedChanged);
            // 
            // DelayTB
            // 
            this.DelayTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DelayTB.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DelayTB.Location = new System.Drawing.Point(120, 206);
            this.DelayTB.Name = "DelayTB";
            this.DelayTB.Size = new System.Drawing.Size(44, 23);
            this.DelayTB.TabIndex = 3;
            this.DelayTB.Text = "N/A";
            this.DelayTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DelayTB.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(336, 151);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(107, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.nexuspw.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Credits : Tyrants";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(455, 171);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.DelayTB);
            this.Controls.Add(this.SettingsGB);
            this.Controls.Add(this.ClientGB);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Window";
            this.Text = "Skill Delay Dispatcher";
            this.ClientGB.ResumeLayout(false);
            this.ClientGB.PerformLayout();
            this.SettingsGB.ResumeLayout(false);
            this.SettingsGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.nexuspw.com/");
        }

    }
}
