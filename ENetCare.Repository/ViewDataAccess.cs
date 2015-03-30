﻿using ENetCare.Repository.ViewData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENetCare.Repository
{
    public class ViewDataAccess
    {
        public static List<DistributionCentreStock> GetDistributionCentreStock(SqlConnection connection)
        {                                                   
            var stockList = new List<DistributionCentreStock>();
            string query = "select PackageTypeId, PackageTypeDescription, CostPerPackage, DistributionCentreId, DistributionCenterName, NumberOfPackages, TotalValue from DistributionCentreStock order by DistributionCentreId, PackageTypeId";
            var cmd = new SqlCommand(query);
            cmd.Connection = connection;
            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default))
            {
                while (reader.Read())
                {
                    var stock = new DistributionCentreStock();
                    if (reader["PackageTypeId"] != DBNull.Value)
                        stock.PackageTypeId = Convert.ToInt32(reader["PackageTypeId"]);
                    if (reader["PackageTypeDescription"] != DBNull.Value)
                        stock.PackageTypeDescription = (string)reader["PackageTypeDescription"];
                    if (reader["CostPerPackage"] != DBNull.Value)
                        stock.CostPerPackage = Convert.ToDecimal(reader["CostPerPackage"]);
                    if (reader["DistributionCentreId"] != DBNull.Value)
                        stock.DistributionCentreId = Convert.ToInt32(reader["DistributionCentreId"]);
                    if (reader["DistributionCenterName"] != DBNull.Value)
                        stock.DistributionCentreName = (string)reader["DistributionCenterName"];
                    if (reader["NumberOfPackages"] != DBNull.Value)
                        stock.NumberOfPackages = Convert.ToInt32(reader["NumberOfPackages"]);
                    if (reader["TotalValue"] != DBNull.Value)
                        stock.TotalValue = Convert.ToDecimal(reader["TotalValue"]);
                    stockList.Add(stock);

                }
            }
            return stockList;
        }

        public static List<DistributionCentreLosses> GetDistributionCentreLosses(SqlConnection connection)
        {
            string query = "select DistributionCentreId, DistributionCenterName, LossRatioNumerator, LossRatioDenominator, TotalLossDiscardedValue " +
                           "from DistributionCentreLosses " +
                            "order by DistributionCentreId";
            List<DistributionCentreLosses> centreList = new List<DistributionCentreLosses>();

            var cmd = new SqlCommand(query);
            cmd.Connection = connection;
            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default))
            {
                while (reader.Read())
                {
                    var centre = new DistributionCentreLosses();
                    if (reader["DistributionCentreId"] != DBNull.Value)
                        centre.DistributionCentreId = Convert.ToInt32(reader["DistributionCentreId"]);
                    if (reader["DistributionCenterName"] != DBNull.Value)
                        centre.DistributionCentreName = (string)reader["DistributionCenterName"];
                    if (reader["LossRatioNumerator"] != DBNull.Value)
                        centre.LossRatioNumerator = Convert.ToInt32(reader["LossRatioNumerator"]);
                    if (reader["LossRatioDenominator"] != DBNull.Value)
                        centre.LossRatioDenominator = Convert.ToInt32(reader["LossRatioDenominator"]);
                    if (reader["TotalLossDiscardedValue"] != DBNull.Value)
                        centre.TotalLossDiscardedValue = Convert.ToDecimal(reader["TotalLossDiscardedValue"]);

                    centreList.Add(centre);
                }
            }
            return centreList;
        }

        public static List<DoctorActivity> GetDoctorActivity(SqlConnection connection)
        {
            string query = "select DoctorId, DoctorName, PackageTypeId, PackageTypeDescription, PackageCount, TotalPackageValue " +
                            "from DoctorActivity " +
                            "order by DoctorId";
            List<DoctorActivity> doctors = new List<DoctorActivity>();
            var cmd = new SqlCommand(query);
            cmd.Connection = connection;
            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default))
            {
                while (reader.Read())
                {
                    var doctor = new DoctorActivity();
                    if (reader["DoctorId"] != DBNull.Value)
                        doctor.DoctorId = Convert.ToInt32(reader["DoctorId"]);
                    if (reader["DoctorName"] != DBNull.Value)
                        doctor.DoctorName = (string)reader["DoctorName"];
                    if (reader["PackageTypeId"] != DBNull.Value)
                        doctor.PackageTypeId = Convert.ToInt32(reader["PackageTypeId"]);
                    if (reader["PackageTypeDescription"] != DBNull.Value)
                        doctor.PackageTypeDescription = (string)reader["PackageTypeDescription"];
                    if (reader["PackageCount"] != DBNull.Value)
                        doctor.PackageCount = Convert.ToInt32(reader["PackageCount"]);
                    if (reader["TotalPackageValue"] != DBNull.Value)
                        doctor.TotalPackageValue = Convert.ToDecimal(reader["TotalPackageValue"]);
                    doctors.Add(doctor);
                }
            }
            return doctors;
        }

        public static List<GlobalStock> GetGlobalStock(SqlConnection connection)
        {
            string query = "select PackageTypeId, PackageTypeDescription, CostPerPackage, NumberOfPackages, TotalValue " +
                            "from GlobalStock " +
                            "order by PackageTypeId";
            List<GlobalStock> stocks = new List<GlobalStock>();
            var cmd = new SqlCommand(query);
            cmd.Connection = connection;
            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default))
            {
                while (reader.Read())
                {
                    var stock = new GlobalStock();
                    if (reader["PackageTypeId"] != DBNull.Value)
                        stock.PackageTypeId = Convert.ToInt32(reader["PackageTypeId"]);
                    if (reader["PackageTypeDescription"] != DBNull.Value)
                        stock.PackageTypeDescription = (string)reader["PackageTypeDescription"];
                    if (reader["CostPerPackage"] != DBNull.Value)
                        stock.CostPerPackage = Convert.ToDecimal(reader["CostPerPackage"]);
                    if (reader["NumberOfPackages"] != DBNull.Value)
                        stock.NumberOfPackages = Convert.ToInt32(reader["NumberOfPackages"]);
                    if (reader["TotalValue"] != DBNull.Value)
                        stock.TotalValue = Convert.ToDecimal(reader["TotalValue"]);
                    stocks.Add(stock);
                }
            }

            return stocks;
        }

        public static List<ValueInTransit> GetValueInTransit(SqlConnection connection)
        {
            string query = "select SenderDistributionCentreId, SenderDistributionCentreName, ReceiverDistributionCentreId, RecieverDistributionCentreName, TotalPackages, TotalValue " +
                            "from ValueInTransit " +
                            "order by SenderDistributionCentreId, ReceiverDistributionCentreId ";
            List<ValueInTransit> valueList = new List<ValueInTransit>();

            var cmd = new SqlCommand(query);
            cmd.Connection = connection;
            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default))
            {
                while (reader.Read())
                {
                    var valueItem = new ValueInTransit();
                    if (reader["SenderDistributionCentreId"] != DBNull.Value)
                        valueItem.SenderDistributionCentreId = Convert.ToInt32(reader["SenderDistributionCentreId"]);
                    if (reader["SenderDistributionCentreName"] != DBNull.Value)
                        valueItem.SenderDistributionCentreName = (string)reader["SenderDistributionCentreName"];
                    if (reader["ReceiverDistributionCentreId"] != DBNull.Value)
                        valueItem.ReceiverDistributionCentreId = Convert.ToInt32(reader["ReceiverDistributionCentreId"]);
                    if (reader["RecieverDistributionCentreName"] != DBNull.Value)
                        valueItem.ReceiverDistributionCentreName = (string)reader["RecieverDistributionCentreName"];
                    if (reader["TotalPackages"] != DBNull.Value)
                        valueItem.TotalPackages = Convert.ToInt32(reader["TotalPackages"]);
                    if (reader["TotalValue"] != DBNull.Value)
                        valueItem.TotalValue = Convert.ToDecimal(reader["TotalValue"]);
                    valueList.Add(valueItem);
                }
            }

            return valueList;

        }
    }
}