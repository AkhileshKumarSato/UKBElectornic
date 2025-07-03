using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Rscja.Deviceapi;
using IOCLAndroidApp;
using IOCLAndroidApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoScanningApp
{
    [Activity(Label = "Sato ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class DirectDispatchActivity : AppCompatActivity
    {
        public RFIDWithUHF uhfAPI;
        List<ItemView> _ListItem = new List<ItemView>();
        string mode = "";
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        Spinner cmbDocNo;
        EditText editAssetBarcode;

        TextView txtTotalQty, txtMsg, txtScanQty, txtToPlant;
        int _TotalQty = 0, _ScanQty = 0;
        RecyclerView recyclerViewItem;
        ItemAdapter itemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        Button btnSave, btnReset, btnBack, btnStart, btnClear;
        List<string> _lst = new List<string>();

        public DirectDispatchActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
                oNetwork = new clsNetwork();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }

        #region Activity Events
        protected override void OnCreate(Bundle savedInstanceState)
        {

            try
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_directDispatch);
                if (uhfAPI == null)
                {
                    try
                    {
                        uhfAPI = RFIDWithUHF.Instance;
                        uhfAPI.StopInventory();
                    }
                    catch
                    {

                    }
                }

                cmbDocNo = FindViewById<Spinner>(Resource.Id.spinnerDocNo);
                cmbDocNo.ItemSelected += CmbDocNo_ItemSelected;


                ImageView imgBack = FindViewById<ImageView>(Resource.Id.imgBack);
                imgBack.Click += (e, a) =>
                {
                    this.Finish();
                };
                TextView txtHeader = FindViewById<TextView>(Resource.Id.txtHeader);


                txtHeader.Text = "DISPATCH";

                txtMsg = FindViewById<TextView>(Resource.Id.txtMsg);
                txtMsg.Text = "";

                txtToPlant = FindViewById<TextView>(Resource.Id.txtPlant);

                txtTotalQty = FindViewById<TextView>(Resource.Id.txtTotalQty);
                txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();
                txtScanQty = FindViewById<TextView>(Resource.Id.txtScanQty);
                txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();





                editAssetBarcode = FindViewById<EditText>(Resource.Id.editBarcode);
                editAssetBarcode.KeyPress += editBinBarcode_KeyPress;

                btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

                btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += BtnBack_Click;


                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += BtnReset_Click;



                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                // txtMsg.Text = "Click start button to start scanning";
                cmbDocNo.RequestFocus();
                btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    StopInventory();
                    
                    this.Finish();
                };
                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewPickingItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);

                BindRecycleView();

                GetDocNumber();

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
          
            
        }
        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnDestroy()
        {

            base.OnDestroy();
            uhfAPI.Free();
        }


        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                ShowConfirmBox("Are you sure you want to Complete?", this, SaveData);

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }


        }

        #endregion

        #region Button Events



        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                txtToPlant.Text = "XXXX";
                if (cmbDocNo.SelectedItemPosition > 0)
                {
                    cmbDocNo.SetSelection(0);
                }
                editAssetBarcode.Text = "";
                txtTotalQty.Text = "Total Qty : 0";
                txtScanQty.Text = "Scan Qty : 0";
                _TotalQty = 0;
                _ScanQty = 0;
                editAssetBarcode.Enabled = false;
                _ListItem.Clear();
                itemAdapter.NotifyDataSetChanged();
                cmbDocNo.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region EditText Events

        private void editBinBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {

                        Save();

                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox("Error : " + ex.Message, this);
            }
        }
        public override void OnBackPressed()
        {
        }

        #endregion

        #region Methods
        public void GetDocNumber()
        {
            try
            {
                string _MESSAGE = "IN_AND_OUT~BIND_DOC~" + clsGlobal.mPlant + "~" + "~" + "~" + "~" + "~" + "~" + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _lst.Clear();
                        _lst.Add("--Select--");
                        string[] sArr = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            _lst.Add(sArr[i]);
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _lst);
                        cmbDocNo.Adapter = arrayAdapter;
                        cmbDocNo.SetSelection(0);

                        break;
                    case "INVALID":
                        editAssetBarcode.Text = "";
                        StartPlayingSound();
                        ShowMessageBox("No Doc found", this);
                        break;

                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        break;
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }
        public void GetToPlant()
        {
            try
            {
                string _MESSAGE = "IN_AND_OUT~BIND_TO_PLANT~" + clsGlobal.mPlant + "~" + "~" + cmbDocNo.SelectedItem.ToString() + "~" + "~" + "~" + "~" + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                switch (_RESPONSE[0])
                {
                    case "VALID":

                        string[] sArr = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            txtToPlant.Text = sArr[i].ToString();
                        }


                        break;
                    case "INVALID":
                        editAssetBarcode.Text = "";
                        StartPlayingSound();
                        ShowMessageBox("No Doc found", this);
                        break;

                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        break;
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        private void BindRecycleView()
        {
            try
            {
                itemAdapter = new ItemAdapter(_ListItem, this);
                recyclerViewItem.SetAdapter(itemAdapter);

            }
            catch (Exception ex) { throw ex; }
        }

        private void CmbDocNo_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (cmbDocNo.SelectedItemPosition > 0)
                {
                    GetDocDetails(cmbDocNo.SelectedItem.ToString());
                    editAssetBarcode.Text = string.Empty;
                    editAssetBarcode.Enabled = true;
                    editAssetBarcode.RequestFocus();
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        public void ShowConfirmBox(string msg, Activity activity, EventHandler<DialogClickEventArgs> handler)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", handler);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }
        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        void handleOkMessage(object sender, DialogClickEventArgs e)
        {
            try
            {
                vibrator.Cancel();
                StopPlayingSound();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void GetDocDetails(string sRequestNo)
        {
            try
            {
                string sRequest = string.Empty;
                sRequest = oNetwork.fnSendReceiveData("IN_AND_OUT~BIND_VIEW~" + clsGlobal.mPlant + "~" + "~" + sRequestNo + "~" + "~" + "~" + "~" + "~" + "}");
                string[] sResponse = sRequest.Split('~');
                switch (sResponse[0])
                {
                    case "VALID":
                        if (sResponse[1] != "")
                        {
                            BindListviewDtl(sResponse[1].ToString());
                            GetToPlant();
                        }
                        itemAdapter.NotifyDataSetChanged();
                        txtTotalQty.Text = "Total Qty :" + _TotalQty;
                        txtScanQty.Text = "Scan Qty : " + _ScanQty;
                        editAssetBarcode.RequestFocus();
                        editAssetBarcode.Text = string.Empty;
                        editAssetBarcode.Enabled = true;
                        break;
                    case "INVALID":
                        StartPlayingSound();
                        ShowMessageBox("No Pending Picklist Items Found!", this);
                        cmbDocNo.RequestFocus();
                        break;
                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(sResponse[1], this);
                        cmbDocNo.RequestFocus();
                        break;
                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Server is unavailable", this);
                        cmbDocNo.RequestFocus();
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        private void BindListviewDtl(string strReqNo)
        {
            _ScanQty = 0;
            _TotalQty = 0;
            _ListItem.Clear();
            string[] arrRow = strReqNo.Split('#');
            foreach (string strRow in arrRow)
            {
                string[] arrCell = strRow.Split('$');
                ItemView pickingItem = new ItemView();
                pickingItem.Asset = arrCell[0];
                pickingItem.Qty = Convert.ToInt32(Convert.ToDecimal(arrCell[1]));
                pickingItem.ScanQty = Convert.ToInt32(Convert.ToDecimal(arrCell[2]));

                _ListItem.Add(pickingItem);
                _TotalQty += Convert.ToInt32(Convert.ToDecimal(arrCell[1]));
                _ScanQty += Convert.ToInt32(Convert.ToDecimal(arrCell[2]));
            }
        }
        async Task<string> ScanDispatchDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                txtMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => ScanDispatchDataToServer());

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        if (!_RESPONSE[1].Equals("Y"))
                        {
                            StartPlayingSound();
                            ShowMessageBox(_RESPONSE[1], this);
                            editAssetBarcode.Text = "";
                            editAssetBarcode.Enabled = true;
                            editAssetBarcode.RequestFocus();
                        }
                        else
                        {
                            GetDocDetails(cmbDocNo.SelectedItem.ToString());
                            if (_TotalQty == _ScanQty)
                            {
                                editAssetBarcode.Enabled = true;
                                editAssetBarcode.Text = "";
                                editAssetBarcode.RequestFocus();
                                ShowMessageBox("Doc Successfully Completed", this); ;
                                BtnReset_Click(null, null);

                            }
                            else
                            {
                                editAssetBarcode.Enabled = true;
                                editAssetBarcode.Text = "";
                                editAssetBarcode.RequestFocus();
                                txtMsg.Text = "Tag Successfully Scanned";
                            }
                        }
                        break;

                    case "INVALID":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        break;
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                progressDialog.Hide();
            }
            finally
            {
                progressDialog.Hide();
            }
            return "";
        }
        async Task<string> CompleteDispatchDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                txtMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => CompleteDispatchDataToServer());

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        if (!_RESPONSE[1].Equals("Y"))
                        {
                            StartPlayingSound();
                            ShowMessageBox(_RESPONSE[1], this);
                            editAssetBarcode.Text = "";
                            editAssetBarcode.Enabled = true;
                            editAssetBarcode.RequestFocus();
                        }
                        else
                        {

                            editAssetBarcode.Enabled = true;
                            editAssetBarcode.Text = "";
                            editAssetBarcode.RequestFocus();
                            ShowMessageBox("Doc Successfully Completed", this); ;
                            BtnReset_Click(null, null);
                        }
                        break;

                    case "INVALID":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        break;
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                progressDialog.Hide();
            }
            finally
            {
                progressDialog.Hide();
            }
            return "";
        }



        private string[] CompleteDispatchDataToServer()
        {
            try
            {
                string _MESSAGE = "IN_AND_OUT~COMPLETE~" + clsGlobal.mPlant + "~" + txtToPlant.Text.Trim() + "~" + cmbDocNo.SelectedItem.ToString().Trim() + "~" + editAssetBarcode.Text.Trim() + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string[] ScanDispatchDataToServer()
        {
            try
            {
                string _MESSAGE = "IN_AND_OUT~SAVE~" + clsGlobal.mPlant + "~" + txtToPlant.Text + "~" + cmbDocNo.SelectedItem.ToString().Trim() + "~" + editAssetBarcode.Text.Trim() + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string[] GetScanCountToServer()
        {
            try
            {
                string _MESSAGE = "GET_SCAN_COUNT~" + clsGlobal.ProcessType + "~" + cmbDocNo.SelectedItem.ToString().Trim() + "~" + "~" + "~" + "~" + "~" + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Save()
        {
            mode = "";

            txtMsg.Text = "";
            if (cmbDocNo.SelectedItemPosition < 0)
            {
                txtMsg.Text = "Select Document No.";
                cmbDocNo.RequestFocus();
                return;
            }

            ScanDispatchDataAsync();
        }
        private void SaveData(object sender, DialogClickEventArgs e)
        {
            CompleteDispatchDataAsync();
        }
        //End


        public void ShowMessageBox(string msg, Activity activity)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Ok", handleOkMessage);
            builder.Show();
        }


        private void StartPlayingSound()
        {
            try
            {
                //Start Vibration
                long[] pattern = { 0, 200, 0 }; //0 to start now, 200 to vibrate 200 ms, 0 to sleep for 0 ms.
                vibrator.Vibrate(pattern, 0);//

                StopPlayingSound();
                mediaPlayerSound = MediaPlayer.Create(this, Resource.Raw.Beep);
                mediaPlayerSound.Start();
            }
            catch (Exception ex) { throw ex; }
        }
        private void StopPlayingSound()
        {
            try
            {
                if (mediaPlayerSound != null)
                {
                    mediaPlayerSound.Stop();
                    mediaPlayerSound.Release();
                    mediaPlayerSound = null;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Clear()
        {
            try
            {
                editAssetBarcode.Text = string.Empty;
                editAssetBarcode.Enabled = true;
                editAssetBarcode.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        public void scan()
        {
            

            string strUII = this.uhfAPI.InventorySingleTag();
            if (!string.IsNullOrEmpty(strUII))
            {
                String strEPC = this.uhfAPI.ConvertUiiToEPC(strUII);
                //AddEPCToList(strEPC, "N/A");
            }
            else
            {
                Toast.MakeText(this, "failuer", ToastLength.Short);
            }


        }
        private void StopInventory()
        {
            
                uhfAPI.StopInventory();
               

            }
        }
        #endregion
       
    }
