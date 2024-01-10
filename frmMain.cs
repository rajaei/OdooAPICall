
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PortaCapena.OdooJsonRpcClient;
using PortaCapena.OdooJsonRpcClient.Attributes;
using PortaCapena.OdooJsonRpcClient.Converters;
using PortaCapena.OdooJsonRpcClient.Models;
using PortaCapena.OdooJsonRpcClient.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PortaCapena.OdooJsonRpcClient.Consts;
using System.Net.Http;
using Odoo.XmlRpcAdapter;

namespace OdooAPI2
{
    public partial class frmMain : Form
    {
        #region initform application
        public OdooConfig config;
        List<string> lstAPIs = new List<string>();
        public int userUid = 0;

        OdooXmlRpcAdapter odooAptConfig = new OdooXmlRpcAdapter(
                   "http://develop1.aminsahm.com:8069/xmlrpc/2/common",
                   "http://develop1.aminsahm.com:8069/xmlrpc/2/object",
                   "test21",
                   "asisster7@gmail.com",
                   "7462",
                   "",
                   bypassRemoteSslCertificateValidation: true);
        void reConfig()
        {
            config = new OdooConfig(
                        apiUrl: txtURL.Text,
                        dbName: txtDB.Text,
                        userName: txtUser.Text,
                        password: txtPass.Text
                        );
            odooAptConfig = new OdooXmlRpcAdapter(
               txtURL.Text + "/xmlrpc/2/common",
               txtURL.Text + "/xmlrpc/2/object",
               txtDB.Text,
               txtUser.Text,
               txtPass.Text,
               "",
               bypassRemoteSslCertificateValidation: true);
        }
        bool SaveFormContent()
        {
            bool result = false;
            Properties.Settings.Default.URL = txtURL.Text;
            Properties.Settings.Default.DB = txtDB.Text;
            Properties.Settings.Default.User = txtUser.Text;
            Properties.Settings.Default.Pass = txtPass.Text;
            Properties.Settings.Default.Save();
            return result;
        }
        bool LoadFormContent()
        {
            bool result = false;
            txtURL.Text = Properties.Settings.Default.URL;
            txtDB.Text = Properties.Settings.Default.DB;
            txtUser.Text = Properties.Settings.Default.User;
            txtPass.Text = Properties.Settings.Default.Pass;
            reConfig();
            return result;
        }
        Boolean frmInit()
        {
            bool result = false;
            StreamReader tr = new StreamReader("APILIST.txt");
            cmbAPIlst.Items.Clear();
            lstAPIs.Clear();
            while (!tr.EndOfStream)
            {
                string readRecord = tr.ReadLine();
                lstAPIs.Add(readRecord);
                List<string> listParams = readRecord.Split(',').ToList();
                cmbAPIlst.Items.Add(listParams[0]);
            }
            tr.Close();


            return result;
        }
        public frmMain()
        {
            InitializeComponent();
            frmInit();
        }
        #endregion
        #region public function
        object getValueFormString(string str)
        {
            object valueOutput = null;
            if (str.Contains('"') | (str.Trim().CompareTo("true") == 0 || str.Trim().CompareTo("false") == 0))
            {
                valueOutput = str.Replace('"', ' ').Trim();
            }
            else valueOutput = Int32.Parse(str);
            return valueOutput;
        }
        List<string> objectToStringList(object obj)
        {
            List<String> lstStr = new List<string>();
            lstStr.Clear();
            var lstRet = obj.GetType().GetProperties().Select(p => p.Name).ToList();
            foreach (var item in lstRet)
            {
                object myValue = obj.GetType().GetProperty(item).GetValue(obj, null);
                if (myValue != null)
                {
                    lstStr.Add(item + ":=>" + myValue.ToString());
                }
                else lstStr.Add(item + ":=> NULL");
            }
            return lstStr;
        }
        void DrawMethodFrom(int index)
        {
            if (index < 0)
                return;

            //Clear controles form input form
            pnlAPIparams.Controls.Clear();

            #region generate controls 
            List<string> lstObj = new List<string>();
            lstObj.AddRange(lstAPIs[index].ToString().Split(','));
            int i = 0;

            lstObj.RemoveAt(0); //remove title

            foreach (string s in lstObj)
            {
                switch (s.Split(':')[1])
                {
                    case "string":
                        Label lbl = new Label();
                        TextBox txt = new TextBox();
                        lbl.Name = "lbl" + lstObj[i].Split(',')[0].Split(':')[0];
                        txt.Name = "txt" + lstObj[i].Split(',')[0].Split(':')[0];
                        lbl.Text = lstObj[i].Split(',')[0].Split(':')[0];
                        txt.Text = "";


                        //txt.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                        lbl.Visible = true;
                        lbl.AutoSize = true;
                        lbl.Refresh();
                        txt.Visible = true;

                        lbl.Top = i * (lbl.Height + 5);
                        txt.Top = i * (lbl.Height + 5);
                        txt.Left = lbl.Width + 5;

                        pnlAPIparams.Controls.Add(lbl);
                        pnlAPIparams.Controls.Add(txt);
                        break;
                    case "inputFile":
                        ucGetFile myfi = new ucGetFile();
                        myfi.Name = lstObj[i].Split(',')[0].Split(':')[0];
                        myfi.Top = i * (myfi.Height + 5);
                        pnlAPIparams.Controls.Add(myfi);
                        break;
                    default:
                        break;
                }

                i++;
            }
            #endregion
        }
        #endregion
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadFormContent();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFormContent();
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            //testcAPIAsync();
            reConfig();
            Execute_API(cmbAPIlst.SelectedIndex);

        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            reConfig();
        }

