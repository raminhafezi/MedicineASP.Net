﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENetCare.BusinessService
{
    public class PackageResult
    {
        public const string BarCodeNotFound = "Bar Code not found";
        public const string PackageElsewhere = "That Package is NOT located in this distribution centre";
        public const string PackageAlreadyDistributed = "That Package has been distributed";
        public const string PackageInTransit = "That Package is in Transit";
        public const string PackageAlreadyDiscarded = "That Package has been Discarded";
        public const string PackageNotExpired = "That package cannot be discarded until it has expired on ";
        public const string EmployeeNotAuthorized = "You are not authorized to distribute packages";
        public const string EmployeeInDifferentLocation = "That Package is NOT located in this distribution centre";
        public const string ExpirationDateCannotBeEarlierThanToday = "The expiration date cannot be earlier than today";
        public const string ReceiveDateCannotBeEarlierThanSend = "The receive date cannot be earlier than the send date";
    }
}
