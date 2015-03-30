﻿using ENetCare.BusinessService;
using ENetCare.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENetCare.Web.Report
{
    public partial class DistributionCentreLosses : System.Web.UI.Page
    {
        private decimal _grandTotalValue = 0M;
        private ReportService _reportService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IReportRepository repository = new ReportRepository(ConfigurationManager.ConnectionStrings["ENetCare"].ConnectionString);
            _reportService = new ReportService(repository);

            grd.DataSource = _reportService.GetDistributionCentreLosses();
            grd.DataBind();
        }

        protected void grd_RowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal totalValue = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalLossDiscardedValue").ToString());
               
                _grandTotalValue += totalValue;

                int numerator = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LossRatioNumerator"));
                int denominator = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LossRatioDenominator"));

                Literal litLossRatio = (Literal)e.Row.FindControl("litLossRatio");
                if (denominator == 0 || numerator == 0)
                    litLossRatio.Text = "-";
                else
                    litLossRatio.Text = ((decimal)numerator / (decimal)denominator).ToString("P4");

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Literal litGrandTotalLossDiscardedValue = (Literal)e.Row.FindControl("litGrandTotalLossDiscardedValue");
                litGrandTotalLossDiscardedValue.Text = _grandTotalValue.ToString("C2");

                e.Row.Cells[0].ColumnSpan = 3;
                e.Row.Cells[0].Text = "Grand Total";
                for (int i = 2; i >= 1; i--)
                    e.Row.Cells.RemoveAt(i);
            }
        }

        protected void btnClose_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}