        private void txtConfig_TextChanged(object sender, EventArgs e)
        {
            reConfig();
        }

        private void cmbAPIlst_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbAPIlst.SelectedIndex < 0)
                return;
            // MessageBox.Show(cmbAPIlst.SelectedIndex.ToString());
            DrawMethodFrom(cmbAPIlst.SelectedIndex);
        }

        async Task OdooCreateAsync(String ModelName, String FileAddress)
        {
            var odooClient = new OdooClient(config);
            //"res.partner"
            var model2 = new OdooDictionaryModel(ModelName);
            StreamReader sr = new StreamReader(FileAddress);
            while (!sr.EndOfStream)
            {
                string readLine = sr.ReadLine();
                string Key = readLine.Split(',')[0];
                string valueInput = readLine.Split(',')[1];
                object valueOutput = getValueFormString(valueInput);

                model2.Add(Key, valueOutput);

            }
            sr.Close();

            var createResult = await odooClient.CreateAsync(model2);
            List<string> myProperty = new List<string>();
            myProperty.AddRange(objectToStringList(createResult));
            foreach (var item in myProperty)
            {
                rtxtLog.Text += item + Environment.NewLine;
            }
        }
        async Task listRecords(string Model, string FileAddress)
        {
            var odooClient = new OdooClient(config);
            //"res.partner"

            StreamReader sr = new StreamReader(FileAddress);


            List<object> lst0 = new List<object>();
            List<object> lst1 = new List<object>();
            List<object> objConditons = new List<object>();
            while (!sr.EndOfStream)
            {
                string readLine = sr.ReadLine();
                if (readLine.Trim().Length > 3)
                {

                    string filedName = readLine.Split(',')[0];
                    string condition = readLine.Split(',')[1];
                    string checkValue = readLine.Split(',')[2];

                    object valueOutput = getValueFormString(checkValue);
                    objConditons.Add(filedName);
                    objConditons.Add(condition);
                    objConditons.Add(checkValue);
                }
            }
            sr.Close();

            lst1.Add(objConditons);
            lst0.Add(lst1);

            List<object> lstObj = new List<object>();

            lstObj.Add(config.DbName);
            lstObj.Add(config.UserName);
            lstObj.Add(config.Password);
            lstObj.Add(Model); //Model 
            lstObj.Add("search"); //function
            lstObj.Add(lst0); //parameters


            OdooRequestParams orp = new OdooRequestParams(config.ApiUrl, "xmlrpc/2/object", "execute_kw", lstObj.ToArray());
            OdooRequestModel orm = new OdooRequestModel(orp);

            OdooQuery oq = new OdooQuery();
            oq.Filters = new OdooFilter();
            oq.Filters.AddRange(objConditons);

            var loginResult = await odooClient.LoginAsync();
            userUid = loginResult.Value;

            HttpResponseMessage t1 = await PortaCapena.OdooJsonRpcClient.OdooClient.CallAsync(orm);

            var t = await PortaCapena.OdooJsonRpcClient.OdooClient.GetModelAsync(config, userUid, "res.partner");

            //<>(config, userUid, oq);
            List<string> myProperty = new List<string>();
            myProperty.AddRange(objectToStringList(t));
            foreach (var item in myProperty)
            {
                rtxtLog.Text += item + Environment.NewLine;
            }
        }
        async Task listCount(string Model, string FileAddress)
        {
            var odooClient = new OdooClient(config);
            //"res.partner"

            StreamReader sr = new StreamReader(FileAddress);


            List<object> lst0 = new List<object>();
            List<object> lst1 = new List<object>();
            List<object> objConditons = new List<object>();
            while (!sr.EndOfStream)
            {
                string readLine = sr.ReadLine();
                if (readLine.Trim().Length > 3)
                {

                    string filedName = readLine.Split(',')[0];
                    string condition = readLine.Split(',')[1];
                    string checkValue = readLine.Split(',')[2];

                    object valueOutput = getValueFormString(checkValue);
                    objConditons.Add(filedName);
                    objConditons.Add(condition);
                    objConditons.Add(checkValue);
                }
            }
            sr.Close();

            lst1.Add(objConditons);
            lst0.Add(lst1);

            List<object> lstObj = new List<object>();

            lstObj.Add(config.DbName);
            lstObj.Add(config.UserName);
            lstObj.Add(config.Password);
            lstObj.Add(Model); //Model 
            lstObj.Add("search_count"); //function
            lstObj.Add(lst0); //parameters


            OdooRequestParams orp = new OdooRequestParams(config.ApiUrl, "xmlrpc/2/object", "execute_kw", lstObj.ToArray());
            OdooRequestModel orm = new OdooRequestModel(orp);

            OdooQuery oq = new OdooQuery();
            oq.Filters = new OdooFilter();
            oq.Filters.AddRange(objConditons);

            var loginResult = await odooClient.LoginAsync();
            userUid = loginResult.Value;

            HttpResponseMessage t1 = await PortaCapena.OdooJsonRpcClient.OdooClient.CallAsync(orm);

            var t = await PortaCapena.OdooJsonRpcClient.OdooClient.GetModelAsync(config, userUid, "res.partner");

            //<>(config, userUid, oq);
            List<string> myProperty = new List<string>();
            myProperty.AddRange(objectToStringList(t));
            foreach (var item in myProperty)
            {
                rtxtLog.Text += item + Environment.NewLine;
            }
        }
        async Task odooCallMethod(string Model, string funationName, List<object> lstParamters)
        {
            var odooClient = new OdooClient(config);
            //call method
            var hash = new Dictionary<string, int>();
            try
            {
                hash.Add("raise_exception", 0);

                List<object> lstObj = new List<object>();

                lstObj.Add(config.DbName);
                lstObj.Add(config.UserName);
                lstObj.Add(config.Password);
                lstObj.Add(Model); //Model 
                lstObj.Add(funationName); //function
                lstObj.Add(lstParamters); //parameters
                lstObj.Add(hash);


                OdooRequestParams orp = new OdooRequestParams(config.ApiUrl, "xmlrpc/2/object", "execute_kw", lstObj.ToArray());
                OdooRequestModel orm = new OdooRequestModel(orp);

                var t = await PortaCapena.OdooJsonRpcClient.OdooClient.CallAsync(orm);
                List<string> myProperty = new List<string>();
                myProperty.AddRange(objectToStringList(t));
                foreach (var item in myProperty)
                {
                    rtxtLog.Text += item + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {

            }
        }
        async Task Execute_API(int Selections)
        {
            if (Selections < 0)
                return;

            List<string> myProperty = new List<string>();
            var odooClient = new OdooClient(config);

            rtxtLog.Text = "";
            switch (cmbAPIlst.Items[cmbAPIlst.SelectedIndex].ToString())
            {


                case "test-database":
                    var versionResult = await odooClient.GetVersionAsync();
                    myProperty.AddRange(objectToStringList(versionResult));
                    foreach (var item in myProperty)
                    {
                        rtxtLog.Text += item + Environment.NewLine;
                    }
                    break;
                case "logging-in":
                    var loginResult = await odooClient.LoginAsync();
                    myProperty.AddRange(objectToStringList(loginResult));
                    foreach (var item in myProperty)
                    {
                        rtxtLog.Text += item + Environment.NewLine;
                    }
                    userUid = loginResult.Id;

                    break;
                case "calling-methods":
                    string model = ((TextBox)(pnlAPIparams.Controls["txtModel"])).Text;
                    string funationName = ((TextBox)(pnlAPIparams.Controls["txtFunction"])).Text;
                    string parametersStr = ((TextBox)(pnlAPIparams.Controls["txtParameters"])).Text;

                    List<object> lstParamters = new List<object>();
                    lstParamters.AddRange(parametersStr.Split(',').ToArray<object>());
                    odooCallMethod(model, funationName, lstParamters);

                    break;
                case "list-records":
                    //string modelName = ((TextBox)(pnlAPIparams.Controls["txtModel"])).Text;
                    //string fileAddress = ((ucGetFile)(pnlAPIparams.Controls["ConditonFile"])).FileAddress;
                    //listRecords(modelName, fileAddress);
                    int[] ids1 = odooAptConfig.Search(
                  "res.partner",
                  0,
                  5,
                  new object[] { "name", "=", "masoud" }
                  );

                    break;
                case "pagination":
                    break;
                case "count-records":
                    string modelNameCountRecords = ((TextBox)(pnlAPIparams.Controls["txtModel"])).Text;
                    string fileAddressCountRecords = ((ucGetFile)(pnlAPIparams.Controls["ConditonFile"])).FileAddress;
                    listCount(modelNameCountRecords, fileAddressCountRecords);
                    break;
                case "read-records":
                    break;
                case "list-record-fields":
                    break;
                case "search-and-read":
                    break;
                case "create-records":
                    string createModelName = ((TextBox)(pnlAPIparams.Controls["txtModel"])).Text;
                    string createFileAddress = ((ucGetFile)(pnlAPIparams.Controls["KeyValueFile"])).FileAddress;
                    OdooCreateAsync(createModelName, createFileAddress);
                    break;
                case "update-records":
                    break;
                case "delete-records":
                    break;

            }
        }
    }
}
