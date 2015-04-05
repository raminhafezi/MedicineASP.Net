﻿using ENetCare.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENetCare.Repository.Repository
{
    public interface IPackageRepository
    {
        int Insert(Package package);
        void Update(Package package);
        Package Get(int? packageId, string barcode);
        //Package Get(int? packageId);
        Package GetPackageWidthBarCode(string barCode); 
        List<StandardPackageType> GetAllStandardPackageTypes();
        StandardPackageType GetStandardPackageType(int packageId);
        int InsertTransit(PackageTransit packageTransit);
        void UpdateTransit(PackageTransit packageTransit);
        PackageTransit GetTransit(Package package, DistributionCentre Receiver);
        List<PackageTransit> GetActiveTransitsByPackage(Package xPackage);
        //int InsertAudit(Employee employee, StandardPackageType packageType, List<string> barCodes);
        //string getConnectionString();
    }
}
