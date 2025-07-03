using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using IOCLAndroidApp;
using IOCLAndroidApp.Models;
using SatoScanningApp;

namespace SatoScanningApp
{
    class ItemAdapter : RecyclerView.Adapter
    {
        public List<ItemView> lstItem;
        Context context;
        public ItemAdapter(List<ItemView> itemDetails, Context cont)
        {
            lstItem = itemDetails;
            context = cont;
        }
        public override int ItemCount
        {
            get { return lstItem.Count; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            try
            {
                ReceiveItemHolder vh = holder as ReceiveItemHolder;
                vh.txtAssetCode.Text = lstItem[position].Asset.ToString();
                vh.txtQty.Text = lstItem[position].Qty.ToString();
                vh.txtScanQty.Text = lstItem[position].ScanQty.ToString();
            }
            catch (System.Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            ReceiveItemHolder vh = null;
            try
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.view_Item, parent, false);
                vh = new ReceiveItemHolder(itemView);

            }
            catch (Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
            return vh;
        }
    }

    public class ReceiveItemHolder : RecyclerView.ViewHolder
    {
      
        public TextView txtAssetCode;
        public TextView txtQty;
        public TextView txtScanQty;
        public ReceiveItemHolder(View itemview) : base(itemview)
        {
            try
            {
               
                txtAssetCode = itemview.FindViewById<TextView>(Resource.Id.txtAsset);
                txtQty = itemview.FindViewById<TextView>(Resource.Id.txtQty);
                txtScanQty = itemview.FindViewById<TextView>(Resource.Id.txtScanQty);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}